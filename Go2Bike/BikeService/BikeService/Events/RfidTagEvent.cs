using System;
using System.Linq;

namespace BikeService.Events
{
    public class RfidTagEvent: AbstractEvent
    {
        public int RfidTag { get; set; }

        internal override void Handle()
        {
            RfidTag = BitConverter.ToInt16(Messages[0].Skip(1).ToArray(), 0);
        }
    }
}
