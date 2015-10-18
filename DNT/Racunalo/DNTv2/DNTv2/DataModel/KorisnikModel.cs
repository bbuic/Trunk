using System.Collections.Generic;
using System.Linq;
using DNTv2.DataAccess;

namespace DNTv2.DataModel
{
    public class KorisnikModel : CommonModel
    {
        Korisnik _korisnik = new Korisnik();

        public Korisnik Korisnik
        {
            get { return _korisnik; }
            set { _korisnik = value; }
        }

        public int Id
        {
            get { return _korisnik.Id; }
            set { _korisnik.Id = value; }
        }

        public string Ime
        {
            get { return _korisnik.Ime; }
            set
            {
                _korisnik.Ime = value;
                OnPropertyChanged("Ime");
            }
        }

        public string Prezime
        {
            get { return _korisnik.Prezime; }
            set
            {
                _korisnik.Prezime = value;
                OnPropertyChanged("Prezime");
            }
        }

        public string Adresa
        {
            get { return _korisnik.Adresa; }
            set
            {
                _korisnik.Adresa = value;
                OnPropertyChanged("Adresa");
            }
        }

        public string KucniBroj
        {
            get { return _korisnik.KucniBroj; }
            set
            {
                _korisnik.KucniBroj = value;
                OnPropertyChanged("KucniBroj");
            }
        }

        public string Grad
        {
            get { return _korisnik.Grad; }
            set
            {
                _korisnik.Grad = value;
                OnPropertyChanged("Grad");
            }
        }

        public string Telefon
        {
            get { return _korisnik.Telefon; }
            set
            {
                _korisnik.Telefon = value;
                OnPropertyChanged("Telefon");
            }
        }

        public IList<KarticaModel> Kartice
        {
            get { return _korisnik.Kartice.Select(kartica => new KarticaModel { Kartica = kartica }).ToList(); }
            set { }
        }
    }
}
