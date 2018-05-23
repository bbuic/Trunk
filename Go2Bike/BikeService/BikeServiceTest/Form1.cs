using System;
using System.Linq;
using System.Windows.Forms;
using BikeService.Objects;
using BikeService.Objects.ObjectHandlers;

namespace BikeServiceTest
{
    public partial class Form1 : Form
    {
        private PilonHandler _pilonHandler;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _pilonHandler = new PilonHandler {Test = true};

            dgvDokinzi.DataSource = _pilonHandler.Dockings;

            EventHandler dgvDokinziOnSelectionChanged = delegate
            {
                if(dgvDokinzi.SelectedRows.Count > 0)
                {
                    var model = dgvDokinzi.SelectedRows[0].DataBoundItem as DockingModel;
                    if (model != null)
                    {
                        dgvReciveCommands.DataSource = model.ReciveCommands;
                        dgvSendCommands.DataSource = model.SendCommands;
                    }
                }
            };
            dgvDokinzi.SelectionChanged += dgvDokinziOnSelectionChanged;
            dgvDokinziOnSelectionChanged(null, null);

            //_pilonHandler.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _pilonHandler.HandleCanMessage(new TPCANMsg{ID = 0x03, LEN = 1, DATA = new byte[]{0x00}});
        }
    }
}
