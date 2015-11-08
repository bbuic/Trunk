using System.Linq;

namespace DNTv2.DataModel.Services
{
    public class TransakcijeModelService : AbstractModelService
    {
        public override void Refresh()
        {
            bindingSource.DataSource = ObjectFactory.TransakcijaDataService.DajTransakcije()
                    .Select(transakcija => new TransakcijeModel { Transakcija = transakcija }).ToList();
        }
    }
}
