using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DNTv2.DataModel.Services
{
    public class KorisnikModelService: AbstractModelService
    {
        internal KarticaModelService KarticaModelService = new KarticaModelService();

        public KorisnikModelService()
        {            
            bindingSource.CurrentChanged += delegate
            {
                if (bindingSource.Current == null) 
                    return;
                
                KarticaModelService.Korisnik = (KorisnikModel) bindingSource.Current;
                KarticaModelService.Refresh();

                if(KarticaModelService.bindingSource.Count <= 0)
                    KarticaModelService.New();
            };            
        }

        public override void New()
        {
            KorisnikModel korisnikModel = (KorisnikModel)bindingSource.AddNew();
            if (korisnikModel != null)
                korisnikModel.modelState = ModelState.Inserted;                        
        }

        public override void Refresh()
        {
            bindingSource.DataSource =
                ObjectFactory.KorisnikDataService.DajSveKorisnike().Select(korisnik => new KorisnikModel { Korisnik = korisnik }).ToList();
        }

        public override void Insert()
        {
            IList<KorisnikModel> list = ((IList<KorisnikModel>)bindingSource.List).Where(x => x.modelState != ModelState.Unchanged).ToList();
            if (list.Count <= 0)
                return;

            IList<KorisnikModel> neValidni = list.Where(x => !x.IsValid()).ToList();            
            if (neValidni.Count > 0)
            {
                bindingSource.Position = bindingSource.IndexOf(neValidni[0]);
                MessageBox.Show(@"Odabranom korisniku nije upisan podatak: Ime.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return;
            }

            foreach (KorisnikModel model in list)
            {
                switch (model.modelState)
                {
                    case ModelState.Inserted:
                        ObjectFactory.KorisnikDataService.UnesiKorisnika(model.Korisnik);
                        break;
                    case ModelState.Modified:
                        ObjectFactory.KorisnikDataService.PromjeniKorisnika(model.Korisnik);
                        break;
                }  
            }            
            Refresh();
            List<KorisnikModel> models = ((IList<KorisnikModel>)bindingSource.DataSource).Where(x=>x.Ime.ToLower() == list[0].Ime.ToLower()).ToList();
            bindingSource.Position = models.Count > 0 ? bindingSource.IndexOf(models[0]) : -1;
            MessageBox.Show(@"Uspješno ste zapamtili korisnika.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public override void Delete()
        {
            KorisnikModel model = ((KorisnikModel)bindingSource.Current);
            if (model.Id > 0)
            {
                if (MessageBox.Show(@"Želite obrisati korisnika: " + model.Ime + @" ?", "", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)                
                    return;
                
                ObjectFactory.KorisnikDataService.ObrisiKorisnika(model.Korisnik);
                MessageBox.Show(@"Uspješno ste obrisali korisnika.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
            else
                bindingSource.RemoveCurrent();
            Refresh();
            bindingSource.Position = -1;
        }


    }
}
