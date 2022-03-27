namespace HASSAgent.Controls.Configuration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notifications));
            this.label18 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.BtnNotificationsReadme = new Syncfusion.WinForms.Controls.SfButton();
            this.label1 = new System.Windows.Forms.Label();
            this.CbAcceptNotifications = new System.Windows.Forms.CheckBox();
            this.NumNotificationApiPort = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.BtnSendTestNotification = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnExecutePortReservation = new Syncfusion.WinForms.Controls.SfButton();
            ((System.ComponentModel.ISupportInitialize)(this.NumNotificationApiPort)).BeginInit();
            this.SuspendLayout();
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label18.Location = new System.Drawing.Point(70, 364);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(416, 128);
            this.label18.TabIndex = 37;
            this.label18.Text = resources.GetString("label18.Text");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(70, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(526, 19);
            this.label12.TabIndex = 36;
            this.label12.Text = "HASS.Agent can receive notifications from Home Assistant, using text and/or image" +
    "s.";
            // 
            // BtnNotificationsReadme
            // 
            this.BtnNotificationsReadme.AccessibleName = "Button";
            this.BtnNotificationsReadme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnNotificationsReadme.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnNotificationsReadme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnNotificationsReadme.Location = new System.Drawing.Point(493, 497);
            this.BtnNotificationsReadme.Name = "BtnNotificationsReadme";
            this.BtnNotificationsReadme.Size = new System.Drawing.Size(228, 31);
            this.BtnNotificationsReadme.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnNotificationsReadme.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnNotificationsReadme.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnNotificationsReadme.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnNotificationsReadme.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnNotificationsReadme.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnNotificationsReadme.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnNotificationsReadme.TabIndex = 35;
            this.BtnNotificationsReadme.Text = "notifications documentation";
            this.BtnNotificationsReadme.UseVisualStyleBackColor = false;
            this.BtnNotificationsReadme.Click += new System.EventHandler(this.BtnNotificationsReadme_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(220, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 19);
            this.label1.TabIndex = 34;
            this.label1.Text = "port";
            // 
            // CbAcceptNotifications
            // 
            this.CbAcceptNotifications.AutoSize = true;
            this.CbAcceptNotifications.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbAcceptNotifications.Location = new System.Drawing.Point(376, 126);
            this.CbAcceptNotifications.Name = "CbAcceptNotifications";
            this.CbAcceptNotifications.Size = new System.Drawing.Size(145, 23);
            this.CbAcceptNotifications.TabIndex = 33;
            this.CbAcceptNotifications.Text = "accept notifications";
            this.CbAcceptNotifications.UseVisualStyleBackColor = true;
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
            this.NumNotificationApiPort.Location = new System.Drawing.Point(261, 124);
            this.NumNotificationApiPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumNotificationApiPort.MaxLength = 10;
            this.NumNotificationApiPort.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumNotificationApiPort.Name = "NumNotificationApiPort";
            this.NumNotificationApiPort.Size = new System.Drawing.Size(83, 25);
            this.NumNotificationApiPort.TabIndex = 72;
            this.NumNotificationApiPort.ThemeName = "Metro";
            this.NumNotificationApiPort.Value = new decimal(new int[] {
            5115,
            0,
            0,
            0});
            this.NumNotificationApiPort.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // BtnSendTestNotification
            // 
            this.BtnSendTestNotification.AccessibleName = "Button";
            this.BtnSendTestNotification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSendTestNotification.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSendTestNotification.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSendTestNotification.Location = new System.Drawing.Point(220, 260);
            this.BtnSendTestNotification.Name = "BtnSendTestNotification";
            this.BtnSendTestNotification.Size = new System.Drawing.Size(301, 31);
            this.BtnSendTestNotification.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSendTestNotification.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSendTestNotification.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSendTestNotification.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSendTestNotification.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSendTestNotification.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSendTestNotification.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnSendTestNotification.TabIndex = 73;
            this.BtnSendTestNotification.Text = "show test notification";
            this.BtnSendTestNotification.UseVisualStyleBackColor = false;
            this.BtnSendTestNotification.Click += new System.EventHandler(this.BtnSendTestNotification_Click);
            // 
            // BtnExecutePortReservation
            // 
            this.BtnExecutePortReservation.AccessibleName = "Button";
            this.BtnExecutePortReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExecutePortReservation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnExecutePortReservation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExecutePortReservation.Location = new System.Drawing.Point(220, 207);
            this.BtnExecutePortReservation.Name = "BtnExecutePortReservation";
            this.BtnExecutePortReservation.Size = new System.Drawing.Size(301, 31);
            this.BtnExecutePortReservation.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExecutePortReservation.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExecutePortReservation.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExecutePortReservation.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExecutePortReservation.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExecutePortReservation.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExecutePortReservation.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnExecutePortReservation.TabIndex = 74;
            this.BtnExecutePortReservation.Text = "execute port reservation";
            this.BtnExecutePortReservation.UseVisualStyleBackColor = false;
            this.BtnExecutePortReservation.Click += new System.EventHandler(this.BtnExecutePortReservation_Click);
            // 
            // Notifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.BtnExecutePortReservation);
            this.Controls.Add(this.BtnSendTestNotification);
            this.Controls.Add(this.NumNotificationApiPort);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.BtnNotificationsReadme);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbAcceptNotifications);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Notifications";
            this.Size = new System.Drawing.Size(740, 544);
            ((System.ComponentModel.ISupportInitialize)(this.NumNotificationApiPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        internal Syncfusion.WinForms.Controls.SfButton BtnNotificationsReadme;
        internal System.Windows.Forms.CheckBox CbAcceptNotifications;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumNotificationApiPort;
        internal Syncfusion.WinForms.Controls.SfButton BtnSendTestNotification;
        internal Syncfusion.WinForms.Controls.SfButton BtnExecutePortReservation;
    }
}
