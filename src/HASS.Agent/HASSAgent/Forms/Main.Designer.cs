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
            this.TsAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.TsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExit = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnHide = new Syncfusion.WinForms.Controls.SfButton();
            this.GpControls = new CustomGroupBox.CustomGroupBox();
            this.BtnAppSettings = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnActionsManager = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnCommandsManager = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnSensorsManager = new Syncfusion.WinForms.Controls.SfButton();
            this.GpStatus = new CustomGroupBox.CustomGroupBox();
            this.LblStatusMqtt = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LblStatusCommands = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblStatusSensors = new System.Windows.Forms.Label();
            this.LblStatusQuickActions = new System.Windows.Forms.Label();
            this.LblStatusHassApi = new System.Windows.Forms.Label();
            this.LblStatusNotificationApi = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCheckForUpdate = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnAbout = new Syncfusion.WinForms.Controls.SfButton();
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
            this.TsAbout,
            this.TsExit});
            this.CmTrayIcon.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(236)))), ((int)(((byte)(249)))));
            this.CmTrayIcon.Name = "CmTrayIcon";
            this.CmTrayIcon.Size = new System.Drawing.Size(192, 220);
            this.CmTrayIcon.Style = Syncfusion.Windows.Forms.Tools.ContextMenuStripEx.ContextMenuStyle.Default;
            this.CmTrayIcon.ThemeName = "Default";
            // 
            // TsShow
            // 
            this.TsShow.Image = global::HASSAgent.Properties.Resources.logo_32;
            this.TsShow.Name = "TsShow";
            this.TsShow.Size = new System.Drawing.Size(191, 22);
            this.TsShow.Text = "show hass.agent";
            this.TsShow.Click += new System.EventHandler(this.TsShow_Click);
            // 
            // TsShowQuickActions
            // 
            this.TsShowQuickActions.Image = global::HASSAgent.Properties.Resources.ti_remote_32;
            this.TsShowQuickActions.Name = "TsShowQuickActions";
            this.TsShowQuickActions.Size = new System.Drawing.Size(191, 22);
            this.TsShowQuickActions.Text = "show quick actions";
            this.TsShowQuickActions.Click += new System.EventHandler(this.TsShowQuickActions_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(188, 6);
            // 
            // TsConfig
            // 
            this.TsConfig.Image = global::HASSAgent.Properties.Resources.ti_gear_32;
            this.TsConfig.Name = "TsConfig";
            this.TsConfig.Size = new System.Drawing.Size(191, 22);
            this.TsConfig.Text = "configuration";
            this.TsConfig.Click += new System.EventHandler(this.TsConfig_Click);
            // 
            // TsQuickItemsConfig
            // 
            this.TsQuickItemsConfig.Image = global::HASSAgent.Properties.Resources.ti_remote_32;
            this.TsQuickItemsConfig.Name = "TsQuickItemsConfig";
            this.TsQuickItemsConfig.Size = new System.Drawing.Size(191, 22);
            this.TsQuickItemsConfig.Text = "manage quick actions";
            this.TsQuickItemsConfig.Click += new System.EventHandler(this.TsQuickItemsConfig_Click);
            // 
            // TsLocalSensors
            // 
            this.TsLocalSensors.Image = global::HASSAgent.Properties.Resources.ti_radar_32;
            this.TsLocalSensors.Name = "TsLocalSensors";
            this.TsLocalSensors.Size = new System.Drawing.Size(191, 22);
            this.TsLocalSensors.Text = "manage local sensors";
            this.TsLocalSensors.Click += new System.EventHandler(this.TsLocalSensors_Click);
            // 
            // TsCommands
            // 
            this.TsCommands.Image = global::HASSAgent.Properties.Resources.ti_workflow_32;
            this.TsCommands.Name = "TsCommands";
            this.TsCommands.Size = new System.Drawing.Size(191, 22);
            this.TsCommands.Text = "manage commands";
            this.TsCommands.Click += new System.EventHandler(this.TsCommands_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(188, 6);
            // 
            // TsCheckForUpdates
            // 
            this.TsCheckForUpdates.Image = global::HASSAgent.Properties.Resources.ti_update_32;
            this.TsCheckForUpdates.Name = "TsCheckForUpdates";
            this.TsCheckForUpdates.Size = new System.Drawing.Size(191, 22);
            this.TsCheckForUpdates.Text = "check for updates";
            this.TsCheckForUpdates.Click += new System.EventHandler(this.TsCheckForUpdates_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // TsAbout
            // 
            this.TsAbout.Image = global::HASSAgent.Properties.Resources.question_32;
            this.TsAbout.Name = "TsAbout";
            this.TsAbout.Size = new System.Drawing.Size(191, 22);
            this.TsAbout.Text = "about";
            this.TsAbout.Click += new System.EventHandler(this.TsAbout_Click);
            // 
            // TsExit
            // 
            this.TsExit.Image = global::HASSAgent.Properties.Resources.ti_exit_32;
            this.TsExit.Name = "TsExit";
            this.TsExit.Size = new System.Drawing.Size(191, 22);
            this.TsExit.Text = "exit";
            this.TsExit.Click += new System.EventHandler(this.TsExit_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.AccessibleName = "Button";
            this.BtnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExit.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.BtnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExit.Location = new System.Drawing.Point(12, 383);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(59, 31);
            this.BtnExit.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExit.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExit.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExit.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExit.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExit.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExit.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnExit.TabIndex = 1;
            this.BtnExit.Text = "exit";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnHide
            // 
            this.BtnHide.AccessibleName = "Button";
            this.BtnHide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHide.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.BtnHide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHide.Location = new System.Drawing.Point(239, 383);
            this.BtnHide.Name = "BtnHide";
            this.BtnHide.Size = new System.Drawing.Size(222, 31);
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
            this.GpControls.Controls.Add(this.BtnAppSettings);
            this.GpControls.Controls.Add(this.BtnActionsManager);
            this.GpControls.Controls.Add(this.BtnCommandsManager);
            this.GpControls.Controls.Add(this.BtnSensorsManager);
            this.GpControls.Location = new System.Drawing.Point(12, 201);
            this.GpControls.Name = "GpControls";
            this.GpControls.Size = new System.Drawing.Size(449, 165);
            this.GpControls.TabIndex = 7;
            this.GpControls.TabStop = false;
            this.GpControls.Text = "controls";
            // 
            // BtnAppSettings
            // 
            this.BtnAppSettings.AccessibleName = "Button";
            this.BtnAppSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAppSettings.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.BtnAppSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAppSettings.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAppSettings.ImageSize = new System.Drawing.Size(48, 48);
            this.BtnAppSettings.Location = new System.Drawing.Point(18, 21);
            this.BtnAppSettings.Name = "BtnAppSettings";
            this.BtnAppSettings.Size = new System.Drawing.Size(95, 130);
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
            this.BtnActionsManager.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.BtnActionsManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnActionsManager.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnActionsManager.ImageSize = new System.Drawing.Size(48, 48);
            this.BtnActionsManager.Location = new System.Drawing.Point(123, 21);
            this.BtnActionsManager.Name = "BtnActionsManager";
            this.BtnActionsManager.Size = new System.Drawing.Size(95, 130);
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
            this.BtnCommandsManager.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.BtnCommandsManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCommandsManager.ImageSize = new System.Drawing.Size(48, 48);
            this.BtnCommandsManager.Location = new System.Drawing.Point(333, 21);
            this.BtnCommandsManager.Name = "BtnCommandsManager";
            this.BtnCommandsManager.Size = new System.Drawing.Size(95, 130);
            this.BtnCommandsManager.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCommandsManager.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCommandsManager.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCommandsManager.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCommandsManager.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCommandsManager.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCommandsManager.Style.Image = global::HASSAgent.Properties.Resources.workflow_48;
            this.BtnCommandsManager.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnCommandsManager.TabIndex = 5;
            this.BtnCommandsManager.Text = "\r\ncommands";
            this.BtnCommandsManager.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCommandsManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnCommandsManager.UseVisualStyleBackColor = false;
            this.BtnCommandsManager.Click += new System.EventHandler(this.BtnCommandsManager_Click);
            // 
            // BtnSensorsManager
            // 
            this.BtnSensorsManager.AccessibleName = "Button";
            this.BtnSensorsManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSensorsManager.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.BtnSensorsManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSensorsManager.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSensorsManager.ImageSize = new System.Drawing.Size(48, 48);
            this.BtnSensorsManager.Location = new System.Drawing.Point(228, 21);
            this.BtnSensorsManager.Name = "BtnSensorsManager";
            this.BtnSensorsManager.Size = new System.Drawing.Size(95, 130);
            this.BtnSensorsManager.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSensorsManager.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSensorsManager.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSensorsManager.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSensorsManager.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSensorsManager.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSensorsManager.Style.Image = global::HASSAgent.Properties.Resources.radar_48;
            this.BtnSensorsManager.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnSensorsManager.TabIndex = 4;
            this.BtnSensorsManager.Text = "\r\nlocal sensors";
            this.BtnSensorsManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnSensorsManager.UseVisualStyleBackColor = false;
            this.BtnSensorsManager.Click += new System.EventHandler(this.BtnSensorsManager_Click);
            // 
            // GpStatus
            // 
            this.GpStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.GpStatus.Controls.Add(this.LblStatusMqtt);
            this.GpStatus.Controls.Add(this.label7);
            this.GpStatus.Controls.Add(this.LblStatusCommands);
            this.GpStatus.Controls.Add(this.label6);
            this.GpStatus.Controls.Add(this.LblStatusSensors);
            this.GpStatus.Controls.Add(this.LblStatusQuickActions);
            this.GpStatus.Controls.Add(this.LblStatusHassApi);
            this.GpStatus.Controls.Add(this.LblStatusNotificationApi);
            this.GpStatus.Controls.Add(this.label3);
            this.GpStatus.Controls.Add(this.label4);
            this.GpStatus.Controls.Add(this.label2);
            this.GpStatus.Controls.Add(this.label1);
            this.GpStatus.Location = new System.Drawing.Point(12, 12);
            this.GpStatus.Name = "GpStatus";
            this.GpStatus.Size = new System.Drawing.Size(449, 170);
            this.GpStatus.TabIndex = 6;
            this.GpStatus.TabStop = false;
            this.GpStatus.Text = "system status";
            // 
            // LblStatusMqtt
            // 
            this.LblStatusMqtt.AutoSize = true;
            this.LblStatusMqtt.Location = new System.Drawing.Point(134, 124);
            this.LblStatusMqtt.Name = "LblStatusMqtt";
            this.LblStatusMqtt.Size = new System.Drawing.Size(11, 13);
            this.LblStatusMqtt.TabIndex = 11;
            this.LblStatusMqtt.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(94, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "mqtt:";
            // 
            // LblStatusCommands
            // 
            this.LblStatusCommands.AutoSize = true;
            this.LblStatusCommands.Location = new System.Drawing.Point(346, 124);
            this.LblStatusCommands.Name = "LblStatusCommands";
            this.LblStatusCommands.Size = new System.Drawing.Size(11, 13);
            this.LblStatusCommands.TabIndex = 9;
            this.LblStatusCommands.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(275, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "commands:";
            // 
            // LblStatusSensors
            // 
            this.LblStatusSensors.AutoSize = true;
            this.LblStatusSensors.Location = new System.Drawing.Point(346, 87);
            this.LblStatusSensors.Name = "LblStatusSensors";
            this.LblStatusSensors.Size = new System.Drawing.Size(11, 13);
            this.LblStatusSensors.TabIndex = 7;
            this.LblStatusSensors.Text = "-";
            // 
            // LblStatusQuickActions
            // 
            this.LblStatusQuickActions.AutoSize = true;
            this.LblStatusQuickActions.Location = new System.Drawing.Point(346, 50);
            this.LblStatusQuickActions.Name = "LblStatusQuickActions";
            this.LblStatusQuickActions.Size = new System.Drawing.Size(11, 13);
            this.LblStatusQuickActions.TabIndex = 6;
            this.LblStatusQuickActions.Text = "-";
            // 
            // LblStatusHassApi
            // 
            this.LblStatusHassApi.AutoSize = true;
            this.LblStatusHassApi.Location = new System.Drawing.Point(134, 87);
            this.LblStatusHassApi.Name = "LblStatusHassApi";
            this.LblStatusHassApi.Size = new System.Drawing.Size(11, 13);
            this.LblStatusHassApi.TabIndex = 5;
            this.LblStatusHassApi.Text = "-";
            // 
            // LblStatusNotificationApi
            // 
            this.LblStatusNotificationApi.AutoSize = true;
            this.LblStatusNotificationApi.Location = new System.Drawing.Point(134, 50);
            this.LblStatusNotificationApi.Name = "LblStatusNotificationApi";
            this.LblStatusNotificationApi.Size = new System.Drawing.Size(11, 13);
            this.LblStatusNotificationApi.TabIndex = 4;
            this.LblStatusNotificationApi.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "sensors:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "quick actions:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "home assistant api:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "notification api:";
            // 
            // BtnCheckForUpdate
            // 
            this.BtnCheckForUpdate.AccessibleName = "Button";
            this.BtnCheckForUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCheckForUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.BtnCheckForUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCheckForUpdate.Location = new System.Drawing.Point(113, 383);
            this.BtnCheckForUpdate.Name = "BtnCheckForUpdate";
            this.BtnCheckForUpdate.Size = new System.Drawing.Size(120, 31);
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
            // BtnAbout
            // 
            this.BtnAbout.AccessibleName = "Button";
            this.BtnAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAbout.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.BtnAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAbout.Location = new System.Drawing.Point(77, 383);
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(30, 31);
            this.BtnAbout.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAbout.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAbout.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAbout.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAbout.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAbout.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAbout.Style.Image = global::HASSAgent.Properties.Resources.question_24;
            this.BtnAbout.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnAbout.TabIndex = 8;
            this.BtnAbout.UseVisualStyleBackColor = false;
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(473, 421);
            this.Controls.Add(this.BtnCheckForUpdate);
            this.Controls.Add(this.BtnAbout);
            this.Controls.Add(this.GpControls);
            this.Controls.Add(this.GpStatus);
            this.Controls.Add(this.BtnHide);
            this.Controls.Add(this.BtnExit);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(131)))));
            this.Name = "Main";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HASS.Agent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
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
        private CustomGroupBox.CustomGroupBox GpStatus;
        private CustomGroupBox.CustomGroupBox GpControls;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblStatusMqtt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem TsAbout;
        private Syncfusion.WinForms.Controls.SfButton BtnAbout;
        private Syncfusion.WinForms.Controls.SfButton BtnCheckForUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TsCheckForUpdates;
    }
}

