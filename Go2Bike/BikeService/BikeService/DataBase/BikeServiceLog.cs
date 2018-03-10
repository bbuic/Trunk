using System;

namespace BikeService.DataBase
{
    class BikeServiceLog
    {
        public DateTime DateTime { get; set; }
        public LogType LogType { get; set; }
        public string Log { get; set; }
    }
}
