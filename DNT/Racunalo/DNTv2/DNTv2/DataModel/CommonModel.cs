using System.ComponentModel;

namespace DNTv2.DataModel
{
    public class CommonModel : INotifyPropertyChanged
    {
        internal ModelState modelState = ModelState.Unchanged;

        public ModelState ModelState
        {
            get { return modelState; }
            set
            {
                if (value == ModelState.Modified && (modelState == ModelState.Inserted || modelState == ModelState.Cancel))
                    return;
                modelState = value;
            }
        }

        public virtual bool IsValid()
        {
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        } 
    }
}
