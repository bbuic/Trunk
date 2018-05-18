using System;

namespace BikeService.DataBase
{
    public class Docking
    {
        public uint Id { get; set; }
        public bool Switch { get; set; }
        public int? Tag { get; set; } 
        public DateTime? DatumUkljucivanja { get; set; }
    }
}
