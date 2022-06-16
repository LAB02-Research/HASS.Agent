using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Configuration
{
    partial class ConfigNotifications
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
            this.LblInfo2 = new System.Windows.Forms.Label();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.BtnNotificationsReadme = new Syncfusion.WinForms.Controls.SfButton();
            this.CbAcceptNotifications = new System.Windows.Forms.CheckBox();
            this.BtnSendTestNotification = new Syncfusion.WinForms.Controls.SfButton();
            this.CbNotificationsIgnoreImageCertErrors = new System.Windows.Forms.CheckBox();
            this.LblLocalApiDisabled = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblInfo2
            // 
            this.LblInfo2.AccessibleDescription = "Debugging info in case the notifications don\'t work.";
            this.LblInfo2.AccessibleName = "Debugging info";
            this.LblInfo2.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo2.Location = new System.Drawing.Point(37, 375);
            this.LblInfo2.Name = "LblInfo2";
            this.LblInfo2.Size = new System.Drawing.Size(643, 114);
            this.LblInfo2.TabIndex = 37;
            this.LblInfo2.Text = Languages.ConfigNotifications_LblInfo2;
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "Notifications information.";
            this.LblInfo1.AccessibleName = "Information";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(70, 36);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(575, 68);
            this.LblInfo1.TabIndex = 36;
            this.LblInfo1.Text = Languages.ConfigNotifications_LblInfo1;
            // 
            // BtnNotificationsReadme
            // 
            this.BtnNotificationsReadme.AccessibleDescription = "Launches the notifications documentation webpage.";
            this.BtnNotificationsReadme.AccessibleName = "Open documentation";
            this.BtnNotificationsReadme.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnNotificationsReadme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnNotificationsReadme.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnNotificationsReadme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnNotificationsReadme.Location = new System.Drawing.Point(452, 497);
            this.BtnNotificationsReadme.Name = "BtnNotificationsReadme";
            this.BtnNotificationsReadme.Size = new System.Drawing.Size(228, 31);
            this.BtnNotificationsReadme.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnNotificationsReadme.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnNotificationsReadme.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnNotificationsReadme.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnNotificationsReadme.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnNotificationsReadme.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnNotificationsReadme.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnNotificationsReadme.TabIndex = 3;
            this.BtnNotificationsReadme.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigNotifications_BtnNotificationsReadme;
            this.BtnNotificationsReadme.UseVisualStyleBackColor = false;
            this.BtnNotificationsReadme.Click += new System.EventHandler(this.BtnNotificationsReadme_Click);
            // 
            // CbAcceptNotifications
            // 
            this.CbAcceptNotifications.AccessibleDescription = "Enable the notifications functionality.";
            this.CbAcceptNotifications.AccessibleName = "Enable notifications";
            this.CbAcceptNotifications.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.CbAcceptNotifications.AutoSize = true;
            this.CbAcceptNotifications.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbAcceptNotifications.Location = new System.Drawing.Point(232, 125);
            this.CbAcceptNotifications.Name = "CbAcceptNotifications";
            this.CbAcceptNotifications.Size = new System.Drawing.Size(145, 23);
            this.CbAcceptNotifications.TabIndex = 0;
            this.CbAcceptNotifications.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigNotifications_CbAcceptNotifications;
            this.CbAcceptNotifications.UseVisualStyleBackColor = true;
            // 
            // BtnSendTestNotification
            // 
            this.BtnSendTestNotification.AccessibleDescription = "Show a test notification.";
            this.BtnSendTestNotification.AccessibleName = "Test notification";
            this.BtnSendTestNotification.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnSendTestNotification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSendTestNotification.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSendTestNotification.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSendTestNotification.Location = new System.Drawing.Point(220, 230);
            this.BtnSendTestNotification.Name = "BtnSendTestNotification";
            this.BtnSendTestNotification.Size = new System.Drawing.Size(301, 31);
            this.BtnSendTestNotification.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSendTestNotification.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSendTestNotification.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSendTestNotification.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSendTestNotification.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSendTestNotification.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSendTestNotification.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnSendTestNotification.TabIndex = 2;
            this.BtnSendTestNotification.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigNotifications_BtnSendTestNotification;
            this.BtnSendTestNotification.UseVisualStyleBackColor = false;
            this.BtnSendTestNotification.Click += new System.EventHandler(this.BtnSendTestNotification_Click);
            // 
            // CbNotificationsIgnoreImageCertErrors
            // 
            this.CbNotificationsIgnoreImageCertErrors.AccessibleDescription = "Download notification images, even when there are certificate errors.";
            this.CbNotificationsIgnoreImageCertErrors.AccessibleName = "Ignore certificate";
            this.CbNotificationsIgnoreImageCertErrors.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.CbNotificationsIgnoreImageCertErrors.AutoSize = true;
            this.CbNotificationsIgnoreImageCertErrors.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbNotificationsIgnoreImageCertErrors.Location = new System.Drawing.Point(232, 171);
            this.CbNotificationsIgnoreImageCertErrors.Name = "CbNotificationsIgnoreImageCertErrors";
            this.CbNotificationsIgnoreImageCertErrors.Size = new System.Drawing.Size(237, 23);
            this.CbNotificationsIgnoreImageCertErrors.TabIndex = 1;
            this.CbNotificationsIgnoreImageCertErrors.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigNotifications_CbNotificationsIgnoreImageCertErrors;
            this.CbNotificationsIgnoreImageCertErrors.UseVisualStyleBackColor = true;
            // 
            // LblLocalApiDisabled
            // 
            this.LblLocalApiDisabled.AccessibleDescription = "Warns that the local API needs to be enabled for this to work.";
            this.LblLocalApiDisabled.AccessibleName = "Local API warning info";
            this.LblLocalApiDisabled.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblLocalApiDisabled.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblLocalApiDisabled.ForeColor = System.Drawing.Color.OrangeRed;
            this.LblLocalApiDisabled.Location = new System.Drawing.Point(19, 301);
            this.LblLocalApiDisabled.Name = "LblLocalApiDisabled";
            this.LblLocalApiDisabled.Size = new System.Drawing.Size(663, 19);
            this.LblLocalApiDisabled.TabIndex = 76;
            this.LblLocalApiDisabled.Text = Languages.ConfigNotifications_LblLocalApiDisabled;
            this.LblLocalApiDisabled.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LblLocalApiDisabled.Visible = false;
            // 
            // ConfigNotifications
            // 
            this.AccessibleDescription = "Panel containing the notification integration\'s configuration.";
            this.AccessibleName = "Notifications";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.LblLocalApiDisabled);
            this.Controls.Add(this.CbNotificationsIgnoreImageCertErrors);
            this.Controls.Add(this.BtnSendTestNotification);
            this.Controls.Add(this.LblInfo2);
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.BtnNotificationsReadme);
            this.Controls.Add(this.CbAcceptNotifications);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfigNotifications";
            this.Size = new System.Drawing.Size(700, 544);
            this.Load += new System.EventHandler(this.ConfigNotifications_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblInfo2;
        private System.Windows.Forms.Label LblInfo1;
        internal Syncfusion.WinForms.Controls.SfButton BtnNotificationsReadme;
        internal System.Windows.Forms.CheckBox CbAcceptNotifications;
        internal Syncfusion.WinForms.Controls.SfButton BtnSendTestNotification;
        internal CheckBox CbNotificationsIgnoreImageCertErrors;
        private Label LblLocalApiDisabled;
    }
}
