namespace HASSAgent.Controls.Onboarding
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
            this.BtnOpenFirewallPort = new Syncfusion.WinForms.Controls.SfButton();
            this.LblFirewallInfo = new System.Windows.Forms.Label();
            this.TbIntNotifierApiPort = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CbAcceptNotifications = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbIntNotifierApiPort)).BeginInit();
            this.SuspendLayout();
            // 
            // PbHassAgentLogo
            // 
            this.PbHassAgentLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbHassAgentLogo.Image = global::HASSAgent.Properties.Resources.logo_128;
            this.PbHassAgentLogo.Location = new System.Drawing.Point(24, 20);
            this.PbHassAgentLogo.Name = "PbHassAgentLogo";
            this.PbHassAgentLogo.Size = new System.Drawing.Size(128, 128);
            this.PbHassAgentLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbHassAgentLogo.TabIndex = 2;
            this.PbHassAgentLogo.TabStop = false;
            // 
            // BtnOpenFirewallPort
            // 
            this.BtnOpenFirewallPort.AccessibleName = "Button";
            this.BtnOpenFirewallPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnOpenFirewallPort.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpenFirewallPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnOpenFirewallPort.Location = new System.Drawing.Point(183, 300);
            this.BtnOpenFirewallPort.Name = "BtnOpenFirewallPort";
            this.BtnOpenFirewallPort.Size = new System.Drawing.Size(402, 31);
            this.BtnOpenFirewallPort.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnOpenFirewallPort.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnOpenFirewallPort.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnOpenFirewallPort.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnOpenFirewallPort.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnOpenFirewallPort.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnOpenFirewallPort.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnOpenFirewallPort.TabIndex = 2;
            this.BtnOpenFirewallPort.Text = "yes, open the firewall port";
            this.BtnOpenFirewallPort.UseVisualStyleBackColor = false;
            this.BtnOpenFirewallPort.Click += new System.EventHandler(this.BtnOpenFirewallPort_Click);
            // 
            // LblFirewallInfo
            // 
            this.LblFirewallInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFirewallInfo.Location = new System.Drawing.Point(180, 258);
            this.LblFirewallInfo.Name = "LblFirewallInfo";
            this.LblFirewallInfo.Size = new System.Drawing.Size(384, 39);
            this.LblFirewallInfo.TabIndex = 28;
            this.LblFirewallInfo.Text = "If you want, HASS.Agent can open the port in your local firewall so Home Assistan" +
    "t can reach you.";
            // 
            // TbIntNotifierApiPort
            // 
            this.TbIntNotifierApiPort.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbIntNotifierApiPort.BeforeTouchSize = new System.Drawing.Size(92, 25);
            this.TbIntNotifierApiPort.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntNotifierApiPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbIntNotifierApiPort.CurrentCultureRefresh = true;
            this.TbIntNotifierApiPort.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntNotifierApiPort.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbIntNotifierApiPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntNotifierApiPort.IntegerValue = ((long)(1883));
            this.TbIntNotifierApiPort.Location = new System.Drawing.Point(183, 204);
            this.TbIntNotifierApiPort.MaxValue = ((long)(66000));
            this.TbIntNotifierApiPort.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntNotifierApiPort.MinValue = ((long)(1));
            this.TbIntNotifierApiPort.Name = "TbIntNotifierApiPort";
            this.TbIntNotifierApiPort.PositiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntNotifierApiPort.Size = new System.Drawing.Size(92, 25);
            this.TbIntNotifierApiPort.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.UICulture;
            this.TbIntNotifierApiPort.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.TbIntNotifierApiPort.TabIndex = 1;
            this.TbIntNotifierApiPort.Text = "1,883";
            this.TbIntNotifierApiPort.ThemeName = "Metro";
            this.TbIntNotifierApiPort.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbIntNotifierApiPort.ThemeStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntNotifierApiPort.ThemeStyle.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntNotifierApiPort.ThemeStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntNotifierApiPort.ThemeStyle.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntNotifierApiPort.ThemeStyle.ZeroForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntNotifierApiPort.ZeroColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(180, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(384, 39);
            this.label2.TabIndex = 26;
            this.label2.Text = "This is the default port, change it only if you changed it in Home Assistant.";
            // 
            // CbAcceptNotifications
            // 
            this.CbAcceptNotifications.AutoSize = true;
            this.CbAcceptNotifications.Checked = true;
            this.CbAcceptNotifications.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbAcceptNotifications.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbAcceptNotifications.Location = new System.Drawing.Point(183, 118);
            this.CbAcceptNotifications.Name = "CbAcceptNotifications";
            this.CbAcceptNotifications.Size = new System.Drawing.Size(165, 21);
            this.CbAcceptNotifications.TabIndex = 0;
            this.CbAcceptNotifications.Text = "yes, accept notifications";
            this.CbAcceptNotifications.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(180, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 87);
            this.label1.TabIndex = 24;
            this.label1.Text = "HASS.Agent can receive notifications from Home Assistant, using text and/or image" +
    "s.\r\n\r\nDo you want to enable this function?";
            // 
            // Notifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.BtnOpenFirewallPort);
            this.Controls.Add(this.LblFirewallInfo);
            this.Controls.Add(this.TbIntNotifierApiPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CbAcceptNotifications);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PbHassAgentLogo);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Notifications";
            this.Size = new System.Drawing.Size(610, 364);
            this.Load += new System.EventHandler(this.Notifications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbIntNotifierApiPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PbHassAgentLogo;
        private Syncfusion.WinForms.Controls.SfButton BtnOpenFirewallPort;
        private System.Windows.Forms.Label LblFirewallInfo;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox TbIntNotifierApiPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CbAcceptNotifications;
        private System.Windows.Forms.Label label1;
    }
}
