namespace BikeService.Objects
{
    public enum MessageType:short
    {
        Unlock = 1,
        Block = 2,
        Reset = 3,
        ResetAll = 4,        
        Status = 5
    }
    public class ServerMessage
    {
        public uint DockingId { get; set; }
        public MessageType MessageType { get; set; }
    }
}
