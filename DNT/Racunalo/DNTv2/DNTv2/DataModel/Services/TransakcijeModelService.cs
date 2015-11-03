using System.ComponentModel;

namespace DNTv2.DataModel.Services
{
    public class TransakcijeModelService : AbstractModelService
    {
        public TransakcijeModelService()
        {
            
        }

        public override void Refresh()
        {
            bindingSource.DataSource = ObjectFactory.TransakcijaDataService.DajSveUTrezoru(); ;
        }
    }
}
