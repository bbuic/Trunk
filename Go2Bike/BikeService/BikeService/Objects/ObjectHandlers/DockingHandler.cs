using System.Collections.Generic;
using System.Linq;

namespace BikeService.Objects.ObjectHandlers
{
    public class DockingHandler : PcanHandler
    {
        readonly List<Docking> _dockings = new List<Docking>();

        public Docking GetDock(uint id)
        {
            return _dockings.FirstOrDefault(x => x.Id == id);
        }

        public void AddDock(Docking docking)
        {
            _dockings.Add(docking);
        }
    }
}
