using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DNTv2.DataModel.Services;

namespace DNTv2.DataModel.Converters
{
    public class KorisnikModel2Gui : IModel2Gui
    {
        public Form Convert2Form()
        {
            KorisnikModelService korisnikModelService = new KorisnikModelService();
            KarticaModelService karticaModelService = korisnikModelService.KarticaModelService;

            frmUser user = new frmUser {dataGridView1 = {DataSource = korisnikModelService.bindingSource}};
            korisnikModelService.Refresh();

            user.txtIme.DataBindings.Add("Text", korisnikModelService.bindingSource, "Ime");
            user.txtPrezime.DataBindings.Add("Text", korisnikModelService.bindingSource, "Prezime");
            user.txtUlica.DataBindings.Add("Text", korisnikModelService.bindingSource, "Adresa");
            user.txtKucniBroj.DataBindings.Add("Text", korisnikModelService.bindingSource, "KucniBroj");
            user.txtGrad.DataBindings.Add("Text", korisnikModelService.bindingSource, "Grad");
            user.txtTelefon.DataBindings.Add("Text", korisnikModelService.bindingSource, "Telefon");            
            user.dgvKartice.DataSource = karticaModelService.bindingSource;
            korisnikModelService.bindingSource.CurrentChanged += delegate
            {
                karticaModelService.bindingSource.DataSource = ((KorisnikModel) korisnikModelService.bindingSource.Current).Kartice;
            };
            if (korisnikModelService.bindingSource.Current != null)
                karticaModelService.bindingSource.DataSource = ((KorisnikModel)korisnikModelService.bindingSource.Current).Kartice;
            
            user.btnNovi.Click += delegate
            {
                switch (user.TabControl1.SelectedIndex)
                {
                    case 0:
                        KorisnikModel korisnikModel = (KorisnikModel)korisnikModelService.bindingSource.AddNew();
                        if (korisnikModel != null) 
                            korisnikModel.modelState = ModelState.Inserted;
                        user.txtIme.Focus();
                        break;
                    default:
                        KarticaModel o = (KarticaModel)karticaModelService.bindingSource.AddNew();
                        if (o != null) 
                            o.modelState = ModelState.Inserted;
                        user.txtBrojKartice.Focus();
                        break;
                }
            };

            
            user.btnZapamti.Click += delegate
            {
                switch (user.TabControl1.SelectedIndex)
                {
                    case 0:
                        korisnikModelService.Insert();
                        break;
                    default:
                        karticaModelService.Insert();
                        break;
                }
            };

            user.btnObrisi.Click += delegate
            {
                switch (user.TabControl1.SelectedIndex)
                {
                    case 0:
                        korisnikModelService.Delete();
                        break;
                    default:
                        karticaModelService.Delete();
                        break;
                }
            };

            user.btnPovratak.Click += delegate
            {
                if(!((IList<KorisnikModel>)korisnikModelService.bindingSource.List).Select(x => x.modelState != ModelState.Unchanged).Any()
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
