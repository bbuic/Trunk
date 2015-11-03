using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DNTv2.DataModel.Services;

namespace DNTv2.DataModel.Converters
{
    public class TransakcijaModel2Gui : IModel2Gui
    {
        public Form Convert2Form()
        {
            TransakcijeModelService service = new TransakcijeModelService();

            frmMain main = new frmMain { dataGridView1 = {DataSource = service.bindingSource} };
            main.lblPraznjenjeTrezora.LinkClicked += delegate
            {
                if (MessageBox.Show(@"Jeste sigurni da želite ispraznuti trezor?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ObjectFactory.TransakcijaDataService.IsprazniTrezor();
                }
            };

            main.lblAdministracijaKorisnika.LinkClicked += delegate
            {
                new KorisnikModel2Gui().Convert2Form().ShowDialog();
            };

            service.bindingSource.ListChanged +=
                            delegate(object sender, ListChangedEventArgs e)
                            {
                                switch (e.ListChangedType)
                                {
                                    case ListChangedType.ItemChanged:
                                        main.lbBrojVrecica.Text = ((IList<TransakcijeModel>)service.bindingSource.List).Sum(x => x.BrojVrecica).ToString();
                                        break;
                                }
                            };

            service.Refresh();
            return main;
        }

        public UserControl Convert2UserControl()
        {
            throw new System.NotImplementedException();
        }
    }
}
