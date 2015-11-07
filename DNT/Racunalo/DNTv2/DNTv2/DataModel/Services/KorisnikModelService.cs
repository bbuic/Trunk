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
            IList<KorisnikModel> list = ((IList<KorisnikModel>)bindingSource.List);

            IList<KorisnikModel> neValidni = list.Where(x => !x.IsValid()).ToList();            
            if (neValidni.Count > 0)
            {
                bindingSource.Position = bindingSource.IndexOf(neValidni[0]);
                MessageBox.Show(@"Odabranom korisniku nije upisan podatak: Ime.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return;
            }

            foreach (KorisnikModel model in list.Where(x => x.modelState != ModelState.Unchanged).ToList())
            {
                switch (model.modelState)
                {
                    case ModelState.Inserted:
                        ObjectFactory.KorisnikDataService.Insert(model);
                        break;
                    case ModelState.Modified:
                        ObjectFactory.KorisnikDataService.Update(model);
                        break;
                }  
            }
            
            list.All(x => { x.ModelState = ModelState.Unchanged; return true; });

            MessageBox.Show(@"Uspješno ste zapamtili korisnika.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public override void Delete()
        {
            KorisnikModel model = ((KorisnikModel)bindingSource.Current);
            if (model.Id > 0)
            {
                if (MessageBox.Show(@"Želite obrisati odabranog korisnika?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ObjectFactory.KorisnikDataService.ObrisiKorisnika(model.Korisnik);
                    MessageBox.Show(@"Uspješno ste obrisali korisnika.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                bindingSource.RemoveCurrent();
            Refresh();
        }


    }
}
