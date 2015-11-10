using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DNTv2.Annotations;
using DNTv2.DataModel.Converters;

namespace DNTv2.DataModel.Services
{
    public abstract class AbstractModelService : INotifyPropertyChanged
    {
        public BindingSource bindingSource = new BindingSource();
        
        protected AbstractModelService()
        {
            bindingSource.ListChanged +=
                            delegate(object sender, ListChangedEventArgs e)
                            {
                                switch (e.ListChangedType)
                                {
                                    case ListChangedType.ItemChanged:
                                        ((CommonModel)bindingSource.Current).ModelState = ModelState.Modified;
                                        break;
                                }
                                OnPropertyChanged("SourceImaPodataka");
                            };
        }


        public bool SourceImaPodataka
        {
            get { return bindingSource.Count > 0; }
            set{}
        }


        public EventHandler GenericEventHandler(EventContext context)
        {
            return delegate(object sender, EventArgs e)
            {
                context.EventObject = sender;
                EventHandler(context);
            };
        }

        public virtual void EventHandler(EventContext context)
        {
        }

        public virtual void Refresh()
        {
            bindingSource.DataSource = null;
        }

        public virtual void Insert()
        {
        }

        public virtual void Delete()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void New()
        {
        }

        public virtual void Cancel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
