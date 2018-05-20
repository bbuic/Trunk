using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using BikeService.Properties;
using Microsoft.ServiceBus.Messaging;

namespace BikeService.Objects.ObjectHandlers
{
    public class PilonHandler
    {
        private PcanHandler _pcanHandler;
        private readonly List<DockingHandler> _dockings = new List<DockingHandler>();

        private static Timer _timerCan;        
        private readonly Queue<TPCANMsg> _queue = new Queue<TPCANMsg>();

        public void Start()
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += delegate(object sender, UnhandledExceptionEventArgs args)
                {
                    //ObjectFactory.LogDataService.Write((Exception) args.ExceptionObject);
                };

                ObjectFactory.EventDataService.Insert(EventType.PilonInit, EventCategory.Info, "Pokrenuta inicjalizacija servisa pilona.");
                
                _pcanHandler = new PcanHandler();
                if(!_pcanHandler.InitCan())
                    throw new Exception("Greška u inicjalizaciji CANa");

                //TODO: provjeriti dali treba ovaj restart???
                foreach (var docking in ObjectFactory.DockingDataService.SelectAll())
                    ((DockingHandler) docking).WriteCanCommand(CanSendCommands.Reset);
                ObjectFactory.DockingDataService.DeleteAll();

                if (_timerCan == null)
                    _timerCan = new Timer(_ => ObradiPodatkeCana());
            
                _pcanHandler.HandleCanMessage += delegate(TPCANMsg msg, TPCANTimestamp stamp){
                    _timerCan.Change(100, Timeout.Infinite);
                    _queue.Enqueue(msg);
                };
                
                #region Service BUS  

                QueueClient queueClient;
                try
                {
                    queueClient = QueueClient.CreateFromConnectionString(Settings.Default.ServiceBusConnString, "ServerQueue");
                }
                catch (Exception e)
                {
                    throw new Exception($"Greška u procesu inicjalizacije ServiceBus-a uređaja. Razlog: {e.Message}, StackTrace: {e.StackTrace}");
                }
                queueClient.OnMessage(receivedMessage =>
                {
                    try
                    {
                        var serverMsg = (ServerMessage) Utils.DeSerialize(receivedMessage.GetBody<string>(new DataContractSerializer(typeof(string))));

                        ObjectFactory.EventDataService.Insert(EventType.ServerRequest, 
                            EventCategory.Info, $"Akcija {serverMsg.MessageType.ToString()}, PilonID {serverMsg.PilonId}");

                        if (serverMsg.MessageType == MessageType.ResetAll)
                        {
                            ResetAllDockings();
                            return;
                        }

                        var dock = _dockings.FirstOrDefault(x => x.Id == serverMsg.PilonId);
                        if (dock != null)
                        {
                            switch (serverMsg.MessageType)
                            {
                                case MessageType.Unlock:
                                    dock.WriteCanCommand(CanSendCommands.ServisniMod);
                                    dock.WriteCanCommand(CanSendCommands.Open);
                                    break;

                                case MessageType.Reset:
                                    dock.WriteCanCommand(CanSendCommands.Reset);
                                    break;

                                case MessageType.Block:
                                    dock.WriteCanCommand(CanSendCommands.Block);
                                    break;

                                case MessageType.Status:
                                    //vraćanje statusa na server
                                    break;
                            }
                        }
                        else
                        {
                            //log na server
                        }
                        receivedMessage.Complete();
                    }
                    catch (Exception e)
                    {                        
                        ObjectFactory.EventDataService.Insert(EventType.ServerRequest,
                            EventCategory.Error, $"Greška u procesu obrade server requesta. Razlog: {e.Message}");
                        receivedMessage.Abandon();
                    }
                });

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
            foreach (var docking in _dockings)
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
                    var dock = _dockings.FirstOrDefault(x => x.Id == dockId);
                    if (dock == null)
                    {
                        dock = new DockingHandler(_pcanHandler) { Id = dockId };
                        _dockings.Add(dock);
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
