﻿using BikeService.Objects;

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
        public static readonly TPCANMsg WorkWithServer = new TPCANMsg { LEN = 2, DATA = new byte[] { 0x12, 0x01 } };        
        public static readonly TPCANMsg BikeTag = new TPCANMsg { LEN = 8, DATA = new byte[] { 0x75 } };        
        public static readonly TPCANMsg BikeTagAck = new TPCANMsg { LEN = 2, DATA = new byte[] { 0x76, 0x06 } };        
    }
}
