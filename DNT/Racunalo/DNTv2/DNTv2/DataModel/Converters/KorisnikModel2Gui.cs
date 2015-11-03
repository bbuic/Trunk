using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            
            user.txtBrojKartice.DataBindings.Add("Text", karticaModelService.bindingSource, "Broj"); 
            user.txtBrojUgovora.DataBindings.Add("Text", karticaModelService.bindingSource, "Ugovor");
            //user.dtpDatumKartice.DataBindings.Add("Value", karticaModelService.bindingSource, "Datum"); 

            user.txtBrojKartice.KeyPress += delegate(object sender, KeyPressEventArgs e)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            };

            user.txtIme.Validating += delegate(object sender, CancelEventArgs e)
            {
                if (user.txtIme.Text.Length > 0 && ((IList<KorisnikModel>)korisnikModelService.bindingSource.List).Any(x => x.Ime == user.txtIme.Text))
                {
                    MessageBox.Show(@"Korisnik sa imenom " + user.txtIme.Text + @" već postoji.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            };

            user.btnNovi.Click += delegate
            {
                switch (user.TabControl1.SelectedIndex)
                {
                    case 0:
                        korisnikModelService.New();
                        user.txtIme.Focus();
                        break;
                    case 1:
                        karticaModelService.New();
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
                    case 1:
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
                if ((((IList<KorisnikModel>)korisnikModelService.bindingSource.List).Any(x => x.modelState != ModelState.Unchanged)
                        ||
                    ((IList<KarticaModel>)karticaModelService.bindingSource.List).Any(x => x.modelState != ModelState.Unchanged))
                    &&
                    MessageBox.Show(@"Želite odustati od promjena?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
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
