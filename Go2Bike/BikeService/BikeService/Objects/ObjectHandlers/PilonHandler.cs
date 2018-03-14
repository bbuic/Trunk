using System;
using System.Collections.Generic;
using System.Linq;

namespace BikeService.Objects.ObjectHandlers
{
    public class PilonHandler : DockingHandler
    {
        
        public void Start()
        {
            if(!PcanHandler.InitCan())
                return;

            PcanHandler.HandleCanMessage += delegate(TPCANMsg msg, TPCANTimestamp stamp)
            {
                var dock = GetDock(msg.ID);

                if (msg.LEN == 1)
                {
                    if (msg.DATA[0] == Commands.Hello)
                    {                        
                        if (dock == null)
                        {
                            dock = AddDock(msg.ID, PcanHandler);                                                                                    
                            dock.ExecuteCommand(new[] { Commands.GetTagState });                                                        
                        }
                        dock.HelloResponse();
                        
                    }
                }   
            };

            AppDomain.CurrentDomain.UnhandledException += delegate(object sender, UnhandledExceptionEventArgs args)
            {

            };
        }
    }
}
