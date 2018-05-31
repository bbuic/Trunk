using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using BikeService;
using BikeService.DataBase;
using BikeService.DataBase.DataServices;
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

            BindingList<Tuple<string, string>> komande = new BindingList<Tuple<string, string>>();
            dgvReciveCommands.DataSource = komande;

            serverHandlerMock.DogadajServisa += delegate(Event dogadaj)
            {
                events.Add(dogadaj);

                if (dogadaj.EventType == EventType.CanReadCommand)
                {
                    foreach (var msg in dogadaj.MessageList)
                    {
                        string s = null;                        
                        komande.Add(new Tuple<string, string>(msg.ID.ToString("X"), ByteArrayToString(msg.DATA)));
                    }
                    
                }
            };

            serverHandlerMock.PilonStatus += delegate(List<DockingModel> list)
            {
                dgvDokinzi.DataSource = list;
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
        }

        public static string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }
    }
}
