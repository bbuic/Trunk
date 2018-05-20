using System;

namespace BikeService.DataBase
{
    class BikeServiceLog
    {
        public DateTime DateTime { get; set; }
        public EventCategory EventCategory { get; set; }
        public string Log { get; set; }
    }
}
