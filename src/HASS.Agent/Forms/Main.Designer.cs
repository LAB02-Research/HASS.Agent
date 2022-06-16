using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Forms
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.CmTrayIcon = new Syncfusion.Windows.Forms.Tools.ContextMenuStripEx();
            this.TsShow = new System.Windows.Forms.ToolStripMenuItem();
            this.TsShowQuickActions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TsConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.TsQuickItemsConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.TsSatelliteService = new System.Windows.Forms.ToolStripMenuItem();
            this.TsLocalSensors = new System.Windows.Forms.ToolStripMenuItem();
            this.TsCommands = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TsCheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.TsDonate = new System.Windows.Forms.ToolStripMenuItem();
            this.TsHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.TsAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.TsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExit = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnHide = new Syncfusion.WinForms.Controls.SfButton();
            this.GpControls = new HASS.Agent.Controls.CustomGroupBox();
            this.BtnServiceManager = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnAppSettings = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnActionsManager = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnCommandsManager = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnSensorsManager = new Syncfusion.WinForms.Controls.SfButton();
            this.GpStatus = new HASS.Agent.Controls.CustomGroupBox();
            this.LblStatusService = new System.Windows.Forms.Label();
            this.LblService = new System.Windows.Forms.Label();
            this.LblStatusMqtt = new System.Windows.Forms.Label();
            this.LblMqtt = new System.Windows.Forms.Label();
            this.LblStatusCommands = new System.Windows.Forms.Label();
            this.LblCommands = new System.Windows.Forms.Label();
            this.LblStatusSensors = new System.Windows.Forms.Label();
            this.LblStatusQuickActions = new System.Windows.Forms.Label();
            this.LblStatusHassApi = new System.Windows.Forms.Label();
            this.LblStatusLocalApi = new System.Windows.Forms.Label();
            this.LblSensors = new System.Windows.Forms.Label();
            this.LblQuickActions = new System.Windows.Forms.Label();
            this.LblHomeAssistantApi = new System.Windows.Forms.Label();
            this.LblLocalApi = new System.Windows.Forms.Label();
            this.BtnCheckForUpdate = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnHelp = new Syncfusion.WinForms.Controls.SfButton();
            this.CmTrayIcon.SuspendLayout();
            this.GpControls.SuspendLayout();
            this.GpStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.BalloonTipTitle = "HASS.Agent";
            this.NotifyIcon.ContextMenuStrip = this.CmTrayIcon;
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "HASS.Agent";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.DoubleClick += new System.EventHandler(this.NotifyIcon_DoubleClick);
            this.NotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // CmTrayIcon
            // 
            this.CmTrayIcon.AccessibleDescription = "System tray menu, shown when the tray icon is right clicked.";
            this.CmTrayIcon.AccessibleName = "System tray menu";
            this.CmTrayIcon.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuPopup;
            this.CmTrayIcon.DropShadowEnabled = false;
            this.CmTrayIcon.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CmTrayIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsShow,
            this.TsShowQuickActions,
            this.toolStripSeparator1,
            this.TsConfig,
            this.TsQuickItemsConfig,
            this.TsSatelliteService,
            this.TsLocalSensors,
            this.TsCommands,
            this.toolStripSeparator2,
            this.TsCheckForUpdates,
            this.toolStripSeparator3,
            this.TsDonate,
            this.TsHelp,
            this.TsAbout,
            this.toolStripSeparator4,
            this.TsExit});
            this.CmTrayIcon.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(236)))), ((int)(((byte)(249)))));
            this.CmTrayIcon.Name = "CmTrayIcon";
            this.CmTrayIcon.Size = new System.Drawing.Size(204, 340);
            this.CmTrayIcon.Style = Syncfusion.Windows.Forms.Tools.ContextMenuStripEx.ContextMenuStyle.Metro;
            this.CmTrayIcon.ThemeName = "Office2016Black";
            this.CmTrayIcon.ThemeStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            // 
            // TsShow
            // 
            this.TsShow.AccessibleDescription = "Opens the main window.";
            this.TsShow.AccessibleName = "Main window";
            this.TsShow.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.TsShow.Image = global::HASS.Agent.Properties.Resources.logo_32;
            this.TsShow.Name = "TsShow";
            this.TsShow.Size = new System.Drawing.Size(203, 26);
            this.TsShow.Text = global::HASS.Agent.Resources.Localization.Languages.Main_TsShow;
            this.TsShow.Click += new System.EventHandler(this.TsShow_Click);
            // 
            // TsShowQuickActions
            // 
            this.TsShowQuickActions.AccessibleDescription = "Show your Quick Actions.";
            this.TsShowQuickActions.AccessibleName = "Show Quick Actions";
            this.TsShowQuickActions.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.TsShowQuickActions.Image = global::HASS.Agent.Properties.Resources.ti_remote_32;
            this.TsShowQuickActions.Name = "TsShowQuickActions";
            this.TsShowQuickActions.Size = new System.Drawing.Size(203, 26);
            this.TsShowQuickActions.Text = global::HASS.Agent.Resources.Localization.Languages.Main_TsShowQuickActions;
            this.TsShowQuickActions.Click += new System.EventHandler(this.TsShowQuickActions_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AccessibleDescription = "Seperator line.";
            this.toolStripSeparator1.AccessibleName = "Seperator";
            this.toolStripSeparator1.AccessibleRole = System.Windows.Forms.AccessibleRole.Separator;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // TsConfig
            // 
            this.TsConfig.AccessibleDescription = "Opens the configuration window.";
            this.TsConfig.AccessibleName = "Configuration";
            this.TsConfig.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.TsConfig.Image = global::HASS.Agent.Properties.Resources.ti_gear_32;
            this.TsConfig.Name = "TsConfig";
            this.TsConfig.Size = new System.Drawing.Size(203, 26);
            this.TsConfig.Text = global::HASS.Agent.Resources.Localization.Languages.Main_TsConfig;
            this.TsConfig.Click += new System.EventHandler(this.TsConfig_Click);
            // 
            // TsQuickItemsConfig
            // 
            this.TsQuickItemsConfig.AccessibleDescription = "Opens the Quick Actions configuration window.";
            this.TsQuickItemsConfig.AccessibleName = "Manage Quick actions";
            this.TsQuickItemsConfig.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.TsQuickItemsConfig.Image = global::HASS.Agent.Properties.Resources.ti_remote_32;
            this.TsQuickItemsConfig.Name = "TsQuickItemsConfig";
            this.TsQuickItemsConfig.Size = new System.Drawing.Size(203, 26);
            this.TsQuickItemsConfig.Text = global::HASS.Agent.Resources.Localization.Languages.Main_TsQuickItemsConfig;
            this.TsQuickItemsConfig.Click += new System.EventHandler(this.TsQuickItemsConfig_Click);
            // 
            // TsSatelliteService
            // 
            this.TsSatelliteService.AccessibleDescription = "Opens the Satellite Service configuration window.";
            this.TsSatelliteService.AccessibleName = "Satellite Service";
            this.TsSatelliteService.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.TsSatelliteService.Image = global::HASS.Agent.Properties.Resources.service_32;
            this.TsSatelliteService.Name = "TsSatelliteService";
            this.TsSatelliteService.Size = new System.Drawing.Size(203, 26);
            this.TsSatelliteService.Text = Languages.Main_TsSatelliteService;
            this.TsSatelliteService.Click += new System.EventHandler(this.TsSatelliteService_Click);
            // 
            // TsLocalSensors
            // 
            this.TsLocalSensors.AccessibleDescription = "Opens the sensors configuration window.";
            this.TsLocalSensors.AccessibleName = "Sensors";
            this.TsLocalSensors.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.TsLocalSensors.Image = global::HASS.Agent.Properties.Resources.ti_radar_32;
            this.TsLocalSensors.Name = "TsLocalSensors";
            this.TsLocalSensors.Size = new System.Drawing.Size(203, 26);
            this.TsLocalSensors.Text = global::HASS.Agent.Resources.Localization.Languages.Main_TsLocalSensors;
            this.TsLocalSensors.Click += new System.EventHandler(this.TsLocalSensors_Click);
            // 
            // TsCommands
            // 
            this.TsCommands.AccessibleDescription = "Opens the commands configuration window.";
            this.TsCommands.AccessibleName = "Commands";
            this.TsCommands.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.TsCommands.Image = global::HASS.Agent.Properties.Resources.ti_workflow_32;
            this.TsCommands.Name = "TsCommands";
            this.TsCommands.Size = new System.Drawing.Size(203, 26);
            this.TsCommands.Text = global::HASS.Agent.Resources.Localization.Languages.Main_TsCommands;
            this.TsCommands.Click += new System.EventHandler(this.TsCommands_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AccessibleDescription = "Seperator line.";
            this.toolStripSeparator2.AccessibleName = "Seperator";
            this.toolStripSeparator2.AccessibleRole = System.Windows.Forms.AccessibleRole.Separator;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(200, 6);
            // 
            // TsCheckForUpdates
            // 
            this.TsCheckForUpdates.AccessibleDescription = "Opens an update check.";
            this.TsCheckForUpdates.AccessibleName = "Update check";
            this.TsCheckForUpdates.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.TsCheckForUpdates.Image = global::HASS.Agent.Properties.Resources.ti_update_32;
            this.TsCheckForUpdates.Name = "TsCheckForUpdates";
            this.TsCheckForUpdates.Size = new System.Drawing.Size(203, 26);
            this.TsCheckForUpdates.Text = global::HASS.Agent.Resources.Localization.Languages.Main_CheckForUpdates;
            this.TsCheckForUpdates.Click += new System.EventHandler(this.TsCheckForUpdates_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AccessibleDescription = "Seperator line.";
            this.toolStripSeparator3.AccessibleName = "Seperator";
            this.toolStripSeparator3.AccessibleRole = System.Windows.Forms.AccessibleRole.Separator;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(200, 6);
            // 
            // TsDonate
            // 
            this.TsDonate.AccessibleDescription = "Opens the \'donate on buymeacoffee\' url.";
            this.TsDonate.AccessibleName = "Donate";
            this.TsDonate.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.TsDonate.Image = global::HASS.Agent.Properties.Resources.bmac_logo_32;
            this.TsDonate.Name = "TsDonate";
            this.TsDonate.Size = new System.Drawing.Size(203, 26);
            this.TsDonate.Text = global::HASS.Agent.Resources.Localization.Languages.Main_TsDonate;
            this.TsDonate.Click += new System.EventHandler(this.TsDonate_Click);
            // 
            // TsHelp
            // 
            this.TsHelp.AccessibleDescription = "Opens the help window.";
            this.TsHelp.AccessibleName = "Help";
            this.TsHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.TsHelp.Image = global::HASS.Agent.Properties.Resources.question_32;
            this.TsHelp.Name = "TsHelp";
            this.TsHelp.Size = new System.Drawing.Size(203, 26);
            this.TsHelp.Text = global::HASS.Agent.Resources.Localization.Languages.Main_TsHelp;
            this.TsHelp.Click += new System.EventHandler(this.TsHelp_Click);
            // 
            // TsAbout
            // 
            this.TsAbout.AccessibleDescription = "Opens the about window.";
            this.TsAbout.AccessibleName = "About";
            this.TsAbout.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.TsAbout.Image = global::HASS.Agent.Properties.Resources.info_32;
            this.TsAbout.Name = "TsAbout";
            this.TsAbout.Size = new System.Drawing.Size(203, 26);
            this.TsAbout.Text = global::HASS.Agent.Resources.Localization.Languages.Main_TsAbout;
            this.TsAbout.Click += new System.EventHandler(this.TsAbout_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.AccessibleDescription = "Seperator line.";
            this.toolStripSeparator4.AccessibleName = "Seperator";
            this.toolStripSeparator4.AccessibleRole = System.Windows.Forms.AccessibleRole.Separator;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(200, 6);
            // 
            // TsExit
            // 
            this.TsExit.AccessibleDescription = "Opens the exit, restart or hide window.";
            this.TsExit.AccessibleName = "Exit, restart or hide";
            this.TsExit.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            this.TsExit.Image = global::HASS.Agent.Properties.Resources.ti_exit_32;
            this.TsExit.Name = "TsExit";
            this.TsExit.Size = new System.Drawing.Size(203, 26);
            this.TsExit.Text = global::HASS.Agent.Resources.Localization.Languages.Main_TsExit;
            this.TsExit.Click += new System.EventHandler(this.TsExit_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.AccessibleDescription = "Opens the exit, restart or hide window.";
            this.BtnExit.AccessibleName = "Exit, restart or hide";
            this.BtnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExit.ImageSize = new System.Drawing.Size(24, 24);
            this.BtnExit.Location = new System.Drawing.Point(13, 445);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(65, 34);
            this.BtnExit.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExit.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExit.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExit.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExit.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExit.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExit.Style.Image = global::HASS.Agent.Properties.Resources.exit_24;
            this.BtnExit.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnExit.TabIndex = 8;
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnHide
            // 
            this.BtnHide.AccessibleDescription = "Hides this window into the system tray icon.";
            this.BtnHide.AccessibleName = "Hide";
            this.BtnHide.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnHide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHide.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnHide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHide.Location = new System.Drawing.Point(300, 445);
            this.BtnHide.Name = "BtnHide";
            this.BtnHide.Size = new System.Drawing.Size(285, 34);
            this.BtnHide.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHide.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHide.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHide.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHide.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHide.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHide.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnHide.TabIndex = 5;
            this.BtnHide.Text = Languages.Main_BtnHide;
            this.BtnHide.UseVisualStyleBackColor = false;
            this.BtnHide.Click += new System.EventHandler(this.BtnHide_Click);
            // 
            // GpControls
            // 
            this.GpControls.AccessibleDescription = "Contains access buttons the the various systems.";
            this.GpControls.AccessibleName = "System controls";
            this.GpControls.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.GpControls.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.GpControls.Controls.Add(this.BtnServiceManager);
            this.GpControls.Controls.Add(this.BtnAppSettings);
            this.GpControls.Controls.Add(this.BtnActionsManager);
            this.GpControls.Controls.Add(this.BtnCommandsManager);
            this.GpControls.Controls.Add(this.BtnSensorsManager);
            this.GpControls.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GpControls.Location = new System.Drawing.Point(13, 243);
            this.GpControls.Name = "GpControls";
            this.GpControls.Size = new System.Drawing.Size(572, 195);
            this.GpControls.TabIndex = 7;
            this.GpControls.TabStop = false;
            this.GpControls.Text = Languages.Main_GpControls;
            // 
            // BtnServiceManager
            // 
            this.BtnServiceManager.AccessibleDescription = "Opens the Satellite Service configuration window.";
            this.BtnServiceManager.AccessibleName = "Satellite Service";
            this.BtnServiceManager.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnServiceManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnServiceManager.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnServiceManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnServiceManager.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnServiceManager.ImageSize = new System.Drawing.Size(48, 48);
            this.BtnServiceManager.Location = new System.Drawing.Point(236, 31);
            this.BtnServiceManager.Name = "BtnServiceManager";
            this.BtnServiceManager.Size = new System.Drawing.Size(100, 144);
            this.BtnServiceManager.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnServiceManager.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnServiceManager.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnServiceManager.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnServiceManager.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnServiceManager.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnServiceManager.Style.Image = global::HASS.Agent.Properties.Resources.service_48;
            this.BtnServiceManager.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnServiceManager.TabIndex = 2;
            this.BtnServiceManager.Text = Languages.Main_BtnServiceManager;
            this.BtnServiceManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnServiceManager.TextMargin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.BtnServiceManager.UseVisualStyleBackColor = false;
            this.BtnServiceManager.Click += new System.EventHandler(this.BtnServiceManager_Click);
            // 
            // BtnAppSettings
            // 
            this.BtnAppSettings.AccessibleDescription = "Opens the configuration window.";
            this.BtnAppSettings.AccessibleName = "Configuration";
            this.BtnAppSettings.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnAppSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAppSettings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnAppSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAppSettings.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAppSettings.ImageSize = new System.Drawing.Size(48, 48);
            this.BtnAppSettings.Location = new System.Drawing.Point(18, 31);
            this.BtnAppSettings.Name = "BtnAppSettings";
            this.BtnAppSettings.Size = new System.Drawing.Size(100, 144);
            this.BtnAppSettings.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAppSettings.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAppSettings.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAppSettings.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAppSettings.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAppSettings.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAppSettings.Style.Image = global::HASS.Agent.Properties.Resources.gear_48;
            this.BtnAppSettings.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnAppSettings.TabIndex = 0;
            this.BtnAppSettings.Text = Languages.Main_BtnAppSettings;
            this.BtnAppSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnAppSettings.UseVisualStyleBackColor = false;
            this.BtnAppSettings.Click += new System.EventHandler(this.BtnAppSettings_Click);
            // 
            // BtnActionsManager
            // 
            this.BtnActionsManager.AccessibleDescription = "Opens the Quick Actions configuration window.";
            this.BtnActionsManager.AccessibleName = "Quick Actions";
            this.BtnActionsManager.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnActionsManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnActionsManager.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnActionsManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnActionsManager.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnActionsManager.ImageSize = new System.Drawing.Size(48, 48);
            this.BtnActionsManager.Location = new System.Drawing.Point(127, 31);
            this.BtnActionsManager.Name = "BtnActionsManager";
            this.BtnActionsManager.Size = new System.Drawing.Size(100, 144);
            this.BtnActionsManager.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnActionsManager.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnActionsManager.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnActionsManager.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnActionsManager.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnActionsManager.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnActionsManager.Style.Image = global::HASS.Agent.Properties.Resources.remote_48;
            this.BtnActionsManager.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnActionsManager.TabIndex = 1;
            this.BtnActionsManager.Text = Languages.Main_BtnActionsManager;
            this.BtnActionsManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnActionsManager.UseVisualStyleBackColor = false;
            this.BtnActionsManager.Click += new System.EventHandler(this.BtnActionsManager_Click);
            // 
            // BtnCommandsManager
            // 
            this.BtnCommandsManager.AccessibleDescription = "Opens the commands configuration window.";
            this.BtnCommandsManager.AccessibleName = "Commands";
            this.BtnCommandsManager.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnCommandsManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCommandsManager.Enabled = false;
            this.BtnCommandsManager.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCommandsManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCommandsManager.ImageSize = new System.Drawing.Size(48, 48);
            this.BtnCommandsManager.Location = new System.Drawing.Point(454, 31);
            this.BtnCommandsManager.Name = "BtnCommandsManager";
            this.BtnCommandsManager.Size = new System.Drawing.Size(100, 144);
            this.BtnCommandsManager.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCommandsManager.Style.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCommandsManager.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCommandsManager.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCommandsManager.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCommandsManager.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCommandsManager.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCommandsManager.Style.Image = global::HASS.Agent.Properties.Resources.workflow_48;
            this.BtnCommandsManager.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnCommandsManager.TabIndex = 4;
            this.BtnCommandsManager.Text = global::HASS.Agent.Resources.Localization.Languages.Main_BtnCommandsManager;
            this.BtnCommandsManager.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCommandsManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnCommandsManager.UseVisualStyleBackColor = false;
            this.BtnCommandsManager.Click += new System.EventHandler(this.BtnCommandsManager_Click);
            // 
            // BtnSensorsManager
            // 
            this.BtnSensorsManager.AccessibleDescription = "Opens the sensors configuration window.";
            this.BtnSensorsManager.AccessibleName = "Sensors";
            this.BtnSensorsManager.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnSensorsManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSensorsManager.Enabled = false;
            this.BtnSensorsManager.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSensorsManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSensorsManager.ImageSize = new System.Drawing.Size(48, 48);
            this.BtnSensorsManager.Location = new System.Drawing.Point(345, 31);
            this.BtnSensorsManager.Name = "BtnSensorsManager";
            this.BtnSensorsManager.Size = new System.Drawing.Size(100, 144);
            this.BtnSensorsManager.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSensorsManager.Style.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSensorsManager.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSensorsManager.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSensorsManager.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSensorsManager.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSensorsManager.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSensorsManager.Style.Image = global::HASS.Agent.Properties.Resources.radar_48;
            this.BtnSensorsManager.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnSensorsManager.TabIndex = 3;
            this.BtnSensorsManager.Text = global::HASS.Agent.Resources.Localization.Languages.Main_BtnSensorsManager;
            this.BtnSensorsManager.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSensorsManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnSensorsManager.UseVisualStyleBackColor = false;
            this.BtnSensorsManager.Click += new System.EventHandler(this.BtnSensorsManager_Click);
            // 
            // GpStatus
            // 
            this.GpStatus.AccessibleDescription = "Contains the status of the various internal systems.";
            this.GpStatus.AccessibleName = "System states";
            this.GpStatus.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.GpStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.GpStatus.Controls.Add(this.LblStatusService);
            this.GpStatus.Controls.Add(this.LblService);
            this.GpStatus.Controls.Add(this.LblStatusMqtt);
            this.GpStatus.Controls.Add(this.LblMqtt);
            this.GpStatus.Controls.Add(this.LblStatusCommands);
            this.GpStatus.Controls.Add(this.LblCommands);
            this.GpStatus.Controls.Add(this.LblStatusSensors);
            this.GpStatus.Controls.Add(this.LblStatusQuickActions);
            this.GpStatus.Controls.Add(this.LblStatusHassApi);
            this.GpStatus.Controls.Add(this.LblStatusLocalApi);
            this.GpStatus.Controls.Add(this.LblSensors);
            this.GpStatus.Controls.Add(this.LblQuickActions);
            this.GpStatus.Controls.Add(this.LblHomeAssistantApi);
            this.GpStatus.Controls.Add(this.LblLocalApi);
            this.GpStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GpStatus.Location = new System.Drawing.Point(13, 13);
            this.GpStatus.Name = "GpStatus";
            this.GpStatus.Size = new System.Drawing.Size(572, 214);
            this.GpStatus.TabIndex = 6;
            this.GpStatus.TabStop = false;
            this.GpStatus.Text = Languages.Main_GpStatus;
            // 
            // LblStatusService
            // 
            this.LblStatusService.AccessibleDescription = "Satellite service status.";
            this.LblStatusService.AccessibleName = "Satellite service status";
            this.LblStatusService.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblStatusService.AutoSize = true;
            this.LblStatusService.Location = new System.Drawing.Point(164, 124);
            this.LblStatusService.Name = "LblStatusService";
            this.LblStatusService.Size = new System.Drawing.Size(15, 19);
            this.LblStatusService.TabIndex = 13;
            this.LblStatusService.Text = "-";
            // 
            // LblService
            // 
            this.LblService.AccessibleDescription = "Description of the satellite service.";
            this.LblService.AccessibleName = "Satellite service description";
            this.LblService.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblService.Location = new System.Drawing.Point(6, 124);
            this.LblService.Name = "LblService";
            this.LblService.Size = new System.Drawing.Size(152, 19);
            this.LblService.TabIndex = 12;
            this.LblService.Text = Languages.Main_LblService;
            this.LblService.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblStatusMqtt
            // 
            this.LblStatusMqtt.AccessibleDescription = "MQTT status.";
            this.LblStatusMqtt.AccessibleName = "MQTT status";
            this.LblStatusMqtt.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblStatusMqtt.AutoSize = true;
            this.LblStatusMqtt.Location = new System.Drawing.Point(164, 165);
            this.LblStatusMqtt.Name = "LblStatusMqtt";
            this.LblStatusMqtt.Size = new System.Drawing.Size(15, 19);
            this.LblStatusMqtt.TabIndex = 11;
            this.LblStatusMqtt.Text = "-";
            // 
            // LblMqtt
            // 
            this.LblMqtt.AccessibleDescription = "Description of the MQTT client.";
            this.LblMqtt.AccessibleName = "MQTT  description";
            this.LblMqtt.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblMqtt.Location = new System.Drawing.Point(6, 165);
            this.LblMqtt.Name = "LblMqtt";
            this.LblMqtt.Size = new System.Drawing.Size(152, 19);
            this.LblMqtt.TabIndex = 10;
            this.LblMqtt.Text = Languages.Main_LblMqtt;
            this.LblMqtt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblStatusCommands
            // 
            this.LblStatusCommands.AccessibleDescription = "Commands status.";
            this.LblStatusCommands.AccessibleName = "Commands status";
            this.LblStatusCommands.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblStatusCommands.AutoSize = true;
            this.LblStatusCommands.Location = new System.Drawing.Point(398, 124);
            this.LblStatusCommands.Name = "LblStatusCommands";
            this.LblStatusCommands.Size = new System.Drawing.Size(15, 19);
            this.LblStatusCommands.TabIndex = 9;
            this.LblStatusCommands.Text = "-";
            // 
            // LblCommands
            // 
            this.LblCommands.AccessibleDescription = "Description of the commands.";
            this.LblCommands.AccessibleName = "Commands description";
            this.LblCommands.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblCommands.Location = new System.Drawing.Point(216, 124);
            this.LblCommands.Name = "LblCommands";
            this.LblCommands.Size = new System.Drawing.Size(176, 19);
            this.LblCommands.TabIndex = 8;
            this.LblCommands.Text = Languages.Main_LblCommands;
            this.LblCommands.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblStatusSensors
            // 
            this.LblStatusSensors.AccessibleDescription = "Sensors status.";
            this.LblStatusSensors.AccessibleName = "Sensors status";
            this.LblStatusSensors.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblStatusSensors.AutoSize = true;
            this.LblStatusSensors.Location = new System.Drawing.Point(398, 83);
            this.LblStatusSensors.Name = "LblStatusSensors";
            this.LblStatusSensors.Size = new System.Drawing.Size(15, 19);
            this.LblStatusSensors.TabIndex = 7;
            this.LblStatusSensors.Text = "-";
            // 
            // LblStatusQuickActions
            // 
            this.LblStatusQuickActions.AccessibleDescription = "Quick Actions status.";
            this.LblStatusQuickActions.AccessibleName = "Quick Actions status";
            this.LblStatusQuickActions.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblStatusQuickActions.AutoSize = true;
            this.LblStatusQuickActions.Location = new System.Drawing.Point(398, 42);
            this.LblStatusQuickActions.Name = "LblStatusQuickActions";
            this.LblStatusQuickActions.Size = new System.Drawing.Size(15, 19);
            this.LblStatusQuickActions.TabIndex = 6;
            this.LblStatusQuickActions.Text = "-";
            // 
            // LblStatusHassApi
            // 
            this.LblStatusHassApi.AccessibleDescription = "Home Assistant status.";
            this.LblStatusHassApi.AccessibleName = "Home Assistant API status";
            this.LblStatusHassApi.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblStatusHassApi.AutoSize = true;
            this.LblStatusHassApi.Location = new System.Drawing.Point(164, 83);
            this.LblStatusHassApi.Name = "LblStatusHassApi";
            this.LblStatusHassApi.Size = new System.Drawing.Size(15, 19);
            this.LblStatusHassApi.TabIndex = 5;
            this.LblStatusHassApi.Text = "-";
            // 
            // LblStatusLocalApi
            // 
            this.LblStatusLocalApi.AccessibleDescription = "Local API status.";
            this.LblStatusLocalApi.AccessibleName = "Local API status";
            this.LblStatusLocalApi.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblStatusLocalApi.AutoSize = true;
            this.LblStatusLocalApi.Location = new System.Drawing.Point(164, 42);
            this.LblStatusLocalApi.Name = "LblStatusLocalApi";
            this.LblStatusLocalApi.Size = new System.Drawing.Size(15, 19);
            this.LblStatusLocalApi.TabIndex = 4;
            this.LblStatusLocalApi.Text = "-";
            // 
            // LblSensors
            // 
            this.LblSensors.AccessibleDescription = "Description of the sensors.";
            this.LblSensors.AccessibleName = "Sensors description";
            this.LblSensors.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblSensors.Location = new System.Drawing.Point(216, 83);
            this.LblSensors.Name = "LblSensors";
            this.LblSensors.Size = new System.Drawing.Size(176, 19);
            this.LblSensors.TabIndex = 3;
            this.LblSensors.Text = Languages.Main_LblSensors;
            this.LblSensors.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblQuickActions
            // 
            this.LblQuickActions.AccessibleDescription = "Description of the Quick Actions.";
            this.LblQuickActions.AccessibleName = "Quick Actions description";
            this.LblQuickActions.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblQuickActions.Location = new System.Drawing.Point(216, 42);
            this.LblQuickActions.Name = "LblQuickActions";
            this.LblQuickActions.Size = new System.Drawing.Size(176, 19);
            this.LblQuickActions.TabIndex = 2;
            this.LblQuickActions.Text = Languages.Main_LblQuickActions;
            this.LblQuickActions.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblHomeAssistantApi
            // 
            this.LblHomeAssistantApi.AccessibleDescription = "Description of the Home Assistant API";
            this.LblHomeAssistantApi.AccessibleName = "Home Assistant API description";
            this.LblHomeAssistantApi.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblHomeAssistantApi.Location = new System.Drawing.Point(6, 83);
            this.LblHomeAssistantApi.Name = "LblHomeAssistantApi";
            this.LblHomeAssistantApi.Size = new System.Drawing.Size(152, 19);
            this.LblHomeAssistantApi.TabIndex = 1;
            this.LblHomeAssistantApi.Text = Languages.Main_LblHomeAssistantApi;
            this.LblHomeAssistantApi.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblLocalApi
            // 
            this.LblLocalApi.AccessibleDescription = "Description of the local API.";
            this.LblLocalApi.AccessibleName = "Local API description";
            this.LblLocalApi.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblLocalApi.Location = new System.Drawing.Point(6, 42);
            this.LblLocalApi.Name = "LblLocalApi";
            this.LblLocalApi.Size = new System.Drawing.Size(152, 19);
            this.LblLocalApi.TabIndex = 0;
            this.LblLocalApi.Text = Languages.Main_LblLocalApi;
            this.LblLocalApi.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BtnCheckForUpdate
            // 
            this.BtnCheckForUpdate.AccessibleDescription = "Starts an update check.";
            this.BtnCheckForUpdate.AccessibleName = "Update check";
            this.BtnCheckForUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnCheckForUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCheckForUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCheckForUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCheckForUpdate.Location = new System.Drawing.Point(125, 445);
            this.BtnCheckForUpdate.Name = "BtnCheckForUpdate";
            this.BtnCheckForUpdate.Size = new System.Drawing.Size(169, 34);
            this.BtnCheckForUpdate.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCheckForUpdate.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCheckForUpdate.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCheckForUpdate.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCheckForUpdate.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCheckForUpdate.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCheckForUpdate.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnCheckForUpdate.TabIndex = 6;
            this.BtnCheckForUpdate.Text = Languages.Main_BtnCheckForUpdate;
            this.BtnCheckForUpdate.UseVisualStyleBackColor = false;
            this.BtnCheckForUpdate.Click += new System.EventHandler(this.BtnCheckForUpdate_Click);
            // 
            // BtnHelp
            // 
            this.BtnHelp.AccessibleDescription = "Opens the help and contact window.";
            this.BtnHelp.AccessibleName = "Help";
            this.BtnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHelp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHelp.Location = new System.Drawing.Point(85, 445);
            this.BtnHelp.Name = "BtnHelp";
            this.BtnHelp.Size = new System.Drawing.Size(33, 34);
            this.BtnHelp.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHelp.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHelp.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHelp.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHelp.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHelp.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHelp.Style.Image = global::HASS.Agent.Properties.Resources.question_24;
            this.BtnHelp.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnHelp.TabIndex = 7;
            this.BtnHelp.UseVisualStyleBackColor = false;
            this.BtnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // Main
            // 
            this.AccessibleDescription = "Main application window. Contains the status of the internal systems, and buttons" +
    " to open the various sections.";
            this.AccessibleName = "Main";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Application;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(598, 481);
            this.Controls.Add(this.BtnCheckForUpdate);
            this.Controls.Add(this.BtnHelp);
            this.Controls.Add(this.GpControls);
            this.Controls.Add(this.GpStatus);
            this.Controls.Add(this.BtnHide);
            this.Controls.Add(this.BtnExit);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.Name = "Main";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HASS.Agent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResizeEnd += new System.EventHandler(this.Main_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Main_KeyUp);
            this.CmTrayIcon.ResumeLayout(false);
            this.GpControls.ResumeLayout(false);
            this.GpStatus.ResumeLayout(false);
            this.GpStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private Syncfusion.WinForms.Controls.SfButton BtnExit;
        private Syncfusion.WinForms.Controls.SfButton BtnHide;
        private Syncfusion.WinForms.Controls.SfButton BtnAppSettings;
        private Syncfusion.WinForms.Controls.SfButton BtnActionsManager;
        private Syncfusion.WinForms.Controls.SfButton BtnSensorsManager;
        private Syncfusion.WinForms.Controls.SfButton BtnCommandsManager;
        private HASS.Agent.Controls.CustomGroupBox GpStatus;
        private HASS.Agent.Controls.CustomGroupBox GpControls;
        private System.Windows.Forms.Label LblSensors;
        private System.Windows.Forms.Label LblQuickActions;
        private System.Windows.Forms.Label LblHomeAssistantApi;
        private System.Windows.Forms.Label LblLocalApi;
        private System.Windows.Forms.Label LblStatusSensors;
        private System.Windows.Forms.Label LblStatusQuickActions;
        private System.Windows.Forms.Label LblStatusHassApi;
        private System.Windows.Forms.Label LblStatusLocalApi;
        private Syncfusion.Windows.Forms.Tools.ContextMenuStripEx CmTrayIcon;
        private System.Windows.Forms.ToolStripMenuItem TsShow;
        private System.Windows.Forms.ToolStripMenuItem TsShowQuickActions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem TsConfig;
        private System.Windows.Forms.ToolStripMenuItem TsQuickItemsConfig;
        private System.Windows.Forms.ToolStripMenuItem TsLocalSensors;
        private System.Windows.Forms.ToolStripMenuItem TsCommands;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem TsExit;
        private System.Windows.Forms.Label LblStatusCommands;
        private System.Windows.Forms.Label LblCommands;
        private System.Windows.Forms.Label LblStatusMqtt;
        private System.Windows.Forms.Label LblMqtt;
        private System.Windows.Forms.ToolStripMenuItem TsAbout;
        private Syncfusion.WinForms.Controls.SfButton BtnHelp;
        private Syncfusion.WinForms.Controls.SfButton BtnCheckForUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem TsCheckForUpdates;
        private System.Windows.Forms.ToolStripMenuItem TsHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem TsDonate;
        private Syncfusion.WinForms.Controls.SfButton BtnServiceManager;
        private Label LblStatusService;
        private Label LblService;
        private ToolStripMenuItem TsSatelliteService;
    }
}

