using System;
using System.Windows.Forms;
using DNTv2.DataModel.Services;

namespace DNTv2.DataModel.Converters
{
    public class TransakcijaModel2Gui : IModel2Gui
    {
        public Form Convert2Form(AbstractModelService modelService)
        {
            TransakcijeModelService service = (TransakcijeModelService) modelService;

            frmMain main = new frmMain {dataGridView1 = {DataSource = service.bindingSource}};
            main.lblPraznjenjeTrezora.LinkClicked += delegate
            {
                main.dataGridView1.Height = 1000;
            };

            service.Refresh();
            return main;
        }

        public UserControl Convert2UserControl(AbstractModelService modelService)
        {
            throw new System.NotImplementedException();
        }
    }
}
