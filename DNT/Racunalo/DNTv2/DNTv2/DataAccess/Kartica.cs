using System;
using DNTv2.DataModel.Attributes;

namespace DNTv2.DataModel
{
    public class Kartica
    {
        [Id]
        public string Broj { get; set; }
        public string Ugovor { get; set; }
        public DateTime Datum { get; set; }
        public int VlasnikId { get; set; }
        public bool Aktivnost { get; set; }
    }
}
