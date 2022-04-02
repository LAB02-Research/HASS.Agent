using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Configuration
{
    partial class ConfigService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigService));
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.LblServiceStatus = new System.Windows.Forms.Label();
            this.LblServiceStatusInfo = new System.Windows.Forms.Label();
            this.BtnStartService = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnDisableService = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnStopService = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnEnableService = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnReinstallService = new Syncfusion.WinForms.Controls.SfButton();
            this.LblInfo2 = new System.Windows.Forms.Label();
            this.LblInfo3 = new System.Windows.Forms.Label();
            this.BtnShowLogs = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnRescanStatus = new Syncfusion.WinForms.Controls.SfButton();
            this.LblInfo4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblInfo1
            // 
            this.LblInfo1.AutoSize = true;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(70, 36);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(581, 38);
            this.LblInfo1.TabIndex = 36;
            this.LblInfo1.Text = Languages.ConfigService_LblInfo1;
            // 
            // LblServiceStatus
            // 
            this.LblServiceStatus.AutoSize = true;
            this.LblServiceStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblServiceStatus.Location = new System.Drawing.Point(290, 107);
            this.LblServiceStatus.Name = "LblServiceStatus";
            this.LblServiceStatus.Size = new System.Drawing.Size(15, 19);
            this.LblServiceStatus.TabIndex = 38;
            this.LblServiceStatus.Text = "-";
            // 
            // LblServiceStatusInfo
            // 
            this.LblServiceStatusInfo.AutoSize = true;
            this.LblServiceStatusInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblServiceStatusInfo.Location = new System.Drawing.Point(154, 107);
            this.LblServiceStatusInfo.Name = "LblServiceStatusInfo";
            this.LblServiceStatusInfo.Size = new System.Drawing.Size(94, 19);
            this.LblServiceStatusInfo.TabIndex = 37;
            this.LblServiceStatusInfo.Text = Languages.ConfigService_LblServiceStatusInfo;
            // 
            // BtnStartService
            // 
            this.BtnStartService.AccessibleName = "Button";
            this.BtnStartService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStartService.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStartService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStartService.Location = new System.Drawing.Point(396, 161);
            this.BtnStartService.Name = "BtnStartService";
            this.BtnStartService.Size = new System.Drawing.Size(188, 31);
            this.BtnStartService.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStartService.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStartService.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStartService.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStartService.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStartService.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStartService.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStartService.TabIndex = 39;
            this.BtnStartService.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigService_BtnStartService;
            this.BtnStartService.UseVisualStyleBackColor = false;
            this.BtnStartService.Click += new System.EventHandler(this.BtnStartService_Click);
            // 
            // BtnDisableService
            // 
            this.BtnDisableService.AccessibleName = "Button";
            this.BtnDisableService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnDisableService.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnDisableService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnDisableService.Location = new System.Drawing.Point(156, 290);
            this.BtnDisableService.Name = "BtnDisableService";
            this.BtnDisableService.Size = new System.Drawing.Size(188, 31);
            this.BtnDisableService.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnDisableService.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnDisableService.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnDisableService.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnDisableService.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnDisableService.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnDisableService.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnDisableService.TabIndex = 40;
            this.BtnDisableService.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigService_BtnDisableService;
            this.BtnDisableService.UseVisualStyleBackColor = false;
            this.BtnDisableService.Click += new System.EventHandler(this.BtnDisableService_Click);
            // 
            // BtnStopService
            // 
            this.BtnStopService.AccessibleName = "Button";
            this.BtnStopService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStopService.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStopService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStopService.Location = new System.Drawing.Point(156, 161);
            this.BtnStopService.Name = "BtnStopService";
            this.BtnStopService.Size = new System.Drawing.Size(188, 31);
            this.BtnStopService.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStopService.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStopService.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStopService.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStopService.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStopService.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStopService.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStopService.TabIndex = 41;
            this.BtnStopService.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigService_BtnStopService;
            this.BtnStopService.UseVisualStyleBackColor = false;
            this.BtnStopService.Click += new System.EventHandler(this.BtnStopService_Click);
            // 
            // BtnEnableService
            // 
            this.BtnEnableService.AccessibleName = "Button";
            this.BtnEnableService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnEnableService.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnEnableService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnEnableService.Location = new System.Drawing.Point(396, 290);
            this.BtnEnableService.Name = "BtnEnableService";
            this.BtnEnableService.Size = new System.Drawing.Size(188, 31);
            this.BtnEnableService.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnEnableService.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnEnableService.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnEnableService.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnEnableService.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnEnableService.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnEnableService.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnEnableService.TabIndex = 42;
            this.BtnEnableService.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigService_BtnEnableService;
            this.BtnEnableService.UseVisualStyleBackColor = false;
            this.BtnEnableService.Click += new System.EventHandler(this.BtnEnableService_Click);
            // 
            // BtnReinstallService
            // 
            this.BtnReinstallService.AccessibleName = "Button";
            this.BtnReinstallService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnReinstallService.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnReinstallService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnReinstallService.Location = new System.Drawing.Point(154, 403);
            this.BtnReinstallService.Name = "BtnReinstallService";
            this.BtnReinstallService.Size = new System.Drawing.Size(432, 31);
            this.BtnReinstallService.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnReinstallService.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnReinstallService.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnReinstallService.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnReinstallService.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnReinstallService.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnReinstallService.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnReinstallService.TabIndex = 43;
            this.BtnReinstallService.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigService_BtnReinstallService;
            this.BtnReinstallService.UseVisualStyleBackColor = false;
            this.BtnReinstallService.Click += new System.EventHandler(this.BtnReinstallService_Click);
            // 
            // LblInfo2
            // 
            this.LblInfo2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LblInfo2.Location = new System.Drawing.Point(29, 207);
            this.LblInfo2.Name = "LblInfo2";
            this.LblInfo2.Size = new System.Drawing.Size(655, 65);
            this.LblInfo2.TabIndex = 44;
            this.LblInfo2.Text = Languages.ConfigService_LblInfo2;
            this.LblInfo2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // LblInfo3
            // 
            this.LblInfo3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo3.Location = new System.Drawing.Point(29, 350);
            this.LblInfo3.Name = "LblInfo3";
            this.LblInfo3.Size = new System.Drawing.Size(644, 38);
            this.LblInfo3.TabIndex = 45;
            this.LblInfo3.Text = Languages.ConfigService_LblInfo3;
            this.LblInfo3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BtnShowLogs
            // 
            this.BtnShowLogs.AccessibleName = "Button";
            this.BtnShowLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnShowLogs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnShowLogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnShowLogs.Location = new System.Drawing.Point(154, 491);
            this.BtnShowLogs.Name = "BtnShowLogs";
            this.BtnShowLogs.Size = new System.Drawing.Size(432, 31);
            this.BtnShowLogs.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnShowLogs.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnShowLogs.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnShowLogs.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnShowLogs.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnShowLogs.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnShowLogs.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnShowLogs.TabIndex = 46;
            this.BtnShowLogs.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigService_BtnShowLogs;
            this.BtnShowLogs.UseVisualStyleBackColor = false;
            this.BtnShowLogs.Click += new System.EventHandler(this.BtnShowLogs_Click);
            // 
            // BtnRescanStatus
            // 
            this.BtnRescanStatus.AccessibleName = "Button";
            this.BtnRescanStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRescanStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnRescanStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRescanStatus.ImageSize = new System.Drawing.Size(24, 24);
            this.BtnRescanStatus.Location = new System.Drawing.Point(535, 100);
            this.BtnRescanStatus.Name = "BtnRescanStatus";
            this.BtnRescanStatus.Size = new System.Drawing.Size(51, 31);
            this.BtnRescanStatus.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRescanStatus.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRescanStatus.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRescanStatus.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRescanStatus.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRescanStatus.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRescanStatus.Style.Image = global::HASS.Agent.Properties.Resources.reset_24;
            this.BtnRescanStatus.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnRescanStatus.TabIndex = 47;
            this.BtnRescanStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.BtnRescanStatus.UseVisualStyleBackColor = false;
            this.BtnRescanStatus.Click += new System.EventHandler(this.BtnRescanStatus_Click);
            // 
            // LblInfo4
            // 
            this.LblInfo4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo4.Location = new System.Drawing.Point(29, 454);
            this.LblInfo4.Name = "LblInfo4";
            this.LblInfo4.Size = new System.Drawing.Size(644, 19);
            this.LblInfo4.TabIndex = 48;
            this.LblInfo4.Text = Languages.ConfigService_LblInfo4;
            this.LblInfo4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ConfigService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.LblInfo4);
            this.Controls.Add(this.BtnRescanStatus);
            this.Controls.Add(this.BtnShowLogs);
            this.Controls.Add(this.LblInfo3);
            this.Controls.Add(this.LblInfo2);
            this.Controls.Add(this.BtnReinstallService);
            this.Controls.Add(this.BtnEnableService);
            this.Controls.Add(this.BtnStopService);
            this.Controls.Add(this.BtnDisableService);
            this.Controls.Add(this.BtnStartService);
            this.Controls.Add(this.LblServiceStatus);
            this.Controls.Add(this.LblServiceStatusInfo);
            this.Controls.Add(this.LblInfo1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfigService";
            this.Size = new System.Drawing.Size(700, 544);
            this.Load += new System.EventHandler(this.ConfigService_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblInfo1;
        internal Label LblServiceStatus;
        private Label LblServiceStatusInfo;
        internal Syncfusion.WinForms.Controls.SfButton BtnStartService;
        internal Syncfusion.WinForms.Controls.SfButton BtnDisableService;
        internal Syncfusion.WinForms.Controls.SfButton BtnStopService;
        internal Syncfusion.WinForms.Controls.SfButton BtnEnableService;
        internal Syncfusion.WinForms.Controls.SfButton BtnReinstallService;
        private Label LblInfo2;
        private Label LblInfo3;
        internal Syncfusion.WinForms.Controls.SfButton BtnShowLogs;
        internal Syncfusion.WinForms.Controls.SfButton BtnRescanStatus;
        private Label LblInfo4;
    }
}
