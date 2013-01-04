using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace IISPathChanger
{
    public class IISAppPath : IISAppItem
    {
        [XmlElement("AppItemPath")]
        public string Path { get; set; }

        public override string ToString()
        {
            return this.Path;
        }
    }
}
