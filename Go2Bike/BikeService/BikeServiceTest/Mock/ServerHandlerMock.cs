using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BikeService;
using BikeService.DataBase;
using BikeService.Objects;
using BikeService.Objects.ObjectHandlers;

namespace BikeServiceTest.Mock
{
    public class ServerHandlerMock : IServerHandler
    {
        public SynchronizationContext SyncContext;

        public delegate void ModelEventHandler(Event dogadaj);
        public event ModelEventHandler DogadajServisa;

        public delegate void PilonStatusEventHandler(List<DockingModel> list);
        public event PilonStatusEventHandler PilonStatus;

        private void DogadajProxy(object dogadaj) => DogadajServisa?.Invoke((Event)dogadaj);
        private void PilonStatusProxy(object dogadaj) => PilonStatus?.Invoke((List<DockingModel>)dogadaj);

        public void SendEvent()
        {
            foreach (var dogadaj in ((EventDataServiceMock) ObjectFactory.EventDataService).Events.Where(x=>!x.SendTime.HasValue).ToList())
            {
                dogadaj.SendTime = DateTime.Now;
                SyncContext?.Post(DogadajProxy, dogadaj);
            }
        }

        public void SendPilonStatus(List<DockingModel> list)
        {
            SyncContext?.Post(PilonStatusProxy, list);
        }

        public bool ValidateRfidTag(int rfidTagId, uint dockId)
        {
            throw new NotImplementedException();
        }

        public bool ValidateBikeTag(int bikeTagId, uint dockId)
        {
            throw new NotImplementedException();
        }
    }
}
