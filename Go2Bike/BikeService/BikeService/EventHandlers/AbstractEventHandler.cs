using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BikeService.Objects;

namespace BikeService.EventHandlers
{
    public delegate void ObradiEventHandler(AbstractEventHandler dogadaj);

    public abstract class AbstractEventHandler
    {
        private readonly ObradiEventHandler _handler;
        private readonly AbstractEventHandler _successor;
        private readonly int _numMsg;
        private readonly byte _firstByte;
        private readonly List<TPCANMsg> _list = new List<TPCANMsg>();
        private readonly Timer _timer;
        
        protected AbstractEventHandler(CanReciveCommands canReciveCommands, int numMsg, byte firstByte, ObradiEventHandler handler, AbstractEventHandler successor = null)
        {
            CanReciveCommands = canReciveCommands;
            _handler = handler;
            _successor = successor;
            _numMsg = numMsg;
            _firstByte = firstByte;

            if (_timer == null)
                _timer = new Timer(delegate
                {
                    _list.Clear();
                });
        }

        public List<TPCANMsg> List
        {
            get { return _list; }
            set {  }
        }

        public CanReciveCommands CanReciveCommands;
        internal byte[][] Messages => _list.Select(x=>x.DATA).ToArray();

        internal void NewMessage(TPCANMsg msg)
        {
            if (msg.DATA[0].Equals(_firstByte))
            {
                msg.ID = Utils.RemoveFirstBit(msg.ID);
                _list.Add(msg);

                if (_list.Count != _numMsg)
                    _timer.Change(Properties.Settings.Default.CleanMessagesTime, Timeout.Infinite);
                else
                {
                    _timer.Change(Timeout.Infinite, Timeout.Infinite);

                    _handler(this);
                    Handle();
                }
            }
            else
                _successor?.NewMessage(msg);
        }

        internal abstract void Handle();       
    }
}
