using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DNTv2.DataAccess.Services;
using DNTv2.DataModel.DataServices;

namespace DNTv2
{
    public sealed class ObjectFactory
    {
        private static TransakcijaDataService _transakcijaDataService;
        private static KarticaDataService _karticaDataService;
        private static KorisnikDataService _korisnikDataService;

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
