namespace DNTServiceProcessor.Lcd
{
    interface ILcdService
    {
        void UvodnaPoruka(int? delay = null);
        void IspisiPoruku(string poruka);
        void Dispose();
    }
}
