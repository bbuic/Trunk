using System;
using System.Collections.Generic;
using System.Threading;
using BikeService.DataBase;
using BikeService.Events;
using BikeService.Events.EventHandlers;

namespace BikeService.Objects.ObjectHandlers
{
    public class DockingHandler:DockingModel
    {        
        private Timer _timerPresence;
        private readonly IPcanHandler _pcanHandler;        
        private readonly Queue<AbstractEvent> _queue = new Queue<AbstractEvent>();
        private readonly Timer _timerEvent;

        public AbstractEventHandler EventHandler;
        
        public DockingHandler(IPcanHandler handler)
        {
            _pcanHandler = handler;
            
            AbstractEventHandler eventHandler4 = new GenericEventHandler(CanReciveCommands.Status,  4, EventHandlerOnObradiEvent, null, typeof(StatusEvent));
            AbstractEventHandler eventHandler3 = new GenericEventHandler(CanReciveCommands.State,  2, EventHandlerOnObradiEvent, eventHandler4, typeof(StateEvent));
            AbstractEventHandler eventHandler2 = new GenericEventHandler(CanReciveCommands.BikeTag,  1, EventHandlerOnObradiEvent, eventHandler3, typeof(BikeTagEvent));
            AbstractEventHandler eventHandler1 = new GenericEventHandler(CanReciveCommands.RfidTag,  2, EventHandlerOnObradiEvent, eventHandler2, typeof(RfidTagEvent));
            EventHandler = new GenericEventHandler(CanReciveCommands.Hello,  1, EventHandlerOnObradiEvent, eventHandler1);

            if (_timerEvent == null)
                _timerEvent = new Timer(_ => ObradiPoruku());            
        }

        private void ObradiPoruku()
        {
            while (_queue.Count > 0)
            {
                var msg = _queue.Dequeue();
                
                ObjectFactory.EventDataService.Insert(new Event(EventType.CanReadCommand, EventCategory.Info, msg.EventType.ToString()){MessageList = msg.List, DockingId = Id});

                if (!DatumUkljucivanja.HasValue && msg.EventType != CanReciveCommands.Hello && msg.EventType != CanReciveCommands.State)
                {
                    WriteCanCommand(CanSendCommands.Reset);
                    return; //ako pilon još nije uključen (nije došla poruka Hello ne dozvoljavamo druge poruke) i resetiramo dock!!
                }

                switch (msg.EventType)
                {
                    case CanReciveCommands.Hello:
                        if (DatumUkljucivanja.HasValue && (DateTime.Now - DatumUkljucivanja.Value).TotalSeconds < 5)
                        {
                            ObjectFactory.EventDataService.Insert(new Event(EventType.CanReadCommand, EventCategory.Fatal, "Dva pilona sa istim IDjem su se prijavila unutar 5 sec."));
                            return;
                        }

                        DatumUkljucivanja = null;
                        IsInit = false;
                        
                        WriteCanCommand(CanSendCommands.HelloResponse);
                        WriteCanCommand(CanSendCommands.WorkWithServer);
                        WriteCanCommand(CanSendCommands.Status);    
                        break;

                    case CanReciveCommands.State:
                        var state = (StateEvent)msg;
                        SwitchState = state.SwitchState;

                        if (!IsInit)
                        {
                            ObjectFactory.EventDataService.Insert(new Event(EventType.NewDocking, EventCategory.Info, $"Novi docking ID {Id}") { DockingId = Id });
                            ObjectFactory.DockingDataService.Insert(this);

                            if (_timerPresence == null)
                                _timerPresence = new Timer(delegate
                                {
                                    _pcanHandler.Write(CanSendCommands.Presence.GetMsg(Id));
                                });
                            _timerPresence.Change(0, Properties.Settings.Default.PresencePeriod);

                            DatumUkljucivanja = DateTime.Now;
                            IsInit = true;
                        }
                        break;

                    case CanReciveCommands.BikeTag:                        
                        var tagEventHandler = (BikeTagEvent) msg;

                        if(Tag.HasValue && Tag == tagEventHandler.BikeTag || !IsInit)
                            return;

                        if (IsLocked)
                        {
                            ObjectFactory.EventDataService.Insert(new Event(EventType.CanReadCommand, EventCategory.Error, 
                                $"Bike tag na zaključanom dokingu. Biketag: {tagEventHandler.BikeTag}"));
                            return;
                        }
                        
                        Tag = tagEventHandler.BikeTag;
                        
                        if(ObjectFactory.ServerHandler.ValidateBikeTag(Tag.Value, Id))
                            WriteCanCommand(CanSendCommands.BikeTagAck);
                        //TODO: vidjeti šta u slučaju kad nije validan?? Ivan...
                        break;

                    case CanReciveCommands.RfidTag:
                        var rfid = (RfidTagEvent)msg;
                        if (ObjectFactory.ServerHandler.ValidateRfidTag(rfid.RfidTag, Id))
                        {
                            WriteCanCommand(CanSendCommands.RfidTagAckOk);
                            WriteCanCommand(CanSendCommands.ServisniMod);
                            WriteCanCommand(CanSendCommands.Open);
                        }
                        else
                            WriteCanCommand(CanSendCommands.RfidTagAckCancel);
                        break;
                        
                    case CanReciveCommands.Status:
                        var status = (StatusEvent)msg;
                        
                        break;

                    default:
                        ObjectFactory.EventDataService.Insert(new Event(EventType.CanReadCommand, EventCategory.Error, $"Nepostojeća komanda {msg.EventType.ToString()}"));
                        WriteCanCommand(CanSendCommands.Reset);
                        break;
                }
            }
        }
        
        private void EventHandlerOnObradiEvent(AbstractEvent dogadaj)
        {
            _timerEvent.Change(100, Timeout.Infinite);
            _queue.Enqueue(dogadaj);
        }

        internal void WriteCanCommand(CanSendCommand cmd)
        {            
            _pcanHandler.Write(cmd.GetMsg(Id));            
            ObjectFactory.EventDataService.Insert(
                new Event(EventType.CanWriteCommand, EventCategory.Info, cmd.CommandName){AddMessage = cmd.GetMsg(Id), DockingId = Id});
        }
    }
}
