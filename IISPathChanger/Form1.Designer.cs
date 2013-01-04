using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IISPathChanger
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.pathsComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.appsComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "IISPathChanger";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // pathsComboBox
            // 
            this.pathsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pathsComboBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathsComboBox.FormattingEnabled = true;
            this.pathsComboBox.Location = new System.Drawing.Point(12, 81);
            this.pathsComboBox.Name = "pathsComboBox";
            this.pathsComboBox.Size = new System.Drawing.Size(325, 22);
            this.pathsComboBox.TabIndex = 0;
            this.pathsComboBox.SelectedIndexChanged += new System.EventHandler(this.pathsComboBox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(114, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Change It Bro!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // appsComboBox
            // 
            this.appsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.appsComboBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appsComboBox.FormattingEnabled = true;
            this.appsComboBox.Location = new System.Drawing.Point(12, 27);
            this.appsComboBox.Name = "appsComboBox";
            this.appsComboBox.Size = new System.Drawing.Size(325, 22);
            this.appsComboBox.TabIndex = 2;
            this.appsComboBox.SelectedIndexChanged += new System.EventHandler(this.appsComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "App";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Path";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.statusLabel.Location = new System.Drawing.Point(301, 128);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(41, 13);
            this.statusLabel.TabIndex = 5;
            this.statusLabel.Text = "Done!";
            this.statusLabel.Hide();

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 158);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.appsComboBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pathsComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "IIS Path Changer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private ComboBox pathsComboBox;
        private Button button1;
        private ComboBox appsComboBox;
        private Label label1;
        private Label label2;

        public void SetupAppsComboBox(List<IISApp> apps)
        {
            // Error check
            if (apps == null)
                return;
           
            // Loop and add
            foreach (var app in apps)
            {
                this.appsComboBox.Items.Add(app);
            }

            // Set default selected indexes
            if (this.appsComboBox.Items.Count > 0)
            {
                this.appsComboBox.SelectedIndex = 0;
            }

        }

        public void UpdatePathsComboBox(IEnumerable<IISAppPath> paths)
        {
            foreach (var path in paths)
            {
                this.pathsComboBox.Items.Add(path);
            }

            // Also add an "Add" to the end
            this.AddComboAddPathItem();

            this.pathsComboBox.SelectedIndex = 0;
        }

        public void AddPath(string path)
        {
            this.AddPath(path, false);
        }

        public void AddPath(string path, bool selected)
        {
            // Remove the 'Add Path..' item
            this.RemoveComboAddPathItem();

            // Get the current app id
            var app = (IISApp) this.appsComboBox.SelectedItem;

            var appPath = new IISAppPath()
                              {
                                  Id = Util.RandId(),
                                  AppId = app.Id,
                                  Path = path,
                              };

            app.Paths.Add(appPath);

            // Add new path
            this.pathsComboBox.Items.Add(appPath);

            // Re-add 'Add Path..' item
            this.AddComboAddPathItem();

            if (selected)
            {
                this.pathsComboBox.SelectedIndex = this.pathsComboBox.Items.Count - 2;
            }
        }

        private void RemoveComboAddPathItem()
        {
            int index = this.pathsComboBox.Items.Count-1;
            this.pathsComboBox.Items.RemoveAt(index);
        }

        private void AddComboAddPathItem()
        {
            this.pathsComboBox.Items.Add(new IISAppAdd("Add Path.."));
        }

        private Label statusLabel;
    }
}

