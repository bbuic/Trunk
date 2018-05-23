namespace BikeService.Objects.ObjectHandlers
{
    public interface IPcanHandler
    {
        event PcanHandler.ReadHandler HandleCanMessage;
        bool InitCan();
        void Write(uint idUredaja, byte[] data);
        bool Write(uint idUredaja, TPCANMsg canMsg);
    }
}
