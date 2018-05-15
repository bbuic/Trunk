namespace BikeService.EventHandlers
{
    public class GenericEventHandler : AbstractEventHandler
    {
        public GenericEventHandler(EventType eventType, int numMsg, byte firstByte, ObradiEventHandler handler, AbstractEventHandler successor = null) : base(eventType, numMsg, firstByte, handler, successor)
        {
        }

        internal override void Handle()
        {
            
        }
    }
}
