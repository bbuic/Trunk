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

    public enum LogLocation
    {
        CanInit,
        CanRelease,
        CanRead,
        CanWrite
    }

    class Constants
    {
    }
}
