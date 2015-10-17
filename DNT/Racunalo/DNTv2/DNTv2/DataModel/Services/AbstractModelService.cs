using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DNTv2.DataModel.Services
{
    public abstract class AbstractModelService
    {
        public BindingSource bindingSource = new BindingSource();

        public virtual void Refresh()
        {
            bindingSource.DataSource = null;
        }

    }
}
