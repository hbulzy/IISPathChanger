using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace IISPathChanger
{
    [XmlType("IISPathChanger.IISApp")]
    public class IISApp
    {
        [XmlElement("AppId")]
        public string Id { get; set; }

        [XmlElement("AppName")]
        public string Name { get; set; }

        [XmlElement("AppPool")]
        public string AppPool { get; set; }

        [XmlElement("AppSiteName")]
        public string SiteName { get; set; }

        [XmlElement("AppPhysicalPath")]
        public string PhysicalPath { get; set; }

        [XmlElement("AppPaths")]
        public List<IISAppPath> Paths { get; set; }

        public IISApp()
        {
            this.Paths = new List<IISAppPath>();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
