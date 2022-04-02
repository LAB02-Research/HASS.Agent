using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Configuration
{
    partial class ConfigMqtt
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
            this.LblTip2 = new System.Windows.Forms.Label();
            this.TbMqttClientId = new System.Windows.Forms.TextBox();
            this.LblClientId = new System.Windows.Forms.Label();
            this.NumMqttPort = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.PbShow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumMqttPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbShow)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTip3
            // 
            this.LblTip3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip3.Location = new System.Drawing.Point(413, 243);
            this.LblTip3.Name = "LblTip3";
            this.LblTip3.Size = new System.Drawing.Size(268, 21);
            this.LblTip3.TabIndex = 64;
            this.LblTip3.Text = Languages.ConfigMqtt_LblTip3;
            // 
            // TbMqttClientCertificate
            // 
            this.TbMqttClientCertificate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttClientCertificate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttClientCertificate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbMqttClientCertificate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttClientCertificate.Location = new System.Drawing.Point(413, 215);
            this.TbMqttClientCertificate.Name = "TbMqttClientCertificate";
            this.TbMqttClientCertificate.Size = new System.Drawing.Size(268, 25);
            this.TbMqttClientCertificate.TabIndex = 62;
            this.TbMqttClientCertificate.DoubleClick += new System.EventHandler(this.TbMqttClientCertificate_DoubleClick);
            // 
            // LblClientCert
            // 
            this.LblClientCert.AutoSize = true;
            this.LblClientCert.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblClientCert.Location = new System.Drawing.Point(410, 193);
            this.LblClientCert.Name = "LblClientCert";
            this.LblClientCert.Size = new System.Drawing.Size(103, 19);
            this.LblClientCert.TabIndex = 63;
            this.LblClientCert.Text = Languages.ConfigMqtt_LblClientCert;
            // 
            // TbMqttRootCertificate
            // 
            this.TbMqttRootCertificate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttRootCertificate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttRootCertificate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbMqttRootCertificate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttRootCertificate.Location = new System.Drawing.Point(413, 155);
            this.TbMqttRootCertificate.Name = "TbMqttRootCertificate";
            this.TbMqttRootCertificate.Size = new System.Drawing.Size(268, 25);
            this.TbMqttRootCertificate.TabIndex = 60;
            this.TbMqttRootCertificate.DoubleClick += new System.EventHandler(this.TbMqttRootCertificate_DoubleClick);
            // 
            // LblRootCert
            // 
            this.LblRootCert.AutoSize = true;
            this.LblRootCert.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblRootCert.Location = new System.Drawing.Point(410, 133);
            this.LblRootCert.Name = "LblRootCert";
            this.LblRootCert.Size = new System.Drawing.Size(97, 19);
            this.LblRootCert.TabIndex = 61;
            this.LblRootCert.Text = Languages.ConfigMqtt_LblRootCert;
            // 
            // CbUseRetainFlag
            // 
            this.CbUseRetainFlag.AutoSize = true;
            this.CbUseRetainFlag.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbUseRetainFlag.Location = new System.Drawing.Point(410, 345);
            this.CbUseRetainFlag.Name = "CbUseRetainFlag";
            this.CbUseRetainFlag.Size = new System.Drawing.Size(114, 23);
            this.CbUseRetainFlag.TabIndex = 59;
            this.CbUseRetainFlag.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigMqtt_CbUseRetainFlag;
            this.CbUseRetainFlag.UseVisualStyleBackColor = true;
            // 
            // CbAllowUntrustedCertificates
            // 
            this.CbAllowUntrustedCertificates.AutoSize = true;
            this.CbAllowUntrustedCertificates.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbAllowUntrustedCertificates.Location = new System.Drawing.Point(410, 287);
            this.CbAllowUntrustedCertificates.Name = "CbAllowUntrustedCertificates";
            this.CbAllowUntrustedCertificates.Size = new System.Drawing.Size(191, 23);
            this.CbAllowUntrustedCertificates.TabIndex = 58;
            this.CbAllowUntrustedCertificates.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigMqtt_CbAllowUntrustedCertificates;
            this.CbAllowUntrustedCertificates.UseVisualStyleBackColor = true;
            // 
            // BtnMqttClearConfig
            // 
            this.BtnMqttClearConfig.AccessibleName = "Button";
            this.BtnMqttClearConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnMqttClearConfig.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnMqttClearConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnMqttClearConfig.Location = new System.Drawing.Point(453, 498);
            this.BtnMqttClearConfig.Name = "BtnMqttClearConfig";
            this.BtnMqttClearConfig.Size = new System.Drawing.Size(228, 31);
            this.BtnMqttClearConfig.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnMqttClearConfig.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnMqttClearConfig.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnMqttClearConfig.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnMqttClearConfig.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnMqttClearConfig.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnMqttClearConfig.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnMqttClearConfig.TabIndex = 57;
            this.BtnMqttClearConfig.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigMqtt_BtnMqttClearConfig;
            this.BtnMqttClearConfig.UseVisualStyleBackColor = false;
            this.BtnMqttClearConfig.Click += new System.EventHandler(this.BtnMqttClearConfig_Click);
            // 
            // LblTip1
            // 
            this.LblTip1.AutoSize = true;
            this.LblTip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip1.Location = new System.Drawing.Point(252, 421);
            this.LblTip1.Name = "LblTip1";
            this.LblTip1.Size = new System.Drawing.Size(138, 15);
            this.LblTip1.TabIndex = 56;
            this.LblTip1.Text = Languages.ConfigMqtt_LblTip1;
            // 
            // LblInfo1
            // 
            this.LblInfo1.AutoSize = true;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(70, 36);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(577, 38);
            this.LblInfo1.TabIndex = 55;
            this.LblInfo1.Text = Languages.ConfigMqtt_LblInfo1;
            // 
            // TbMqttDiscoveryPrefix
            // 
            this.TbMqttDiscoveryPrefix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttDiscoveryPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttDiscoveryPrefix.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbMqttDiscoveryPrefix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttDiscoveryPrefix.Location = new System.Drawing.Point(55, 417);
            this.TbMqttDiscoveryPrefix.Name = "TbMqttDiscoveryPrefix";
            this.TbMqttDiscoveryPrefix.Size = new System.Drawing.Size(191, 25);
            this.TbMqttDiscoveryPrefix.TabIndex = 53;
            // 
            // LblDiscoPrefix
            // 
            this.LblDiscoPrefix.AutoSize = true;
            this.LblDiscoPrefix.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDiscoPrefix.Location = new System.Drawing.Point(52, 395);
            this.LblDiscoPrefix.Name = "LblDiscoPrefix";
            this.LblDiscoPrefix.Size = new System.Drawing.Size(103, 19);
            this.LblDiscoPrefix.TabIndex = 54;
            this.LblDiscoPrefix.Text = Languages.ConfigMqtt_LblDiscoPrefix;
            // 
            // TbMqttPassword
            // 
            this.TbMqttPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbMqttPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttPassword.Location = new System.Drawing.Point(55, 345);
            this.TbMqttPassword.Name = "TbMqttPassword";
            this.TbMqttPassword.Size = new System.Drawing.Size(191, 25);
            this.TbMqttPassword.TabIndex = 49;
            this.TbMqttPassword.UseSystemPasswordChar = true;
            // 
            // TbMqttUsername
            // 
            this.TbMqttUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbMqttUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttUsername.Location = new System.Drawing.Point(57, 287);
            this.TbMqttUsername.Name = "TbMqttUsername";
            this.TbMqttUsername.Size = new System.Drawing.Size(191, 25);
            this.TbMqttUsername.TabIndex = 48;
            // 
            // TbMqttAddress
            // 
            this.TbMqttAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttAddress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbMqttAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttAddress.Location = new System.Drawing.Point(57, 155);
            this.TbMqttAddress.Name = "TbMqttAddress";
            this.TbMqttAddress.Size = new System.Drawing.Size(259, 25);
            this.TbMqttAddress.TabIndex = 44;
            // 
            // CbMqttTls
            // 
            this.CbMqttTls.AutoSize = true;
            this.CbMqttTls.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbMqttTls.Location = new System.Drawing.Point(218, 215);
            this.CbMqttTls.Name = "CbMqttTls";
            this.CbMqttTls.Size = new System.Drawing.Size(49, 23);
            this.CbMqttTls.TabIndex = 46;
            this.CbMqttTls.Text = "TLS";
            this.CbMqttTls.UseVisualStyleBackColor = true;
            // 
            // LblBrokerPassword
            // 
            this.LblBrokerPassword.AutoSize = true;
            this.LblBrokerPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblBrokerPassword.Location = new System.Drawing.Point(54, 323);
            this.LblBrokerPassword.Name = "LblBrokerPassword";
            this.LblBrokerPassword.Size = new System.Drawing.Size(67, 19);
            this.LblBrokerPassword.TabIndex = 52;
            this.LblBrokerPassword.Text = Languages.ConfigMqtt_LblBrokerPassword;
            // 
            // LblBrokerUsername
            // 
            this.LblBrokerUsername.AutoSize = true;
            this.LblBrokerUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblBrokerUsername.Location = new System.Drawing.Point(54, 265);
            this.LblBrokerUsername.Name = "LblBrokerUsername";
            this.LblBrokerUsername.Size = new System.Drawing.Size(69, 19);
            this.LblBrokerUsername.TabIndex = 51;
            this.LblBrokerUsername.Text = Languages.ConfigMqtt_LblBrokerUsername;
            // 
            // LblBrokerPort
            // 
            this.LblBrokerPort.AutoSize = true;
            this.LblBrokerPort.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblBrokerPort.Location = new System.Drawing.Point(52, 215);
            this.LblBrokerPort.Name = "LblBrokerPort";
            this.LblBrokerPort.Size = new System.Drawing.Size(35, 19);
            this.LblBrokerPort.TabIndex = 50;
            this.LblBrokerPort.Text = Languages.ConfigMqtt_LblBrokerPort;
            // 
            // LblBrokerIp
            // 
            this.LblBrokerIp.AutoSize = true;
            this.LblBrokerIp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblBrokerIp.Location = new System.Drawing.Point(54, 133);
            this.LblBrokerIp.Name = "LblBrokerIp";
            this.LblBrokerIp.Size = new System.Drawing.Size(197, 19);
            this.LblBrokerIp.TabIndex = 47;
            this.LblBrokerIp.Text = Languages.ConfigMqtt_LblBrokerIp;
            // 
            // LblTip2
            // 
            this.LblTip2.AutoSize = true;
            this.LblTip2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip2.Location = new System.Drawing.Point(252, 479);
            this.LblTip2.Name = "LblTip2";
            this.LblTip2.Size = new System.Drawing.Size(142, 15);
            this.LblTip2.TabIndex = 70;
            this.LblTip2.Text = Languages.ConfigMqtt_LblTip2;
            // 
            // TbMqttClientId
            // 
            this.TbMqttClientId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttClientId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttClientId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbMqttClientId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttClientId.Location = new System.Drawing.Point(55, 475);
            this.TbMqttClientId.MaxLength = 100;
            this.TbMqttClientId.Name = "TbMqttClientId";
            this.TbMqttClientId.Size = new System.Drawing.Size(191, 25);
            this.TbMqttClientId.TabIndex = 68;
            // 
            // LblClientId
            // 
            this.LblClientId.AutoSize = true;
            this.LblClientId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblClientId.Location = new System.Drawing.Point(52, 453);
            this.LblClientId.Name = "LblClientId";
            this.LblClientId.Size = new System.Drawing.Size(56, 19);
            this.LblClientId.TabIndex = 69;
            this.LblClientId.Text = Languages.ConfigMqtt_LblClientId;
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
            this.NumMqttPort.Location = new System.Drawing.Point(108, 213);
            this.NumMqttPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumMqttPort.MaxLength = 10;
            this.NumMqttPort.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumMqttPort.Name = "NumMqttPort";
            this.NumMqttPort.Size = new System.Drawing.Size(83, 25);
            this.NumMqttPort.TabIndex = 71;
            this.NumMqttPort.ThemeName = "Metro";
            this.NumMqttPort.Value = new decimal(new int[] {
            1883,
            0,
            0,
            0});
            this.NumMqttPort.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // PbShow
            // 
            this.PbShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbShow.Image = global::HASS.Agent.Properties.Resources.show_24;
            this.PbShow.Location = new System.Drawing.Point(252, 346);
            this.PbShow.Name = "PbShow";
            this.PbShow.Size = new System.Drawing.Size(24, 24);
            this.PbShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbShow.TabIndex = 100;
            this.PbShow.TabStop = false;
            this.PbShow.Click += new System.EventHandler(this.PbShow_Click);
            // 
            // ConfigMqtt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.PbShow);
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
            this.Name = "ConfigMqtt";
            this.Size = new System.Drawing.Size(700, 544);
            this.Load += new System.EventHandler(this.ConfigMqtt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumMqttPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTip3;
        private System.Windows.Forms.Label LblClientCert;
        private System.Windows.Forms.Label LblRootCert;
        private System.Windows.Forms.Label LblTip1;
        private System.Windows.Forms.Label LblInfo1;
        private System.Windows.Forms.Label LblDiscoPrefix;
        private System.Windows.Forms.Label LblBrokerPassword;
        private System.Windows.Forms.Label LblBrokerUsername;
        private System.Windows.Forms.Label LblBrokerPort;
        private System.Windows.Forms.Label LblBrokerIp;
        internal System.Windows.Forms.TextBox TbMqttClientCertificate;
        internal System.Windows.Forms.TextBox TbMqttRootCertificate;
        internal System.Windows.Forms.CheckBox CbUseRetainFlag;
        internal System.Windows.Forms.CheckBox CbAllowUntrustedCertificates;
        internal Syncfusion.WinForms.Controls.SfButton BtnMqttClearConfig;
        internal System.Windows.Forms.TextBox TbMqttDiscoveryPrefix;
        internal System.Windows.Forms.TextBox TbMqttPassword;
        internal System.Windows.Forms.TextBox TbMqttUsername;
        internal System.Windows.Forms.TextBox TbMqttAddress;
        internal System.Windows.Forms.CheckBox CbMqttTls;
        private System.Windows.Forms.Label LblTip2;
        internal System.Windows.Forms.TextBox TbMqttClientId;
        private System.Windows.Forms.Label LblClientId;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumMqttPort;
        private PictureBox PbShow;
    }
}
