using System;

namespace DNTv2.DataModel
{
    public class TransakcijeModel : CommonModel
    {
        Transakcija _transakcija = new Transakcija();

        public Transakcija Transakcija
        {
            get { return _transakcija; }
            set { _transakcija = value; }
        }
        
        public string Ime
        {
            get { return _transakcija.Ime; }
            set { _transakcija.Ime = value; }
        }

        public string Prezime
        {
            get { return _transakcija.Prezime; }
            set { _transakcija.Prezime = value; }
        }

        public string Kartica
        {
            get { return _transakcija.Kartica; }
            set { _transakcija.Kartica = value; }
        }

        public DateTime DatumOd
        {
            get { return _transakcija.DatumOd; }
            set { _transakcija.DatumOd = value; }
        }
        
        public short BrojVrecica
        {
            get { return _transakcija.BrojVrecica; }
            set { _transakcija.BrojVrecica = value; }
        }

        public DateTime? DatumDo
        {
            get { return _transakcija.DatumDo; }
            set { _transakcija.DatumDo = value; }
        }
        public bool Trezor { get; set; }

        
    }
}
