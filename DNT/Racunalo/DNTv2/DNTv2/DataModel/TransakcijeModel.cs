using System.ComponentModel;

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

        public short BrojVrecica
        {
            get { return _transakcija.BrojVrecica; }
            set { _transakcija.BrojVrecica = value; }
        }
    }
}
