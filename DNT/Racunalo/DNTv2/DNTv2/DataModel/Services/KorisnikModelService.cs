using System.Collections.Generic;
using System.Linq;
using DNTv2.DataAccess;

namespace DNTv2.DataModel.Services
{
    public class KorisnikModelService: AbstractModelService
    {
        internal KarticaModelService KarticaModelService = new KarticaModelService();

        public KorisnikModelService()
        {
            
        }

        public override void Refresh()
        {
            bindingSource.DataSource =
                ObjectFactory.KorisnikDataService.DajSveKorisnike().Select(korisnik => new KorisnikModel { Korisnik = korisnik }).ToList();
        }

        public void SaveModel()
        {
            
        }
    }
}
