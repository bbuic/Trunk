using System.Collections.Generic;
using System.Linq;
using BikeService.Objects;

namespace BikeService
{
    public enum EventCategory
    {
        Info,
        Error,
        Fatal, //nemoguć rad, potrebna intervancija admina        
        Cloud
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
        CanReadCommand,
        BikeOpend,
        BikeClosed
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
        State,
        Status
    }
    
    public class CanSendCommand
    {
        public string CommandName;
        public TPCANMsg Msg;

        public CanSendCommand(string commandname, TPCANMsg msg)
        {
            CommandName = commandname;
            Msg = msg;
        }
    }

    public class CanSendCommands
    {

        //public static readonly TPCANMsg Hello = new TPCANMsg { LEN = 1, DATA = new byte[] { 0x00 } };
        public static readonly CanSendCommand HelloResponse = new CanSendCommand("HelloResponse", new TPCANMsg { LEN = 1, DATA = new byte[] { 0x01 } });

        public static readonly CanSendCommand Presence = new CanSendCommand("Presence", new TPCANMsg { LEN = 1, DATA = new byte[] { 0x04 } });
        public static readonly CanSendCommand PresenceResponse = new CanSendCommand("PresenceResponse", new TPCANMsg { LEN = 1, DATA = new byte[] { 0x05 } });

        public static readonly CanSendCommand WorkWithServer = new CanSendCommand("WorkWithServer", new TPCANMsg { LEN = 2, DATA = new byte[] { 0x12, 0x01 } });        
        
        //public static readonly TPCANMsg BikeTag = new TPCANMsg { LEN = 8, DATA = new byte[] { 0x75 } };        
        public static readonly CanSendCommand BikeTagAck = new CanSendCommand("BikeTagAck", new TPCANMsg { LEN = 2, DATA = new byte[] { 0x76, 0x06 } });        

        //public static readonly TPCANMsg RfidTag = new TPCANMsg { LEN = 8, DATA = new byte[] { 0x77 } };        
        public static readonly CanSendCommand RfidTagAckOk = new CanSendCommand("RfidTagAckOk", new TPCANMsg { LEN = 1, DATA = new byte[] { 0x15 } });        
        public static readonly CanSendCommand RfidTagAckCancel = new CanSendCommand("RfidTagAckCancel", new TPCANMsg { LEN = 1, DATA = new byte[] { 0x06 } });        

        public static readonly CanSendCommand Reset = new CanSendCommand("Reset", new TPCANMsg { LEN = 1, DATA = new byte[] { 0x10 } });
        
        public static readonly CanSendCommand Status = new CanSendCommand("Status", new TPCANMsg { LEN = 1, DATA = new byte[] { 0x7B } });        

        public static readonly CanSendCommand ServisniMod = new CanSendCommand("ServisniMod", new TPCANMsg { LEN = 2, DATA = new byte[] { 0x79, 0x01 } });        
        public static readonly CanSendCommand Open = new CanSendCommand("Open", new TPCANMsg { LEN = 2, DATA = new byte[] { 0x79, 03 } });        
    }
}
