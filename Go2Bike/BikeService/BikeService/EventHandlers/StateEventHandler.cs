using System;

namespace BikeService.EventHandlers
{
    public class StateEventHandler:AbstractEventHandler
    {
        public StateEventHandler(EventType eventType, int numMsg, byte firstByte, ObradiEventHandler handler, AbstractEventHandler successor = null) : base(eventType, numMsg, firstByte, handler, successor)
        {
        }

        internal override void Handle()
        {
            throw new NotImplementedException();
        }
    }
}
