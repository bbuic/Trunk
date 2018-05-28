using System.Collections.Generic;

namespace BikeService.Objects
{
    public class CanMessage
    {
        public CanReciveCommands CanReciveCommands { get; set; }
        public List<TPCANMsg> RawMessage { get; set; }
    }
}
