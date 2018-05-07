using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BikeService.DataBase;

namespace BikeService.Objects.ObjectHandlers
{
    public class PilonHandler : PcanHandler
    {
        readonly List<DockingModel> _dockings = new List<DockingModel>();
        
        static Timer _timerCan;        
        private readonly Queue<TPCANMsg> _queue = new Queue<TPCANMsg>();

        public void Start()
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += delegate(object sender, UnhandledExceptionEventArgs args)
                    {
                        ObjectFactory.LogDataService.Write((Exception) args.ExceptionObject);
                    };

                ObjectFactory.LogDataService.Write(LogType.Info, "Pokrenut servis pilona.");

                if(!InitCan())
                    return;

                ObjectFactory.EventDataService.Insert(new Event(EventType.PilonUpdate, Utils.Serialize(_dockings)));

                if (_timerCan == null)
                    _timerCan = new Timer(_ => ObradiPodatkeCana());
            
                HandleCanMessage += delegate(TPCANMsg msg, TPCANTimestamp stamp)
                    {
                        _timerCan.Change(100, Timeout.Infinite);
                        _queue.Enqueue(msg);
                    };
            
                ObjectFactory.LogDataService.Write(LogType.Info, "Završen init servisa pilona.");
            }
            catch (Exception e)
            {
                ObjectFactory.LogDataService.Write(e);
            }
        }

        public void Stop()
        {
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
                
                    if(msg.Equals(Commands.Hello))
                    {
                        if (dock == null)
                        {
                            dock = new DockingModel(this) {Id = dockId};
                            _dockings.Add(dock);                            
                        }
                    
                        if(dock.DatumUkljucivanja.HasValue && (DateTime.Now - dock.DatumUkljucivanja.Value).TotalSeconds < 5)
                            ObjectFactory.EventDataService.Insert(new Event(EventType.PilonError, "Dva pilona sa istim IDjem su se prijavila unutar 5 sec."));

                        dock.DatumUkljucivanja = DateTime.Now;
                    
                        WriteCanCommand(dockId, Commands.HelloResponse);

                        ObjectFactory.EventDataService.Insert(new Event(EventType.PilonUpdate, Utils.Serialize(_dockings)));
                        ObjectFactory.DockingDataService.InsertCommand(new CanCommand(dockId, msg, true));
                        ObjectFactory.DockingDataService.UpdateDock(dock);
                    }
                    else if (msg.Equals(Commands.PresenceResponse))
                    {
                        // elektronika odgovara na Presence, mi obavještavamo server o stanju svakih N sekundi
                        ObjectFactory.EventDataService.Insert(new Event(EventType.PilonUpdate, Utils.Serialize(_dockings)));
                    }                                  
                }
            }
            catch (Exception e)
            {
                ObjectFactory.LogDataService.Write(e);
            }
        }

        private void WriteCanCommand(uint idUredaja, TPCANMsg msg)
        {
            Write(idUredaja, msg);
            ObjectFactory.DockingDataService.InsertCommand(new CanCommand(idUredaja, msg, false));
        }

    }
}
