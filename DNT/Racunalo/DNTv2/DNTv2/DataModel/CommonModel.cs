using System.ComponentModel;

namespace DNTv2.DataModel
{
    public class CommonModel : INotifyPropertyChanged
    {
        internal ModelState modelState = ModelState.Unchanged;

        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        } 
    }
}
