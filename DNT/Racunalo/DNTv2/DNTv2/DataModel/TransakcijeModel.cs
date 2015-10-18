using System.ComponentModel;

namespace DNTv2.DataModel
{
    public class TransakcijeModel : Transakcija, INotifyPropertyChanged
    {
        private ModelState _modelState = ModelState.Unchanged;
        
        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        } 


    }
}
