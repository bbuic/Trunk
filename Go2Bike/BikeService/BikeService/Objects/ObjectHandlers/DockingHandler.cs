using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading;
using BikeService.DataBase;
using BikeService.EventHandlers;

namespace BikeService.Objects.ObjectHandlers
{
    public class DockingHandler:DockingModel
    {        
        private Timer _timerPresence;
        private readonly IPcanHandler _pcanHandler;        
        private readonly Queue<AbstractEventHandler> _queue = new Queue<AbstractEventHandler>();
        private readonly Timer _timerEvent;

        public AbstractEventHandler EventHandler;

        public DockingHandler(IPcanHandler handler)
        {
            _pcanHandler = handler;

            AbstractEventHandler eventHandler4 = new StatusEventHandler(CanReciveCommands.Status,  4, 0x80, EventHandlerOnObradiEvent);
            AbstractEventHandler eventHandler3 = new StateEventHandler(CanReciveCommands.State,  2, 0x7C, EventHandlerOnObradiEvent, eventHandler4);
            AbstractEventHandler eventHandler2 = new BikeTagEventHandler(CanReciveCommands.BikeTag,  1, 0x75, EventHandlerOnObradiEvent, eventHandler3);
            AbstractEventHandler eventHandler1 = new RfidTagEventHandler(CanReciveCommands.RfidTag,  2, 0x77, EventHandlerOnObradiEvent, eventHandler2);
            EventHandler = new GenericEventHandler(CanReciveCommands.Hello,  1, 0x00, EventHandlerOnObradiEvent, eventHandler1);

            if (_timerEvent == null)
                _timerEvent = new Timer(_ => ObradiPoruku());
        }

        private void ObradiPoruku()
        {
            while (_queue.Count > 0)
            {
                var msg = _queue.Dequeue();
                
                ObjectFactory.EventDataService.Insert(new Event(EventType.CanReadCommand, EventCategory.Info, msg.CanReciveCommands.ToString()){MessageList = msg.List});

                if (!DatumUkljucivanja.HasValue && msg.CanReciveCommands != CanReciveCommands.Hello)
                {
                    WriteCanCommand(CanSendCommands.Reset);
                    return; //ako pilon još nije uključen (nije došla poruka Hello ne dozvoljavamo druge poruke) i resetiramo dock!!
                }

                switch (msg.CanReciveCommands)
                {
                    case CanReciveCommands.Hello:
                        if (DatumUkljucivanja.HasValue && (DateTime.Now - DatumUkljucivanja.Value).TotalSeconds < 5)
                            ObjectFactory.EventDataService.Insert(new Event(EventType.CanReadCommand, EventCategory.Fatal, "Dva pilona sa istim IDjem su se prijavila unutar 5 sec."));

                        DatumUkljucivanja = DateTime.Now;
                        IsInit = false;
                        
                        WriteCanCommand(CanSendCommands.HelloResponse);
                        WriteCanCommand(CanSendCommands.WorkWithServer);

                        if (_timerPresence == null)
                            _timerPresence = new Timer(delegate { _pcanHandler.Write(Id, CanSendCommands.Presence.Msg); });
                        _timerPresence.Change(Timeout.Infinite, Properties.Settings.Default.PresencePeriod);

                        WriteCanCommand(CanSendCommands.Status);    
                        break;

                    case CanReciveCommands.BikeTag:                        
                        var tagEventHandler = (BikeTagEventHandler) msg;

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
                        var rfid = (RfidTagEventHandler)msg;
                        if(ObjectFactory.ServerHandler.ValidateRfidTag(rfid.RfidTag, Id))
                            WriteCanCommand(CanSendCommands.ServisniMod);
                            WriteCanCommand(CanSendCommands.Open);
                        break;

                    case CanReciveCommands.State:
                        var state = (StateEventHandler)msg;
                        SwitchState = state.SwitchState;
                        if(!IsInit)
                        {
                            ObjectFactory.EventDataService.Insert(new Event(EventType.NewDocking, EventCategory.Info, $"Novi docking ID {Id}"));
                            ObjectFactory.DockingDataService.Insert(this);
                            IsInit = true;
                        }
                        break;

                    case CanReciveCommands.Status:
                        var status = (StatusEventHandler)msg;
                        
                        break;

                    default:
                        ObjectFactory.EventDataService.Insert(new Event(EventType.CanReadCommand, EventCategory.Error, $"Nepostojeća komanda {msg.CanReciveCommands.ToString()}"));
                        WriteCanCommand(CanSendCommands.Reset);
                        break;
                }
            }
        }
        
        private void EventHandlerOnObradiEvent(AbstractEventHandler dogadaj)
        {
            _timerEvent.Change(100, Timeout.Infinite);
            _queue.Enqueue(dogadaj);
        }

        internal void WriteCanCommand(CanSendCommand cmd)
        {
            _pcanHandler.Write(Id, cmd.Msg);            
            ObjectFactory.EventDataService.Insert(new Event(EventType.CanWriteCommand, EventCategory.Info, cmd.CommandName){AddMessage = cmd.Msg});
        }
    }
}
