using System.Collections.Generic;
using BikeService.Objects;

namespace BikeService.EventHandlers
{
    public delegate void ObradiEventHandler(AbstractEventHandler dogadaj);

    public abstract class AbstractEventHandler
    {
        private readonly ObradiEventHandler _handler;
        private AbstractEventHandler _successor;
        private readonly int _numMsg;
        private readonly byte _firstByte;

        internal EventType EventType;      
        internal List<TPCANMsg> List = new List<TPCANMsg>();
        

        protected AbstractEventHandler(EventType eventType, int numMsg, byte firstByte, ObradiEventHandler handler, AbstractEventHandler successor = null)
        {
            EventType = eventType;
            _handler = handler;
            _successor = successor;
            _numMsg = numMsg;
            _firstByte = firstByte;
        }

        internal void NewMessage(TPCANMsg msg)
        {
            if (msg.DATA[0].Equals(_firstByte))
            {
                List.Add(msg);
                if (List.Count == _numMsg)
                {
                    _handler(this);
                    Handle();
                }
            }
            else if (_successor != null)
                _successor.NewMessage(msg);
        }

        internal abstract void Handle();

        internal void SetSuccessor(AbstractEventHandler successor1)
        {
            _successor = successor1;
        }
    }
}
