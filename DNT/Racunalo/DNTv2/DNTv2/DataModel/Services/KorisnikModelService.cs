namespace DNTv2.DataModel.Services
{
    public class KorisnikModelService: AbstractModelService
    {
        public override void Refresh()
        {
            bindingSource.DataSource = ObjectFactory.KorisnikDataService.DajSveKorisnike();
        }
    }
}
