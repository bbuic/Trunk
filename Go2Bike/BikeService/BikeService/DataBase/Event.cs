using System;

namespace BikeService.DataBase
{
    public class Event
    {
        private bool _send = true;

        public Event(EventType eventType)
        {
            EventType = eventType;
            Datum = DateTime.Now;
        }

        public Event(EventType eventType, string opisDogadaja)
        {
            EventType = eventType;
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
        public EventType EventType { get; set; }
        public string OpisDogadaja { get; set; }

        public DateTime? SendTime { get; set; }
    }
}
