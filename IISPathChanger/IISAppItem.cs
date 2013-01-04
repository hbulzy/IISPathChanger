using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace IISPathChanger
{
    public class IISAppItem
    {
        [XmlElement("AppItemId")]
        public string Id { get; set; }

        [XmlElement("AppItemAppId")]
        public string AppId { get; set; }

        public override string ToString()
        {
            return this.Id;
        }
    }
}
