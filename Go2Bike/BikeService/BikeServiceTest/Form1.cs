using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using BikeService.Objects;
using BikeService.Objects.ObjectHandlers;
using BikeServiceTest.Mock;

namespace BikeServiceTest
{
    public partial class Form1 : Form
    {
        private PilonHandler _pilonHandler;
        readonly PcanHandlerMock _pcanHandlerMock = new PcanHandlerMock();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            _pilonHandler = new PilonHandler {Test = true, PcanHandler = _pcanHandlerMock};

            var source = new BindingSource();
            source.DataSource = _pilonHandler.Dockings;
            dgvDokinzi.DataSource = source;

            source.DataSourceChanged += delegate
            {
                if (dgvDokinzi.SelectedRows.Count > 0)
                {
                    var model = dgvDokinzi.SelectedRows[0].DataBoundItem as DockingModel;
                    if (model != null)
                    {
                        dgvReciveCommands.DataSource = model.ReciveCommands;
                        dgvSendCommands.DataSource = model.SendCommands;
                    }
                }
            };

            _pilonHandler.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _pcanHandlerMock.PosaljiPoruku(new TPCANMsg { ID = 0x03, LEN = 1, DATA = new byte[] { 0x00 } });            
        }
    }
}
