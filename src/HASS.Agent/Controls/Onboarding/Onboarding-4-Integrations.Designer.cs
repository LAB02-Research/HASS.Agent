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
            this.LblInfo2 = new System.Windows.Forms.Label();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.LblMediaPlayerIntegration = new System.Windows.Forms.Label();
            this.LblInfo3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).BeginInit();
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
            // LblNotifierIntegration
            // 
            this.LblNotifierIntegration.AccessibleDescription = "Shortcut to open the notifier integrations webpage.";
            this.LblNotifierIntegration.AccessibleName = "Notifier webpage";
            this.LblNotifierIntegration.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblNotifierIntegration.AutoSize = true;
            this.LblNotifierIntegration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblNotifierIntegration.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblNotifierIntegration.Location = new System.Drawing.Point(180, 141);
            this.LblNotifierIntegration.Name = "LblNotifierIntegration";
            this.LblNotifierIntegration.Size = new System.Drawing.Size(215, 19);
            this.LblNotifierIntegration.TabIndex = 0;
            this.LblNotifierIntegration.Text = Languages.OnboardingIntegrations_LblNotifierIntegration;
            this.LblNotifierIntegration.Click += new System.EventHandler(this.LblNotifierIntegration_Click);
            // 
            // LblInfo2
            // 
            this.LblInfo2.AccessibleDescription = "Extra information on how to install and configure the integrations.";
            this.LblInfo2.AccessibleName = "Integrations info";
            this.LblInfo2.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo2.Location = new System.Drawing.Point(180, 318);
            this.LblInfo2.Name = "LblInfo2";
            this.LblInfo2.Size = new System.Drawing.Size(592, 114);
            this.LblInfo2.TabIndex = 26;
            this.LblInfo2.Text = Languages.OnboardingIntegrations_LblInfo2;
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "Notifications integration information.";
            this.LblInfo1.AccessibleName = "Notifications info";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(180, 20);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(592, 106);
            this.LblInfo1.TabIndex = 25;
            this.LblInfo1.Text = Languages.OnboardingIntegrations_LblInfo1;
            // 
            // LblMediaPlayerIntegration
            // 
            this.LblMediaPlayerIntegration.AccessibleDescription = "Shortcut to open the media player integrations webpage.";
            this.LblMediaPlayerIntegration.AccessibleName = "Media player webpage";
            this.LblMediaPlayerIntegration.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblMediaPlayerIntegration.AutoSize = true;
            this.LblMediaPlayerIntegration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblMediaPlayerIntegration.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblMediaPlayerIntegration.Location = new System.Drawing.Point(180, 263);
            this.LblMediaPlayerIntegration.Name = "LblMediaPlayerIntegration";
            this.LblMediaPlayerIntegration.Size = new System.Drawing.Size(245, 19);
            this.LblMediaPlayerIntegration.TabIndex = 1;
            this.LblMediaPlayerIntegration.Text = "HASS.Agent-MediaPlayer GitHub page";
            this.LblMediaPlayerIntegration.Click += new System.EventHandler(this.LblMediaPlayerIntegration_Click);
            // 
            // LblInfo3
            // 
            this.LblInfo3.AccessibleDescription = "Media player integration information.";
            this.LblInfo3.AccessibleName = "Media player info";
            this.LblInfo3.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo3.Location = new System.Drawing.Point(180, 171);
            this.LblInfo3.Name = "LblInfo3";
            this.LblInfo3.Size = new System.Drawing.Size(592, 62);
            this.LblInfo3.TabIndex = 77;
            this.LblInfo3.Text = Languages.OnboardingIntegrations_LblInfo3;
            this.LblInfo3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // OnboardingIntegrations
            // 
            this.AccessibleDescription = "Panel containing the onboarding integrations configuration.";
            this.AccessibleName = "Integrations";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.LblInfo3);
            this.Controls.Add(this.LblMediaPlayerIntegration);
            this.Controls.Add(this.LblNotifierIntegration);
            this.Controls.Add(this.LblInfo2);
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
        private System.Windows.Forms.Label LblInfo2;
        private System.Windows.Forms.Label LblInfo1;
        private Label LblMediaPlayerIntegration;
        private Label LblInfo3;
    }
}
