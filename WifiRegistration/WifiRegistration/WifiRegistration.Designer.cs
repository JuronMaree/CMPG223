namespace WifiRegistration
{
    partial class WifiRegistration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WifiRegistration));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.wifiRegistrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUnitOwnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expiredDevicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addComplexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewALLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wifiRegistrationToolStripMenuItem,
            this.viewALLToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1370, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // wifiRegistrationToolStripMenuItem
            // 
            this.wifiRegistrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUnitOwnerToolStripMenuItem,
            this.addDeviceToolStripMenuItem,
            this.expiredDevicesToolStripMenuItem,
            this.addComplexToolStripMenuItem,
            this.addAddressToolStripMenuItem});
            this.wifiRegistrationToolStripMenuItem.Name = "wifiRegistrationToolStripMenuItem";
            this.wifiRegistrationToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.wifiRegistrationToolStripMenuItem.Text = "WifiRegistration";
            this.wifiRegistrationToolStripMenuItem.Click += new System.EventHandler(this.wifiRegistrationToolStripMenuItem_Click);
            // 
            // addUnitOwnerToolStripMenuItem
            // 
            this.addUnitOwnerToolStripMenuItem.Name = "addUnitOwnerToolStripMenuItem";
            this.addUnitOwnerToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.addUnitOwnerToolStripMenuItem.Text = "Add Unit/Owner";
            this.addUnitOwnerToolStripMenuItem.Click += new System.EventHandler(this.addUnitOwnerToolStripMenuItem_Click);
            // 
            // addDeviceToolStripMenuItem
            // 
            this.addDeviceToolStripMenuItem.Name = "addDeviceToolStripMenuItem";
            this.addDeviceToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.addDeviceToolStripMenuItem.Text = "Add Device";
            this.addDeviceToolStripMenuItem.Click += new System.EventHandler(this.addDeviceToolStripMenuItem_Click);
            // 
            // expiredDevicesToolStripMenuItem
            // 
            this.expiredDevicesToolStripMenuItem.Name = "expiredDevicesToolStripMenuItem";
            this.expiredDevicesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.expiredDevicesToolStripMenuItem.Text = "Expired Devices";
            this.expiredDevicesToolStripMenuItem.Click += new System.EventHandler(this.expiredDevicesToolStripMenuItem_Click);
            // 
            // addComplexToolStripMenuItem
            // 
            this.addComplexToolStripMenuItem.Name = "addComplexToolStripMenuItem";
            this.addComplexToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.addComplexToolStripMenuItem.Text = "Add Complex";
            this.addComplexToolStripMenuItem.Click += new System.EventHandler(this.AddComplexToolStripMenuItem_Click);
            // 
            // addAddressToolStripMenuItem
            // 
            this.addAddressToolStripMenuItem.Name = "addAddressToolStripMenuItem";
            this.addAddressToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.addAddressToolStripMenuItem.Text = "Add Address";
            this.addAddressToolStripMenuItem.Click += new System.EventHandler(this.AddAddressToolStripMenuItem_Click);
            // 
            // viewALLToolStripMenuItem
            // 
            this.viewALLToolStripMenuItem.Name = "viewALLToolStripMenuItem";
            this.viewALLToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.viewALLToolStripMenuItem.Text = "View ALL";
            this.viewALLToolStripMenuItem.Click += new System.EventHandler(this.viewALLToolStripMenuItem_Click);
            // 
            // WifiRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 473);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WifiRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WiFi Registration Database";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.WifiRegistration_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem wifiRegistrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUnitOwnerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDeviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expiredDevicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewALLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addComplexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAddressToolStripMenuItem;
    }
}

