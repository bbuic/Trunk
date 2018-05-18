namespace BikeService.EventHandlers
{
    public class GenericEventHandler : AbstractEventHandler
    {
        public GenericEventHandler(CanReciveCommands canReciveCommands, int numMsg, byte firstByte, ObradiEventHandler handler, AbstractEventHandler successor = null) : base(canReciveCommands, numMsg, firstByte, handler, successor)
        {
        }

        internal override void Handle()
        {
            
        }
    }
}
