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
            this.LblInfo3 = new System.Windows.Forms.Label();
            this.PbUpdate = new System.Windows.Forms.PictureBox();
            this.LblInfo2 = new System.Windows.Forms.Label();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.PbBMAC = new System.Windows.Forms.PictureBox();
            this.LblInfo6 = new System.Windows.Forms.Label();
            this.LblTip2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBMAC)).BeginInit();
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
            // LblInfo3
            // 
            this.LblInfo3.AccessibleDescription = "Configuration tip and thanks message.";
            this.LblInfo3.AccessibleName = "Final info";
            this.LblInfo3.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo3.Location = new System.Drawing.Point(180, 158);
            this.LblInfo3.Name = "LblInfo3";
            this.LblInfo3.Size = new System.Drawing.Size(595, 111);
            this.LblInfo3.TabIndex = 25;
            this.LblInfo3.Text = Languages.OnboardingDone_LblInfo3;
            // 
            // PbUpdate
            // 
            this.PbUpdate.AccessibleDescription = "Celebration image.";
            this.PbUpdate.AccessibleName = "Celebrations";
            this.PbUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbUpdate.Image = ((System.Drawing.Image)(resources.GetObject("PbUpdate.Image")));
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
            this.LblInfo2.Location = new System.Drawing.Point(180, 67);
            this.LblInfo2.Name = "LblInfo2";
            this.LblInfo2.Size = new System.Drawing.Size(515, 46);
            this.LblInfo2.TabIndex = 28;
            this.LblInfo2.Text = Languages.OnboardingDone_LblInfo2;
            this.LblInfo2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "Done notification.";
            this.LblInfo1.AccessibleName = "Done";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.AutoSize = true;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(180, 20);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(187, 47);
            this.LblInfo1.TabIndex = 29;
            this.LblInfo1.Text = Languages.OnboardingDone_LblInfo1;
            // 
            // PbBMAC
            // 
            this.PbBMAC.AccessibleDescription = "Opens the \'buy me a coffee\' donation website.";
            this.PbBMAC.AccessibleName = "BMAC donation";
            this.PbBMAC.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.PbBMAC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbBMAC.Image = ((System.Drawing.Image)(resources.GetObject("PbBMAC.Image")));
            this.PbBMAC.Location = new System.Drawing.Point(622, 393);
            this.PbBMAC.Name = "PbBMAC";
            this.PbBMAC.Size = new System.Drawing.Size(153, 43);
            this.PbBMAC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbBMAC.TabIndex = 31;
            this.PbBMAC.TabStop = false;
            this.PbBMAC.Click += new System.EventHandler(this.PbBMAC_Click);
            // 
            // LblInfo6
            // 
            this.LblInfo6.AccessibleDescription = "Donating for HASS.Agent message.";
            this.LblInfo6.AccessibleName = "Donating info";
            this.LblInfo6.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo6.Location = new System.Drawing.Point(180, 326);
            this.LblInfo6.Name = "LblInfo6";
            this.LblInfo6.Size = new System.Drawing.Size(595, 85);
            this.LblInfo6.TabIndex = 30;
            this.LblInfo6.Text = Languages.OnboardingDone_LblInfo6;
            // 
            // LblTip2
            // 
            this.LblTip2.AccessibleDescription = "Contains a donation tip.";
            this.LblTip2.AccessibleName = "Donation tip";
            this.LblTip2.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblTip2.AutoSize = true;
            this.LblTip2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip2.Location = new System.Drawing.Point(180, 423);
            this.LblTip2.Name = "LblTip2";
            this.LblTip2.Size = new System.Drawing.Size(343, 13);
            this.LblTip2.TabIndex = 36;
            this.LblTip2.Text = Languages.OnboardingDone_LblTip2;
            // 
            // OnboardingDone
            // 
            this.AccessibleDescription = "Final onboarding panel.";
            this.AccessibleName = "Done";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.LblTip2);
            this.Controls.Add(this.PbBMAC);
            this.Controls.Add(this.LblInfo6);
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.PbUpdate);
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
            ((System.ComponentModel.ISupportInitialize)(this.PbBMAC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PbHassAgentLogo;
        private System.Windows.Forms.Label LblInfo3;
        private System.Windows.Forms.PictureBox PbUpdate;
        private System.Windows.Forms.Label LblInfo2;
        private Label LblInfo1;
        private PictureBox PbBMAC;
        private Label LblInfo6;
        private Label LblTip2;
    }
}
