using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNTv2.DataModel.DataServices
{
    public class KorisnikDataService : AbstractAutoDataService
    {
        public override Type ObjectType
        {
            get { return typeof(Korisnik); }
        }
    }
}
