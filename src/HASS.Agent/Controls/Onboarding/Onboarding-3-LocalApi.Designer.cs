using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Onboarding
{
    partial class OnboardingLocalApi
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
            this.PbHassAgentLogo = new System.Windows.Forms.PictureBox();
            this.LblTip1 = new System.Windows.Forms.Label();
            this.CbEnableLocalApi = new System.Windows.Forms.CheckBox();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.NumNotificationApiPort = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.CbEnableNotifications = new System.Windows.Forms.CheckBox();
            this.CbEnableMediaPlayer = new System.Windows.Forms.CheckBox();
            this.LblInfo2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumNotificationApiPort)).BeginInit();
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
            // LblTip1
            // 
            this.LblTip1.AccessibleDescription = "Contains extra port information.";
            this.LblTip1.AccessibleName = "Port info";
            this.LblTip1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblTip1.AutoSize = true;
            this.LblTip1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip1.Location = new System.Drawing.Point(180, 415);
            this.LblTip1.Name = "LblTip1";
            this.LblTip1.Size = new System.Drawing.Size(425, 13);
            this.LblTip1.TabIndex = 26;
            this.LblTip1.Text = Languages.OnboardingLocalApi_LblTip1;
            // 
            // CbEnableLocalApi
            // 
            this.CbEnableLocalApi.AccessibleDescription = "Enable the local API, which is used by the integrations.";
            this.CbEnableLocalApi.AccessibleName = "Enable local API";
            this.CbEnableLocalApi.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.CbEnableLocalApi.AutoSize = true;
            this.CbEnableLocalApi.Checked = true;
            this.CbEnableLocalApi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbEnableLocalApi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbEnableLocalApi.Location = new System.Drawing.Point(180, 135);
            this.CbEnableLocalApi.Name = "CbEnableLocalApi";
            this.CbEnableLocalApi.Size = new System.Drawing.Size(222, 23);
            this.CbEnableLocalApi.TabIndex = 0;
            this.CbEnableLocalApi.Text = Languages.OnboardingLocalApi_CbEnableLocalApi;
            this.CbEnableLocalApi.UseVisualStyleBackColor = true;
            this.CbEnableLocalApi.CheckStateChanged += new System.EventHandler(this.CbEnableLocalApi_CheckStateChanged);
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "Local API information.";
            this.LblInfo1.AccessibleName = "Information";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(180, 20);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(592, 101);
            this.LblInfo1.TabIndex = 24;
            this.LblInfo1.Text = Languages.OnboardingLocalApi_LblInfo1;
            // 
            // NumNotificationApiPort
            // 
            this.NumNotificationApiPort.AccessibleDescription = "The port used by the local API. Only accepts numeric values.";
            this.NumNotificationApiPort.AccessibleName = "Local API port";
            this.NumNotificationApiPort.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.NumNotificationApiPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.NumNotificationApiPort.BeforeTouchSize = new System.Drawing.Size(83, 25);
            this.NumNotificationApiPort.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.NumNotificationApiPort.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.NumNotificationApiPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumNotificationApiPort.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumNotificationApiPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.NumNotificationApiPort.Location = new System.Drawing.Point(466, 135);
            this.NumNotificationApiPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumNotificationApiPort.MaxLength = 10;
            this.NumNotificationApiPort.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumNotificationApiPort.Name = "NumNotificationApiPort";
            this.NumNotificationApiPort.Size = new System.Drawing.Size(83, 25);
            this.NumNotificationApiPort.TabIndex = 1;
            this.NumNotificationApiPort.ThemeName = "Metro";
            this.NumNotificationApiPort.Value = new decimal(new int[] {
            5115,
            0,
            0,
            0});
            this.NumNotificationApiPort.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // CbEnableNotifications
            // 
            this.CbEnableNotifications.AccessibleDescription = "Enable the ability to receive notifications, sent throught the integration.";
            this.CbEnableNotifications.AccessibleName = "Enable notifications";
            this.CbEnableNotifications.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.CbEnableNotifications.AutoSize = true;
            this.CbEnableNotifications.Checked = true;
            this.CbEnableNotifications.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbEnableNotifications.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbEnableNotifications.Location = new System.Drawing.Point(180, 282);
            this.CbEnableNotifications.Name = "CbEnableNotifications";
            this.CbEnableNotifications.Size = new System.Drawing.Size(146, 23);
            this.CbEnableNotifications.TabIndex = 2;
            this.CbEnableNotifications.Text = Languages.OnboardingLocalApi_CbEnableNotifications;
            this.CbEnableNotifications.UseVisualStyleBackColor = true;
            // 
            // CbEnableMediaPlayer
            // 
            this.CbEnableMediaPlayer.AccessibleDescription = "Enable the media player functionality of the integration.";
            this.CbEnableMediaPlayer.AccessibleName = "Enable media player";
            this.CbEnableMediaPlayer.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.CbEnableMediaPlayer.AutoSize = true;
            this.CbEnableMediaPlayer.Checked = true;
            this.CbEnableMediaPlayer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbEnableMediaPlayer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbEnableMediaPlayer.Location = new System.Drawing.Point(180, 338);
            this.CbEnableMediaPlayer.Name = "CbEnableMediaPlayer";
            this.CbEnableMediaPlayer.Size = new System.Drawing.Size(267, 23);
            this.CbEnableMediaPlayer.TabIndex = 3;
            this.CbEnableMediaPlayer.Text = Languages.OnboardingLocalApi_CbEnableMediaPlayer;
            this.CbEnableMediaPlayer.UseVisualStyleBackColor = true;
            // 
            // LblInfo2
            // 
            this.LblInfo2.AccessibleDescription = "Information about the various integration modules.";
            this.LblInfo2.AccessibleName = "Module info";
            this.LblInfo2.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo2.Location = new System.Drawing.Point(180, 201);
            this.LblInfo2.Name = "LblInfo2";
            this.LblInfo2.Size = new System.Drawing.Size(592, 62);
            this.LblInfo2.TabIndex = 76;
            this.LblInfo2.Text = Languages.OnboardingLocalApi_LblInfo2;
            // 
            // OnboardingLocalApi
            // 
            this.AccessibleDescription = "Panel containing the onboarding local API configuration.";
            this.AccessibleName = "Local API";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.LblInfo2);
            this.Controls.Add(this.CbEnableMediaPlayer);
            this.Controls.Add(this.CbEnableNotifications);
            this.Controls.Add(this.NumNotificationApiPort);
            this.Controls.Add(this.LblTip1);
            this.Controls.Add(this.CbEnableLocalApi);
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.PbHassAgentLogo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OnboardingLocalApi";
            this.Size = new System.Drawing.Size(803, 457);
            this.Load += new System.EventHandler(this.OnboardingLocalApi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumNotificationApiPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PbHassAgentLogo;
        private System.Windows.Forms.Label LblTip1;
        private System.Windows.Forms.CheckBox CbEnableLocalApi;
        private System.Windows.Forms.Label LblInfo1;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumNotificationApiPort;
        private CheckBox CbEnableNotifications;
        private CheckBox CbEnableMediaPlayer;
        private Label LblInfo2;
    }
}
