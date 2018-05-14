namespace BikeService.EventHandlers
{
    public class EventHandler : AbstractEventHandler
    {
        public EventHandler(EventType eventType, int numMsg, byte firstByte, ObradiEventHandler handler, AbstractEventHandler successor = null) : base(eventType, numMsg, firstByte, handler, successor)
        {
        }

        internal override void Handle()
        {
            
        }
    }
}
