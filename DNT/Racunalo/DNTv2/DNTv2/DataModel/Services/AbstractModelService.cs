using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DNTv2.DataModel.Converters;

namespace DNTv2.DataModel.Services
{
    public abstract class AbstractModelService
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
                            };
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
    }
}
