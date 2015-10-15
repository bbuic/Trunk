using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DNTv2.DataModel.Attributes;

namespace DNTv2.DataModel
{
    public class PersistentObject
    {
        protected int id;

        public PersistentObject()
        {
        }

        public PersistentObject(int id)
        {
            this.id = id;
        }

        [Id]
        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
