using DNTDataAccess.DataServices;
using DNTv2.DataAccess.Services;

namespace DNTDataAccess
{
    public sealed class ObjectFactory
    {
        private static TransakcijaDataService _transakcijaDataService;
        private static KarticaDataService _karticaDataService;
        private static KorisnikDataService _korisnikDataService;
        private static DogadajDataService _dogadajDataService;

        public static DogadajDataService DogadajDataService
        {
            get { return _dogadajDataService ?? (_dogadajDataService = new DogadajDataService()); }
        }

        public static KorisnikDataService KorisnikDataService
        {
            get { return _korisnikDataService ?? (_korisnikDataService = new KorisnikDataService()); }
        }

        public static TransakcijaDataService TransakcijaDataService
        {
            get { return _transakcijaDataService ?? (_transakcijaDataService = new TransakcijaDataService()); }
        }

        public static KarticaDataService KarticaDataService
        {
            get { return _karticaDataService ?? (_karticaDataService = new KarticaDataService()); }
        } 
    }
}
