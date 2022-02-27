namespace HASSAgent.Forms
{
    partial class Configuration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.ConfigTabs = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.TabGeneral = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.TabHassApi = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.TabNotifications = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.TabMQTT = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.TabStartup = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.TabHotKey = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.TabUpdates = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.TabLocalStorage = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.TabLogging = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.BtnAbout = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnHelp = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnStore = new Syncfusion.WinForms.Controls.SfButton();
            this.PnlTabs = new System.Windows.Forms.Panel();
            this.TabExternalTools = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigTabs)).BeginInit();
            this.ConfigTabs.SuspendLayout();
            this.PnlTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfigTabs
            // 
            this.ConfigTabs.AccessibleDescription = "2328";
            this.ConfigTabs.ActiveTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ConfigTabs.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.ConfigTabs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ConfigTabs.BeforeTouchSize = new System.Drawing.Size(884, 461);
            this.ConfigTabs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConfigTabs.Controls.Add(this.TabGeneral);
            this.ConfigTabs.Controls.Add(this.TabExternalTools);
            this.ConfigTabs.Controls.Add(this.TabHassApi);
            this.ConfigTabs.Controls.Add(this.TabHotKey);
            this.ConfigTabs.Controls.Add(this.TabLocalStorage);
            this.ConfigTabs.Controls.Add(this.TabLogging);
            this.ConfigTabs.Controls.Add(this.TabMQTT);
            this.ConfigTabs.Controls.Add(this.TabNotifications);
            this.ConfigTabs.Controls.Add(this.TabStartup);
            this.ConfigTabs.Controls.Add(this.TabUpdates);
            this.ConfigTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigTabs.FixedSingleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ConfigTabs.FocusOnTabClick = false;
            this.ConfigTabs.InactiveTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.ConfigTabs.Location = new System.Drawing.Point(0, 0);
            this.ConfigTabs.Name = "ConfigTabs";
            this.ConfigTabs.RotateTextWhenVertical = true;
            this.ConfigTabs.Size = new System.Drawing.Size(884, 461);
            this.ConfigTabs.TabIndex = 0;
            this.ConfigTabs.TabPanelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ConfigTabs.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererMetro);
            this.ConfigTabs.ThemeName = "TabRendererMetro";
            this.ConfigTabs.ThemesEnabled = true;
            this.ConfigTabs.ThemeStyle.PrimitiveButtonStyle.DisabledNextPageImage = null;
            // 
            // TabGeneral
            // 
            this.TabGeneral.AutoScroll = true;
            this.TabGeneral.Image = null;
            this.TabGeneral.ImageSize = new System.Drawing.Size(16, 16);
            this.TabGeneral.Location = new System.Drawing.Point(161, 2);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.ShowCloseButton = false;
            this.TabGeneral.Size = new System.Drawing.Size(721, 457);
            this.TabGeneral.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TabGeneral.TabForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TabGeneral.TabIndex = 9;
            this.TabGeneral.Text = "General";
            this.TabGeneral.ThemesEnabled = false;
            // 
            // TabHassApi
            // 
            this.TabHassApi.AutoScroll = true;
            this.TabHassApi.Image = null;
            this.TabHassApi.ImageSize = new System.Drawing.Size(16, 16);
            this.TabHassApi.Location = new System.Drawing.Point(161, 2);
            this.TabHassApi.Name = "TabHassApi";
            this.TabHassApi.ShowCloseButton = false;
            this.TabHassApi.Size = new System.Drawing.Size(721, 457);
            this.TabHassApi.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TabHassApi.TabForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TabHassApi.TabIndex = 1;
            this.TabHassApi.Text = "Home Assistant API";
            this.TabHassApi.ThemesEnabled = false;
            // 
            // TabNotifications
            // 
            this.TabNotifications.AutoScroll = true;
            this.TabNotifications.Image = null;
            this.TabNotifications.ImageSize = new System.Drawing.Size(16, 16);
            this.TabNotifications.Location = new System.Drawing.Point(161, 2);
            this.TabNotifications.Name = "TabNotifications";
            this.TabNotifications.ShowCloseButton = true;
            this.TabNotifications.Size = new System.Drawing.Size(721, 457);
            this.TabNotifications.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TabNotifications.TabForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TabNotifications.TabIndex = 2;
            this.TabNotifications.Text = "Notifications";
            this.TabNotifications.ThemesEnabled = false;
            // 
            // TabMQTT
            // 
            this.TabMQTT.AutoScroll = true;
            this.TabMQTT.Image = null;
            this.TabMQTT.ImageSize = new System.Drawing.Size(16, 16);
            this.TabMQTT.Location = new System.Drawing.Point(161, 2);
            this.TabMQTT.Name = "TabMQTT";
            this.TabMQTT.ShowCloseButton = true;
            this.TabMQTT.Size = new System.Drawing.Size(721, 457);
            this.TabMQTT.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TabMQTT.TabForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TabMQTT.TabIndex = 3;
            this.TabMQTT.Text = "MQTT";
            this.TabMQTT.ThemesEnabled = false;
            // 
            // TabStartup
            // 
            this.TabStartup.AutoScroll = true;
            this.TabStartup.Image = null;
            this.TabStartup.ImageSize = new System.Drawing.Size(16, 16);
            this.TabStartup.Location = new System.Drawing.Point(161, 2);
            this.TabStartup.Name = "TabStartup";
            this.TabStartup.ShowCloseButton = true;
            this.TabStartup.Size = new System.Drawing.Size(721, 457);
            this.TabStartup.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TabStartup.TabForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TabStartup.TabIndex = 4;
            this.TabStartup.Text = "Startup";
            this.TabStartup.ThemesEnabled = false;
            // 
            // TabHotKey
            // 
            this.TabHotKey.AutoScroll = true;
            this.TabHotKey.Image = null;
            this.TabHotKey.ImageSize = new System.Drawing.Size(16, 16);
            this.TabHotKey.Location = new System.Drawing.Point(161, 2);
            this.TabHotKey.Name = "TabHotKey";
            this.TabHotKey.ShowCloseButton = true;
            this.TabHotKey.Size = new System.Drawing.Size(721, 457);
            this.TabHotKey.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TabHotKey.TabForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TabHotKey.TabIndex = 5;
            this.TabHotKey.Text = "HotKey";
            this.TabHotKey.ThemesEnabled = false;
            // 
            // TabUpdates
            // 
            this.TabUpdates.AutoScroll = true;
            this.TabUpdates.Image = null;
            this.TabUpdates.ImageSize = new System.Drawing.Size(16, 16);
            this.TabUpdates.Location = new System.Drawing.Point(161, 2);
            this.TabUpdates.Name = "TabUpdates";
            this.TabUpdates.ShowCloseButton = true;
            this.TabUpdates.Size = new System.Drawing.Size(721, 457);
            this.TabUpdates.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TabUpdates.TabForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TabUpdates.TabIndex = 6;
            this.TabUpdates.Text = "Updates";
            this.TabUpdates.ThemesEnabled = false;
            // 
            // TabLocalStorage
            // 
            this.TabLocalStorage.AutoScroll = true;
            this.TabLocalStorage.Image = null;
            this.TabLocalStorage.ImageSize = new System.Drawing.Size(16, 16);
            this.TabLocalStorage.Location = new System.Drawing.Point(161, 2);
            this.TabLocalStorage.Name = "TabLocalStorage";
            this.TabLocalStorage.ShowCloseButton = true;
            this.TabLocalStorage.Size = new System.Drawing.Size(721, 457);
            this.TabLocalStorage.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TabLocalStorage.TabForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TabLocalStorage.TabIndex = 8;
            this.TabLocalStorage.Text = "Local Storage";
            this.TabLocalStorage.ThemesEnabled = false;
            // 
            // TabLogging
            // 
            this.TabLogging.AutoScroll = true;
            this.TabLogging.Image = null;
            this.TabLogging.ImageSize = new System.Drawing.Size(16, 16);
            this.TabLogging.Location = new System.Drawing.Point(161, 2);
            this.TabLogging.Name = "TabLogging";
            this.TabLogging.ShowCloseButton = true;
            this.TabLogging.Size = new System.Drawing.Size(721, 457);
            this.TabLogging.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TabLogging.TabForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TabLogging.TabIndex = 7;
            this.TabLogging.Text = "Logging and Reporting";
            this.TabLogging.ThemesEnabled = false;
            // 
            // BtnAbout
            // 
            this.BtnAbout.AccessibleName = "Button";
            this.BtnAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAbout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAbout.Location = new System.Drawing.Point(0, 476);
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(172, 31);
            this.BtnAbout.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAbout.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAbout.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAbout.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAbout.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAbout.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAbout.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnAbout.TabIndex = 9;
            this.BtnAbout.Text = "about";
            this.BtnAbout.UseVisualStyleBackColor = false;
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // BtnHelp
            // 
            this.BtnHelp.AccessibleName = "Button";
            this.BtnHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHelp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHelp.Location = new System.Drawing.Point(178, 476);
            this.BtnHelp.Name = "BtnHelp";
            this.BtnHelp.Size = new System.Drawing.Size(172, 31);
            this.BtnHelp.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHelp.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHelp.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHelp.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHelp.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHelp.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHelp.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnHelp.TabIndex = 8;
            this.BtnHelp.Text = "help && contact";
            this.BtnHelp.UseVisualStyleBackColor = false;
            this.BtnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // BtnStore
            // 
            this.BtnStore.AccessibleName = "Button";
            this.BtnStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Location = new System.Drawing.Point(356, 476);
            this.BtnStore.Name = "BtnStore";
            this.BtnStore.Size = new System.Drawing.Size(530, 31);
            this.BtnStore.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStore.TabIndex = 10;
            this.BtnStore.Text = "store configuration";
            this.BtnStore.UseVisualStyleBackColor = false;
            this.BtnStore.Click += new System.EventHandler(this.BtnStore_Click);
            // 
            // PnlTabs
            // 
            this.PnlTabs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlTabs.Controls.Add(this.ConfigTabs);
            this.PnlTabs.Location = new System.Drawing.Point(0, 7);
            this.PnlTabs.Name = "PnlTabs";
            this.PnlTabs.Size = new System.Drawing.Size(886, 463);
            this.PnlTabs.TabIndex = 11;
            // 
            // TabExternalTools
            // 
            this.TabExternalTools.AutoScroll = true;
            this.TabExternalTools.Image = null;
            this.TabExternalTools.ImageSize = new System.Drawing.Size(16, 16);
            this.TabExternalTools.Location = new System.Drawing.Point(0, 0);
            this.TabExternalTools.Name = "TabExternalTools";
            this.TabExternalTools.ShowCloseButton = true;
            this.TabExternalTools.Size = new System.Drawing.Size(200, 100);
            this.TabExternalTools.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TabExternalTools.TabForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TabExternalTools.TabIndex = 10;
            this.TabExternalTools.Text = "External Tools";
            this.TabExternalTools.ThemesEnabled = true;
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(886, 508);
            this.Controls.Add(this.PnlTabs);
            this.Controls.Add(this.BtnStore);
            this.Controls.Add(this.BtnAbout);
            this.Controls.Add(this.BtnHelp);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(131)))));
            this.Name = "Configuration";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Configuration_FormClosing);
            this.Load += new System.EventHandler(this.Configuration_Load);
            this.ResizeEnd += new System.EventHandler(this.Configuration_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Configuration_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.ConfigTabs)).EndInit();
            this.ConfigTabs.ResumeLayout(false);
            this.PnlTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.TabControlAdv ConfigTabs;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv TabHassApi;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv TabNotifications;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv TabMQTT;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv TabStartup;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv TabHotKey;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv TabUpdates;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv TabLogging;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv TabLocalStorage;
        private Syncfusion.WinForms.Controls.SfButton BtnAbout;
        private Syncfusion.WinForms.Controls.SfButton BtnHelp;
        private Syncfusion.WinForms.Controls.SfButton BtnStore;
        private System.Windows.Forms.Panel PnlTabs;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv TabGeneral;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv TabExternalTools;
    }
}

