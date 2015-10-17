using System.Collections.Generic;

namespace DNTv2.DataModel
{
    public class Korisnik
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string KucniBroj { get; set; }
        public string Grad { get; set; }
        public string Telefon { get; set; }
        public IList<Kartica> Kartice = new List<Kartica>();
    }
}
