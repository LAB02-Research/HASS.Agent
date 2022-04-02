using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Service
{
    partial class ServiceMqtt
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NumMqttPort = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.LblTip2 = new System.Windows.Forms.Label();
            this.TbMqttClientId = new System.Windows.Forms.TextBox();
            this.LblClientId = new System.Windows.Forms.Label();
            this.LblTip3 = new System.Windows.Forms.Label();
            this.TbMqttClientCertificate = new System.Windows.Forms.TextBox();
            this.LblClientCert = new System.Windows.Forms.Label();
            this.TbMqttRootCertificate = new System.Windows.Forms.TextBox();
            this.LblRootCert = new System.Windows.Forms.Label();
            this.CbUseRetainFlag = new System.Windows.Forms.CheckBox();
            this.CbAllowUntrustedCertificates = new System.Windows.Forms.CheckBox();
            this.BtnMqttClearConfig = new Syncfusion.WinForms.Controls.SfButton();
            this.LblTip1 = new System.Windows.Forms.Label();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.TbMqttDiscoveryPrefix = new System.Windows.Forms.TextBox();
            this.LblDiscoPrefix = new System.Windows.Forms.Label();
            this.TbMqttPassword = new System.Windows.Forms.TextBox();
            this.TbMqttUsername = new System.Windows.Forms.TextBox();
            this.TbMqttAddress = new System.Windows.Forms.TextBox();
            this.CbMqttTls = new System.Windows.Forms.CheckBox();
            this.LblBrokerPassword = new System.Windows.Forms.Label();
            this.LblBrokerUsername = new System.Windows.Forms.Label();
            this.LblBrokerPort = new System.Windows.Forms.Label();
            this.LblBrokerIp = new System.Windows.Forms.Label();
            this.BtnStore = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnCopy = new Syncfusion.WinForms.Controls.SfButton();
            this.LblStored = new System.Windows.Forms.Label();
            this.PbShow = new System.Windows.Forms.PictureBox();
            this.LblStatusInfo = new System.Windows.Forms.Label();
            this.LblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumMqttPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbShow)).BeginInit();
            this.SuspendLayout();
            // 
            // NumMqttPort
            // 
            this.NumMqttPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.NumMqttPort.BeforeTouchSize = new System.Drawing.Size(83, 25);
            this.NumMqttPort.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.NumMqttPort.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.NumMqttPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumMqttPort.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumMqttPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.NumMqttPort.Location = new System.Drawing.Point(138, 239);
            this.NumMqttPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumMqttPort.MaxLength = 10;
            this.NumMqttPort.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumMqttPort.Name = "NumMqttPort";
            this.NumMqttPort.Size = new System.Drawing.Size(83, 25);
            this.NumMqttPort.TabIndex = 95;
            this.NumMqttPort.ThemeName = "Metro";
            this.NumMqttPort.Value = new decimal(new int[] {
            1883,
            0,
            0,
            0});
            this.NumMqttPort.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // LblTip2
            // 
            this.LblTip2.AutoSize = true;
            this.LblTip2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip2.Location = new System.Drawing.Point(277, 507);
            this.LblTip2.Name = "LblTip2";
            this.LblTip2.Size = new System.Drawing.Size(142, 15);
            this.LblTip2.TabIndex = 94;
            this.LblTip2.Text = Languages.ServiceMqtt_LblTip2;
            // 
            // TbMqttClientId
            // 
            this.TbMqttClientId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttClientId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttClientId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbMqttClientId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttClientId.Location = new System.Drawing.Point(80, 503);
            this.TbMqttClientId.MaxLength = 100;
            this.TbMqttClientId.Name = "TbMqttClientId";
            this.TbMqttClientId.Size = new System.Drawing.Size(191, 25);
            this.TbMqttClientId.TabIndex = 92;
            // 
            // LblClientId
            // 
            this.LblClientId.AutoSize = true;
            this.LblClientId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblClientId.Location = new System.Drawing.Point(77, 481);
            this.LblClientId.Name = "LblClientId";
            this.LblClientId.Size = new System.Drawing.Size(56, 19);
            this.LblClientId.TabIndex = 93;
            this.LblClientId.Text = Languages.ServiceMqtt_LblClientId;
            // 
            // LblTip3
            // 
            this.LblTip3.AutoSize = true;
            this.LblTip3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip3.Location = new System.Drawing.Point(509, 267);
            this.LblTip3.Name = "LblTip3";
            this.LblTip3.Size = new System.Drawing.Size(205, 15);
            this.LblTip3.TabIndex = 91;
            this.LblTip3.Text = Languages.ServiceMqtt_LblTip3;
            // 
            // TbMqttClientCertificate
            // 
            this.TbMqttClientCertificate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttClientCertificate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttClientCertificate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbMqttClientCertificate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttClientCertificate.Location = new System.Drawing.Point(509, 239);
            this.TbMqttClientCertificate.Name = "TbMqttClientCertificate";
            this.TbMqttClientCertificate.Size = new System.Drawing.Size(268, 25);
            this.TbMqttClientCertificate.TabIndex = 89;
            this.TbMqttClientCertificate.DoubleClick += new System.EventHandler(this.TbMqttClientCertificate_DoubleClick);
            // 
            // LblClientCert
            // 
            this.LblClientCert.AutoSize = true;
            this.LblClientCert.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblClientCert.Location = new System.Drawing.Point(506, 217);
            this.LblClientCert.Name = "LblClientCert";
            this.LblClientCert.Size = new System.Drawing.Size(103, 19);
            this.LblClientCert.TabIndex = 90;
            this.LblClientCert.Text = Languages.ServiceMqtt_LblClientCert;
            // 
            // TbMqttRootCertificate
            // 
            this.TbMqttRootCertificate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttRootCertificate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttRootCertificate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbMqttRootCertificate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttRootCertificate.Location = new System.Drawing.Point(509, 179);
            this.TbMqttRootCertificate.Name = "TbMqttRootCertificate";
            this.TbMqttRootCertificate.Size = new System.Drawing.Size(268, 25);
            this.TbMqttRootCertificate.TabIndex = 87;
            this.TbMqttRootCertificate.DoubleClick += new System.EventHandler(this.TbMqttRootCertificate_DoubleClick);
            // 
            // LblRootCert
            // 
            this.LblRootCert.AutoSize = true;
            this.LblRootCert.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblRootCert.Location = new System.Drawing.Point(506, 157);
            this.LblRootCert.Name = "LblRootCert";
            this.LblRootCert.Size = new System.Drawing.Size(97, 19);
            this.LblRootCert.TabIndex = 88;
            this.LblRootCert.Text = Languages.ServiceMqtt_LblRootCert;
            // 
            // CbUseRetainFlag
            // 
            this.CbUseRetainFlag.AutoSize = true;
            this.CbUseRetainFlag.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbUseRetainFlag.Location = new System.Drawing.Point(506, 353);
            this.CbUseRetainFlag.Name = "CbUseRetainFlag";
            this.CbUseRetainFlag.Size = new System.Drawing.Size(114, 23);
            this.CbUseRetainFlag.TabIndex = 86;
            this.CbUseRetainFlag.Text = global::HASS.Agent.Resources.Localization.Languages.ServiceMqtt_CbUseRetainFlag;
            this.CbUseRetainFlag.UseVisualStyleBackColor = true;
            // 
            // CbAllowUntrustedCertificates
            // 
            this.CbAllowUntrustedCertificates.AutoSize = true;
            this.CbAllowUntrustedCertificates.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbAllowUntrustedCertificates.Location = new System.Drawing.Point(506, 313);
            this.CbAllowUntrustedCertificates.Name = "CbAllowUntrustedCertificates";
            this.CbAllowUntrustedCertificates.Size = new System.Drawing.Size(191, 23);
            this.CbAllowUntrustedCertificates.TabIndex = 85;
            this.CbAllowUntrustedCertificates.Text = global::HASS.Agent.Resources.Localization.Languages.ServiceMqtt_CbAllowUntrustedCertificates;
            this.CbAllowUntrustedCertificates.UseVisualStyleBackColor = true;
            // 
            // BtnMqttClearConfig
            // 
            this.BtnMqttClearConfig.AccessibleName = "Button";
            this.BtnMqttClearConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnMqttClearConfig.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnMqttClearConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnMqttClearConfig.Location = new System.Drawing.Point(666, 532);
            this.BtnMqttClearConfig.Name = "BtnMqttClearConfig";
            this.BtnMqttClearConfig.Size = new System.Drawing.Size(228, 31);
            this.BtnMqttClearConfig.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnMqttClearConfig.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnMqttClearConfig.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnMqttClearConfig.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnMqttClearConfig.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnMqttClearConfig.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnMqttClearConfig.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnMqttClearConfig.TabIndex = 84;
            this.BtnMqttClearConfig.Text = global::HASS.Agent.Resources.Localization.Languages.ServiceMqtt_BtnMqttClearConfig;
            this.BtnMqttClearConfig.UseVisualStyleBackColor = false;
            this.BtnMqttClearConfig.Click += new System.EventHandler(this.BtnMqttClearConfig_Click);
            // 
            // LblTip1
            // 
            this.LblTip1.AutoSize = true;
            this.LblTip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip1.Location = new System.Drawing.Point(277, 449);
            this.LblTip1.Name = "LblTip1";
            this.LblTip1.Size = new System.Drawing.Size(138, 15);
            this.LblTip1.TabIndex = 83;
            this.LblTip1.Text = Languages.ServiceMqtt_LblTip1;
            // 
            // LblInfo1
            // 
            this.LblInfo1.AutoSize = true;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(80, 24);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(749, 38);
            this.LblInfo1.TabIndex = 82;
            this.LblInfo1.Text = Languages.ServiceMqtt_LblInfo1;
            // 
            // TbMqttDiscoveryPrefix
            // 
            this.TbMqttDiscoveryPrefix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttDiscoveryPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttDiscoveryPrefix.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbMqttDiscoveryPrefix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttDiscoveryPrefix.Location = new System.Drawing.Point(80, 445);
            this.TbMqttDiscoveryPrefix.Name = "TbMqttDiscoveryPrefix";
            this.TbMqttDiscoveryPrefix.Size = new System.Drawing.Size(191, 25);
            this.TbMqttDiscoveryPrefix.TabIndex = 80;
            // 
            // LblDiscoPrefix
            // 
            this.LblDiscoPrefix.AutoSize = true;
            this.LblDiscoPrefix.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDiscoPrefix.Location = new System.Drawing.Point(77, 423);
            this.LblDiscoPrefix.Name = "LblDiscoPrefix";
            this.LblDiscoPrefix.Size = new System.Drawing.Size(103, 19);
            this.LblDiscoPrefix.TabIndex = 81;
            this.LblDiscoPrefix.Text = Languages.ServiceMqtt_LblDiscoPrefix;
            // 
            // TbMqttPassword
            // 
            this.TbMqttPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbMqttPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttPassword.Location = new System.Drawing.Point(78, 369);
            this.TbMqttPassword.Name = "TbMqttPassword";
            this.TbMqttPassword.Size = new System.Drawing.Size(191, 25);
            this.TbMqttPassword.TabIndex = 76;
            this.TbMqttPassword.UseSystemPasswordChar = true;
            // 
            // TbMqttUsername
            // 
            this.TbMqttUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbMqttUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttUsername.Location = new System.Drawing.Point(80, 311);
            this.TbMqttUsername.Name = "TbMqttUsername";
            this.TbMqttUsername.Size = new System.Drawing.Size(191, 25);
            this.TbMqttUsername.TabIndex = 75;
            // 
            // TbMqttAddress
            // 
            this.TbMqttAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttAddress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbMqttAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttAddress.Location = new System.Drawing.Point(80, 179);
            this.TbMqttAddress.Name = "TbMqttAddress";
            this.TbMqttAddress.Size = new System.Drawing.Size(259, 25);
            this.TbMqttAddress.TabIndex = 72;
            // 
            // CbMqttTls
            // 
            this.CbMqttTls.AutoSize = true;
            this.CbMqttTls.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbMqttTls.Location = new System.Drawing.Point(290, 237);
            this.CbMqttTls.Name = "CbMqttTls";
            this.CbMqttTls.Size = new System.Drawing.Size(49, 23);
            this.CbMqttTls.TabIndex = 73;
            this.CbMqttTls.Text = "TLS";
            this.CbMqttTls.UseVisualStyleBackColor = true;
            // 
            // LblBrokerPassword
            // 
            this.LblBrokerPassword.AutoSize = true;
            this.LblBrokerPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblBrokerPassword.Location = new System.Drawing.Point(77, 347);
            this.LblBrokerPassword.Name = "LblBrokerPassword";
            this.LblBrokerPassword.Size = new System.Drawing.Size(67, 19);
            this.LblBrokerPassword.TabIndex = 79;
            this.LblBrokerPassword.Text = Languages.ServiceMqtt_LblBrokerPassword;
            // 
            // LblBrokerUsername
            // 
            this.LblBrokerUsername.AutoSize = true;
            this.LblBrokerUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblBrokerUsername.Location = new System.Drawing.Point(77, 289);
            this.LblBrokerUsername.Name = "LblBrokerUsername";
            this.LblBrokerUsername.Size = new System.Drawing.Size(69, 19);
            this.LblBrokerUsername.TabIndex = 78;
            this.LblBrokerUsername.Text = Languages.ServiceMqtt_LblBrokerUsername;
            // 
            // LblBrokerPort
            // 
            this.LblBrokerPort.AutoSize = true;
            this.LblBrokerPort.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblBrokerPort.Location = new System.Drawing.Point(75, 239);
            this.LblBrokerPort.Name = "LblBrokerPort";
            this.LblBrokerPort.Size = new System.Drawing.Size(35, 19);
            this.LblBrokerPort.TabIndex = 77;
            this.LblBrokerPort.Text = Languages.ServiceMqtt_LblBrokerPort;
            // 
            // LblBrokerIp
            // 
            this.LblBrokerIp.AutoSize = true;
            this.LblBrokerIp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblBrokerIp.Location = new System.Drawing.Point(77, 157);
            this.LblBrokerIp.Name = "LblBrokerIp";
            this.LblBrokerIp.Size = new System.Drawing.Size(197, 19);
            this.LblBrokerIp.TabIndex = 74;
            this.LblBrokerIp.Text = Languages.ServiceMqtt_LblBrokerIp;
            // 
            // BtnStore
            // 
            this.BtnStore.AccessibleName = "Button";
            this.BtnStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnStore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Location = new System.Drawing.Point(0, 575);
            this.BtnStore.Name = "BtnStore";
            this.BtnStore.Size = new System.Drawing.Size(903, 47);
            this.BtnStore.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStore.TabIndex = 96;
            this.BtnStore.Text = global::HASS.Agent.Resources.Localization.Languages.ServiceMqtt_BtnStore;
            this.BtnStore.UseVisualStyleBackColor = false;
            this.BtnStore.Click += new System.EventHandler(this.BtnStore_Click);
            // 
            // BtnCopy
            // 
            this.BtnCopy.AccessibleName = "Button";
            this.BtnCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCopy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCopy.Location = new System.Drawing.Point(666, 491);
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.Size = new System.Drawing.Size(228, 31);
            this.BtnCopy.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCopy.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCopy.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCopy.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCopy.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCopy.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCopy.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnCopy.TabIndex = 97;
            this.BtnCopy.Text = global::HASS.Agent.Resources.Localization.Languages.ServiceMqtt_BtnCopy;
            this.BtnCopy.UseVisualStyleBackColor = false;
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // LblStored
            // 
            this.LblStored.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblStored.ForeColor = System.Drawing.Color.LimeGreen;
            this.LblStored.Location = new System.Drawing.Point(275, 533);
            this.LblStored.Name = "LblStored";
            this.LblStored.Size = new System.Drawing.Size(375, 30);
            this.LblStored.TabIndex = 98;
            this.LblStored.Text = Languages.ServiceMqtt_LblStored;
            this.LblStored.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.LblStored.Visible = false;
            // 
            // PbShow
            // 
            this.PbShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbShow.Image = global::HASS.Agent.Properties.Resources.show_24;
            this.PbShow.Location = new System.Drawing.Point(275, 370);
            this.PbShow.Name = "PbShow";
            this.PbShow.Size = new System.Drawing.Size(24, 24);
            this.PbShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbShow.TabIndex = 99;
            this.PbShow.TabStop = false;
            this.PbShow.Click += new System.EventHandler(this.PbShow_Click);
            // 
            // LblStatusInfo
            // 
            this.LblStatusInfo.AutoSize = true;
            this.LblStatusInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblStatusInfo.Location = new System.Drawing.Point(80, 102);
            this.LblStatusInfo.Name = "LblStatusInfo";
            this.LblStatusInfo.Size = new System.Drawing.Size(46, 19);
            this.LblStatusInfo.TabIndex = 100;
            this.LblStatusInfo.Text = Languages.ServiceMqtt_LblStatusInfo;
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.LblStatus.Location = new System.Drawing.Point(171, 102);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(73, 19);
            this.LblStatus.TabIndex = 101;
            this.LblStatus.Text = Languages.ServiceMqtt_LblStatus;
            // 
            // ServiceMqtt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.LblStatusInfo);
            this.Controls.Add(this.LblStatus);
            this.Controls.Add(this.PbShow);
            this.Controls.Add(this.LblStored);
            this.Controls.Add(this.BtnCopy);
            this.Controls.Add(this.BtnStore);
            this.Controls.Add(this.NumMqttPort);
            this.Controls.Add(this.LblTip2);
            this.Controls.Add(this.TbMqttClientId);
            this.Controls.Add(this.LblClientId);
            this.Controls.Add(this.LblTip3);
            this.Controls.Add(this.TbMqttClientCertificate);
            this.Controls.Add(this.LblClientCert);
            this.Controls.Add(this.TbMqttRootCertificate);
            this.Controls.Add(this.LblRootCert);
            this.Controls.Add(this.CbUseRetainFlag);
            this.Controls.Add(this.CbAllowUntrustedCertificates);
            this.Controls.Add(this.BtnMqttClearConfig);
            this.Controls.Add(this.LblTip1);
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.TbMqttDiscoveryPrefix);
            this.Controls.Add(this.LblDiscoPrefix);
            this.Controls.Add(this.TbMqttPassword);
            this.Controls.Add(this.TbMqttUsername);
            this.Controls.Add(this.TbMqttAddress);
            this.Controls.Add(this.CbMqttTls);
            this.Controls.Add(this.LblBrokerPassword);
            this.Controls.Add(this.LblBrokerUsername);
            this.Controls.Add(this.LblBrokerPort);
            this.Controls.Add(this.LblBrokerIp);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ServiceMqtt";
            this.Size = new System.Drawing.Size(903, 622);
            this.Load += new System.EventHandler(this.ServiceMqtt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumMqttPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumMqttPort;
        private Label LblTip2;
        internal TextBox TbMqttClientId;
        private Label LblClientId;
        private Label LblTip3;
        internal TextBox TbMqttClientCertificate;
        private Label LblClientCert;
        internal TextBox TbMqttRootCertificate;
        private Label LblRootCert;
        internal CheckBox CbUseRetainFlag;
        internal CheckBox CbAllowUntrustedCertificates;
        internal Syncfusion.WinForms.Controls.SfButton BtnMqttClearConfig;
        private Label LblTip1;
        private Label LblInfo1;
        internal TextBox TbMqttDiscoveryPrefix;
        private Label LblDiscoPrefix;
        internal TextBox TbMqttPassword;
        internal TextBox TbMqttUsername;
        internal TextBox TbMqttAddress;
        internal CheckBox CbMqttTls;
        private Label LblBrokerPassword;
        private Label LblBrokerUsername;
        private Label LblBrokerPort;
        private Label LblBrokerIp;
        private Syncfusion.WinForms.Controls.SfButton BtnStore;
        internal Syncfusion.WinForms.Controls.SfButton BtnCopy;
        private Label LblStored;
        private PictureBox PbShow;
        private Label LblStatusInfo;
        private Label LblStatus;
    }
}
