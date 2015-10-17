using System;

namespace DNTv2.DataModel
{
    public class Transakcija
    {
        Korisnik _korisnik = new Korisnik();

        public string Kartica { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public short BrojVrecica { get; set; }
        public bool Trezor { get; set; }
        
        public Korisnik Korisnik
        {
            get { return _korisnik; }
            set { _korisnik = value; }
        }        
    }
}
