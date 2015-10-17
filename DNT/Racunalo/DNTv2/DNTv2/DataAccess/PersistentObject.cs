using DNTv2.DataModel.Attributes;

namespace DNTv2.DataAccess
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
