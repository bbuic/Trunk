using System;

namespace BikeService.Events.EventHandlers
{
    public class GenericEventHandler : AbstractEventHandler
    {
        public GenericEventHandler(CanReciveCommands canReciveCommands, int numMsg, ObradiEventHandler handler, AbstractEventHandler successor = null, Type type = null) : base(canReciveCommands, numMsg, handler, successor, type)
        {
        }
    }
}
