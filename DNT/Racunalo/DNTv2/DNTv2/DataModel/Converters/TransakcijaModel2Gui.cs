using System;
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

            service.Refresh();
            return main;
        }

        public UserControl Convert2UserControl()
        {
            throw new System.NotImplementedException();
        }
    }
}
