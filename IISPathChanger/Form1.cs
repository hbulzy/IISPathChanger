using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace IISPathChanger
{
    public partial class Form1 : Form
    {
        public IISController Controller { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(IISController controller) : this()
        {
            this.Controller = controller;

            // Setup the combo boxes
            SetupAppsComboBox(this.Controller.AppsList);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Change the path
            var app = ((IISApp) this.appsComboBox.SelectedItem);
            var path = ((IISAppPath)this.pathsComboBox.SelectedItem);

            // Update path on iis
            var result = this.Controller.UpdateAppPath(app, path);
            if (result)
            {
                this.statusLabel.Text = "Done!";
                this.statusLabel.ForeColor = System.Drawing.Color.DarkGreen;
            }
            else
            {
                this.statusLabel.Text = "Error!";
                this.statusLabel.ForeColor = System.Drawing.Color.DarkRed;
            }
            statusLabel.Show();

        }

        private void pathsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hide status label
            statusLabel.Hide();

            var combo = (ComboBox) sender;

            var selectedItem = combo.SelectedItem;

            // Check is add
            if (selectedItem.GetType() == typeof(IISAppAdd))
            {
                // Show select path dialog
                var dialog = new FolderBrowserDialog();
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Add this new path
                    var path = dialog.SelectedPath;
                    this.AddPath(path, true);
                }
            }
        }

        private void appsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hide status label
            statusLabel.Hide();

            var combo = (ComboBox)sender;

            // Load the paths for the apps
            var app = ((IISApp)this.appsComboBox.SelectedItem);
            this.pathsComboBox.Items.Clear();

            foreach (var path in app.Paths)
            {
                this.pathsComboBox.Items.Add(path);
            }

            if (this.pathsComboBox.Items.Count > 0)
            {
                this.SelectCurrentPathForApp(app);
            }

            // Add default combo
            this.AddComboAddPathItem();
        }

        public void SelectCurrentPathForApp(IISApp app)
        {
            var currentPath = app.PhysicalPath;

            // Loop and check
            foreach (var path in app.Paths)
            {
                // Compare
                if (path.Path == currentPath)
                {
                    this.pathsComboBox.SelectedItem = path;
                    return;
                }
            }
        }
    }
}
