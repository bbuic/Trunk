using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNTv2.DataModel
{
    public class KarticaModel:CommonModel
    {
        Kartica _kartica = new Kartica();

        public Kartica Kartica
        {
            get { return _kartica; }
            set { _kartica = value; }
        }
    }
}
