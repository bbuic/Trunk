using BikeService.DataBase.DataServices;
using BikeService.Objects.ObjectHandlers;

namespace BikeService
{
    public sealed class ObjectFactory
    {
        private static EventDataService _eventDataService;        
        private static DockingDataService _dockingDataService;
        private static ServerHandler _serverHandler;

        public static ServerHandler ServerHandler => _serverHandler ?? (_serverHandler = new ServerHandler());
        public static EventDataService EventDataService => _eventDataService ?? (_eventDataService = new EventDataService());
        public static DockingDataService DockingDataService => _dockingDataService ?? (_dockingDataService = new DockingDataService());
    }
}
