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
        private Timer _timerRefresh;

        public Form Convert2Form()
        {
            TransakcijeModelService service = new TransakcijeModelService();

            frmMain main = new frmMain { dgvTransakcije = {DataSource = service.bindingSource}, dgvDogadaj = {DataSource = service.bindingSourceDogadaj}};            
            main.dgvTransakcije.SelectionChanged += delegate { main.dgvTransakcije.ClearSelection(); };
        
            //Pražnjenje trezora
            main.lblPraznjenjeTrezora.LinkClicked += delegate
            {       
                //if (main.TransakcijaUTijeku)
                //{
                //    MessageBox.Show(@"Nije moguće izvršiti pražnjenje trezora jer je transakcija u tijeku.", "", MessageBoxButtons.OK,
                //        MessageBoxIcon.Information);
                //    return;
                //}

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
                    service.Refresh();
                }
            };

            main.lblDatumPraznjenjaTrezora.Text =
                ObjectFactory.TransakcijaDataService.ZadnjePraznjenjeTrezora().ToString("dd.MM.yyyy HH:mm:ss");

            //Administracija korisnika
            main.lblAdministracijaKorisnika.LinkClicked += delegate{
                    try
                    {
                        new KorisnikModel2Gui().Convert2Form().ShowDialog(main);
                        service.Refresh();
                    }
                    catch (Exception e)
                    {
                        Utils.Log(e);

                        MessageBox.Show(@"Došlo je do nepredviđene greške u dijelu administracije korisnika. " +
                            @"Vrijeme greške: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") +
                            @", Opis greške: " + e.Message,
                            "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            };

            //Pretraživanje transakcija
            main.lblPretragaTransakcija.LinkClicked += delegate
            {
                try
                {
                    service.PretrazivanjeUTijeku = true;
                    main.dgvTransakcije.Height = main.dgvTransakcije.Height - main.gbPretragaTransakcija.Height - 5;
                    main.grbMainIzbornik.Enabled = false;
                    main.dtpDatumDo.Value = DateTime.Now;
                    main.dtpDatumOd.Value = DateTime.Now.AddDays(-1);
                    service.bindingSource.DataSource =
                        ObjectFactory.TransakcijaDataService.DajTransakcije(main.dtpDatumOd.Value, main.dtpDatumDo.Value).
                            Select(transakcija => new TransakcijeModel { Transakcija = transakcija }).ToList();
                }
                catch (Exception e)
                {
                    Utils.Log(e);

                    MessageBox.Show(@"Došlo je do nepredviđene greške u dijelu pretraživanja transakcija. " +
                        @"Vrijeme greške: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") +
                        @", Opis greške: " + e.Message,
                        "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                service.PretrazivanjeUTijeku = false;
                main.dgvTransakcije.Height = main.panel2.Height;
                main.grbMainIzbornik.Enabled = true;
                service.Refresh();
            };

            main.linkLabel1.Click += delegate { service.Refresh(); };

            main.btnPrint.Click += delegate
            {
                service.bindingSource.DataSource = ObjectFactory.TransakcijaDataService.DajTransakcije(main.dtpDatumOd.Value, main.dtpDatumDo.Value).
                    Select(transakcija => new TransakcijeModel { Transakcija = transakcija }).ToList();

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
                main.dgvTransakcije.Height = main.panel2.Height;
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

            main.dgvDogadaj.Columns["Id"].Visible = false;
            main.dgvDogadaj.Columns["DatumOd"].HeaderText = @"Vrijeme početka događaja";
            main.dgvDogadaj.Columns["DatumOd"].Width = 250;
            main.dgvDogadaj.Columns["DatumOd"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            main.dgvDogadaj.Columns["DatumOd"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            main.dgvDogadaj.Columns["DatumDo"].Visible = false;
            main.dgvDogadaj.Columns["Naziv"].HeaderText = @"Naziv događaja";
            main.dgvDogadaj.Columns["Naziv"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            main.dgvDogadaj.SelectionChanged += delegate { main.dgvDogadaj.ClearSelection(); };

            _timerRefresh = new Timer { Interval = int.Parse(Utils.ReadSetting("TimerRefresh")) * 1000 };
            _timerRefresh.Tick += delegate
            {
                service.Refresh();
            };
            _timerRefresh.Start();

            return main;
        }

        
    }
}
