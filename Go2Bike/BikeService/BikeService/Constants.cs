using BikeService.Objects;

namespace BikeService
{
    public enum EventCategory
    {
        Info,
        Error,
        Fatal, //nemoguć rad, potrebna intervancija admina        
    }

    public enum EventType
    {
        UnknownEvent,
        PilonInit,
        CanInit,
        ServiceBusInit,
        ServerRequest,
        NewDocking,
        CanWriteCommand,
        CanReadCommand
    }

    public enum SwitchState
    {
        Otvoreno,
        Zatvoreno
    }

    public enum StanjeSignalizacije
    {
        Unlocked,
        RedX,
        Locked,
        Blink
    }

    public enum CanReciveCommands
    {
        Hello,
        BikeTag,
        RfidTag,
        State
    }

    public class CanSendCommands
    {
        //public static readonly TPCANMsg Hello = new TPCANMsg { LEN = 1, DATA = new byte[] { 0x00 } };
        public static readonly TPCANMsg HelloResponse = new TPCANMsg { LEN = 1, DATA = new byte[] { 0x01 } };

        public static readonly TPCANMsg Presence = new TPCANMsg { LEN = 1, DATA = new byte[] { 0x04 } };
        public static readonly TPCANMsg PresenceResponse = new TPCANMsg { LEN = 1, DATA = new byte[] { 0x05 } };

        public static readonly TPCANMsg WorkWithServer = new TPCANMsg { LEN = 2, DATA = new byte[] { 0x12, 0x01 } };        
        
        //public static readonly TPCANMsg BikeTag = new TPCANMsg { LEN = 8, DATA = new byte[] { 0x75 } };        
        public static readonly TPCANMsg BikeTagAck = new TPCANMsg { LEN = 2, DATA = new byte[] { 0x76, 0x06 } };        

        //public static readonly TPCANMsg RfidTag = new TPCANMsg { LEN = 8, DATA = new byte[] { 0x77 } };        
        public static readonly TPCANMsg RfidTagAckOk = new TPCANMsg { LEN = 1, DATA = new byte[] { 0x15 } };        
        public static readonly TPCANMsg RfidTagAckCancel = new TPCANMsg { LEN = 1, DATA = new byte[] { 0x06 } };        

        public static readonly TPCANMsg Reset = new TPCANMsg { LEN = 1, DATA = new byte[] { 0x10 } };
        
        public static readonly TPCANMsg Status = new TPCANMsg { LEN = 1, DATA = new byte[] { 0x7B } };        

        public static readonly TPCANMsg ServisniMod = new TPCANMsg { LEN = 2, DATA = new byte[] { 0x79, 0x01 } };        
        public static readonly TPCANMsg Open = new TPCANMsg { LEN = 2, DATA = new byte[] { 0x79, 03 } };

        public static readonly TPCANMsg Block = new TPCANMsg { LEN = 2, DATA = new byte[] { 0x79, 03 } };        
    }
}
