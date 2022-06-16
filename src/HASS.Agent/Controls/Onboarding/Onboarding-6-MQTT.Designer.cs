using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Onboarding
{
    partial class OnboardingMqtt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnboardingMqtt));
            this.PbHassAgentLogo = new System.Windows.Forms.PictureBox();
            this.TbMqttPassword = new System.Windows.Forms.TextBox();
            this.TbMqttUsername = new System.Windows.Forms.TextBox();
            this.TbMqttAddress = new System.Windows.Forms.TextBox();
            this.CbMqttTls = new System.Windows.Forms.CheckBox();
            this.LblPassword = new System.Windows.Forms.Label();
            this.LblUsername = new System.Windows.Forms.Label();
            this.LblPort = new System.Windows.Forms.Label();
            this.LblIpAdress = new System.Windows.Forms.Label();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.TbMqttDiscoveryPrefix = new System.Windows.Forms.TextBox();
            this.LblDiscoveryPrefix = new System.Windows.Forms.Label();
            this.LblTip1 = new System.Windows.Forms.Label();
            this.LblTip2 = new System.Windows.Forms.Label();
            this.NumMqttPort = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.PbShow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMqttPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbShow)).BeginInit();
            this.SuspendLayout();
            // 
            // PbHassAgentLogo
            // 
            this.PbHassAgentLogo.AccessibleDescription = "HASS Agent logo image.";
            this.PbHassAgentLogo.AccessibleName = "HASS Agent logo";
            this.PbHassAgentLogo.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbHassAgentLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbHassAgentLogo.Image = global::HASS.Agent.Properties.Resources.logo_128;
            this.PbHassAgentLogo.Location = new System.Drawing.Point(24, 20);
            this.PbHassAgentLogo.Name = "PbHassAgentLogo";
            this.PbHassAgentLogo.Size = new System.Drawing.Size(128, 128);
            this.PbHassAgentLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbHassAgentLogo.TabIndex = 2;
            this.PbHassAgentLogo.TabStop = false;
            // 
            // TbMqttPassword
            // 
            this.TbMqttPassword.AccessibleDescription = "The password to use when connecting to your MQTT broker.";
            this.TbMqttPassword.AccessibleName = "Password";
            this.TbMqttPassword.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbMqttPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbMqttPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttPassword.Location = new System.Drawing.Point(373, 275);
            this.TbMqttPassword.Name = "TbMqttPassword";
            this.TbMqttPassword.Size = new System.Drawing.Size(162, 25);
            this.TbMqttPassword.TabIndex = 4;
            this.TbMqttPassword.UseSystemPasswordChar = true;
            // 
            // TbMqttUsername
            // 
            this.TbMqttUsername.AccessibleDescription = "The username to use when connecting to your MQTT broker.";
            this.TbMqttUsername.AccessibleName = "Username";
            this.TbMqttUsername.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbMqttUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbMqttUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttUsername.Location = new System.Drawing.Point(181, 275);
            this.TbMqttUsername.Name = "TbMqttUsername";
            this.TbMqttUsername.Size = new System.Drawing.Size(160, 25);
            this.TbMqttUsername.TabIndex = 3;
            // 
            // TbMqttAddress
            // 
            this.TbMqttAddress.AccessibleDescription = "The IP address or hostname of your MQTT broker (the same address as your Home Ass" +
    "istant instance if you use the MQTT addon).";
            this.TbMqttAddress.AccessibleName = "Broker address";
            this.TbMqttAddress.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbMqttAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttAddress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbMqttAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttAddress.Location = new System.Drawing.Point(181, 151);
            this.TbMqttAddress.Name = "TbMqttAddress";
            this.TbMqttAddress.Size = new System.Drawing.Size(352, 25);
            this.TbMqttAddress.TabIndex = 0;
            // 
            // CbMqttTls
            // 
            this.CbMqttTls.AccessibleDescription = "Enables the usage of an encrypted TLS connection.";
            this.CbMqttTls.AccessibleName = "TLS";
            this.CbMqttTls.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.CbMqttTls.AutoSize = true;
            this.CbMqttTls.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbMqttTls.Location = new System.Drawing.Point(374, 208);
            this.CbMqttTls.Name = "CbMqttTls";
            this.CbMqttTls.Size = new System.Drawing.Size(49, 23);
            this.CbMqttTls.TabIndex = 2;
            this.CbMqttTls.Text = global::HASS.Agent.Resources.Localization.Languages.OnboardingMqtt_CbMqttTls;
            this.CbMqttTls.UseVisualStyleBackColor = true;
            this.CbMqttTls.CheckedChanged += new System.EventHandler(this.CbMqttTls_CheckedChanged);
            // 
            // LblPassword
            // 
            this.LblPassword.AccessibleDescription = "Password textbox description.";
            this.LblPassword.AccessibleName = "Password info";
            this.LblPassword.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblPassword.AutoSize = true;
            this.LblPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblPassword.Location = new System.Drawing.Point(373, 253);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(67, 19);
            this.LblPassword.TabIndex = 31;
            this.LblPassword.Text = Languages.OnboardingMqtt_LblPassword;
            // 
            // LblUsername
            // 
            this.LblUsername.AccessibleDescription = "Username textbox description.";
            this.LblUsername.AccessibleName = "Username info";
            this.LblUsername.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblUsername.AutoSize = true;
            this.LblUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblUsername.Location = new System.Drawing.Point(181, 253);
            this.LblUsername.Name = "LblUsername";
            this.LblUsername.Size = new System.Drawing.Size(69, 19);
            this.LblUsername.TabIndex = 30;
            this.LblUsername.Text = Languages.OnboardingMqtt_LblUsername;
            // 
            // LblPort
            // 
            this.LblPort.AccessibleDescription = "Port textbox description.";
            this.LblPort.AccessibleName = "Port info";
            this.LblPort.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblPort.AutoSize = true;
            this.LblPort.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblPort.Location = new System.Drawing.Point(182, 208);
            this.LblPort.Name = "LblPort";
            this.LblPort.Size = new System.Drawing.Size(35, 19);
            this.LblPort.TabIndex = 29;
            this.LblPort.Text = Languages.OnboardingMqtt_LblPort;
            // 
            // LblIpAdress
            // 
            this.LblIpAdress.AccessibleDescription = "IP textbox description.";
            this.LblIpAdress.AccessibleName = "Broker info";
            this.LblIpAdress.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblIpAdress.AutoSize = true;
            this.LblIpAdress.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblIpAdress.Location = new System.Drawing.Point(181, 129);
            this.LblIpAdress.Name = "LblIpAdress";
            this.LblIpAdress.Size = new System.Drawing.Size(153, 19);
            this.LblIpAdress.TabIndex = 28;
            this.LblIpAdress.Text = Languages.OnboardingMqtt_LblIpAdress;
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "MQTT information.";
            this.LblInfo1.AccessibleName = "Information";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(180, 20);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(588, 98);
            this.LblInfo1.TabIndex = 27;
            this.LblInfo1.Text = Languages.OnboardingMqtt_LblInfo1;
            // 
            // TbMqttDiscoveryPrefix
            // 
            this.TbMqttDiscoveryPrefix.AccessibleDescription = "The discovery prefix used in the MQTT topics. Optional, requires configuration in" +
    " Home Assistant.";
            this.TbMqttDiscoveryPrefix.AccessibleName = "Discovery prefix";
            this.TbMqttDiscoveryPrefix.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbMqttDiscoveryPrefix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttDiscoveryPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttDiscoveryPrefix.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbMqttDiscoveryPrefix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttDiscoveryPrefix.Location = new System.Drawing.Point(181, 350);
            this.TbMqttDiscoveryPrefix.Name = "TbMqttDiscoveryPrefix";
            this.TbMqttDiscoveryPrefix.Size = new System.Drawing.Size(162, 25);
            this.TbMqttDiscoveryPrefix.TabIndex = 5;
            // 
            // LblDiscoveryPrefix
            // 
            this.LblDiscoveryPrefix.AccessibleDescription = "Discovery prefix textbox description.";
            this.LblDiscoveryPrefix.AccessibleName = "Discovery prefix info";
            this.LblDiscoveryPrefix.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblDiscoveryPrefix.AutoSize = true;
            this.LblDiscoveryPrefix.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDiscoveryPrefix.Location = new System.Drawing.Point(180, 328);
            this.LblDiscoveryPrefix.Name = "LblDiscoveryPrefix";
            this.LblDiscoveryPrefix.Size = new System.Drawing.Size(103, 19);
            this.LblDiscoveryPrefix.TabIndex = 33;
            this.LblDiscoveryPrefix.Text = Languages.OnboardingMqtt_LblDiscoveryPrefix;
            // 
            // LblTip1
            // 
            this.LblTip1.AccessibleDescription = "Contains a usage tip.";
            this.LblTip1.AccessibleName = "Discovery prefix tip";
            this.LblTip1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblTip1.AutoSize = true;
            this.LblTip1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip1.Location = new System.Drawing.Point(349, 355);
            this.LblTip1.Name = "LblTip1";
            this.LblTip1.Size = new System.Drawing.Size(135, 13);
            this.LblTip1.TabIndex = 34;
            this.LblTip1.Text = Languages.OnboardingMqtt_LblTip1;
            // 
            // LblTip2
            // 
            this.LblTip2.AccessibleDescription = "Contains a configuration tip.";
            this.LblTip2.AccessibleName = "Configuration tip";
            this.LblTip2.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblTip2.AutoSize = true;
            this.LblTip2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip2.Location = new System.Drawing.Point(181, 419);
            this.LblTip2.Name = "LblTip2";
            this.LblTip2.Size = new System.Drawing.Size(358, 13);
            this.LblTip2.TabIndex = 35;
            this.LblTip2.Text = Languages.OnboardingMqtt_LblTip2;
            // 
            // NumMqttPort
            // 
            this.NumMqttPort.AccessibleDescription = "The port of your MQTT broker. Only accepts numeric values.";
            this.NumMqttPort.AccessibleName = "Port";
            this.NumMqttPort.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.NumMqttPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.NumMqttPort.BeforeTouchSize = new System.Drawing.Size(83, 25);
            this.NumMqttPort.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.NumMqttPort.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.NumMqttPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumMqttPort.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumMqttPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.NumMqttPort.Location = new System.Drawing.Point(260, 206);
            this.NumMqttPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumMqttPort.MaxLength = 10;
            this.NumMqttPort.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumMqttPort.Name = "NumMqttPort";
            this.NumMqttPort.Size = new System.Drawing.Size(83, 25);
            this.NumMqttPort.TabIndex = 1;
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
            this.PbShow.AccessibleDescription = "Reveals the password characters.";
            this.PbShow.AccessibleName = "Reveal password";
            this.PbShow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.PbShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbShow.Image = global::HASS.Agent.Properties.Resources.show_24;
            this.PbShow.Location = new System.Drawing.Point(541, 275);
            this.PbShow.Name = "PbShow";
            this.PbShow.Size = new System.Drawing.Size(24, 24);
            this.PbShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbShow.TabIndex = 100;
            this.PbShow.TabStop = false;
            this.PbShow.Click += new System.EventHandler(this.PbShow_Click);
            // 
            // OnboardingMqtt
            // 
            this.AccessibleDescription = "Panel containing the onboarding MQTT configuration.";
            this.AccessibleName = "MQTT";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.PbShow);
            this.Controls.Add(this.NumMqttPort);
            this.Controls.Add(this.LblTip2);
            this.Controls.Add(this.LblTip1);
            this.Controls.Add(this.TbMqttDiscoveryPrefix);
            this.Controls.Add(this.LblDiscoveryPrefix);
            this.Controls.Add(this.TbMqttPassword);
            this.Controls.Add(this.TbMqttUsername);
            this.Controls.Add(this.TbMqttAddress);
            this.Controls.Add(this.CbMqttTls);
            this.Controls.Add(this.LblPassword);
            this.Controls.Add(this.LblUsername);
            this.Controls.Add(this.LblPort);
            this.Controls.Add(this.LblIpAdress);
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.PbHassAgentLogo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OnboardingMqtt";
            this.Size = new System.Drawing.Size(803, 457);
            this.Load += new System.EventHandler(this.OnboardingMqtt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMqttPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PbHassAgentLogo;
        private System.Windows.Forms.TextBox TbMqttPassword;
        private System.Windows.Forms.TextBox TbMqttUsername;
        private System.Windows.Forms.TextBox TbMqttAddress;
        private System.Windows.Forms.CheckBox CbMqttTls;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.Label LblUsername;
        private System.Windows.Forms.Label LblPort;
        private System.Windows.Forms.Label LblIpAdress;
        private System.Windows.Forms.Label LblInfo1;
        private System.Windows.Forms.TextBox TbMqttDiscoveryPrefix;
        private System.Windows.Forms.Label LblDiscoveryPrefix;
        private System.Windows.Forms.Label LblTip1;
        private System.Windows.Forms.Label LblTip2;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumMqttPort;
        private PictureBox PbShow;
    }
}
