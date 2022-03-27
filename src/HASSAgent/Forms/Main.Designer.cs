namespace HASSAgent.Forms
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
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TsConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.TsQuickItemsConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.TsLocalSensors = new System.Windows.Forms.ToolStripMenuItem();
            this.TsCommands = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.TsCheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TsDonate = new System.Windows.Forms.ToolStripMenuItem();
            this.TsHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.TsAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.TsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExit = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnHide = new Syncfusion.WinForms.Controls.SfButton();
            this.GpControls = new HASSAgent.Controls.CustomGroupBox();
            this.BtnServiceManager = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnAppSettings = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnActionsManager = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnCommandsManager = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnSensorsManager = new Syncfusion.WinForms.Controls.SfButton();
            this.GpStatus = new HASSAgent.Controls.CustomGroupBox();
            this.LblStatusService = new System.Windows.Forms.Label();
            this.LblService = new System.Windows.Forms.Label();
            this.LblStatusMqtt = new System.Windows.Forms.Label();
            this.LblMqtt = new System.Windows.Forms.Label();
            this.LblStatusCommands = new System.Windows.Forms.Label();
            this.LblCommands = new System.Windows.Forms.Label();
            this.LblStatusSensors = new System.Windows.Forms.Label();
            this.LblStatusQuickActions = new System.Windows.Forms.Label();
            this.LblStatusHassApi = new System.Windows.Forms.Label();
            this.LblStatusNotificationApi = new System.Windows.Forms.Label();
            this.LblSensors = new System.Windows.Forms.Label();
            this.LblQuickActions = new System.Windows.Forms.Label();
            this.LblHomeAssistantApi = new System.Windows.Forms.Label();
            this.LblNotificationApi = new System.Windows.Forms.Label();
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
            // 
            // CmTrayIcon
            // 
            this.CmTrayIcon.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CmTrayIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsShow,
            this.TsShowQuickActions,
            this.toolStripSeparator2,
            this.TsConfig,
            this.TsQuickItemsConfig,
            this.TsLocalSensors,
            this.TsCommands,
            this.toolStripMenuItem1,
            this.TsCheckForUpdates,
            this.toolStripSeparator1,
            this.TsDonate,
            this.TsHelp,
            this.TsAbout,
            this.toolStripSeparator3,
            this.TsExit});
            this.CmTrayIcon.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(236)))), ((int)(((byte)(249)))));
            this.CmTrayIcon.Name = "CmTrayIcon";
            this.CmTrayIcon.Size = new System.Drawing.Size(195, 314);
            this.CmTrayIcon.Style = Syncfusion.Windows.Forms.Tools.ContextMenuStripEx.ContextMenuStyle.Default;
            this.CmTrayIcon.ThemeName = "Default";
            // 
            // TsShow
            // 
            this.TsShow.Image = global::HASSAgent.Properties.Resources.logo_32;
            this.TsShow.Name = "TsShow";
            this.TsShow.Size = new System.Drawing.Size(194, 26);
            this.TsShow.Text = "show hass.agent";
            this.TsShow.Click += new System.EventHandler(this.TsShow_Click);
            // 
            // TsShowQuickActions
            // 
            this.TsShowQuickActions.Image = global::HASSAgent.Properties.Resources.ti_remote_32;
            this.TsShowQuickActions.Name = "TsShowQuickActions";
            this.TsShowQuickActions.Size = new System.Drawing.Size(194, 26);
            this.TsShowQuickActions.Text = "show quick actions";
            this.TsShowQuickActions.Click += new System.EventHandler(this.TsShowQuickActions_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(191, 6);
            // 
            // TsConfig
            // 
            this.TsConfig.Image = global::HASSAgent.Properties.Resources.ti_gear_32;
            this.TsConfig.Name = "TsConfig";
            this.TsConfig.Size = new System.Drawing.Size(194, 26);
            this.TsConfig.Text = "configuration";
            this.TsConfig.Click += new System.EventHandler(this.TsConfig_Click);
            // 
            // TsQuickItemsConfig
            // 
            this.TsQuickItemsConfig.Image = global::HASSAgent.Properties.Resources.ti_remote_32;
            this.TsQuickItemsConfig.Name = "TsQuickItemsConfig";
            this.TsQuickItemsConfig.Size = new System.Drawing.Size(194, 26);
            this.TsQuickItemsConfig.Text = "manage quick actions";
            this.TsQuickItemsConfig.Click += new System.EventHandler(this.TsQuickItemsConfig_Click);
            // 
            // TsLocalSensors
            // 
            this.TsLocalSensors.Image = global::HASSAgent.Properties.Resources.ti_radar_32;
            this.TsLocalSensors.Name = "TsLocalSensors";
            this.TsLocalSensors.Size = new System.Drawing.Size(194, 26);
            this.TsLocalSensors.Text = "manage local sensors";
            this.TsLocalSensors.Click += new System.EventHandler(this.TsLocalSensors_Click);
            // 
            // TsCommands
            // 
            this.TsCommands.Image = global::HASSAgent.Properties.Resources.ti_workflow_32;
            this.TsCommands.Name = "TsCommands";
            this.TsCommands.Size = new System.Drawing.Size(194, 26);
            this.TsCommands.Text = "manage commands";
            this.TsCommands.Click += new System.EventHandler(this.TsCommands_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(191, 6);
            // 
            // TsCheckForUpdates
            // 
            this.TsCheckForUpdates.Image = global::HASSAgent.Properties.Resources.ti_update_32;
            this.TsCheckForUpdates.Name = "TsCheckForUpdates";
            this.TsCheckForUpdates.Size = new System.Drawing.Size(194, 26);
            this.TsCheckForUpdates.Text = "check for updates";
            this.TsCheckForUpdates.Click += new System.EventHandler(this.TsCheckForUpdates_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(191, 6);
            // 
            // TsDonate
            // 
            this.TsDonate.Image = global::HASSAgent.Properties.Resources.bmac_logo_32;
            this.TsDonate.Name = "TsDonate";
            this.TsDonate.Size = new System.Drawing.Size(194, 26);
            this.TsDonate.Text = "donate";
            this.TsDonate.Click += new System.EventHandler(this.TsDonate_Click);
            // 
            // TsHelp
            // 
            this.TsHelp.Image = global::HASSAgent.Properties.Resources.question_32;
            this.TsHelp.Name = "TsHelp";
            this.TsHelp.Size = new System.Drawing.Size(194, 26);
            this.TsHelp.Text = "help && contact";
            this.TsHelp.Click += new System.EventHandler(this.TsHelp_Click);
            // 
            // TsAbout
            // 
            this.TsAbout.Image = global::HASSAgent.Properties.Resources.question_32;
            this.TsAbout.Name = "TsAbout";
            this.TsAbout.Size = new System.Drawing.Size(194, 26);
            this.TsAbout.Text = "about";
            this.TsAbout.Click += new System.EventHandler(this.TsAbout_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(191, 6);
            // 
            // TsExit
            // 
            this.TsExit.Image = global::HASSAgent.Properties.Resources.ti_exit_32;
            this.TsExit.Name = "TsExit";
            this.TsExit.Size = new System.Drawing.Size(194, 26);
            this.TsExit.Text = "exit";
            this.TsExit.Click += new System.EventHandler(this.TsExit_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.AccessibleName = "Button";
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
            this.BtnExit.Style.Image = global::HASSAgent.Properties.Resources.exit_24;
            this.BtnExit.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnExit.TabIndex = 1;
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnHide
            // 
            this.BtnHide.AccessibleName = "Button";
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
            this.BtnHide.TabIndex = 0;
            this.BtnHide.Text = "hide";
            this.BtnHide.UseVisualStyleBackColor = false;
            this.BtnHide.Click += new System.EventHandler(this.BtnHide_Click);
            // 
            // GpControls
            // 
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
            this.GpControls.Text = "controls";
            // 
            // BtnServiceManager
            // 
            this.BtnServiceManager.AccessibleName = "Button";
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
            this.BtnServiceManager.Style.Image = global::HASSAgent.Properties.Resources.service_48;
            this.BtnServiceManager.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnServiceManager.TabIndex = 6;
            this.BtnServiceManager.Text = "\r\nsatellite service";
            this.BtnServiceManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnServiceManager.TextMargin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.BtnServiceManager.UseVisualStyleBackColor = false;
            this.BtnServiceManager.Click += new System.EventHandler(this.BtnServiceManager_Click);
            // 
            // BtnAppSettings
            // 
            this.BtnAppSettings.AccessibleName = "Button";
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
            this.BtnAppSettings.Style.Image = global::HASSAgent.Properties.Resources.gear_48;
            this.BtnAppSettings.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnAppSettings.TabIndex = 2;
            this.BtnAppSettings.Text = "\r\nconfiguration";
            this.BtnAppSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnAppSettings.UseVisualStyleBackColor = false;
            this.BtnAppSettings.Click += new System.EventHandler(this.BtnAppSettings_Click);
            // 
            // BtnActionsManager
            // 
            this.BtnActionsManager.AccessibleName = "Button";
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
            this.BtnActionsManager.Style.Image = global::HASSAgent.Properties.Resources.remote_48;
            this.BtnActionsManager.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnActionsManager.TabIndex = 3;
            this.BtnActionsManager.Text = "\r\nquick actions";
            this.BtnActionsManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnActionsManager.UseVisualStyleBackColor = false;
            this.BtnActionsManager.Click += new System.EventHandler(this.BtnActionsManager_Click);
            // 
            // BtnCommandsManager
            // 
            this.BtnCommandsManager.AccessibleName = "Button";
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
            this.BtnCommandsManager.Style.Image = global::HASSAgent.Properties.Resources.workflow_48;
            this.BtnCommandsManager.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnCommandsManager.TabIndex = 5;
            this.BtnCommandsManager.Text = "\r\nloading";
            this.BtnCommandsManager.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCommandsManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnCommandsManager.UseVisualStyleBackColor = false;
            this.BtnCommandsManager.Click += new System.EventHandler(this.BtnCommandsManager_Click);
            // 
            // BtnSensorsManager
            // 
            this.BtnSensorsManager.AccessibleName = "Button";
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
            this.BtnSensorsManager.Style.Image = global::HASSAgent.Properties.Resources.radar_48;
            this.BtnSensorsManager.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnSensorsManager.TabIndex = 4;
            this.BtnSensorsManager.Text = "\r\nloading";
            this.BtnSensorsManager.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSensorsManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnSensorsManager.UseVisualStyleBackColor = false;
            this.BtnSensorsManager.Click += new System.EventHandler(this.BtnSensorsManager_Click);
            // 
            // GpStatus
            // 
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
            this.GpStatus.Controls.Add(this.LblStatusNotificationApi);
            this.GpStatus.Controls.Add(this.LblSensors);
            this.GpStatus.Controls.Add(this.LblQuickActions);
            this.GpStatus.Controls.Add(this.LblHomeAssistantApi);
            this.GpStatus.Controls.Add(this.LblNotificationApi);
            this.GpStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GpStatus.Location = new System.Drawing.Point(13, 13);
            this.GpStatus.Name = "GpStatus";
            this.GpStatus.Size = new System.Drawing.Size(572, 214);
            this.GpStatus.TabIndex = 6;
            this.GpStatus.TabStop = false;
            this.GpStatus.Text = "system status";
            // 
            // LblStatusService
            // 
            this.LblStatusService.AutoSize = true;
            this.LblStatusService.Location = new System.Drawing.Point(164, 124);
            this.LblStatusService.Name = "LblStatusService";
            this.LblStatusService.Size = new System.Drawing.Size(15, 19);
            this.LblStatusService.TabIndex = 13;
            this.LblStatusService.Text = "-";
            // 
            // LblService
            // 
            this.LblService.AutoSize = true;
            this.LblService.Location = new System.Drawing.Point(55, 124);
            this.LblService.Name = "LblService";
            this.LblService.Size = new System.Drawing.Size(103, 19);
            this.LblService.TabIndex = 12;
            this.LblService.Text = "satellite service:";
            // 
            // LblStatusMqtt
            // 
            this.LblStatusMqtt.AutoSize = true;
            this.LblStatusMqtt.Location = new System.Drawing.Point(164, 165);
            this.LblStatusMqtt.Name = "LblStatusMqtt";
            this.LblStatusMqtt.Size = new System.Drawing.Size(15, 19);
            this.LblStatusMqtt.TabIndex = 11;
            this.LblStatusMqtt.Text = "-";
            // 
            // LblMqtt
            // 
            this.LblMqtt.AutoSize = true;
            this.LblMqtt.Location = new System.Drawing.Point(116, 165);
            this.LblMqtt.Name = "LblMqtt";
            this.LblMqtt.Size = new System.Drawing.Size(42, 19);
            this.LblMqtt.TabIndex = 10;
            this.LblMqtt.Text = "mqtt:";
            // 
            // LblStatusCommands
            // 
            this.LblStatusCommands.AutoSize = true;
            this.LblStatusCommands.Location = new System.Drawing.Point(398, 124);
            this.LblStatusCommands.Name = "LblStatusCommands";
            this.LblStatusCommands.Size = new System.Drawing.Size(15, 19);
            this.LblStatusCommands.TabIndex = 9;
            this.LblStatusCommands.Text = "-";
            // 
            // LblCommands
            // 
            this.LblCommands.AutoSize = true;
            this.LblCommands.Location = new System.Drawing.Point(313, 124);
            this.LblCommands.Name = "LblCommands";
            this.LblCommands.Size = new System.Drawing.Size(79, 19);
            this.LblCommands.TabIndex = 8;
            this.LblCommands.Text = "commands:";
            // 
            // LblStatusSensors
            // 
            this.LblStatusSensors.AutoSize = true;
            this.LblStatusSensors.Location = new System.Drawing.Point(398, 83);
            this.LblStatusSensors.Name = "LblStatusSensors";
            this.LblStatusSensors.Size = new System.Drawing.Size(15, 19);
            this.LblStatusSensors.TabIndex = 7;
            this.LblStatusSensors.Text = "-";
            // 
            // LblStatusQuickActions
            // 
            this.LblStatusQuickActions.AutoSize = true;
            this.LblStatusQuickActions.Location = new System.Drawing.Point(398, 42);
            this.LblStatusQuickActions.Name = "LblStatusQuickActions";
            this.LblStatusQuickActions.Size = new System.Drawing.Size(15, 19);
            this.LblStatusQuickActions.TabIndex = 6;
            this.LblStatusQuickActions.Text = "-";
            // 
            // LblStatusHassApi
            // 
            this.LblStatusHassApi.AutoSize = true;
            this.LblStatusHassApi.Location = new System.Drawing.Point(164, 83);
            this.LblStatusHassApi.Name = "LblStatusHassApi";
            this.LblStatusHassApi.Size = new System.Drawing.Size(15, 19);
            this.LblStatusHassApi.TabIndex = 5;
            this.LblStatusHassApi.Text = "-";
            // 
            // LblStatusNotificationApi
            // 
            this.LblStatusNotificationApi.AutoSize = true;
            this.LblStatusNotificationApi.Location = new System.Drawing.Point(164, 42);
            this.LblStatusNotificationApi.Name = "LblStatusNotificationApi";
            this.LblStatusNotificationApi.Size = new System.Drawing.Size(15, 19);
            this.LblStatusNotificationApi.TabIndex = 4;
            this.LblStatusNotificationApi.Text = "-";
            // 
            // LblSensors
            // 
            this.LblSensors.AutoSize = true;
            this.LblSensors.Location = new System.Drawing.Point(334, 83);
            this.LblSensors.Name = "LblSensors";
            this.LblSensors.Size = new System.Drawing.Size(58, 19);
            this.LblSensors.TabIndex = 3;
            this.LblSensors.Text = "sensors:";
            // 
            // LblQuickActions
            // 
            this.LblQuickActions.AutoSize = true;
            this.LblQuickActions.Location = new System.Drawing.Point(301, 42);
            this.LblQuickActions.Name = "LblQuickActions";
            this.LblQuickActions.Size = new System.Drawing.Size(91, 19);
            this.LblQuickActions.TabIndex = 2;
            this.LblQuickActions.Text = "quick actions:";
            // 
            // LblHomeAssistantApi
            // 
            this.LblHomeAssistantApi.AutoSize = true;
            this.LblHomeAssistantApi.Location = new System.Drawing.Point(32, 83);
            this.LblHomeAssistantApi.Name = "LblHomeAssistantApi";
            this.LblHomeAssistantApi.Size = new System.Drawing.Size(126, 19);
            this.LblHomeAssistantApi.TabIndex = 1;
            this.LblHomeAssistantApi.Text = "home assistant api:";
            // 
            // LblNotificationApi
            // 
            this.LblNotificationApi.AutoSize = true;
            this.LblNotificationApi.Location = new System.Drawing.Point(56, 42);
            this.LblNotificationApi.Name = "LblNotificationApi";
            this.LblNotificationApi.Size = new System.Drawing.Size(102, 19);
            this.LblNotificationApi.TabIndex = 0;
            this.LblNotificationApi.Text = "notification api:";
            // 
            // BtnCheckForUpdate
            // 
            this.BtnCheckForUpdate.AccessibleName = "Button";
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
            this.BtnCheckForUpdate.TabIndex = 9;
            this.BtnCheckForUpdate.Text = "check for updates";
            this.BtnCheckForUpdate.UseVisualStyleBackColor = false;
            this.BtnCheckForUpdate.Click += new System.EventHandler(this.BtnCheckForUpdate_Click);
            // 
            // BtnHelp
            // 
            this.BtnHelp.AccessibleName = "Button";
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
            this.BtnHelp.Style.Image = global::HASSAgent.Properties.Resources.question_24;
            this.BtnHelp.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnHelp.TabIndex = 8;
            this.BtnHelp.UseVisualStyleBackColor = false;
            this.BtnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // Main
            // 
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
        private HASSAgent.Controls.CustomGroupBox GpStatus;
        private HASSAgent.Controls.CustomGroupBox GpControls;
        private System.Windows.Forms.Label LblSensors;
        private System.Windows.Forms.Label LblQuickActions;
        private System.Windows.Forms.Label LblHomeAssistantApi;
        private System.Windows.Forms.Label LblNotificationApi;
        private System.Windows.Forms.Label LblStatusSensors;
        private System.Windows.Forms.Label LblStatusQuickActions;
        private System.Windows.Forms.Label LblStatusHassApi;
        private System.Windows.Forms.Label LblStatusNotificationApi;
        private Syncfusion.Windows.Forms.Tools.ContextMenuStripEx CmTrayIcon;
        private System.Windows.Forms.ToolStripMenuItem TsShow;
        private System.Windows.Forms.ToolStripMenuItem TsShowQuickActions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem TsConfig;
        private System.Windows.Forms.ToolStripMenuItem TsQuickItemsConfig;
        private System.Windows.Forms.ToolStripMenuItem TsLocalSensors;
        private System.Windows.Forms.ToolStripMenuItem TsCommands;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem TsExit;
        private System.Windows.Forms.Label LblStatusCommands;
        private System.Windows.Forms.Label LblCommands;
        private System.Windows.Forms.Label LblStatusMqtt;
        private System.Windows.Forms.Label LblMqtt;
        private System.Windows.Forms.ToolStripMenuItem TsAbout;
        private Syncfusion.WinForms.Controls.SfButton BtnHelp;
        private Syncfusion.WinForms.Controls.SfButton BtnCheckForUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TsCheckForUpdates;
        private System.Windows.Forms.ToolStripMenuItem TsHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem TsDonate;
        private Syncfusion.WinForms.Controls.SfButton BtnServiceManager;
        private Label LblStatusService;
        private Label LblService;
    }
}

