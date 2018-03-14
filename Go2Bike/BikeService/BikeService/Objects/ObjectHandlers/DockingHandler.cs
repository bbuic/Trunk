using System.Collections.Generic;
using System.Linq;

namespace BikeService.Objects.ObjectHandlers
{
    public class DockingHandler
    {
        internal PcanHandler PcanHandler = new PcanHandler();
        readonly List<Docking> _dockings = new List<Docking>();

        public Docking GetDock(uint id)
        {
            return _dockings.FirstOrDefault(x => x.Id == id);
        }

        public Docking AddDock(uint Id, PcanHandler pcanHandler)
        {
            var docking = new Docking {Id = Id, PcanHandler = PcanHandler};
            _dockings.Add(docking);
            return docking;
        }
    }
}
