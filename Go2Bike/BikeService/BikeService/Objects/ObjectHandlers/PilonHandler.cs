using System;
using System.Collections.Generic;
using System.Linq;

namespace BikeService.Objects.ObjectHandlers
{
    public class PilonHandler : DockingHandler
    {
        
        public void Start()
        {
            if(!InitCan())
                return;

            HandleCanMessage += delegate(TPCANMsg msg, TPCANTimestamp stamp)
            {
                var dock = GetDock(msg.ID);

                if (msg.LEN == 1)
                {
                    if (msg.DATA[0] == Commands.Hello)
                    {                        
                        if (dock == null)
                        {
                            dock = new Docking { Id = msg.ID };
                            AddDock(dock);
                            Write(msg.ID, new[] { Commands.GetLockState });                                                        
                            Write(msg.ID, new[] { Commands.GetTagState });                                                        
                        }
                        Write(msg.ID, new[]{Commands.HelloResponse});
                        dock.LastHello = DateTime.Now;
                    }
                }   
            };

            AppDomain.CurrentDomain.UnhandledException += delegate(object sender, UnhandledExceptionEventArgs args)
            {

            };
        }
    }
}
