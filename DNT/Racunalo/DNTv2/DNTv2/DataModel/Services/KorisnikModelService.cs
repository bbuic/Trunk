using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DNTv2.DataAccess;
using DNTv2.DataModel.Converters;

namespace DNTv2.DataModel.Services
{
    public class KorisnikModelService: AbstractModelService
    {
        internal KarticaModelService KarticaModelService = new KarticaModelService();

        public KorisnikModelService()
        {
            
        }

        public override void EventHandler(EventContext context)
        {

        }

        public override void Refresh()
        {
            bindingSource.DataSource =
                ObjectFactory.KorisnikDataService.DajSveKorisnike().Select(korisnik => new KorisnikModel { Korisnik = korisnik }).ToList();
        }

        public override void Insert()
        {
            KorisnikModel korisnikModel = ((KorisnikModel)bindingSource.Current);
            if (korisnikModel.modelState == ModelState.Unchanged) return;

            if (korisnikModel.modelState == ModelState.Inserted)
                ObjectFactory.KorisnikDataService.Insert(korisnikModel.Korisnik);
            else
                ObjectFactory.KorisnikDataService.Update(korisnikModel.Korisnik);

            ((List<KorisnikModel>)bindingSource.List).All(x => { x.ModelState = ModelState.Unchanged; return true; });
        }

        public override void Delete()
        {
            KorisnikModel korisnikModel = ((KorisnikModel)bindingSource.Current);
            if (korisnikModel.Id <= 0)
                bindingSource.RemoveCurrent();
            else
            {
                if (MessageBox.Show(@"Želite obrisati odabranog korisnika?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    ObjectFactory.KorisnikDataService.ObrisiKorisnika(korisnikModel.Korisnik);
            }
            //((IList<KorisnikModel>)service.bindingSource.List).Select(c => { c.modelState = ModelState.Unchanged; return c; }).ToList();
            Refresh();
        }


    }
}
