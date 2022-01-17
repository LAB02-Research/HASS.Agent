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
            this.TabHassApi = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.BtnTestApi = new Syncfusion.WinForms.Controls.SfButton();
            this.label11 = new System.Windows.Forms.Label();
            this.TbHassApiToken = new System.Windows.Forms.TextBox();
            this.TbHassIp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TabNotifications = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.label18 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TbIntNotifierApiPort = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.BtnNotificationsReadme = new Syncfusion.WinForms.Controls.SfButton();
            this.label1 = new System.Windows.Forms.Label();
            this.CbAcceptNotifications = new System.Windows.Forms.CheckBox();
            this.TabMQTT = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.BtnMqttClearConfig = new Syncfusion.WinForms.Controls.SfButton();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TbMqttDiscoveryPrefix = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TbIntMqttPort = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.TbMqttPassword = new System.Windows.Forms.TextBox();
            this.TbMqttUsername = new System.Windows.Forms.TextBox();
            this.TbMqttAddress = new System.Windows.Forms.TextBox();
            this.CbMqttTls = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TabStartup = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.label15 = new System.Windows.Forms.Label();
            this.BtnSetStartOnLogin = new Syncfusion.WinForms.Controls.SfButton();
            this.LblStartOnLoginStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TabHotKey = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.BtnClear = new Syncfusion.WinForms.Controls.SfButton();
            this.label16 = new System.Windows.Forms.Label();
            this.TbQuickActionsHotkey = new System.Windows.Forms.TextBox();
            this.CbEnableQuickActionsHotkey = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TabUpdates = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.label17 = new System.Windows.Forms.Label();
            this.CbUpdates = new System.Windows.Forms.CheckBox();
            this.TabLocalStorage = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.BtnClearImageCache = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnOpenImageCache = new Syncfusion.WinForms.Controls.SfButton();
            this.TbImageCacheLocation = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.TbIntImageRetention = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.TabLogging = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.LblCoderr = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.CbExceptionReporting = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.CbExtendedLogging = new System.Windows.Forms.CheckBox();
            this.BtnAbout = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnHelp = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnStore = new Syncfusion.WinForms.Controls.SfButton();
            this.PnlTabs = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigTabs)).BeginInit();
            this.ConfigTabs.SuspendLayout();
            this.TabHassApi.SuspendLayout();
            this.TabNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TbIntNotifierApiPort)).BeginInit();
            this.TabMQTT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TbIntMqttPort)).BeginInit();
            this.TabStartup.SuspendLayout();
            this.TabHotKey.SuspendLayout();
            this.TabUpdates.SuspendLayout();
            this.TabLocalStorage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TbIntImageRetention)).BeginInit();
            this.TabLogging.SuspendLayout();
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
            this.ConfigTabs.Controls.Add(this.TabHassApi);
            this.ConfigTabs.Controls.Add(this.TabNotifications);
            this.ConfigTabs.Controls.Add(this.TabMQTT);
            this.ConfigTabs.Controls.Add(this.TabStartup);
            this.ConfigTabs.Controls.Add(this.TabHotKey);
            this.ConfigTabs.Controls.Add(this.TabUpdates);
            this.ConfigTabs.Controls.Add(this.TabLocalStorage);
            this.ConfigTabs.Controls.Add(this.TabLogging);
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
            // TabHassApi
            // 
            this.TabHassApi.Controls.Add(this.BtnTestApi);
            this.TabHassApi.Controls.Add(this.label11);
            this.TabHassApi.Controls.Add(this.TbHassApiToken);
            this.TabHassApi.Controls.Add(this.TbHassIp);
            this.TabHassApi.Controls.Add(this.label3);
            this.TabHassApi.Controls.Add(this.label2);
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
            // BtnTestApi
            // 
            this.BtnTestApi.AccessibleName = "Button";
            this.BtnTestApi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnTestApi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTestApi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnTestApi.Location = new System.Drawing.Point(463, 264);
            this.BtnTestApi.Name = "BtnTestApi";
            this.BtnTestApi.Size = new System.Drawing.Size(180, 29);
            this.BtnTestApi.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnTestApi.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnTestApi.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnTestApi.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnTestApi.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnTestApi.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnTestApi.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnTestApi.TabIndex = 14;
            this.BtnTestApi.Text = "test connection";
            this.BtnTestApi.UseVisualStyleBackColor = false;
            this.BtnTestApi.Click += new System.EventHandler(this.BtnTestApi_Click);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(27, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(669, 96);
            this.label11.TabIndex = 15;
            this.label11.Text = resources.GetString("label11.Text");
            // 
            // TbHassApiToken
            // 
            this.TbHassApiToken.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbHassApiToken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbHassApiToken.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbHassApiToken.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbHassApiToken.Location = new System.Drawing.Point(159, 233);
            this.TbHassApiToken.Name = "TbHassApiToken";
            this.TbHassApiToken.Size = new System.Drawing.Size(484, 25);
            this.TbHassApiToken.TabIndex = 7;
            // 
            // TbHassIp
            // 
            this.TbHassIp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbHassIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbHassIp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbHassIp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbHassIp.Location = new System.Drawing.Point(159, 187);
            this.TbHassIp.Name = "TbHassIp";
            this.TbHassIp.Size = new System.Drawing.Size(484, 25);
            this.TbHassIp.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "api token:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "server uri:";
            // 
            // TabNotifications
            // 
            this.TabNotifications.Controls.Add(this.label18);
            this.TabNotifications.Controls.Add(this.label12);
            this.TabNotifications.Controls.Add(this.TbIntNotifierApiPort);
            this.TabNotifications.Controls.Add(this.BtnNotificationsReadme);
            this.TabNotifications.Controls.Add(this.label1);
            this.TabNotifications.Controls.Add(this.CbAcceptNotifications);
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
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(27, 219);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(393, 156);
            this.label18.TabIndex = 31;
            this.label18.Text = resources.GetString("label18.Text");
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(27, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(677, 58);
            this.label12.TabIndex = 25;
            this.label12.Text = "HASS.Agent can receive notifications from Home Assistant, using text and/or image" +
    "s.\r\n\r\n";
            // 
            // TbIntNotifierApiPort
            // 
            this.TbIntNotifierApiPort.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbIntNotifierApiPort.BeforeTouchSize = new System.Drawing.Size(67, 25);
            this.TbIntNotifierApiPort.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntNotifierApiPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbIntNotifierApiPort.CurrentCultureRefresh = true;
            this.TbIntNotifierApiPort.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntNotifierApiPort.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbIntNotifierApiPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntNotifierApiPort.IntegerValue = ((long)(1883));
            this.TbIntNotifierApiPort.Location = new System.Drawing.Point(160, 98);
            this.TbIntNotifierApiPort.MaxValue = ((long)(66000));
            this.TbIntNotifierApiPort.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntNotifierApiPort.MinValue = ((long)(1));
            this.TbIntNotifierApiPort.Name = "TbIntNotifierApiPort";
            this.TbIntNotifierApiPort.NumberGroupSeparator = "";
            this.TbIntNotifierApiPort.PositiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntNotifierApiPort.Size = new System.Drawing.Size(92, 25);
            this.TbIntNotifierApiPort.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.UICulture;
            this.TbIntNotifierApiPort.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.TbIntNotifierApiPort.TabIndex = 4;
            this.TbIntNotifierApiPort.Text = "1883";
            this.TbIntNotifierApiPort.ThemeName = "Metro";
            this.TbIntNotifierApiPort.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbIntNotifierApiPort.ThemeStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntNotifierApiPort.ThemeStyle.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntNotifierApiPort.ThemeStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntNotifierApiPort.ThemeStyle.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntNotifierApiPort.ThemeStyle.ZeroForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntNotifierApiPort.ZeroColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            // 
            // BtnNotificationsReadme
            // 
            this.BtnNotificationsReadme.AccessibleName = "Button";
            this.BtnNotificationsReadme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnNotificationsReadme.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNotificationsReadme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnNotificationsReadme.Location = new System.Drawing.Point(476, 411);
            this.BtnNotificationsReadme.Name = "BtnNotificationsReadme";
            this.BtnNotificationsReadme.Size = new System.Drawing.Size(228, 31);
            this.BtnNotificationsReadme.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnNotificationsReadme.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnNotificationsReadme.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnNotificationsReadme.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnNotificationsReadme.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnNotificationsReadme.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnNotificationsReadme.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnNotificationsReadme.TabIndex = 7;
            this.BtnNotificationsReadme.Text = "notifications readme";
            this.BtnNotificationsReadme.UseVisualStyleBackColor = false;
            this.BtnNotificationsReadme.Click += new System.EventHandler(this.BtnNotificationsReadme_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(119, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "port";
            // 
            // CbAcceptNotifications
            // 
            this.CbAcceptNotifications.AutoSize = true;
            this.CbAcceptNotifications.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbAcceptNotifications.Location = new System.Drawing.Point(282, 99);
            this.CbAcceptNotifications.Name = "CbAcceptNotifications";
            this.CbAcceptNotifications.Size = new System.Drawing.Size(139, 21);
            this.CbAcceptNotifications.TabIndex = 5;
            this.CbAcceptNotifications.Text = "accept notifications";
            this.CbAcceptNotifications.UseVisualStyleBackColor = true;
            // 
            // TabMQTT
            // 
            this.TabMQTT.Controls.Add(this.BtnMqttClearConfig);
            this.TabMQTT.Controls.Add(this.label14);
            this.TabMQTT.Controls.Add(this.label13);
            this.TabMQTT.Controls.Add(this.TbMqttDiscoveryPrefix);
            this.TabMQTT.Controls.Add(this.label10);
            this.TabMQTT.Controls.Add(this.TbIntMqttPort);
            this.TabMQTT.Controls.Add(this.TbMqttPassword);
            this.TabMQTT.Controls.Add(this.TbMqttUsername);
            this.TabMQTT.Controls.Add(this.TbMqttAddress);
            this.TabMQTT.Controls.Add(this.CbMqttTls);
            this.TabMQTT.Controls.Add(this.label9);
            this.TabMQTT.Controls.Add(this.label8);
            this.TabMQTT.Controls.Add(this.label7);
            this.TabMQTT.Controls.Add(this.label6);
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
            // BtnMqttClearConfig
            // 
            this.BtnMqttClearConfig.AccessibleName = "Button";
            this.BtnMqttClearConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnMqttClearConfig.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMqttClearConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnMqttClearConfig.Location = new System.Drawing.Point(476, 411);
            this.BtnMqttClearConfig.Name = "BtnMqttClearConfig";
            this.BtnMqttClearConfig.Size = new System.Drawing.Size(228, 31);
            this.BtnMqttClearConfig.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnMqttClearConfig.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnMqttClearConfig.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnMqttClearConfig.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnMqttClearConfig.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnMqttClearConfig.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnMqttClearConfig.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnMqttClearConfig.TabIndex = 36;
            this.BtnMqttClearConfig.Text = "clear config";
            this.BtnMqttClearConfig.UseVisualStyleBackColor = false;
            this.BtnMqttClearConfig.Click += new System.EventHandler(this.BtnMqttClearConfig_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(269, 356);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(135, 13);
            this.label14.TabIndex = 35;
            this.label14.Text = "(leave default if not sure)";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(27, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(670, 80);
            this.label13.TabIndex = 28;
            this.label13.Text = resources.GetString("label13.Text");
            // 
            // TbMqttDiscoveryPrefix
            // 
            this.TbMqttDiscoveryPrefix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttDiscoveryPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttDiscoveryPrefix.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbMqttDiscoveryPrefix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttDiscoveryPrefix.Location = new System.Drawing.Point(72, 351);
            this.TbMqttDiscoveryPrefix.Name = "TbMqttDiscoveryPrefix";
            this.TbMqttDiscoveryPrefix.Size = new System.Drawing.Size(191, 25);
            this.TbMqttDiscoveryPrefix.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(71, 331);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 17);
            this.label10.TabIndex = 24;
            this.label10.Text = "discovery prefix";
            // 
            // TbIntMqttPort
            // 
            this.TbIntMqttPort.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbIntMqttPort.BeforeTouchSize = new System.Drawing.Size(67, 25);
            this.TbIntMqttPort.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntMqttPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbIntMqttPort.CurrentCultureRefresh = true;
            this.TbIntMqttPort.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntMqttPort.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbIntMqttPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntMqttPort.IntegerValue = ((long)(1883));
            this.TbIntMqttPort.Location = new System.Drawing.Point(107, 187);
            this.TbIntMqttPort.MaxValue = ((long)(66000));
            this.TbIntMqttPort.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntMqttPort.MinValue = ((long)(1));
            this.TbIntMqttPort.Name = "TbIntMqttPort";
            this.TbIntMqttPort.NumberGroupSeparator = "";
            this.TbIntMqttPort.PositiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntMqttPort.Size = new System.Drawing.Size(92, 25);
            this.TbIntMqttPort.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.UICulture;
            this.TbIntMqttPort.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.TbIntMqttPort.TabIndex = 15;
            this.TbIntMqttPort.Text = "1883";
            this.TbIntMqttPort.ThemeName = "Metro";
            this.TbIntMqttPort.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbIntMqttPort.ThemeStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntMqttPort.ThemeStyle.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntMqttPort.ThemeStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntMqttPort.ThemeStyle.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntMqttPort.ThemeStyle.ZeroForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntMqttPort.ZeroColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            // 
            // TbMqttPassword
            // 
            this.TbMqttPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbMqttPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttPassword.Location = new System.Drawing.Point(72, 298);
            this.TbMqttPassword.Name = "TbMqttPassword";
            this.TbMqttPassword.Size = new System.Drawing.Size(191, 25);
            this.TbMqttPassword.TabIndex = 19;
            this.TbMqttPassword.UseSystemPasswordChar = true;
            // 
            // TbMqttUsername
            // 
            this.TbMqttUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbMqttUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttUsername.Location = new System.Drawing.Point(74, 246);
            this.TbMqttUsername.Name = "TbMqttUsername";
            this.TbMqttUsername.Size = new System.Drawing.Size(191, 25);
            this.TbMqttUsername.TabIndex = 18;
            // 
            // TbMqttAddress
            // 
            this.TbMqttAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbMqttAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttAddress.Location = new System.Drawing.Point(74, 144);
            this.TbMqttAddress.Name = "TbMqttAddress";
            this.TbMqttAddress.Size = new System.Drawing.Size(330, 25);
            this.TbMqttAddress.TabIndex = 14;
            // 
            // CbMqttTls
            // 
            this.CbMqttTls.AutoSize = true;
            this.CbMqttTls.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbMqttTls.Location = new System.Drawing.Point(222, 192);
            this.CbMqttTls.Name = "CbMqttTls";
            this.CbMqttTls.Size = new System.Drawing.Size(47, 21);
            this.CbMqttTls.TabIndex = 16;
            this.CbMqttTls.Text = "TLS";
            this.CbMqttTls.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(71, 278);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "password";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(71, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "username";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(69, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "port";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(71, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "ip address or hostname";
            // 
            // TabStartup
            // 
            this.TabStartup.Controls.Add(this.label15);
            this.TabStartup.Controls.Add(this.BtnSetStartOnLogin);
            this.TabStartup.Controls.Add(this.LblStartOnLoginStatus);
            this.TabStartup.Controls.Add(this.label4);
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
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(27, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(668, 96);
            this.label15.TabIndex = 11;
            this.label15.Text = resources.GetString("label15.Text");
            // 
            // BtnSetStartOnLogin
            // 
            this.BtnSetStartOnLogin.AccessibleName = "Button";
            this.BtnSetStartOnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSetStartOnLogin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSetStartOnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSetStartOnLogin.Location = new System.Drawing.Point(128, 223);
            this.BtnSetStartOnLogin.Name = "BtnSetStartOnLogin";
            this.BtnSetStartOnLogin.Size = new System.Drawing.Size(295, 31);
            this.BtnSetStartOnLogin.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSetStartOnLogin.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSetStartOnLogin.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSetStartOnLogin.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSetStartOnLogin.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSetStartOnLogin.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSetStartOnLogin.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnSetStartOnLogin.TabIndex = 9;
            this.BtnSetStartOnLogin.Text = "enable start-on-login";
            this.BtnSetStartOnLogin.UseVisualStyleBackColor = false;
            this.BtnSetStartOnLogin.Click += new System.EventHandler(this.BtnSetStartOnLogin_Click);
            // 
            // LblStartOnLoginStatus
            // 
            this.LblStartOnLoginStatus.AutoSize = true;
            this.LblStartOnLoginStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStartOnLoginStatus.Location = new System.Drawing.Point(298, 169);
            this.LblStartOnLoginStatus.Name = "LblStartOnLoginStatus";
            this.LblStartOnLoginStatus.Size = new System.Drawing.Size(13, 17);
            this.LblStartOnLoginStatus.TabIndex = 8;
            this.LblStartOnLoginStatus.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(125, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "start-on-login status:";
            // 
            // TabHotKey
            // 
            this.TabHotKey.Controls.Add(this.BtnClear);
            this.TabHotKey.Controls.Add(this.label16);
            this.TabHotKey.Controls.Add(this.TbQuickActionsHotkey);
            this.TabHotKey.Controls.Add(this.CbEnableQuickActionsHotkey);
            this.TabHotKey.Controls.Add(this.label5);
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
            // BtnClear
            // 
            this.BtnClear.AccessibleName = "Button";
            this.BtnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClear.Location = new System.Drawing.Point(362, 237);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(102, 25);
            this.BtnClear.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClear.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClear.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClear.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClear.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClear.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClear.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnClear.TabIndex = 13;
            this.BtnClear.Text = "clear";
            this.BtnClear.UseVisualStyleBackColor = false;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(27, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(664, 62);
            this.label16.TabIndex = 12;
            this.label16.Text = "An easy way to pull up your quick actions is to use a global hotkey.\r\n\r\nThis way," +
    " whatever you\'re doing on your machine, you can always interact with Home Assist" +
    "ant.\r\n";
            // 
            // TbQuickActionsHotkey
            // 
            this.TbQuickActionsHotkey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbQuickActionsHotkey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbQuickActionsHotkey.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbQuickActionsHotkey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbQuickActionsHotkey.Location = new System.Drawing.Point(125, 237);
            this.TbQuickActionsHotkey.Name = "TbQuickActionsHotkey";
            this.TbQuickActionsHotkey.Size = new System.Drawing.Size(231, 25);
            this.TbQuickActionsHotkey.TabIndex = 11;
            // 
            // CbEnableQuickActionsHotkey
            // 
            this.CbEnableQuickActionsHotkey.AutoSize = true;
            this.CbEnableQuickActionsHotkey.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbEnableQuickActionsHotkey.Location = new System.Drawing.Point(125, 169);
            this.CbEnableQuickActionsHotkey.Name = "CbEnableQuickActionsHotkey";
            this.CbEnableQuickActionsHotkey.Size = new System.Drawing.Size(187, 21);
            this.CbEnableQuickActionsHotkey.TabIndex = 10;
            this.CbEnableQuickActionsHotkey.Text = "enable quick actions hotkey";
            this.CbEnableQuickActionsHotkey.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(122, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "hotkey combination";
            // 
            // TabUpdates
            // 
            this.TabUpdates.Controls.Add(this.label17);
            this.TabUpdates.Controls.Add(this.CbUpdates);
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
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(27, 19);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(668, 69);
            this.label17.TabIndex = 13;
            this.label17.Text = "If you want, HASS.Agent can check for updates in the background. \r\n\r\nYou\'ll get a" +
    " notification (once per update) , letting you know a new version is ready to be " +
    "installed.";
            // 
            // CbUpdates
            // 
            this.CbUpdates.AutoSize = true;
            this.CbUpdates.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbUpdates.Location = new System.Drawing.Point(125, 169);
            this.CbUpdates.Name = "CbUpdates";
            this.CbUpdates.Size = new System.Drawing.Size(267, 21);
            this.CbUpdates.TabIndex = 8;
            this.CbUpdates.Text = "notify me when a new release is available";
            this.CbUpdates.UseVisualStyleBackColor = true;
            // 
            // TabLocalStorage
            // 
            this.TabLocalStorage.Controls.Add(this.BtnClearImageCache);
            this.TabLocalStorage.Controls.Add(this.BtnOpenImageCache);
            this.TabLocalStorage.Controls.Add(this.TbImageCacheLocation);
            this.TabLocalStorage.Controls.Add(this.label21);
            this.TabLocalStorage.Controls.Add(this.label20);
            this.TabLocalStorage.Controls.Add(this.TbIntImageRetention);
            this.TabLocalStorage.Controls.Add(this.label19);
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
            // BtnClearImageCache
            // 
            this.BtnClearImageCache.AccessibleName = "Button";
            this.BtnClearImageCache.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClearImageCache.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClearImageCache.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClearImageCache.Location = new System.Drawing.Point(438, 87);
            this.BtnClearImageCache.Name = "BtnClearImageCache";
            this.BtnClearImageCache.Size = new System.Drawing.Size(197, 25);
            this.BtnClearImageCache.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClearImageCache.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClearImageCache.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClearImageCache.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClearImageCache.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClearImageCache.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClearImageCache.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnClearImageCache.TabIndex = 29;
            this.BtnClearImageCache.Text = "clear image cache";
            this.BtnClearImageCache.UseVisualStyleBackColor = false;
            this.BtnClearImageCache.Click += new System.EventHandler(this.BtnClearImageCache_Click);
            // 
            // BtnOpenImageCache
            // 
            this.BtnOpenImageCache.AccessibleName = "Button";
            this.BtnOpenImageCache.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnOpenImageCache.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpenImageCache.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnOpenImageCache.Location = new System.Drawing.Point(510, 198);
            this.BtnOpenImageCache.Name = "BtnOpenImageCache";
            this.BtnOpenImageCache.Size = new System.Drawing.Size(125, 25);
            this.BtnOpenImageCache.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnOpenImageCache.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnOpenImageCache.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnOpenImageCache.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnOpenImageCache.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnOpenImageCache.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnOpenImageCache.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnOpenImageCache.TabIndex = 28;
            this.BtnOpenImageCache.Text = "open folder";
            this.BtnOpenImageCache.UseVisualStyleBackColor = false;
            this.BtnOpenImageCache.Click += new System.EventHandler(this.BtnOpenImageCache_Click);
            // 
            // TbImageCacheLocation
            // 
            this.TbImageCacheLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbImageCacheLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbImageCacheLocation.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbImageCacheLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbImageCacheLocation.Location = new System.Drawing.Point(96, 167);
            this.TbImageCacheLocation.Name = "TbImageCacheLocation";
            this.TbImageCacheLocation.ReadOnly = true;
            this.TbImageCacheLocation.Size = new System.Drawing.Size(539, 25);
            this.TbImageCacheLocation.TabIndex = 27;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(93, 147);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(131, 17);
            this.label21.TabIndex = 26;
            this.label21.Text = "image cache location";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(172, 91);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 17);
            this.label20.TabIndex = 25;
            this.label20.Text = "days";
            // 
            // TbIntImageRetention
            // 
            this.TbIntImageRetention.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbIntImageRetention.BeforeTouchSize = new System.Drawing.Size(67, 25);
            this.TbIntImageRetention.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntImageRetention.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbIntImageRetention.CurrentCultureRefresh = true;
            this.TbIntImageRetention.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntImageRetention.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbIntImageRetention.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntImageRetention.IntegerValue = ((long)(7));
            this.TbIntImageRetention.Location = new System.Drawing.Point(96, 87);
            this.TbIntImageRetention.MaxValue = ((long)(365));
            this.TbIntImageRetention.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntImageRetention.MinValue = ((long)(0));
            this.TbIntImageRetention.Name = "TbIntImageRetention";
            this.TbIntImageRetention.PositiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntImageRetention.Size = new System.Drawing.Size(67, 25);
            this.TbIntImageRetention.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.UICulture;
            this.TbIntImageRetention.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.TbIntImageRetention.TabIndex = 24;
            this.TbIntImageRetention.Text = "7";
            this.TbIntImageRetention.ThemeName = "Metro";
            this.TbIntImageRetention.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbIntImageRetention.ThemeStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntImageRetention.ThemeStyle.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntImageRetention.ThemeStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntImageRetention.ThemeStyle.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntImageRetention.ThemeStyle.ZeroForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntImageRetention.ZeroColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(27, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(634, 46);
            this.label19.TabIndex = 23;
            this.label19.Text = "Images shown in notifications have to be temporarily stored locally. You can conf" +
    "igure the amount of days they should be kept before HASS.Agent deletes them. Ent" +
    "er \'0\' to keep them permanently.";
            // 
            // TabLogging
            // 
            this.TabLogging.Controls.Add(this.LblCoderr);
            this.TabLogging.Controls.Add(this.label22);
            this.TabLogging.Controls.Add(this.CbExceptionReporting);
            this.TabLogging.Controls.Add(this.label23);
            this.TabLogging.Controls.Add(this.CbExtendedLogging);
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
            // LblCoderr
            // 
            this.LblCoderr.AutoSize = true;
            this.LblCoderr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblCoderr.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCoderr.Location = new System.Drawing.Point(654, 426);
            this.LblCoderr.Name = "LblCoderr";
            this.LblCoderr.Size = new System.Drawing.Size(49, 17);
            this.LblCoderr.TabIndex = 29;
            this.LblCoderr.Text = "Coderr";
            this.LblCoderr.Click += new System.EventHandler(this.LblCoderr_Click);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(110, 194);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(535, 124);
            this.label22.TabIndex = 28;
            this.label22.Text = resources.GetString("label22.Text");
            // 
            // CbExceptionReporting
            // 
            this.CbExceptionReporting.AutoSize = true;
            this.CbExceptionReporting.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbExceptionReporting.Location = new System.Drawing.Point(113, 331);
            this.CbExceptionReporting.Name = "CbExceptionReporting";
            this.CbExceptionReporting.Size = new System.Drawing.Size(185, 21);
            this.CbExceptionReporting.TabIndex = 27;
            this.CbExceptionReporting.Text = "enable exception reporting";
            this.CbExceptionReporting.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(110, 40);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(535, 82);
            this.label23.TabIndex = 26;
            this.label23.Text = resources.GetString("label23.Text");
            // 
            // CbExtendedLogging
            // 
            this.CbExtendedLogging.AutoSize = true;
            this.CbExtendedLogging.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbExtendedLogging.Location = new System.Drawing.Point(113, 125);
            this.CbExtendedLogging.Name = "CbExtendedLogging";
            this.CbExtendedLogging.Size = new System.Drawing.Size(173, 21);
            this.CbExtendedLogging.TabIndex = 25;
            this.CbExtendedLogging.Text = "enable extended logging";
            this.CbExtendedLogging.UseVisualStyleBackColor = true;
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
            this.BtnHelp.Text = "help && documentation";
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
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(887, 508);
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
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Configuration_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.ConfigTabs)).EndInit();
            this.ConfigTabs.ResumeLayout(false);
            this.TabHassApi.ResumeLayout(false);
            this.TabHassApi.PerformLayout();
            this.TabNotifications.ResumeLayout(false);
            this.TabNotifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TbIntNotifierApiPort)).EndInit();
            this.TabMQTT.ResumeLayout(false);
            this.TabMQTT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TbIntMqttPort)).EndInit();
            this.TabStartup.ResumeLayout(false);
            this.TabStartup.PerformLayout();
            this.TabHotKey.ResumeLayout(false);
            this.TabHotKey.PerformLayout();
            this.TabUpdates.ResumeLayout(false);
            this.TabUpdates.PerformLayout();
            this.TabLocalStorage.ResumeLayout(false);
            this.TabLocalStorage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TbIntImageRetention)).EndInit();
            this.TabLogging.ResumeLayout(false);
            this.TabLogging.PerformLayout();
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
        private System.Windows.Forms.TextBox TbHassApiToken;
        private System.Windows.Forms.TextBox TbHassIp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox TbIntNotifierApiPort;
        private Syncfusion.WinForms.Controls.SfButton BtnNotificationsReadme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CbAcceptNotifications;
        private System.Windows.Forms.TextBox TbMqttDiscoveryPrefix;
        private System.Windows.Forms.Label label10;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox TbIntMqttPort;
        private System.Windows.Forms.TextBox TbMqttPassword;
        private System.Windows.Forms.TextBox TbMqttUsername;
        private System.Windows.Forms.TextBox TbMqttAddress;
        private System.Windows.Forms.CheckBox CbMqttTls;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Syncfusion.WinForms.Controls.SfButton BtnSetStartOnLogin;
        private System.Windows.Forms.Label LblStartOnLoginStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TbQuickActionsHotkey;
        private System.Windows.Forms.CheckBox CbEnableQuickActionsHotkey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox CbUpdates;
        private Syncfusion.WinForms.Controls.SfButton BtnAbout;
        private Syncfusion.WinForms.Controls.SfButton BtnHelp;
        private Syncfusion.WinForms.Controls.SfButton BtnStore;
        private System.Windows.Forms.Panel PnlTabs;
        private Syncfusion.WinForms.Controls.SfButton BtnTestApi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private Syncfusion.WinForms.Controls.SfButton BtnClear;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private Syncfusion.WinForms.Controls.SfButton BtnMqttClearConfig;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox TbIntImageRetention;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox TbImageCacheLocation;
        private System.Windows.Forms.Label label21;
        private Syncfusion.WinForms.Controls.SfButton BtnOpenImageCache;
        private Syncfusion.WinForms.Controls.SfButton BtnClearImageCache;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.CheckBox CbExtendedLogging;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox CbExceptionReporting;
        private System.Windows.Forms.Label LblCoderr;
    }
}

