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
            
            frmUser user = new frmUser {dgvKorisnici = {DataSource = korisnikModelService.bindingSource}};
            korisnikModelService.Refresh();
            
            user.txtIme.DataBindings.Add("Text", korisnikModelService.bindingSource, "Ime");
            user.txtIme.DataBindings.Add("Enabled", korisnikModelService, "SourceImaPodataka");
            user.txtPrezime.DataBindings.Add("Text", korisnikModelService.bindingSource, "Prezime");
            user.txtPrezime.DataBindings.Add("Enabled", korisnikModelService, "SourceImaPodataka");
            user.txtUlica.DataBindings.Add("Text", korisnikModelService.bindingSource, "Adresa");
            user.txtUlica.DataBindings.Add("Enabled", korisnikModelService, "SourceImaPodataka");
            user.txtKucniBroj.DataBindings.Add("Text", korisnikModelService.bindingSource, "KucniBroj");
            user.txtKucniBroj.DataBindings.Add("Enabled", korisnikModelService, "SourceImaPodataka");
            user.txtGrad.DataBindings.Add("Text", korisnikModelService.bindingSource, "Grad");
            user.txtGrad.DataBindings.Add("Enabled", korisnikModelService, "SourceImaPodataka");
            user.txtTelefon.DataBindings.Add("Text", korisnikModelService.bindingSource, "Telefon");
            user.txtTelefon.DataBindings.Add("Enabled", korisnikModelService, "SourceImaPodataka");

            user.dgvKartice.DataSource = karticaModelService.bindingSource;
            
            user.txtBrojKartice.DataBindings.Add("Text", karticaModelService.bindingSource, "Broj");
            user.txtBrojKartice.DataBindings.Add("Enabled", karticaModelService, "SourceImaPodataka"); 
            user.txtBrojUgovora.DataBindings.Add("Text", karticaModelService.bindingSource, "Ugovor");
            user.txtBrojUgovora.DataBindings.Add("Enabled", karticaModelService, "SourceImaPodataka");
            user.dtpDatumKartice.DataBindings.Add("Value", karticaModelService.bindingSource, "Datum", true);
            user.dtpDatumKartice.DataBindings.Add("Enabled", karticaModelService, "SourceImaPodataka"); 

            //za broj kartice dozvoljeno samo brojeve
            user.txtBrojKartice.KeyPress += delegate(object sender, KeyPressEventArgs e)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            };

            user.txtIme.Validating += delegate(object sender, CancelEventArgs e)
            {
                KorisnikModel model = (KorisnikModel)korisnikModelService.bindingSource.Current;
                if (user.txtIme.Text.Length > 0 && model != null && model.ModelState != ModelState.Unchanged &&
                    ((IList<KorisnikModel>)korisnikModelService.bindingSource.List).Any(x => !string.IsNullOrEmpty(x.Ime) && x.Ime.Trim() == user.txtIme.Text.Trim()))
                {
                    MessageBox.Show(@"Korisnik sa imenom (" + user.txtIme.Text.Trim() + @") već postoji.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            };

            user.KeyPress += delegate(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == (int) Keys.Escape)
                {
                    user.dgvKorisnici.Focus();
                    e.Handled = true;
                }
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
                KarticaModel model = (KarticaModel)karticaModelService.bindingSource.Current;
                if (!string.IsNullOrEmpty(user.txtBrojKartice.Text) && model != null && model.ModelState != ModelState.Unchanged &&
                    ObjectFactory.KarticaDataService.PostojiBrojKartice(user.txtBrojKartice.Text))
                {
                    MessageBox.Show(@"Broj kartice (" + user.txtBrojKartice.Text.Trim() + @") već postoji.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }                    
            };

            user.btnNovi.Click += delegate
            {
                switch (user.TabControl1.SelectedIndex)
                {
                    case 0:
                        user.txtImeFilter.Clear();
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
                if ((((IList<KorisnikModel>)korisnikModelService.bindingSource.List).Any(x => x.ModelState != ModelState.Unchanged)
                        ||
                    ((IList<KarticaModel>)karticaModelService.bindingSource.List).Any(x => x.ModelState != ModelState.Unchanged))
                    &&
                    MessageBox.Show(@"Želite odustati od promjena?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
                user.Close();
            };

            korisnikModelService.bindingSource.CurrentChanged += delegate
            {
                user.lblBrojKorisnika.Text = korisnikModelService.bindingSource.Count.ToString();
            };
            user.lblBrojKorisnika.Text = korisnikModelService.bindingSource.Count.ToString();


            KorisnikModel korisnik = null;
            if (korisnikModelService.bindingSource.List.Count <= 0)
            {
                korisnik = new KorisnikModel();
                korisnikModelService.bindingSource.List.Add(korisnik);
            }
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
            if (korisnik != null)
                korisnikModelService.bindingSource.List.Remove(korisnik);


            KarticaModel kartica = null;
            if (karticaModelService.bindingSource.List.Count <= 0)
            {
                kartica = new KarticaModel();
                karticaModelService.bindingSource.DataSource = new List<KarticaModel> { kartica };
            }
            user.dgvKartice.Columns["Broj"].HeaderText = @"Broj kartice";
            user.dgvKartice.Columns["Broj"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            user.dgvKartice.Columns["Ugovor"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            user.dgvKartice.Columns["Datum"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            user.dgvKartice.Columns["Datum"].DefaultCellStyle.Format = "dd.MM.yyyy";
            if (kartica != null)
                karticaModelService.bindingSource.Clear();

            return user;
        }
    }
}
