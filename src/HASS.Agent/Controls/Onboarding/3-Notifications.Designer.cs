namespace HASS.Agent.Controls.Onboarding
{
    partial class Notifications
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
            this.label2 = new System.Windows.Forms.Label();
            this.CbAcceptNotifications = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(180, 415);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(425, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Note: 5115 is the default port, only change it if you changed it in Home Assistan" +
    "t.";
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
            this.CbAcceptNotifications.Text = "yes, accept notifications on port";
            this.CbAcceptNotifications.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(180, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(555, 68);
            this.label1.TabIndex = 24;
            this.label1.Text = "HASS.Agent can receive notifications from Home Assistant, using text and/or image" +
    "s.\r\n\r\nDo you want to enable this function?";
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
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CbAcceptNotifications);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PbHassAgentLogo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Notifications";
            this.Size = new System.Drawing.Size(803, 457);
            this.Load += new System.EventHandler(this.Notifications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumNotificationApiPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PbHassAgentLogo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CbAcceptNotifications;
        private System.Windows.Forms.Label label1;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumNotificationApiPort;
    }
}
