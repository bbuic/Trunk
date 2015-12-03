﻿using System;
using DNTv2.DataAccess;

namespace DNTDataAccess
{
    public enum DogadajTip:short
    {
        Vrata = 1,
        Foto = 2
    }

    public class Dogadaj:PersistentObject
    {
        public DogadajTip DogadajTipId { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
    }
}
