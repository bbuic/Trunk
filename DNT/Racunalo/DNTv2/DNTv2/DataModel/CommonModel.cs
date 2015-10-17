using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DNTv2.Annotations;

namespace DNTv2.DataModel
{
    public class CommonModel : INotifyPropertyChanged
    {
        private ModelState modelState = ModelState.Unchanged;

        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        } 
    }
}
