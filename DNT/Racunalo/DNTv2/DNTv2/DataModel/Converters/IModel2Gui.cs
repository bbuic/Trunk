using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DNTv2.DataModel.Services;

namespace DNTv2.DataModel.Converters
{
    public interface IModel2Gui
    {
        Form Convert2Form(AbstractModelService modelService);
        UserControl Convert2UserControl(AbstractModelService modelService);
    }
}
