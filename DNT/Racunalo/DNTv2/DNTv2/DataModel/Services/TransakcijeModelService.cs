using System.Linq;

namespace DNTv2.DataModel.Services
{
    public class TransakcijeModelService : AbstractModelService
    {
        internal bool PretrazivanjeUTijeku { get; set; }

        public override void Refresh()
        {
            if(PretrazivanjeUTijeku)
                return;

            bindingSource.DataSource = ObjectFactory.TransakcijaDataService.DajTransakcije()
                    .Select(transakcija => new TransakcijeModel { Transakcija = transakcija }).ToList();
        }
    }
}
