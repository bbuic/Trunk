using System.Threading;
using BikeService.DataBase;
using BikeService.Objects.ObjectHandlers;

namespace BikeService.Objects
{
    public class DockingModel: Docking
    {
        private readonly PcanHandler _pcanHandler;
        private readonly Timer _timerPresence;
        
        public DockingModel(PcanHandler handler)
        {
            _pcanHandler = handler;
            if (_timerPresence == null)
                _timerPresence = new Timer(_ => SlanjePresence());
            _timerPresence.Change(Timeout.Infinite, Properties.Settings.Default.PresencePeriod);
        }

        private void SlanjePresence()
        {
            _pcanHandler.Write(Id, Commands.Presence);
        }
    }
}
