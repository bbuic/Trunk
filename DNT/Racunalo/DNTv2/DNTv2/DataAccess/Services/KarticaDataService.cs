using System;
using DNTv2.DataModel;

namespace DNTv2.DataAccess.Services
{
    public class KarticaDataService:AbstractAutoDataService
    {
        public override Type ObjectType
        {
            get { return typeof (Kartica); }
        }
    }
}
