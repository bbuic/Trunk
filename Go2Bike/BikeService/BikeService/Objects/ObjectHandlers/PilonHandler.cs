using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using BikeService.DataBase;
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
                    ObjectFactory.LogDataService.Write((Exception) args.ExceptionObject);
                };

                ObjectFactory.LogDataService.Write(LogType.Info, "Pokrenut servis pilona.");

                _pcanHandler = new PcanHandler();
                if(!_pcanHandler.InitCan())
                    return;

                ObjectFactory.EventDataService.Insert(new Event(CanReciveCommands.Hello, Utils.Serialize(_dockings)));
                
                if (_timerCan == null)
                    _timerCan = new Timer(_ => ObradiPodatkeCana());
            
                _pcanHandler.HandleCanMessage += delegate(TPCANMsg msg, TPCANTimestamp stamp){
                    _timerCan.Change(100, Timeout.Infinite);
                    _queue.Enqueue(msg);
                };
                
                #region Service BUS  

                string serviceBusConnectionString = Settings.Default.ApiKey;//"ServiceBusConnectionString"];

                var queueClient = QueueClient.CreateFromConnectionString(serviceBusConnectionString, "DebugQueue");                    
                queueClient.OnMessage(receivedMessage =>
                {
                    string message = receivedMessage.GetBody<string>(new DataContractSerializer(typeof(string)));
                    Console.WriteLine(message);                    
                });                    
                queueClient.Close();
                
                #endregion

                ObjectFactory.LogDataService.Write(LogType.Info, "Završen init servisa pilona.");
            }
            catch (Exception e)
            {
                ObjectFactory.LogDataService.Write(e);
            }
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
                ObjectFactory.LogDataService.Write(e);
            }
        }       
    }
}
