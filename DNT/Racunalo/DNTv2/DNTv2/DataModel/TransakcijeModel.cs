using System.ComponentModel;

namespace DNTv2.DataModel
{
    public class TransakcijeModel : CommonModel
    {
        Transakcija _transakcija = new Transakcija();

        public short BrojVrecica { get; set; }
    }
}
