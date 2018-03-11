using BikeService.DataBase.DataServices;

namespace BikeService
{
    public sealed class ObjectFactory
    {
        private static BikeServiceLogDataService _bikeServiceLogDataService;

        public static BikeServiceLogDataService LogDataService
        {
            get { return _bikeServiceLogDataService ?? (_bikeServiceLogDataService = new BikeServiceLogDataService()); }
        }
    }
}
