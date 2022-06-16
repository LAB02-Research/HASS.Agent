using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Onboarding
{
    partial class OnboardingDone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnboardingDone));
            this.PbHassAgentLogo = new System.Windows.Forms.PictureBox();
            this.LblGitHub = new System.Windows.Forms.Label();
            this.LblInfo3 = new System.Windows.Forms.Label();
            this.PbUpdate = new System.Windows.Forms.PictureBox();
            this.LblInfo2 = new System.Windows.Forms.Label();
            this.LblInfo1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbUpdate)).BeginInit();
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
            // LblGitHub
            // 
            this.LblGitHub.AccessibleDescription = "Opens the HASS.Agent GitHub webpage.";
            this.LblGitHub.AccessibleName = "GitHub link";
            this.LblGitHub.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblGitHub.AutoSize = true;
            this.LblGitHub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblGitHub.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblGitHub.Location = new System.Drawing.Point(180, 397);
            this.LblGitHub.Name = "LblGitHub";
            this.LblGitHub.Size = new System.Drawing.Size(164, 19);
            this.LblGitHub.TabIndex = 0;
            this.LblGitHub.Text = Languages.OnboardingDone_LblGitHub;
            this.LblGitHub.Click += new System.EventHandler(this.LblGitHub_Click);
            // 
            // LblInfo3
            // 
            this.LblInfo3.AccessibleDescription = "Configuration tip and thanks message.";
            this.LblInfo3.AccessibleName = "Final info";
            this.LblInfo3.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo3.Location = new System.Drawing.Point(180, 224);
            this.LblInfo3.Name = "LblInfo3";
            this.LblInfo3.Size = new System.Drawing.Size(595, 148);
            this.LblInfo3.TabIndex = 25;
            this.LblInfo3.Text = Languages.OnboardingDone_LblInfo3;
            // 
            // PbUpdate
            // 
            this.PbUpdate.AccessibleDescription = "Celebration image.";
            this.PbUpdate.AccessibleName = "Celebrations";
            this.PbUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbUpdate.Image = global::HASS.Agent.Properties.Resources.update;
            this.PbUpdate.Location = new System.Drawing.Point(705, 20);
            this.PbUpdate.Name = "PbUpdate";
            this.PbUpdate.Size = new System.Drawing.Size(70, 70);
            this.PbUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbUpdate.TabIndex = 27;
            this.PbUpdate.TabStop = false;
            // 
            // LblInfo2
            // 
            this.LblInfo2.AccessibleDescription = "Information on how the onboarding will now proceed.";
            this.LblInfo2.AccessibleName = "Onboarding next steps info";
            this.LblInfo2.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo2.Location = new System.Drawing.Point(180, 84);
            this.LblInfo2.Name = "LblInfo2";
            this.LblInfo2.Size = new System.Drawing.Size(595, 95);
            this.LblInfo2.TabIndex = 28;
            this.LblInfo2.Text = Languages.OnboardingDone_LblInfo2;
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "Done notification.";
            this.LblInfo1.AccessibleName = "Done";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.AutoSize = true;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(180, 20);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(92, 25);
            this.LblInfo1.TabIndex = 29;
            this.LblInfo1.Text = Languages.OnboardingDone_LblInfo1;
            // 
            // OnboardingDone
            // 
            this.AccessibleDescription = "Final onboarding panel.";
            this.AccessibleName = "Done";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.PbUpdate);
            this.Controls.Add(this.LblGitHub);
            this.Controls.Add(this.LblInfo3);
            this.Controls.Add(this.PbHassAgentLogo);
            this.Controls.Add(this.LblInfo2);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OnboardingDone";
            this.Size = new System.Drawing.Size(803, 457);
            this.Load += new System.EventHandler(this.OnboardingDone_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbUpdate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PbHassAgentLogo;
        private System.Windows.Forms.Label LblGitHub;
        private System.Windows.Forms.Label LblInfo3;
        private System.Windows.Forms.PictureBox PbUpdate;
        private System.Windows.Forms.Label LblInfo2;
        private Label LblInfo1;
    }
}
