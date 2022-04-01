using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Onboarding
{
    partial class OnboardingNotifications
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
            this.CbAcceptNotifications = new System.Windows.Forms.CheckBox();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.NumNotificationApiPort = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumNotificationApiPort)).BeginInit();
            this.SuspendLayout();
            // 
            // PbHassAgentLogo
            // 
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
            this.LblTip1.AutoSize = true;
            this.LblTip1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip1.Location = new System.Drawing.Point(180, 415);
            this.LblTip1.Name = "LblTip1";
            this.LblTip1.Size = new System.Drawing.Size(425, 13);
            this.LblTip1.TabIndex = 26;
            this.LblTip1.Text = Languages.OnboardingNotifications_LblTip1;
            // 
            // CbAcceptNotifications
            // 
            this.CbAcceptNotifications.AutoSize = true;
            this.CbAcceptNotifications.Checked = true;
            this.CbAcceptNotifications.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbAcceptNotifications.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbAcceptNotifications.Location = new System.Drawing.Point(180, 179);
            this.CbAcceptNotifications.Name = "CbAcceptNotifications";
            this.CbAcceptNotifications.Size = new System.Drawing.Size(222, 23);
            this.CbAcceptNotifications.TabIndex = 0;
            this.CbAcceptNotifications.Text = Languages.OnboardingNotifications_CbAcceptNotifications;
            this.CbAcceptNotifications.UseVisualStyleBackColor = true;
            // 
            // LblInfo1
            // 
            this.LblInfo1.AutoSize = true;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(180, 20);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(526, 57);
            this.LblInfo1.TabIndex = 24;
            this.LblInfo1.Text = Languages.OnboardingNotifications_LblInfo1;
            // 
            // NumNotificationApiPort
            // 
            this.NumNotificationApiPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.NumNotificationApiPort.BeforeTouchSize = new System.Drawing.Size(83, 25);
            this.NumNotificationApiPort.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.NumNotificationApiPort.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.NumNotificationApiPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumNotificationApiPort.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumNotificationApiPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.NumNotificationApiPort.Location = new System.Drawing.Point(408, 179);
            this.NumNotificationApiPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumNotificationApiPort.MaxLength = 10;
            this.NumNotificationApiPort.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumNotificationApiPort.Name = "NumNotificationApiPort";
            this.NumNotificationApiPort.Size = new System.Drawing.Size(83, 25);
            this.NumNotificationApiPort.TabIndex = 73;
            this.NumNotificationApiPort.ThemeName = "Metro";
            this.NumNotificationApiPort.Value = new decimal(new int[] {
            5115,
            0,
            0,
            0});
            this.NumNotificationApiPort.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // Notifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.NumNotificationApiPort);
            this.Controls.Add(this.LblTip1);
            this.Controls.Add(this.CbAcceptNotifications);
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.PbHassAgentLogo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Notifications";
            this.Size = new System.Drawing.Size(803, 457);
            this.Load += new System.EventHandler(this.OnboardingNotifications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumNotificationApiPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PbHassAgentLogo;
        private System.Windows.Forms.Label LblTip1;
        private System.Windows.Forms.CheckBox CbAcceptNotifications;
        private System.Windows.Forms.Label LblInfo1;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumNotificationApiPort;
    }
}
