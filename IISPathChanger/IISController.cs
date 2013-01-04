using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using IISPathChanger.Properties;

namespace IISPathChanger
{
    public class IISController
    {
        public List<IISApp> AppsList;
        public ProcessManager ProcessManager;

        public IISController()
        {
            // Create a process manager
            this.ProcessManager = new ProcessManager();

            // Load the list of paths from memory
            var items = this.DeserializeFromXml();

            // Setup the app paths from memory
            if (items != null)
            {
                // Get the apps list
                this.AppsList = items;
            }
            else
            {
                // Get the apps list
                this.AppsList = this.ProcessManager.ListApps();
            }

            // TODO update the apps list periodically!

            // Error check
            if (this.AppsList == null)
            {
                throw new Exception("Could not load apps list");
            }
        }

        public bool UpdateAppPath(IISApp app, IISAppPath path)
        {
            SerializeToXml(this.AppsList);

            return this.ProcessManager.SetAppPath(app.Name, path.Path);
        }

        private const string XmlFilePath = @"C:\iis-path-changer-apps.xml";
        public void SerializeToXml(List<IISApp> apps)
        {
            var serializer = new XmlSerializer(typeof(List<IISApp>));
            var textWriter = new StreamWriter(XmlFilePath);
            serializer.Serialize(textWriter, apps);
            textWriter.Close();
        }

        public List<IISApp> DeserializeFromXml()
        {
            var deserializer = new XmlSerializer(typeof(List<IISApp>));
            //var deserializer = new XmlSerializer(typeof(List<IISApp>), new Type[] { typeof(IISApp) });
            try
            {
                var textReader = new StreamReader(XmlFilePath);
                var apps = (List<IISApp>)deserializer.Deserialize(textReader);
                textReader.Close();

                return apps;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
