using System;
using System.Xml.Serialization;

namespace DNTv2
{
    [Serializable]
    public enum ModelState
    {
        [XmlEnum("1")]
        Unchanged = 1,
        [XmlEnum("2")]
        Inserted = 2,
        [XmlEnum("3")]
        Deleted = 3,
        [XmlEnum("4")]
        Modified = 4,
        [XmlEnum("5")]
        Cancel = 5 //Otkazivanje terpije
    }

    public sealed class Constants
    {

    }
}
