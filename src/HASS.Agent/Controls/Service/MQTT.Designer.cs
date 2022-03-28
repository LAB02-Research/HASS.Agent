namespace HASS.Agent.Controls.Service
{
    partial class MQTT
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
            this.label1 = new System.Windows.Forms.Label();
            this.TbMqttClientId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.TbMqttClientCertificate = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.TbMqttRootCertificate = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.CbUseRetainFlag = new System.Windows.Forms.CheckBox();
            this.CbAllowUntrustedCertificates = new System.Windows.Forms.CheckBox();
            this.BtnMqttClearConfig = new Syncfusion.WinForms.Controls.SfButton();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.TbMqttDiscoveryPrefix = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TbMqttPassword = new System.Windows.Forms.TextBox();
            this.TbMqttUsername = new System.Windows.Forms.TextBox();
            this.TbMqttAddress = new System.Windows.Forms.TextBox();
            this.CbMqttTls = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnStore = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnCopy = new Syncfusion.WinForms.Controls.SfButton();
            this.LblStored = new System.Windows.Forms.Label();
            this.PbShow = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.NumMqttPort.Location = new System.Drawing.Point(114, 237);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(277, 507);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 15);
            this.label1.TabIndex = 94;
            this.label1.Text = "(leave empty for random)";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(77, 481);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 19);
            this.label2.TabIndex = 93;
            this.label2.Text = "client id";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label27.Location = new System.Drawing.Point(509, 267);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(205, 15);
            this.label27.TabIndex = 91;
            this.label27.Text = "tip: doubleclick these fields to browse";
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
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label26.Location = new System.Drawing.Point(506, 217);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(103, 19);
            this.label26.TabIndex = 90;
            this.label26.Text = "client certificate";
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
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label25.Location = new System.Drawing.Point(506, 157);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(97, 19);
            this.label25.TabIndex = 88;
            this.label25.Text = "root certificate";
            // 
            // CbUseRetainFlag
            // 
            this.CbUseRetainFlag.AutoSize = true;
            this.CbUseRetainFlag.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbUseRetainFlag.Location = new System.Drawing.Point(506, 353);
            this.CbUseRetainFlag.Name = "CbUseRetainFlag";
            this.CbUseRetainFlag.Size = new System.Drawing.Size(114, 23);
            this.CbUseRetainFlag.TabIndex = 86;
            this.CbUseRetainFlag.Text = "use retain flag";
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
            this.CbAllowUntrustedCertificates.Text = "allow untrusted certificates";
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
            this.BtnMqttClearConfig.Text = "clear config";
            this.BtnMqttClearConfig.UseVisualStyleBackColor = false;
            this.BtnMqttClearConfig.Click += new System.EventHandler(this.BtnMqttClearConfig_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(277, 449);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(138, 15);
            this.label14.TabIndex = 83;
            this.label14.Text = "(leave default if not sure)";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(80, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(670, 44);
            this.label13.TabIndex = 82;
            this.label13.Text = "Commands and sensors are sent through MQTT. Please provide credentials for your s" +
    "erver. If you\'re using the HA addon, you can probably use the preset address.\r\n";
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(77, 423);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 19);
            this.label10.TabIndex = 81;
            this.label10.Text = "discovery prefix";
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
            this.CbMqttTls.Location = new System.Drawing.Point(220, 239);
            this.CbMqttTls.Name = "CbMqttTls";
            this.CbMqttTls.Size = new System.Drawing.Size(49, 23);
            this.CbMqttTls.TabIndex = 73;
            this.CbMqttTls.Text = "TLS";
            this.CbMqttTls.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(77, 347);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 19);
            this.label9.TabIndex = 79;
            this.label9.Text = "password";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(77, 289);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 19);
            this.label8.TabIndex = 78;
            this.label8.Text = "username";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(75, 239);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 19);
            this.label7.TabIndex = 77;
            this.label7.Text = "port";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(77, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 19);
            this.label6.TabIndex = 74;
            this.label6.Text = "broker ip address or hostname";
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
            this.BtnStore.Text = "send and activate config";
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
            this.BtnCopy.Text = "copy from hass.agent";
            this.BtnCopy.UseVisualStyleBackColor = false;
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // LblStored
            // 
            this.LblStored.AutoSize = true;
            this.LblStored.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblStored.ForeColor = System.Drawing.Color.LimeGreen;
            this.LblStored.Location = new System.Drawing.Point(509, 529);
            this.LblStored.Name = "LblStored";
            this.LblStored.Size = new System.Drawing.Size(141, 30);
            this.LblStored.TabIndex = 98;
            this.LblStored.Text = "config stored!";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(80, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 19);
            this.label5.TabIndex = 100;
            this.label5.Text = "status";
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
            this.LblStatus.Text = "querying ..";
            // 
            // MQTT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LblStatus);
            this.Controls.Add(this.PbShow);
            this.Controls.Add(this.LblStored);
            this.Controls.Add(this.BtnCopy);
            this.Controls.Add(this.BtnStore);
            this.Controls.Add(this.NumMqttPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TbMqttClientId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.TbMqttClientCertificate);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.TbMqttRootCertificate);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.CbUseRetainFlag);
            this.Controls.Add(this.CbAllowUntrustedCertificates);
            this.Controls.Add(this.BtnMqttClearConfig);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.TbMqttDiscoveryPrefix);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TbMqttPassword);
            this.Controls.Add(this.TbMqttUsername);
            this.Controls.Add(this.TbMqttAddress);
            this.Controls.Add(this.CbMqttTls);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MQTT";
            this.Size = new System.Drawing.Size(903, 622);
            this.Load += new System.EventHandler(this.MQTT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumMqttPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumMqttPort;
        private Label label1;
        internal TextBox TbMqttClientId;
        private Label label2;
        private Label label27;
        internal TextBox TbMqttClientCertificate;
        private Label label26;
        internal TextBox TbMqttRootCertificate;
        private Label label25;
        internal CheckBox CbUseRetainFlag;
        internal CheckBox CbAllowUntrustedCertificates;
        internal Syncfusion.WinForms.Controls.SfButton BtnMqttClearConfig;
        private Label label14;
        private Label label13;
        internal TextBox TbMqttDiscoveryPrefix;
        private Label label10;
        internal TextBox TbMqttPassword;
        internal TextBox TbMqttUsername;
        internal TextBox TbMqttAddress;
        internal CheckBox CbMqttTls;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Syncfusion.WinForms.Controls.SfButton BtnStore;
        internal Syncfusion.WinForms.Controls.SfButton BtnCopy;
        private Label LblStored;
        private PictureBox PbShow;
        private Label label5;
        private Label LblStatus;
    }
}
