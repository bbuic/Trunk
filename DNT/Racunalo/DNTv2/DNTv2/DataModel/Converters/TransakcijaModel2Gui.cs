using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DNTv2.DataModel.Services;
using DNTv2.Report;

namespace DNTv2.DataModel.Converters
{
    public class TransakcijaModel2Gui : IModel2Gui
    {
        public Form Convert2Form()
        {
            TransakcijeModelService service = new TransakcijeModelService();

            frmMain main = new frmMain { dgvTransakcije = {DataSource = service.bindingSource} };
            main.dgvTransakcije.SelectionChanged += delegate { main.dgvTransakcije.ClearSelection(); };
            main.lblPraznjenjeTrezora.LinkClicked += delegate
            {
                if (MessageBox.Show(@"Želite isprintati trezorsku knjigu ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    new frmReportViewer((IList<TransakcijeModel>)service.bindingSource.List).ShowDialog(main);

                if (MessageBox.Show(@"Jeste sigurni da želite ispraznuti trezor?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ObjectFactory.TransakcijaDataService.IsprazniTrezor();
                    main.lblDatumPraznjenjaTrezora.Text =
                        ObjectFactory.TransakcijaDataService.ZadnjePraznjenjeTrezora().ToString(CultureInfo.CurrentCulture);
                }
            };

            main.lblAdministracijaKorisnika.LinkClicked += delegate
            {
                new KorisnikModel2Gui().Convert2Form().ShowDialog(main);
            };

            main.lblPretragaTransakcija.LinkClicked += delegate
            {
                main.dgvTransakcije.Height = main.dgvTransakcije.Height - main.gbPretragaTransakcija.Height - 5;
                main.grbMainIzbornik.Enabled = false;
            };
            
            main.btnPovratak.Click += delegate
            {
                main.dgvTransakcije.Height = main.Panel1.Height;
                main.grbMainIzbornik.Enabled = true;
            };

            main.Load += delegate
            {
                main.dgvTransakcije.Height = main.Panel1.Height;
                main.dgvTransakcije.Width = main.Width - main.Panel1.Width;
                main.dgvTransakcije.Left = main.Panel1.Left + main.Panel1.Width;
                main.lblDatumPraznjenjaTrezora.Left = (main.grbInfo.Width - main.lblDatumPraznjenjaTrezora.Width)/2;
            };

            main.btnPrint.Click += delegate
            {
                new frmReportViewer((IList<TransakcijeModel>)service.bindingSource.List).ShowDialog(main);
            };

            service.bindingSource.DataSourceChanged += delegate{ 
                main.lbBrojVrecica.Text = ((IList<TransakcijeModel>)service.bindingSource.List).Sum(x => x.BrojVrecica).ToString();
                main.lbBrojVrecica.Left = (main.grbInfo.Width - main.lbBrojVrecica.Width) / 2;
            };

            main.lblDatumPraznjenjaTrezora.Text = 
                ObjectFactory.TransakcijaDataService.ZadnjePraznjenjeTrezora().ToString("dd.MM.yyyy HH:mm:ss");
            
            service.Refresh();

            main.dgvTransakcije.Columns["Transakcija"].Visible = false;
            main.dgvTransakcije.Columns["Trezor"].Visible = false;
            main.dgvTransakcije.Columns["ModelState"].Visible = false;
            
            main.dgvTransakcije.Columns["Ime"].HeaderText = @"Ime (Naziv1)";
            main.dgvTransakcije.Columns["Ime"].Width = 200;

            main.dgvTransakcije.Columns["Prezime"].HeaderText = @"Prezime (Naziv2)";
            main.dgvTransakcije.Columns["Prezime"].Width = 200;

            main.dgvTransakcije.Columns["DatumOd"].HeaderText = @"Datum otvaranja";
            main.dgvTransakcije.Columns["DatumOd"].Width = 120;
            main.dgvTransakcije.Columns["DatumOd"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            main.dgvTransakcije.Columns["DatumOd"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            
            main.dgvTransakcije.Columns["DatumOd"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss";
            
            main.dgvTransakcije.Columns["DatumDo"].HeaderText = @"Datum zatvaranja";
            main.dgvTransakcije.Columns["DatumDo"].Width = 120;
            main.dgvTransakcije.Columns["DatumDo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            main.dgvTransakcije.Columns["DatumDo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            main.dgvTransakcije.Columns["DatumDo"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss";

            main.dgvTransakcije.Columns["BrojVrecica"].HeaderText = @"Broj vrečica";
            main.dgvTransakcije.Columns["BrojVrecica"].Width = 100;
            main.dgvTransakcije.Columns["BrojVrecica"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            main.dgvTransakcije.Columns["BrojVrecica"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            main.dgvTransakcije.Columns["Kartica"].HeaderText = @"Broj kartice";
            main.dgvTransakcije.Columns["Kartica"].Width = 100;
            main.dgvTransakcije.Columns["Kartica"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            main.dgvTransakcije.Columns["Kartica"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            return main;
        }
    }
}
