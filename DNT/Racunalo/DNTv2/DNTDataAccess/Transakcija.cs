using System;
using DNTv2.DataAccess;

namespace DNTv2.DataModel
{
    public class Transakcija
    {
        Korisnik _korisnik = new Korisnik();
        
        public Korisnik Korisnik
        {
            get { return _korisnik; }
            set { _korisnik = value; }
        }

        public string Ime
        {
            get { return _korisnik.Ime; }
            set { _korisnik.Ime = value; }
        }

        public string Prezime
        {
            get { return _korisnik.Prezime; }
            set { _korisnik.Prezime = value; }
        }

        public string Kartica { get; set; }
        public string OdgovornaOsoba { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime? DatumDo { get; set; }
        public short BrojVrecica { get; set; }
        public bool Trezor { get; set; }
        
      
    }
}
