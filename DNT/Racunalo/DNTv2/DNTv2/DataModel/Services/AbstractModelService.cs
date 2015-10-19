using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        public virtual void Refresh()
        {
            bindingSource.DataSource = null;
        }

    }
}
