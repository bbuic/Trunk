using System;

namespace BikeService.EventHandlers
{
    public class StateEventHandler:AbstractEventHandler
    {
        public StateEventHandler(CanReciveCommands canReciveCommands, int numMsg, byte firstByte, ObradiEventHandler handler, AbstractEventHandler successor = null) : base(canReciveCommands, numMsg, firstByte, handler, successor)
        {
        }

        internal override void Handle()
        {
            throw new NotImplementedException();
        }
    }
}
