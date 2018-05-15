using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
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

        internal EventType EventType;

        protected AbstractEventHandler(EventType eventType, int numMsg, byte firstByte, ObradiEventHandler handler, AbstractEventHandler successor = null)
        {
            EventType = eventType;
            _handler = handler;
            _successor = successor;
            _numMsg = numMsg;
            _firstByte = firstByte;
        }

        internal TPCANMsg[] Message
        {
            get { return _list.ToArray(); }
        }

        internal void NewMessage(TPCANMsg msg)
        {
            if (msg.DATA[0].Equals(_firstByte))
            {
                _list.Add(msg);
                if (_list.Count == _numMsg)
                {
                    _handler(this);
                    Handle();
                }
            }
            else if (_successor != null)
                _successor.NewMessage(msg);
        }

        internal abstract void Handle();       
    }
}
