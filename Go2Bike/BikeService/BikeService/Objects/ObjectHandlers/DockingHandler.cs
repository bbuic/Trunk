using System;
using System.Collections.Generic;
using System.Threading;
using BikeService.DataBase;
using BikeService.EventHandlers;
using EventHandler = BikeService.EventHandlers.EventHandler;

namespace BikeService.Objects.ObjectHandlers
{
    public class DockingHandler:DockingModel
    {
        private Timer _timerPresence;
        private readonly PcanHandler _pcanHandler;
        public AbstractEventHandler EventHandler;
        private readonly Queue<AbstractEventHandler> _queue = new Queue<AbstractEventHandler>();
        private static Timer _timerEvent;  

        public DockingHandler(PcanHandler handler)
        {
            _pcanHandler = handler;

            AbstractEventHandler eventHandler2 = new EventHandler(EventType.BikeTag,  2, 0x75, EventHandlerOnObradiEvent);
            AbstractEventHandler eventHandler1 = new EventHandler(EventType.RfidTag,  2, 0x77, EventHandlerOnObradiEvent, eventHandler2);
            EventHandler = new EventHandler(EventType.Hello,  1, 0x00, EventHandlerOnObradiEvent, eventHandler1);

            if (_timerEvent == null)
                _timerEvent = new Timer(_ => ObradiPodatkeCana());
        }

        private void ObradiPodatkeCana()
        {
            while (_queue.Count > 0)
            {
                var msg = _queue.Dequeue();
                switch (msg.EventType)
                {
                    case EventType.Hello:
                        //if (DatumUkljucivanja.HasValue && (DateTime.Now - DatumUkljucivanja.Value).TotalSeconds < 5)
                        //    ObjectFactory.EventDataService.Insert(new Event(EventType.PilonError, "Dva pilona sa istim IDjem su se prijavila unutar 5 sec."));

                        DatumUkljucivanja = DateTime.Now;

                        WriteCanCommand(Id, SendCommands.HelloResponse);
                        WriteCanCommand(Id, SendCommands.WorkWithServer);

                        if (_timerPresence == null)
                            _timerPresence = new Timer(delegate { _pcanHandler.Write(Id, SendCommands.Presence); });
                        _timerPresence.Change(Timeout.Infinite, Properties.Settings.Default.PresencePeriod);

                        //ObjectFactory.EventDataService.Insert(new Event(EventType.PilonUpdate, Utils.Serialize(_dockings)));
                        //ObjectFactory.DockingDataService.InsertCommand(new CanCommand(dockId, msg, true));
                        //ObjectFactory.DockingDataService.UpdateDock(dock);

                        break;

                    case EventType.BikeTag:
                        ObjectFactory.EventDataService.Insert(new Event(EventType.BikeTag, Utils.Serialize(_dockings)));
                        //    var bikeTag = BitConverter.ToInt16(msg.DATA.Skip(1).ToArray(), 0);

                        //    bool tag = ObjectFactory.ServerHandler.ValidateBikeTag(bikeTag);
                        //    WriteCanCommand(dockId, SendCommands.BikeTagAck);
                        break;

                }
            }
        }

        private void EventHandlerOnObradiEvent(AbstractEventHandler dogadaj)
        {
            _timerEvent.Change(100, Timeout.Infinite);
            _queue.Enqueue(dogadaj);
        }

        internal void WriteCanCommand(uint idUredaja, TPCANMsg msg)
        {
            _pcanHandler.Write(idUredaja, msg);
            ObjectFactory.DockingDataService.InsertCommand(new CanCommand(idUredaja, msg, false));
        }
    }
}
