using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            main.lblPraznjenjeTrezora.LinkClicked += delegate
            {
                if (MessageBox.Show(@"Želite isprintati trezorsku knjigu ?", "", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                    new frmReportViewer().ShowDialog(main);

                if (MessageBox.Show(@"Jeste sigurni da želite ispraznuti trezor?", "", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    ObjectFactory.TransakcijaDataService.IsprazniTrezor();
            };

            main.lblAdministracijaKorisnika.LinkClicked += delegate
            {
                new KorisnikModel2Gui().Convert2Form().ShowDialog(main);
            };

            main.lblPretragaTransakcija.LinkClicked += delegate
            {
                main.dgvTransakcije.Height = main.dgvTransakcije.Height - main.gbPretragaTransakcija.Height;
            };

            main.btnPrint.Click += delegate { new frmReportViewer().ShowDialog(main); };

            service.bindingSource.ListChanged +=
                            delegate(object sender, ListChangedEventArgs e)
                            {
                                switch (e.ListChangedType)
                                {
                                    case ListChangedType.ItemChanged:
                                    case ListChangedType.ItemAdded:
                                    case ListChangedType.ItemDeleted:
                                        main.lbBrojVrecica.Text = ((IList<TransakcijeModel>)service.bindingSource.List).Sum(x => x.BrojVrecica).ToString();
                                        break;
                                }
                            };

            main.lblDatumPraznjenjaTrezora.Text = ObjectFactory.TransakcijaDataService.ZadnjePraznjenjeTrezora().ToString(CultureInfo.CurrentCulture);
            
            service.Refresh();
            return main;
        }

        public UserControl Convert2UserControl()
        {
            throw new System.NotImplementedException();
        }
    }
}
