using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using BikeService.Properties;
using Microsoft.ServiceBus.Messaging;

namespace BikeService.Objects.ObjectHandlers
{
    public class PilonHandler
    {
        public bool Test { get; set; }
        public IPcanHandler PcanHandler;
        public BindingList<DockingHandler> Dockings = new BindingList<DockingHandler>();

        private static Timer _timerCan;        
        private readonly Queue<TPCANMsg> _queue = new Queue<TPCANMsg>();

        public void Start()
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += delegate (object sender, UnhandledExceptionEventArgs args)
                {
                    //ObjectFactory.LogDataService.Write((Exception) args.ExceptionObject);
                };

                ObjectFactory.EventDataService.Insert(EventType.PilonInit, EventCategory.Cloud, "Pokrenuta inicjalizacija servisa pilona.");

                if(PcanHandler == null)
                    PcanHandler = new PcanHandler();
                if (!PcanHandler.InitCan())
                    throw new Exception("Greška u inicjalizaciji CANa");

                if (_timerCan == null)
                    _timerCan = new Timer(_ => ObradiPodatkeCana());

                //TODO: provjeriti dali treba ovaj restart??? 
                //(namjena bi bila da kao se servis restarta da se ne čeka da se dokovi sami restartaju već da ih prisilno restartamo)
                foreach (var docking in ObjectFactory.DockingDataService.SelectAll())
                    ((DockingHandler)docking).WriteCanCommand(CanSendCommands.Reset);
                ObjectFactory.DockingDataService.DeleteAll();

                PcanHandler.HandleCanMessage += delegate (TPCANMsg msg, TPCANTimestamp stamp) {
                    _timerCan.Change(100, Timeout.Infinite);
                    _queue.Enqueue(msg);
                };

                #region Service BUS  

                //QueueClient queueClient;
                //try
                //{
                //    queueClient = QueueClient.CreateFromConnectionString(Settings.Default.ServiceBusConnString, "BojanQueue");
                //}
                //catch (Exception e)
                //{
                //    throw new Exception($"Greška u procesu inicjalizacije ServiceBus-a uređaja. Razlog: {e.Message}, StackTrace: {e.StackTrace}");
                //}
                //queueClient.OnMessage(receivedMessage =>
                //{
                //    try
                //    {
                //        Stream stream = receivedMessage.GetBody<Stream>();

                //        string messageBody = "";

                //        using (TextReader reader = new StreamReader(stream, Encoding.UTF8))

                //        {

                //            messageBody = reader.ReadToEnd();

                //        }

                //        var body = receivedMessage.GetBody<string>(new DataContractSerializer(typeof(string)));

                //        var serverMsg = (ServerMessage) Utils.DeSerialize(body);
                        
                //        if (serverMsg.MessageType == MessageType.ResetAll)
                //        {
                //            ResetAllDockings();
                //            ObjectFactory.EventDataService.Insert(EventType.ServerRequest,
                //                EventCategory.Info, $"Akcija {serverMsg.MessageType.ToString()}, PilonID {serverMsg.DockingId}");
                //            return;
                //        }

                //        var dock = Dockings.FirstOrDefault(x => x.Id == serverMsg.DockingId);
                //        if (dock != null)
                //        {
                //            ObjectFactory.EventDataService.Insert(EventType.ServerRequest,
                //                EventCategory.Info, $"Akcija {serverMsg.MessageType.ToString()}, PilonID {serverMsg.DockingId}", dock.Id);

                //            switch (serverMsg.MessageType)
                //            {
                //                case MessageType.Unlock:
                //                    dock.WriteCanCommand(CanSendCommands.ServisniMod);
                //                    dock.WriteCanCommand(CanSendCommands.Open);
                //                    break;

                //                case MessageType.Reset:
                //                    dock.WriteCanCommand(CanSendCommands.Reset);
                //                    break;

                //                case MessageType.Block:
                //                    dock.WriteCanCommand(CanSendCommands.ServisniMod);
                //                    break;

                //                case MessageType.Status:
                //                    //vraćanje statusa na server
                //                    break;
                //            }
                //        }
                //        else
                //        {
                //            ObjectFactory.EventDataService.Insert(EventType.ServerRequest,
                //                EventCategory.Error, $"Nepoznat pilonId {serverMsg.DockingId}, akcija {serverMsg.MessageType.ToString()}");
                //        }
                //        receivedMessage.Complete();
                //    }
                //    catch (Exception e)
                //    {                        
                //        ObjectFactory.EventDataService.Insert(EventType.ServerRequest,
                //            EventCategory.Error, $"Greška u procesu obrade server requesta. Razlog: {e.Message}");
                //        receivedMessage.Abandon();
                //    }
                //});

                #endregion

                ObjectFactory.EventDataService.Insert(EventType.PilonInit, EventCategory.Info, "Završena inicjalizacija servisa pilona.");
            }
            catch (Exception e)
            {
                ObjectFactory.EventDataService.Insert(EventType.PilonInit,
                    EventCategory.Fatal, $"Greška u procesu inicjalizacije pilona. Razlog: {e.Message}");
            }
        }
        
        private void ResetAllDockings()
        {
            foreach (var docking in Dockings)
                docking.WriteCanCommand(CanSendCommands.Reset);
        }

        private void ObradiPodatkeCana()
        {
            try
            {
                while (_queue.Count > 0)
                {
                    var msg = _queue.Dequeue();

                    uint dockId = Utils.RemoveFirstBit(msg.ID);
                    var dock = Dockings.FirstOrDefault(x => x.Id == dockId);
                    if (dock == null)
                    {
                        dock = new DockingHandler(PcanHandler) { Id = dockId, Test = Test};
                        Dockings.Add(dock);
                    }
                    dock.EventHandler.NewMessage(msg);                    
                }
            }
            catch (Exception e)
            {
                ObjectFactory.EventDataService.Insert(EventType.CanReadCommand,
                    EventCategory.Error, $"Greška u procesu obrade podatka CANa. Razlog: {e.Message}");
            }
        }       
    }
}
