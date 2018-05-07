using System;
using BikeService.Objects;

namespace BikeService.DataBase
{
    public class CanCommand
    {
        public CanCommand(uint dockId, TPCANMsg command, bool recive)
        {
            DockId = dockId;
            Command = command;
            Datum = DateTime.Now;
            Recive = recive;
        }

        public uint DockId { get; set; }
        public TPCANMsg Command { get; set; }
        public DateTime Datum { get; set; }
        public bool Recive { get; set; }
    }
}
