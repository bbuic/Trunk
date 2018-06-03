using System.Collections.Generic;
using System.Linq;
using BikeService.Objects;

namespace BikeService.Events
{
    public class AbstractEvent
    {
        public CanReciveCommands EventType;
        public List<TPCANMsg> List { get; set; } = new List<TPCANMsg>();
        public byte[][] Messages => List.Select(x => x.DATA).ToArray();

        internal virtual void Handle(){}
    }
}
