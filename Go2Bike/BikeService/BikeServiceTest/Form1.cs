using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        readonly PcanHandlerMock _pcanHandlerMock = new PcanHandlerMock();
        internal SynchronizationContext SyncContext;

        BindingList<Event> events = new BindingList<Event>();

        public Form1()
        {
            InitializeComponent();
            SyncContext = SynchronizationContext.Current;

            Shown += delegate { Init(); };      
        }

        private void Init()
        {
            ObjectFactory.EventDataService = new EventDataServiceMock();
            ObjectFactory.ServerHandler = new ServerHandlerMock();
            var serverHandlerMock = (ServerHandlerMock) ObjectFactory.ServerHandler;
            serverHandlerMock.SyncContext = SyncContext;

            _pilonHandler = new PilonHandler {PcanHandler = _pcanHandlerMock};
            dgvEvents.DataSource = events;
            dgvEvents.Columns["SendTime"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm:ss";
            dgvEvents.Columns["Opis"].Width = 300;
            dgvEvents.Columns["SendTime"].Width = 120;

            var reciveKomande = new BindingList<Tuple<string, string>>();
            dgvReciveCommands.DataSource = reciveKomande;
            dgvReciveCommands.Columns[0].HeaderText = @"ID";
            dgvReciveCommands.Columns[1].HeaderText = @"Recive cmd";

            var sendKomande = new BindingList<Tuple<string, string>>();
            dgvSendCommands.DataSource = sendKomande;
            dgvSendCommands.Columns[0].HeaderText = @"ID";
            dgvSendCommands.Columns[1].HeaderText = @"Send cmd";

            serverHandlerMock.DogadajServisa += delegate(Event dogadaj)
            {
                events.Add(dogadaj);

                if (dogadaj.EventType == EventType.CanReadCommand)
                {
                    foreach (var msg in dogadaj.MessageList)
                    {
                        string s = null;                        
                        reciveKomande.Add(new Tuple<string, string>(msg.ID.ToString("X"), ByteArrayToString(msg.DATA)));
                    }                    
                }

                if (dogadaj.EventType == EventType.CanWriteCommand)
                {
                    foreach (var msg in dogadaj.MessageList)
                    {
                        string s = null;
                        sendKomande.Add(new Tuple<string, string>(msg.ID.ToString("X"), ByteArrayToString(msg.DATA)));
                    }
                }
            };

            serverHandlerMock.PilonStatus += delegate(List<DockingModel> list)
            {
                dgvDokinzi.DataSource = list;
                lblRefresh.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            };
            
            _pilonHandler.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _pcanHandlerMock.PosaljiPoruku(new TPCANMsg { ID = 0x03, LEN = 1, DATA = new byte[] { 0x00 } });            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _pcanHandlerMock.PosaljiPoruku(new TPCANMsg { ID = 0x03, LEN = 8, DATA = new byte[] { 0x7C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 } });
            _pcanHandlerMock.PosaljiPoruku(new TPCANMsg { ID = 0x03, LEN = 8, DATA = new byte[] { 0x7C, 0x01, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00 } });
        }

        public static string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }
    }
}
