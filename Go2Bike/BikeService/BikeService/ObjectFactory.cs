using BikeService.DataBase.DataServices;
using BikeService.Objects.ObjectHandlers;

namespace BikeService
{
    public sealed class ObjectFactory
    {
        private static EventDataService _eventDataService;
        private static LogDataService _logDataService;
        private static DockingDataService _dockingDataService;
        private static ServerHandler _serverHandler;

        public static ServerHandler ServerHandler
        {
            get { return _serverHandler ?? (_serverHandler = new ServerHandler()); }
        }

        public static EventDataService EventDataService
        {
            get { return _eventDataService ?? (_eventDataService = new EventDataService()); }
        }

        public static LogDataService LogDataService
        {
            get { return _logDataService ?? (_logDataService = new LogDataService()); }
        }

        public static DockingDataService DockingDataService
        {
            get { return _dockingDataService ?? (_dockingDataService = new DockingDataService()); }
        }
    }
}
