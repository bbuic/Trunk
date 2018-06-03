using System;
using System.Linq;

namespace BikeService.Events
{
    public class BikeTagEvent: AbstractEvent
    {
        public int BikeTag { get; set; }

        internal override void Handle()
        {
            BikeTag = BitConverter.ToInt16(Messages[0].Skip(1).ToArray(), 0);
        }
    }
}
