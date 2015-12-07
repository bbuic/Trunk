using System.Linq;
using System.Windows.Forms;

namespace DNTv2.DataModel.Services
{
    public class TransakcijeModelService : AbstractModelService
    {
        internal bool PretrazivanjeUTijeku { get; set; }
        internal BindingSource bindingSourceDogadaj = new BindingSource();

        public override void Refresh()
        {
            if(!PretrazivanjeUTijeku)
            {
                bindingSource.DataSource = ObjectFactory.TransakcijaDataService.DajTransakcije()
                    .Select(transakcija => new TransakcijeModel { Transakcija = transakcija }).ToList();                
            }
            bindingSourceDogadaj.DataSource = DNTDataAccess.ObjectFactory.DogadajDataService.
                DajSveDogadaje().Select(x=> new DogadajModel{DatumOd = x.DatumOd, DatumDo = x.DatumDo, DogadajTipId = x.DogadajTipId}).ToList();
        }
    }
}
