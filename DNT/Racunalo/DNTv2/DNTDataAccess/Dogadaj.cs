using System;
using System.ComponentModel;
using DNTv2.DataAccess;

namespace DNTDataAccess
{
    public enum DogadajTip
    {
        Vrata = 1,
        Foto = 2
    }

    public class Dogadaj:PersistentObject
    {
        [Browsable(false)]
        public DogadajTip DogadajTipId { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public string Kartica { get; set; }
    }
}
