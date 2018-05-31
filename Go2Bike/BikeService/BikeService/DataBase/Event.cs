using System;
using System.Collections.Generic;
using BikeService.Objects;

namespace BikeService.DataBase
{
    public class Event
    {
        public EventType EventType { get; set; }
        public EventCategory EventCategory { get; set; }
        public string Opis { get; set; }
        public uint? DockingId { get; set; }

        public List<TPCANMsg> MessageList;
        public TPCANMsg AddMessage
        {
            set
            {
                if(MessageList == null)
                    MessageList = new List<TPCANMsg>();
                MessageList.Add(value);
            }
        }

        public DateTime? SendTime { get; set; }

        public Event(EventType eventType, EventCategory eventCategory, string opis)
        {
            EventType = eventType;
            EventCategory = eventCategory;
            Opis = opis;
        }
    }
}
