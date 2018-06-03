using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using BikeService.DataBase;
using BikeService.Properties;
using Microsoft.ServiceBus.Messaging;

namespace BikeService.Objects.ObjectHandlers
{
    public class PilonHandler
    {        
        public IPcanHandler PcanHandler;
        public List<DockingHandler> Dockings = new List<DockingHandler>();
        
        private static Timer _timerCan;        
        private static Timer _timerServer;        
        private readonly Queue<TPCANMsg> _queue = new Queue<TPCANMsg>();
        
        public void Start()
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += delegate (object sender, UnhandledExceptionEventArgs args)
                {
                    //ObjectFactory.LogDataService.Write((Exception) args.ExceptionObject);
                };

                ObjectFactory.EventDataService.Insert(new Event(EventType.PilonInit, EventCategory.Cloud, "Pokrenuta inicjalizacija servisa pilona."));

                if(PcanHandler == null)
                    PcanHandler = new PcanHandler();
                if (!PcanHandler.InitCan())
                    throw new Exception("Greška u inicjalizaciji CANa");

                if (_timerCan == null)
                    _timerCan = new Timer(_ => ObradiPodatkeCana());

                if (_timerServer == null)
                {
                    _timerServer = new Timer(delegate
                    {
                        ObjectFactory.ServerHandler.SendEvent();
                        ObjectFactory.ServerHandler.SendPilonStatus(Dockings.Cast<DockingModel>().ToList());
                    });
                    _timerServer.Change(0, 2000);
                }

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

                ObjectFactory.ServerBusHandler.ServerBusMsg += delegate(ServerMessage serverMsg)
                {
                    try
                    {
                        if (serverMsg.MessageType == MessageType.ResetAll)
                        {
                            ResetAllDockings();
                            ObjectFactory.EventDataService.Insert(new Event(EventType.ServerRequest,
                                EventCategory.Info, $"Akcija {serverMsg.MessageType.ToString()}, PilonID {serverMsg.DockingId}"));
                            return;
                        }

                        var dock = Dockings.FirstOrDefault(x => x.Id == serverMsg.DockingId);
                        if (dock != null)
                        {
                            ObjectFactory.EventDataService.Insert(
                                new Event(EventType.ServerRequest, EventCategory.Info, $"Akcija {serverMsg.MessageType.ToString()}, PilonID {serverMsg.DockingId}"){ DockingId = dock.Id });

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
                                    dock.WriteCanCommand(CanSendCommands.ServisniMod);
                                    break;

                                case MessageType.Status:
                                    //vraćanje statusa na server
                                    break;
                            }
                        }
                        else
                        {
                            ObjectFactory.EventDataService.Insert(new Event(EventType.ServerRequest,
                                EventCategory.Error, $"Nepoznat pilonId {serverMsg.DockingId}, tražena akcija {serverMsg.MessageType.ToString()}"));
                        }                        
                    }
                    catch (Exception e)
                    {
                        ObjectFactory.EventDataService.Insert(new Event(EventType.ServerRequest,
                            EventCategory.Error, $"Greška u procesu obrade server requesta. Razlog: {e.Message}"));                        
                    }
                };
         
                #endregion

                ObjectFactory.EventDataService.Insert(new Event(EventType.PilonInit, EventCategory.Info, "Završena inicjalizacija servisa pilona."));
            }
            catch (Exception e)
            {
                ObjectFactory.EventDataService.Insert(new Event(EventType.PilonInit,
                    EventCategory.Fatal, $"Greška u procesu inicjalizacije pilona. Razlog: {e.Message}"));
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

                    if (msg.ID <= 0 || msg.DATA == null || msg.DATA.Length <= 0)
                        return;

                    uint dockId = Utils.RemoveFirstBit(msg.ID);
                    var dock = Dockings.FirstOrDefault(x => x.Id == dockId);
                    if (dock == null)
                    {
                        if(msg.DATA[0] != (int) CanReciveCommands.Hello)
                            return;

                        dock = new DockingHandler(PcanHandler) { Id = dockId};                        
                        Dockings.Add(dock);
                    }
                    dock.EventHandler.NewMessage(msg);                    
                }
            }
            catch (Exception e)
            {
                ObjectFactory.EventDataService.Insert(new Event(EventType.CanReadCommand,
                    EventCategory.Error, $"Greška u procesu obrade podatka CANa. Razlog: {e.Message}"));
            }
        }       
    }
}
