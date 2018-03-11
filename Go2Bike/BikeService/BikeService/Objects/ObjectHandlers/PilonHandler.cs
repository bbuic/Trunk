using System;

namespace BikeService.Objects.ObjectHandlers
{
    public class PilonHandler
    {
        readonly PcanHandler _pcanHandler = new PcanHandler();
        Docking _docking = new Docking();

        public void Start()
        {
            if(!_pcanHandler.Init())
                return;

            _pcanHandler.CanRead += delegate(TPCANMsg msg, TPCANTimestamp stamp)
            {
                    
            };

            AppDomain.CurrentDomain.UnhandledException += delegate(object sender, UnhandledExceptionEventArgs args)
            {

            };
        }
    }
}
