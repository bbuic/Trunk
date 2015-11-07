using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DNTv2.DataModel.Services
{
    public class KarticaModelService:AbstractModelService
    {
        internal KorisnikModel Korisnik { get; set; }

        public override void New()
        {
            if (Korisnik == null || Korisnik.Id <= 0)
            {
                MessageBox.Show(@"Niste odabrali korisnika za kojeg želite unijeti kartice.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            KarticaModel o = (KarticaModel) bindingSource.AddNew();
            if (o != null)
            {
                o.modelState = ModelState.Inserted;
                o.VlasnikId = Korisnik.Id;
            }         
        }

        public override void Refresh()
        {
            bindingSource.DataSource = 
                ObjectFactory.KarticaDataService.DajKarticeKorisnika(Korisnik.Id).Select(kartica => new KarticaModel { Kartica = kartica }).ToList();            
        }

        public override void Insert()
        {
            IList<KarticaModel> list = ((IList<KarticaModel>)bindingSource.List).Where(x => x.modelState != ModelState.Unchanged).ToList();
            if(list.Count <= 0)
                return;

            IList<KarticaModel> neValidni = list.Where(x => !x.IsValid()).ToList();
            if (neValidni.Count > 0)
            {
                bindingSource.Position = bindingSource.IndexOf(neValidni[0]);
                MessageBox.Show(@"Odabranoj kartici nisu upisani svi obavezni podaci.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (KarticaModel model in list)
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

            MessageBox.Show(@"Uspješno ste zapamtili karticu.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public override void Delete()
        {
            KarticaModel model = (KarticaModel)bindingSource.Current;
            if(model == null)
                return;

            if(string.IsNullOrEmpty(model.Broj))
            {
                bindingSource.RemoveCurrent();
                return;
            }

            if (MessageBox.Show(@"Želite obrisati odabranu karticu?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                ObjectFactory.KarticaDataService.ObrisiKarticu(model.Kartica);            
                Refresh();
                MessageBox.Show(@"Uspješno ste obrisali karticu.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
