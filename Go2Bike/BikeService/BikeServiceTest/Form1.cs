using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using BikeService;
using BikeService.DataBase;
using BikeService.Objects;
using BikeService.Objects.ObjectHandlers;
using BikeServiceTest.Mock;

namespace BikeServiceTest
{
    
    public partial class Form1 : Form
    {
        private PilonHandler _pilonHandler;
        private PcanHandlerMock _pcanHandlerMock;
        private readonly SynchronizationContext _syncContext;
        
        public Form1()
        {
            InitializeComponent();
            _syncContext = SynchronizationContext.Current;

            Shown += delegate { Init(); };      
        }

        private void Init()
        {
            ObjectFactory.EventDataService = new EventDataServiceMock();
            ObjectFactory.ServerHandler = new ServerHandlerMock();
            ObjectFactory.ServerBusHandler = new ServerBusHandlerMock();
            var serverHandlerMock = (ServerHandlerMock) ObjectFactory.ServerHandler;
            serverHandlerMock.SyncContext = _syncContext;

            _pcanHandlerMock = new PcanHandlerMock();
            _pilonHandler = new PilonHandler {PcanHandler = _pcanHandlerMock};

            dgvDokinzi.DataSource = new List<DockingModel>();
            dgvDokinzi.Columns["DatumUkljucivanja"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss";
            dgvDokinzi.Columns["DatumUkljucivanja"].Width = 120;
            dgvDokinzi.CurrentCellChanged += delegate
            {
                if (dgvDokinzi.CurrentRow != null)
                    dgvDokinzi.Rows[dgvDokinzi.CurrentRow.Index].Selected = true;                
            };
            var events = new BindingList<Event>();
            dgvEvents.DataSource = events;
            dgvEvents.Columns["SendTime"].Visible = false;
            dgvEvents.Columns["EventDateTime"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss.fff";            
            dgvEvents.Columns["EventDateTime"].Width = 150;
            dgvEvents.Columns["Opis"].Width = 300;

            var reciveKomande = new BindingList<Tuple<string, string>>();
            dgvReciveCommands.DataSource = reciveKomande;
            dgvReciveCommands.Columns[0].HeaderText = @"ID";
            dgvReciveCommands.Columns[1].HeaderText = @"Recive cmd";
            dgvReciveCommands.Columns[1].Width = 150;

            var sendKomande = new BindingList<Tuple<string, string>>();
            dgvSendCommands.DataSource = sendKomande;
            dgvSendCommands.Columns[0].HeaderText = @"ID";
            dgvSendCommands.Columns[1].HeaderText = @"Send cmd";

            serverHandlerMock.DogadajServisa += delegate(Event dogadaj)
            {
                events.Add(dogadaj);
                dgvEvents.DataSource = events.OrderByDescending(x=>x.LocalId).ToList();

                if (dogadaj.EventType == EventType.CanReadCommand)
                {
                    if (dogadaj.MessageList != null)
                    {
                        foreach (var msg in dogadaj.MessageList)
                        {
                            string s = null;                        
                            reciveKomande.Add(new Tuple<string, string>(msg.ID.ToString("X"), ByteArrayToString(msg.DATA)));
                        }
                    }                    
                }

                if (dogadaj.EventType == EventType.CanWriteCommand)
                {
                    foreach (var msg in dogadaj.MessageList)
                    {
                        string s = null;
                        sendKomande.Add(new Tuple<string, string>(msg.ID.ToString("X"), ByteArrayToString(msg.DATA)));
                    }
                    if (dogadaj.MessageList.Any(x => x.DATA[0].Equals(0x7B)))
                    {
                        _pcanHandlerMock.PosaljiPoruku(new TPCANMsg { ID = Utils.AddFirstBit(dogadaj.DockingId.Value), LEN = 8, DATA = new byte[] { 0x7C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 } });
                        _pcanHandlerMock.PosaljiPoruku(new TPCANMsg { ID = Utils.AddFirstBit(dogadaj.DockingId.Value), LEN = 8, DATA = new byte[] { 0x7C, 0x01, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00 } });
                    }
                }
            };

            serverHandlerMock.PilonStatus += delegate(List<DockingModel> list)
            {
                int index = 0;
                if (dgvDokinzi.SelectedRows.Count > 0 && dgvDokinzi.CurrentRow != null)
                    index = dgvDokinzi.CurrentRow.Index;
                dgvDokinzi.DataSource = list;
                if (index < dgvDokinzi.Rows.Count)
                {
                    dgvDokinzi.Rows[index].Selected = true;
                    dgvDokinzi.CurrentCell = dgvDokinzi[1, index];
                }
                lblRefresh.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            };
            
            _pilonHandler.Start();
        }
        
        public static string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }

        private void btnRfidKartica_Click(object sender, EventArgs e)
        {
            _pcanHandlerMock.PosaljiPoruku(new TPCANMsg { ID = Utils.AddFirstBit(Convert.ToUInt32(numericUpDown1.Text)), LEN = 8, DATA = new byte[] { 0x77, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 } });
            _pcanHandlerMock.PosaljiPoruku(new TPCANMsg { ID = Utils.AddFirstBit(Convert.ToUInt32(numericUpDown1.Text)), LEN = 8, DATA = new byte[] { 0x77, 0x01, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00 } });
        }

        private void btnBikeTag_Click(object sender, EventArgs e)
        {
            _pcanHandlerMock.PosaljiPoruku(new TPCANMsg { ID = Utils.AddFirstBit(Convert.ToUInt32(numericUpDown1.Text)), LEN = 8, DATA = new byte[] { 0x75, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 } });            
        }

        private void btnHello_Click(object sender, EventArgs e)
        {
            _pcanHandlerMock.PosaljiPoruku(new TPCANMsg { ID = Utils.AddFirstBit(Convert.ToUInt32(numericUpDown1.Text)), LEN = 1, DATA = new byte[] { 0x00 } });
        }

        private void ServerPilonHandler(object sender, EventArgs e)
        {
            if (dgvDokinzi.CurrentRow == null)
            {
                MessageBox.Show(@"Niste odabrali doking na kojeg želite poslati poruku");
                return;
            }
            var id = ((DockingModel) dgvDokinzi.CurrentRow.DataBoundItem).Id;
            var handlerMock = (ServerBusHandlerMock)ObjectFactory.ServerBusHandler;
            switch (((Button)sender).Text)
            {
                case "Unlock":
                    handlerMock.SendMessage(new ServerMessage { DockingId = id, MessageType = MessageType.Unlock });
                    break;
                case "Reset":
                    handlerMock.SendMessage(new ServerMessage { DockingId = id, MessageType = MessageType.Reset });
                    break;
                case "Block":
                    handlerMock.SendMessage(new ServerMessage { DockingId = id, MessageType = MessageType.Block });
                    break;
               default:
                    MessageBox.Show(@"Nepoznata akcija");
                    break;
            }
        }                
    }
}
