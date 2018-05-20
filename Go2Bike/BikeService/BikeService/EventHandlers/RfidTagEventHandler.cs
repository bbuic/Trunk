using System;
using System.Linq;

namespace BikeService.EventHandlers
{
    public class RfidTagEventHandler: AbstractEventHandler
    {
        public RfidTagEventHandler(CanReciveCommands canReciveCommands, int numMsg, byte firstByte, ObradiEventHandler handler, AbstractEventHandler successor = null) : base(canReciveCommands, numMsg, firstByte, handler, successor)
        {
        }

        public int RfidTag { get; set; }

        internal override void Handle()
        {
            RfidTag = BitConverter.ToInt16(Messages[0].Skip(1).ToArray(), 0);
        }
    }
}
