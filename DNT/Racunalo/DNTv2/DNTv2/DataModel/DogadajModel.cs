using DNTDataAccess;

namespace DNTv2.DataModel
{
    public class DogadajModel : Dogadaj
    {        
        public string Ime { get; set; }
        public string Prezime { get; set; }
        
        public string Naziv
        {
            get
            {
                switch (DogadajTipId)
                {
                    case DogadajTip.Foto:
                        return "Blokada fotosenzora";
                    case DogadajTip.Vrata:
                        return "Vanjska vrata trezora otvorena bez aktivnosti predaje pologa";
                    default:
                        return "";
                }
            }
            set{}
        }
    }
}
