using BikeService.DataBase.DataServices;

namespace BikeService
{
    public sealed class ObjectFactory
    {
        private static EventDataService _eventDataService;
        private static LogDataService _logDataService;
        private static DockingDataService _dockingDataService;

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
