using System.Collections.Generic;
using BikeService.DataBase;
using BikeService.DataBase.DataServices;

namespace BikeServiceTest.Mock
{
    public class EventDataServiceMock : IEventDataService
    {
        public List<Event> Events = new List<Event>();

        public void Insert(Event dogadaj)
        {
            Events.Add(dogadaj);
        }
    }
}
