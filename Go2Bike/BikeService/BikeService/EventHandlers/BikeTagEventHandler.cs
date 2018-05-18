﻿using System;
using System.Linq;

namespace BikeService.EventHandlers
{
    public class BikeTagEventHandler: AbstractEventHandler
    {
        public BikeTagEventHandler(CanReciveCommands canReciveCommands, int numMsg, byte firstByte, ObradiEventHandler handler, AbstractEventHandler successor = null) : base(canReciveCommands, numMsg, firstByte, handler, successor)
        {
        }

        public int BikeTag { get; set; }

        internal override void Handle()
        {
            BikeTag = BitConverter.ToInt16(Message[0].DATA.Skip(1).ToArray(), 0);
        }
    }
}
