using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows.Forms;

namespace IISPathChanger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Create controller
            var controller = new IISController();

            // Create form
            var form = new Form1(controller);

            // Run
            Application.Run(form);
       }
    }
}
