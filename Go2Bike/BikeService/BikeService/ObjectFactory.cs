using BikeService.DataBase.DataServices;
using BikeService.Objects.ObjectHandlers;

namespace BikeService
{
    public sealed class ObjectFactory
    {
        private static IEventDataService _eventDataService;        
        private static DockingDataService _dockingDataService;
        private static IServerHandler _serverHandler;

        public static IServerHandler ServerHandler
        {
            get => _serverHandler ?? (_serverHandler = new ServerHandler());
            set => _serverHandler = value;
        }

        public static IEventDataService EventDataService
        {
            get => _eventDataService ?? (_eventDataService = new EventDataService());
            set => _eventDataService = value;
        }

        public static DockingDataService DockingDataService => _dockingDataService ?? (_dockingDataService = new DockingDataService());
    }
}
