using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Onboarding
{
    partial class OnboardingIntegrations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnboardingIntegrations));
            this.PbHassAgentLogo = new System.Windows.Forms.PictureBox();
            this.LblNotifierIntegration = new System.Windows.Forms.Label();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.CbEnableMediaPlayer = new System.Windows.Forms.CheckBox();
            this.CbEnableNotifications = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // PbHassAgentLogo
            // 
            this.PbHassAgentLogo.AccessibleDescription = "HASS Agent logo image.";
            this.PbHassAgentLogo.AccessibleName = "HASS Agent logo";
            this.PbHassAgentLogo.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbHassAgentLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbHassAgentLogo.Image = ((System.Drawing.Image)(resources.GetObject("PbHassAgentLogo.Image")));
            this.PbHassAgentLogo.Location = new System.Drawing.Point(24, 20);
            this.PbHassAgentLogo.Name = "PbHassAgentLogo";
            this.PbHassAgentLogo.Size = new System.Drawing.Size(128, 128);
            this.PbHassAgentLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbHassAgentLogo.TabIndex = 2;
            this.PbHassAgentLogo.TabStop = false;
            // 
            // LblNotifierIntegration
            // 
            this.LblNotifierIntegration.AccessibleDescription = "Shortcut to open the integrations webpage.";
            this.LblNotifierIntegration.AccessibleName = "Integration webpage";
            this.LblNotifierIntegration.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblNotifierIntegration.AutoSize = true;
            this.LblNotifierIntegration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblNotifierIntegration.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblNotifierIntegration.Location = new System.Drawing.Point(180, 395);
            this.LblNotifierIntegration.Name = "LblNotifierIntegration";
            this.LblNotifierIntegration.Size = new System.Drawing.Size(238, 19);
            this.LblNotifierIntegration.TabIndex = 0;
            this.LblNotifierIntegration.Text = Languages.OnboardingIntegrations_LblNotifierIntegration;
            this.LblNotifierIntegration.Click += new System.EventHandler(this.LblNotifierIntegration_Click);
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "Notifications integration information.";
            this.LblInfo1.AccessibleName = "Notifications info";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(180, 20);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(602, 208);
            this.LblInfo1.TabIndex = 25;
            this.LblInfo1.Text = Languages.OnboardingIntegrations_LblInfo1;
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
            this.CbEnableMediaPlayer.Location = new System.Drawing.Point(180, 304);
            this.CbEnableMediaPlayer.Name = "CbEnableMediaPlayer";
            this.CbEnableMediaPlayer.Size = new System.Drawing.Size(307, 23);
            this.CbEnableMediaPlayer.TabIndex = 27;
            this.CbEnableMediaPlayer.Text = Languages.OnboardingIntegrations_CbEnableMediaPlayer;
            this.CbEnableMediaPlayer.UseVisualStyleBackColor = true;
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
            this.CbEnableNotifications.Location = new System.Drawing.Point(180, 248);
            this.CbEnableNotifications.Name = "CbEnableNotifications";
            this.CbEnableNotifications.Size = new System.Drawing.Size(146, 23);
            this.CbEnableNotifications.TabIndex = 26;
            this.CbEnableNotifications.Text = Languages.OnboardingIntegrations_CbEnableNotifications;
            this.CbEnableNotifications.UseVisualStyleBackColor = true;
            // 
            // OnboardingIntegrations
            // 
            this.AccessibleDescription = "Panel containing the onboarding integrations configuration.";
            this.AccessibleName = "Integrations";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.CbEnableMediaPlayer);
            this.Controls.Add(this.CbEnableNotifications);
            this.Controls.Add(this.LblNotifierIntegration);
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.PbHassAgentLogo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OnboardingIntegrations";
            this.Size = new System.Drawing.Size(803, 457);
            this.Load += new System.EventHandler(this.OnboardingIntegrations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PbHassAgentLogo;
        private System.Windows.Forms.Label LblNotifierIntegration;
        private System.Windows.Forms.Label LblInfo1;
        private CheckBox CbEnableMediaPlayer;
        private CheckBox CbEnableNotifications;
    }
}
