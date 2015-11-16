using System;
using System.ComponentModel;

namespace DNTv2.DataModel
{
    public class KarticaModel:CommonModel
    {
        Kartica _kartica = new Kartica();

        [Browsable(false)] 
        public Kartica Kartica
        {
            get { return _kartica; }
            set { _kartica = value; }
        }

        public string Broj
        {
            get { return _kartica.Broj; }
            set
            {
                _kartica.Broj = value;
                OnPropertyChanged("Broj");
            }
        }

        public string Ugovor
        {
            get { return _kartica.Ugovor; }
            set
            {
                _kartica.Ugovor = value;
                OnPropertyChanged("Ugovor");
            }
        }

        public DateTime Datum
        {
            get { return _kartica.Datum; }
            set
            {
                _kartica.Datum = value;
                OnPropertyChanged("Datum");
            }
        }

        [Browsable(false)] 
        public int VlasnikId
        {
            get { return _kartica.VlasnikId; }
            set { _kartica.VlasnikId = value; }
        }

        public bool Aktivnost
        {
            get { return _kartica.Aktivnost; }
            set
            {
                _kartica.Aktivnost = value;
                OnPropertyChanged("Aktivnost");
            }
        }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(Broj) && VlasnikId > 0;
        }
    }
}
