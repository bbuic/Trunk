using System.Collections.Generic;

namespace BikeService.Objects.ObjectHandlers
{
    public interface IServerHandler
    {
        void SendEvent();
        void SendPilonStatus(List<DockingModel> list);
        bool ValidateRfidTag(int rfidTagId, uint dockId);
        bool ValidateBikeTag(int bikeTagId, uint dockId);
    }
}