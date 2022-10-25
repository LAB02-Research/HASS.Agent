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
            this.LblInfo5 = new System.Windows.Forms.Label();
            this.BtnManageService = new Syncfusion.WinForms.Controls.SfButton();
            this.SuspendLayout();
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "Service information.";
            this.LblInfo1.AccessibleName = "Information";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(70, 36);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(581, 61);
            this.LblInfo1.TabIndex = 36;
            this.LblInfo1.Text = Languages.ConfigService_LblInfo1;
            // 
            // LblServiceStatus
            // 
            this.LblServiceStatus.AccessibleDescription = "Current status of the Satellite Service.";
            this.LblServiceStatus.AccessibleName = "Current status";
            this.LblServiceStatus.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
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
            this.LblServiceStatusInfo.AccessibleDescription = "Service status description.";
            this.LblServiceStatusInfo.AccessibleName = "Status description info";
            this.LblServiceStatusInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
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
            this.BtnStartService.AccessibleDescription = "Starts the Satellite Service. This will show an UAC prompt, asking for elevation." +
    "";
            this.BtnStartService.AccessibleName = "Start service";
            this.BtnStartService.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
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
            this.BtnStartService.TabIndex = 2;
            this.BtnStartService.Text = Languages.ConfigService_BtnStartService;
            this.BtnStartService.UseVisualStyleBackColor = false;
            this.BtnStartService.Click += new System.EventHandler(this.BtnStartService_Click);
            // 
            // BtnDisableService
            // 
            this.BtnDisableService.AccessibleDescription = "Completely disables the Satellite Service. This will show an UAC prompt, asking f" +
    "or elevation.";
            this.BtnDisableService.AccessibleName = "Disable service";
            this.BtnDisableService.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnDisableService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnDisableService.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnDisableService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnDisableService.Location = new System.Drawing.Point(154, 418);
            this.BtnDisableService.Name = "BtnDisableService";
            this.BtnDisableService.Size = new System.Drawing.Size(188, 31);
            this.BtnDisableService.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnDisableService.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnDisableService.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnDisableService.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnDisableService.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnDisableService.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnDisableService.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnDisableService.TabIndex = 3;
            this.BtnDisableService.Text = Languages.ConfigService_BtnDisableService;
            this.BtnDisableService.UseVisualStyleBackColor = false;
            this.BtnDisableService.Click += new System.EventHandler(this.BtnDisableService_Click);
            // 
            // BtnStopService
            // 
            this.BtnStopService.AccessibleDescription = "Stops the Satellite Service. This will show an UAC prompt, asking for elevation.";
            this.BtnStopService.AccessibleName = "Stop service";
            this.BtnStopService.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
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
            this.BtnStopService.TabIndex = 1;
            this.BtnStopService.Text = Languages.ConfigService_BtnStopService;
            this.BtnStopService.UseVisualStyleBackColor = false;
            this.BtnStopService.Click += new System.EventHandler(this.BtnStopService_Click);
            // 
            // BtnEnableService
            // 
            this.BtnEnableService.AccessibleDescription = "Enables the Satellite Service. This will show an UAC prompt, asking for elevation" +
    ".";
            this.BtnEnableService.AccessibleName = "Enable service";
            this.BtnEnableService.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnEnableService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnEnableService.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnEnableService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnEnableService.Location = new System.Drawing.Point(394, 418);
            this.BtnEnableService.Name = "BtnEnableService";
            this.BtnEnableService.Size = new System.Drawing.Size(188, 31);
            this.BtnEnableService.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnEnableService.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnEnableService.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnEnableService.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnEnableService.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnEnableService.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnEnableService.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnEnableService.TabIndex = 4;
            this.BtnEnableService.Text = Languages.ConfigService_BtnEnableService;
            this.BtnEnableService.UseVisualStyleBackColor = false;
            this.BtnEnableService.Click += new System.EventHandler(this.BtnEnableService_Click);
            // 
            // BtnReinstallService
            // 
            this.BtnReinstallService.AccessibleDescription = "Removes and then reinstalls the Satellite Service. This will show an UAC prompt, " +
    "asking for elevation.";
            this.BtnReinstallService.AccessibleName = "Reinstall service";
            this.BtnReinstallService.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnReinstallService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnReinstallService.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnReinstallService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnReinstallService.Location = new System.Drawing.Point(152, 531);
            this.BtnReinstallService.Name = "BtnReinstallService";
            this.BtnReinstallService.Size = new System.Drawing.Size(432, 31);
            this.BtnReinstallService.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnReinstallService.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnReinstallService.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnReinstallService.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnReinstallService.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnReinstallService.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnReinstallService.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnReinstallService.TabIndex = 5;
            this.BtnReinstallService.Text = Languages.ConfigService_BtnReinstallService;
            this.BtnReinstallService.UseVisualStyleBackColor = false;
            this.BtnReinstallService.Click += new System.EventHandler(this.BtnReinstallService_Click);
            // 
            // LblInfo2
            // 
            this.LblInfo2.AccessibleDescription = "Information regarding disabling the Satellite Service.";
            this.LblInfo2.AccessibleName = "Disable service info";
            this.LblInfo2.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LblInfo2.Location = new System.Drawing.Point(27, 335);
            this.LblInfo2.Name = "LblInfo2";
            this.LblInfo2.Size = new System.Drawing.Size(655, 65);
            this.LblInfo2.TabIndex = 44;
            this.LblInfo2.Text = Languages.ConfigService_LblInfo2;
            this.LblInfo2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // LblInfo3
            // 
            this.LblInfo3.AccessibleDescription = "Information regarding reinstalling the Satellite Service.";
            this.LblInfo3.AccessibleName = "Reinstall info";
            this.LblInfo3.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo3.Location = new System.Drawing.Point(27, 478);
            this.LblInfo3.Name = "LblInfo3";
            this.LblInfo3.Size = new System.Drawing.Size(644, 38);
            this.LblInfo3.TabIndex = 45;
            this.LblInfo3.Text = Languages.ConfigService_LblInfo3;
            this.LblInfo3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BtnShowLogs
            // 
            this.BtnShowLogs.AccessibleDescription = "Open the Satellite Service logs storage path in Explorer.";
            this.BtnShowLogs.AccessibleName = "Open logs";
            this.BtnShowLogs.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnShowLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnShowLogs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnShowLogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnShowLogs.Location = new System.Drawing.Point(152, 619);
            this.BtnShowLogs.Name = "BtnShowLogs";
            this.BtnShowLogs.Size = new System.Drawing.Size(432, 31);
            this.BtnShowLogs.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnShowLogs.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnShowLogs.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnShowLogs.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnShowLogs.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnShowLogs.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnShowLogs.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnShowLogs.TabIndex = 6;
            this.BtnShowLogs.Text = Languages.ConfigService_BtnShowLogs;
            this.BtnShowLogs.UseVisualStyleBackColor = false;
            this.BtnShowLogs.Click += new System.EventHandler(this.BtnShowLogs_Click);
            // 
            // BtnRescanStatus
            // 
            this.BtnRescanStatus.AccessibleDescription = "Refreshes the current Satellite Service status.";
            this.BtnRescanStatus.AccessibleName = "Refresh status";
            this.BtnRescanStatus.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
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
            this.BtnRescanStatus.Style.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.BtnRescanStatus.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnRescanStatus.TabIndex = 0;
            this.BtnRescanStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.BtnRescanStatus.UseVisualStyleBackColor = false;
            this.BtnRescanStatus.Click += new System.EventHandler(this.BtnRescanStatus_Click);
            // 
            // LblInfo4
            // 
            this.LblInfo4.AccessibleDescription = "Information on what to do when the Satellite Service keeps failing.";
            this.LblInfo4.AccessibleName = "Service failing info";
            this.LblInfo4.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo4.Location = new System.Drawing.Point(27, 571);
            this.LblInfo4.Name = "LblInfo4";
            this.LblInfo4.Size = new System.Drawing.Size(644, 37);
            this.LblInfo4.TabIndex = 48;
            this.LblInfo4.Text = Languages.ConfigService_LblInfo4;
            this.LblInfo4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // LblInfo5
            // 
            this.LblInfo5.AccessibleDescription = "Information regarding managing the Satellite Service.";
            this.LblInfo5.AccessibleName = "Managing info";
            this.LblInfo5.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo5.Location = new System.Drawing.Point(27, 236);
            this.LblInfo5.Name = "LblInfo5";
            this.LblInfo5.Size = new System.Drawing.Size(644, 38);
            this.LblInfo5.TabIndex = 50;
            this.LblInfo5.Text = Languages.ConfigService_LblInfo5;
            this.LblInfo5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BtnManageService
            // 
            this.BtnManageService.AccessibleDescription = "Opens the \'manage satellite service\' window.";
            this.BtnManageService.AccessibleName = "Manage service";
            this.BtnManageService.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnManageService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnManageService.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnManageService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnManageService.Location = new System.Drawing.Point(152, 289);
            this.BtnManageService.Name = "BtnManageService";
            this.BtnManageService.Size = new System.Drawing.Size(432, 31);
            this.BtnManageService.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnManageService.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnManageService.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnManageService.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnManageService.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnManageService.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnManageService.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnManageService.TabIndex = 49;
            this.BtnManageService.Text = Languages.ConfigService_BtnManageService;
            this.BtnManageService.UseVisualStyleBackColor = false;
            this.BtnManageService.Click += new System.EventHandler(this.BtnManageService_Click);
            // 
            // ConfigService
            // 
            this.AccessibleDescription = "Panel containing the satellite service configuration.";
            this.AccessibleName = "Satellite service";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.LblInfo5);
            this.Controls.Add(this.BtnManageService);
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
            this.Size = new System.Drawing.Size(700, 678);
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
        private Label LblInfo5;
        internal Syncfusion.WinForms.Controls.SfButton BtnManageService;
    }
}
