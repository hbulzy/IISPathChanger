using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace IISPathChanger
{
    public class IISAppAdd : IISAppItem
    {
        [XmlElement("AppItemValue")]
        public string Value { get; set; }

        public IISAppAdd(string value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}
