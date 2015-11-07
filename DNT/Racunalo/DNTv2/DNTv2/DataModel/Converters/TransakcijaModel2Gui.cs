using System;
using System.Collections.Generic;
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
                IList<TransakcijeModel> list = (IList<TransakcijeModel>)service.bindingSource.List;
                if(list.Count <= 0)
                    return;

                if (MessageBox.Show(@"Želite isprintati trezorsku knjigu ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {                    
                    new frmReportViewer(list).ShowDialog(main);
                }

                if (MessageBox.Show(@"Jeste sigurni da želite ispraznuti trezor?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ObjectFactory.TransakcijaDataService.IsprazniTrezor();
                    main.lblDatumPraznjenjaTrezora.Text =
                        ObjectFactory.TransakcijaDataService.ZadnjePraznjenjeTrezora().ToString("dd.MM.yyyy HH:mm:ss");
                }
            };

            main.lblDatumPraznjenjaTrezora.Text =
                ObjectFactory.TransakcijaDataService.ZadnjePraznjenjeTrezora().ToString("dd.MM.yyyy HH:mm:ss");

            //Administracija korisnika
            main.lblAdministracijaKorisnika.LinkClicked += delegate{
                new KorisnikModel2Gui().Convert2Form().ShowDialog(main);
            };

            //Pretraživanje transakcija
            main.lblPretragaTransakcija.LinkClicked += delegate
            {
                main.dgvTransakcije.Height = main.dgvTransakcije.Height - main.gbPretragaTransakcija.Height - 5;
                main.grbMainIzbornik.Enabled = false;
                main.dtpDatumDo.Value = DateTime.Now;
                main.dtpDatumOd.Value = DateTime.Now.AddDays(-7);
                service.bindingSource.DataSource =
                    ObjectFactory.TransakcijaDataService.DajTransakcije(main.dtpDatumOd.Value, main.dtpDatumDo.Value).
                    Select(transakcija => new TransakcijeModel { Transakcija = transakcija }).ToList();
            };

            main.dtpDatumDo.ValueChanged += delegate { main.dtpDatumOd.MaxDate = main.dtpDatumDo.Value; };
            main.dtpDatumOd.ValueChanged += delegate { main.dtpDatumDo.MinDate = main.dtpDatumOd.Value; };

            main.btnPretrazi.Click += delegate
            {
                service.bindingSource.DataSource =
                    ObjectFactory.TransakcijaDataService.DajTransakcije(main.dtpDatumOd.Value, main.dtpDatumDo.Value).
                    Select(transakcija => new TransakcijeModel { Transakcija = transakcija }).ToList();
            };

            main.btnPovratakIzPretrazivanja.Click += delegate
            {
                main.dgvTransakcije.Height = main.Panel1.Height;
                main.grbMainIzbornik.Enabled = true;
                service.Refresh();
            };
            
            main.btnPrint.Click += delegate
            {
                IList<TransakcijeModel> list = (IList<TransakcijeModel>)service.bindingSource.List;
                if (list.Count <= 0)
                {
                    MessageBox.Show(@"Nema transkacija za ispis.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;                    
                }
                new frmReportViewer(list).ShowDialog(main);
            };

            main.Load += delegate
            {
                main.dgvTransakcije.Height = main.Panel1.Height;
                main.Label14.Left = (main.grbInfo.Width - main.Label14.Width) / 2;
                main.Label35.Left = (main.grbInfo.Width - main.Label35.Width) / 2;
                main.lblDatumPraznjenjaTrezora.Left = (main.grbInfo.Width - main.lblDatumPraznjenjaTrezora.Width) / 2;
                main.lblDatumPraznjenjaTrezora.Left = (main.grbInfo.Width - main.lblDatumPraznjenjaTrezora.Width) / 2;
            };

            service.bindingSource.DataSourceChanged += delegate
            {
                main.lbBrojVrecica.Text = ObjectFactory.TransakcijaDataService.DajBrojVrecicaUTrezoru().ToString();
                main.lbBrojVrecica.Left = (main.grbInfo.Width - main.lbBrojVrecica.Width) / 2;
            };
            
            service.Refresh();

            main.dgvTransakcije.Columns["Transakcija"].Visible = false;
            main.dgvTransakcije.Columns["Trezor"].Visible = false;
            main.dgvTransakcije.Columns["ModelState"].Visible = false;
            
            main.dgvTransakcije.Columns["Ime"].HeaderText = @"Ime (Naziv1)";
            main.dgvTransakcije.Columns["Ime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            main.dgvTransakcije.Columns["Prezime"].HeaderText = @"Prezime (Naziv2)";
            main.dgvTransakcije.Columns["Prezime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            main.dgvTransakcije.Columns["DatumOd"].HeaderText = @"Datum otvaranja";
            main.dgvTransakcije.Columns["DatumOd"].Width = 150;
            main.dgvTransakcije.Columns["DatumOd"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            main.dgvTransakcije.Columns["DatumOd"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            
            main.dgvTransakcije.Columns["DatumOd"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss";
            
            main.dgvTransakcije.Columns["DatumDo"].HeaderText = @"Datum zatvaranja";
            main.dgvTransakcije.Columns["DatumDo"].Width = 150;
            main.dgvTransakcije.Columns["DatumDo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            main.dgvTransakcije.Columns["DatumDo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            main.dgvTransakcije.Columns["DatumDo"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss";

            main.dgvTransakcije.Columns["BrojVrecica"].HeaderText = @"Broj pologa";
            main.dgvTransakcije.Columns["BrojVrecica"].Width = 100;
            main.dgvTransakcije.Columns["BrojVrecica"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            main.dgvTransakcije.Columns["BrojVrecica"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            main.dgvTransakcije.Columns["Kartica"].HeaderText = @"Broj kartice";
            main.dgvTransakcije.Columns["Kartica"].Width = 120;
            main.dgvTransakcije.Columns["Kartica"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            main.dgvTransakcije.Columns["Kartica"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            return main;
        }
    }
}
