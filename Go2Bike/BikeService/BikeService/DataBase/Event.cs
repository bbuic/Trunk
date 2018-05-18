using System;

namespace BikeService.DataBase
{
    public class Event
    {
        private bool _send = true;

        public Event(CanReciveCommands canReciveCommands)
        {
            CanReciveCommands = canReciveCommands;
            Datum = DateTime.Now;
        }

        public Event(CanReciveCommands canReciveCommands, string opisDogadaja)
        {
            CanReciveCommands = canReciveCommands;
            OpisDogadaja = opisDogadaja;
            Datum = DateTime.Now;
        }

        public bool Send
        {
            get { return _send; }
            set { _send = value; }
        }

        public uint DockId  { get; set; }
        public DateTime Datum { get; set; }
        public CanReciveCommands CanReciveCommands { get; set; }
        public string OpisDogadaja { get; set; }

        public DateTime? SendTime { get; set; }
    }
}
