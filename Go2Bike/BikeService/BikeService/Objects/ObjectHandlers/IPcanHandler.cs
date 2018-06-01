namespace BikeService.Objects.ObjectHandlers
{
    public interface IPcanHandler
    {
        event PcanHandler.ReadHandler HandleCanMessage;
        bool InitCan();        
        bool Write(TPCANMsg msg);
    }
}
