using System.Collections.Generic;
using DNTv2.DataModel;

namespace DNTv2.DataAccess
{
    public class Korisnik : PersistentObject
    {
        public virtual string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string KucniBroj { get; set; }
        public string Grad { get; set; }
        public string Telefon { get; set; }
        public IList<Kartica> Kartice = new List<Kartica>();
    }
}
