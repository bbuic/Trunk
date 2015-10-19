using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DNTv2.DataAccess;
using DNTv2.DataModel.Services;

namespace DNTv2.DataModel.Converters
{
    public class KorisnikModel2Gui : IModel2Gui
    {
        public Form Convert2Form()
        {
            KorisnikModelService service = new KorisnikModelService();

            frmUser user = new frmUser {dataGridView1 = {DataSource = service.bindingSource}};
            service.Refresh();

            user.txtIme.DataBindings.Add("Text", service.bindingSource, "Ime");
            user.txtPrezime.DataBindings.Add("Text", service.bindingSource, "Prezime");
            user.txtUlica.DataBindings.Add("Text", service.bindingSource, "Adresa");
            user.txtKucniBroj.DataBindings.Add("Text", service.bindingSource, "KucniBroj");
            user.txtGrad.DataBindings.Add("Text", service.bindingSource, "Grad");
            user.txtTelefon.DataBindings.Add("Text", service.bindingSource, "Telefon");
            user.dgvKartice.DataSource = service.KarticaModelService.bindingSource;
            service.bindingSource.CurrentChanged += delegate
            {
                service.KarticaModelService.bindingSource.DataSource = ((KorisnikModel) service.bindingSource.Current).Kartice;
            };
            if (service.bindingSource.Current != null)
                service.KarticaModelService.bindingSource.DataSource = ((KorisnikModel)service.bindingSource.Current).Kartice;

            user.btnNovi.Click += delegate
            {
                if (user.TabControl1.SelectedIndex == 0)
                {
                    KorisnikModel korisnikModel = (KorisnikModel) service.bindingSource.AddNew();
                    korisnikModel.modelState = ModelState.Inserted;
                    user.txtIme.Focus();
                }
                else
                {
                    KarticaModel o = (KarticaModel) service.KarticaModelService.bindingSource.AddNew();
                    o.modelState = ModelState.Inserted;
                    user.txtBrojKartice.Focus();
                }
            };

            
            user.btnZapamti.Click += delegate
            {
                KorisnikModel korisnikModel = ((KorisnikModel)service.bindingSource.Current);
                if (korisnikModel.modelState == ModelState.Unchanged) return;

                if (korisnikModel.modelState == ModelState.Inserted)
                    ObjectFactory.KorisnikDataService.Insert(korisnikModel.Korisnik);
                else
                    ObjectFactory.KorisnikDataService.Update(korisnikModel.Korisnik);

                ((List<KorisnikModel>)service.bindingSource.List).All(x => { x.ModelState = ModelState.Unchanged; return true; });
            };

            user.btnObrisi.Click += delegate
            {
                if (user.TabControl1.SelectedIndex == 0)
                {
                    KorisnikModel korisnikModel = ((KorisnikModel) service.bindingSource.Current);
                    if (korisnikModel.Id <= 0)
                        service.bindingSource.RemoveCurrent();
                    else
                    {
                        if (MessageBox.Show(@"Želite obrisati odabranog korisnika?", "",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            ObjectFactory.KorisnikDataService.ObrisiKorisnika(korisnikModel.Korisnik);
                    }
                    //((IList<KorisnikModel>)service.bindingSource.List).Select(c => { c.modelState = ModelState.Unchanged; return c; }).ToList();
                    service.Refresh();
                }
                else
                {
                    
                }
            };

            user.btnPovratak.Click += delegate
            {
                if(!((IList<KorisnikModel>)service.bindingSource.List).Select(x => x.modelState != ModelState.Unchanged).Any()
                    || MessageBox.Show(@"Želite odustati od promjena?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    user.Close();
            };

            return user;
        }

        public UserControl Convert2UserControl()
        {
            throw new NotImplementedException();
        }
    }
}
