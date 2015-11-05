using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DNTv2.DataModel.Services
{
    public class TransakcijeModelService : AbstractModelService
    {
        public TransakcijeModelService()
        {
            
        }
        public List<TransakcijeModel> GetProducts()
        {
            return new List<TransakcijeModel>();
        }

        public override void Refresh()
        {
            bindingSource.DataSource = 
                ObjectFactory.TransakcijaDataService.DajTransakcije().Select(transakcija => new TransakcijeModel { Transakcija = transakcija }).ToList(); ;
        }
    }
}
