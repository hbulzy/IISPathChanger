using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using IISPathChanger.Properties;

namespace IISPathChanger
{
    public class ProcessManager
    {
        public List<IISApp> ListApps()
        {
            try
            {
                // Run the list command
                const string args = "list apps /config /xml";
                string xmlString = RunExternalExe(Settings.Default.AppCmdPath, args);

                // Error check the xmlString
                if (string.IsNullOrEmpty(xmlString))
                    return null;

                // Create apps response array
                var apps = new List<IISApp>();

                // Create an XmlReader and read the response
                using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
                {
                    // Read each app element
                    while (reader.ReadToFollowing("APP"))
                    {
                        // Create app object
                        var app = new IISApp();

                        // Pass values
                        reader.MoveToAttribute("APP.NAME");
                        app.Name = reader.Value;

                        reader.MoveToAttribute("APPPOOL.NAME");
                        app.Id = reader.Value;
                        app.AppPool = reader.Value;

                        reader.MoveToAttribute("SITE.NAME");
                        app.SiteName = reader.Value;

                        reader.ReadToFollowing("virtualDirectory");
                        reader.MoveToAttribute("physicalPath");
                        app.PhysicalPath = reader.Value;

                        // Also create default path
                        var path = new IISAppPath()
                                       {
                                           Id = Util.RandId(),
                                           Path = app.PhysicalPath,
                                           AppId = app.Id
                                       };
                        app.Paths.Add(path);

                        // Add
                        apps.Add(app);
                    }
                }

                return apps;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool SetAppPath(string app, string path)
        {
            var args = "set app /app.name: " + app + " /[path='/'].physicalPath:" + path;
            try
            {
                string output = RunExternalExe(Settings.Default.AppCmdPath, args);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public string RunExternalExe(string filename, string arguments = null)
        {
            // Start the process
            var process = new Process();

            process.StartInfo.FileName = filename;
            if (!string.IsNullOrEmpty(arguments))
            {
                process.StartInfo.Arguments = arguments;
            }

            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.UseShellExecute = false;

            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            var stdOutput = new StringBuilder();
            process.OutputDataReceived += (sender, args) => stdOutput.Append(args.Data);

            string stdError = null;
            try
            {
                process.Start();
                process.BeginOutputReadLine();
                stdError = process.StandardError.ReadToEnd();
                process.WaitForExit();
            }
            catch (Exception e)
            {
                throw new Exception("OS error while executing " + Format(filename, arguments) + ": " + e.Message, e);
            }

            if (process.ExitCode == 0)
            {
                return stdOutput.ToString();
            }
            else
            {
                var message = new StringBuilder();

                if (!string.IsNullOrEmpty(stdError))
                {
                    message.AppendLine(stdError);
                }

                if (stdOutput.Length != 0)
                {
                    message.AppendLine("Std output:");
                    message.AppendLine(stdOutput.ToString());
                }

                throw new Exception(Format(filename, arguments) + " finished with exit code = " + process.ExitCode + ": " + message);
            }
        }

        private string Format(string filename, string arguments)
        {
            return "'" + filename +
                ((string.IsNullOrEmpty(arguments)) ? string.Empty : " " + arguments) +
                "'";
        }

    }
}
