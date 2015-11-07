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
            
            frmUser user = new frmUser {dgvKorisnici = {DataSource = korisnikModelService.bindingSource}};
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
            user.dtpDatumKartice.DataBindings.Add("Value", karticaModelService.bindingSource, "Datum", true); 

            //za broj kartice dozvoljeno samo brojeve
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

            user.txtImeFilter.KeyPress += delegate(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == (int) Keys.Escape)
                    user.dgvKorisnici.Focus();
            };
            
            user.txtImeFilter.TextChanged += delegate
            {
                if(string.IsNullOrEmpty(user.txtImeFilter.Text))
                {
                    foreach (DataGridViewRow row in user.dgvKorisnici.Rows)
                        row.Visible = true;
                    return;
                }
                
                user.dgvKorisnici.CurrentCell = null;
                foreach (DataGridViewRow row in user.dgvKorisnici.Rows)
                    row.Visible = row.Cells["Ime"].Value.ToString().ToLower().Contains(user.txtImeFilter.Text.ToLower());

                if (user.dgvKorisnici.DisplayedRowCount(true) > 0)
                {                    
                    user.dgvKorisnici.CurrentCell = user.dgvKorisnici.Rows[user.dgvKorisnici.FirstDisplayedScrollingRowIndex].Cells[2];
                    user.dgvKorisnici.Rows[user.dgvKorisnici.FirstDisplayedScrollingRowIndex].Selected = true;
                }
            };

            user.txtBrojKartice.Validating += delegate(object sender, CancelEventArgs e)
            {
                if (!string.IsNullOrEmpty(user.txtBrojKartice.Text))
                    e.Cancel = ObjectFactory.KarticaDataService.PostojiBrojKartice(user.txtBrojKartice.Text);
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

            user.dgvKorisnici.Columns["Korisnik"].Visible = false;
            user.dgvKorisnici.Columns["Id"].Visible = false;
            user.dgvKorisnici.Columns["Kartice"].Visible = false;
            user.dgvKorisnici.Columns["ModelState"].Visible = false;

            user.dgvKorisnici.Columns["Ime"].HeaderText = @"Ime (Naziv1)";
            user.dgvKorisnici.Columns["Ime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            user.dgvKorisnici.Columns["Prezime"].HeaderText = @"Prezime (Naziv2)";
            user.dgvKorisnici.Columns["Prezime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            user.dgvKorisnici.Columns["Adresa"].Width = 80;
            user.dgvKorisnici.Columns["Adresa"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            user.dgvKorisnici.Columns["Grad"].Width = 80;
            user.dgvKorisnici.Columns["Grad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            user.dgvKorisnici.Columns["Grad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            user.dgvKorisnici.Columns["KucniBroj"].HeaderText = @"Kućni broj";
            user.dgvKorisnici.Columns["KucniBroj"].Width = 80;
            user.dgvKorisnici.Columns["KucniBroj"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            user.dgvKorisnici.Columns["KucniBroj"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            user.dgvKorisnici.Columns["Telefon"].Width = 80;
            user.dgvKorisnici.Columns["Telefon"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            user.dgvKartice.Columns["Kartica"].Visible = false;
            user.dgvKartice.Columns["ModelState"].Visible = false;
            user.dgvKartice.Columns["VlasnikId"].Visible = false;
            user.dgvKartice.Columns["Broj"].HeaderText = "Broj kartice";
            user.dgvKartice.Columns["Broj"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            user.dgvKartice.Columns["Ugovor"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            user.dgvKartice.Columns["Datum"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            return user;
        }
    }
}
