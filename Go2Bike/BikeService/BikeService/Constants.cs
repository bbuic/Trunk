namespace BikeService
{
    public enum SwitchState
    {
        Nepoznato,
        Zakljucano,
        Otkljucano
    }

    public enum TagState
    {
        Nepoznato,
        Prisutan,
        Neprisutan
    }

    public enum LogType
    {
        Info,
        Error
    }
    
    public class Commands
    {
        public const byte Hello = 0x00;
        public const byte HelloResponse = 0x01;
        public const byte GetLockState = 0x02;
        public const byte GetTagState = 0x02;
    }
}
