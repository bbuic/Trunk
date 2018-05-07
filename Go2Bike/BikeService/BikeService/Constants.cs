using BikeService.Objects;

namespace BikeService
{
    public enum LogType
    {
        Info,
        Error
    }

    public enum EventType
    {
        PilonUpdate,        
        DockUnlock,
        DockLock,
        Rfid,
        DockDisable,
        DockEnable,
        PilonError
    }


    public class Commands
    {
        public static readonly TPCANMsg Hello = new TPCANMsg { LEN = 1, DATA = new byte[] { 0x00 } };
        public static readonly TPCANMsg HelloResponse = new TPCANMsg { LEN = 1, DATA = new byte[] { 0x01 } };
        public static readonly TPCANMsg Presence = new TPCANMsg { LEN = 1, DATA = new byte[] { 0x04 } };
        public static readonly TPCANMsg PresenceResponse = new TPCANMsg { LEN = 1, DATA = new byte[] { 0x05 } };        
    }
}
