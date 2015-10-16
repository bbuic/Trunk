using System;
using DNTv2.DataModel.Attributes;

namespace DNTv2.DataModel
{
    public class Kartica
    {
        [Id]
        public string Broj { get; set; }

        public string Ugovor { get; set; }
        public DateTime DatumIzdavanja { get; set; }
    }
}
