
using HASSAgent.Controls;
using HASSAgent.Functions;

namespace HASSAgent.Forms
{
    partial class Configuration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.BtnStore = new Syncfusion.WinForms.Controls.SfButton();
            this.customGroupBox1 = new CustomGroupBox.CustomGroupBox();
            this.TbQuickActionsHotkey = new System.Windows.Forms.TextBox();
            this.CbEnableQuickActionsHotkey = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.GpStartup = new CustomGroupBox.CustomGroupBox();
            this.BtnScheduledTaskReadme = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnCreateLaunchOnBootTask = new Syncfusion.WinForms.Controls.SfButton();
            this.LblLaunchOnBootActive = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GpConfig = new CustomGroupBox.CustomGroupBox();
            this.TbHassApiToken = new System.Windows.Forms.TextBox();
            this.TbHassIp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GpNotifications = new CustomGroupBox.CustomGroupBox();
            this.TbIntNotifierApiPort = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.BtnNotificationsReadme = new Syncfusion.WinForms.Controls.SfButton();
            this.label1 = new System.Windows.Forms.Label();
            this.CbAcceptNotifications = new System.Windows.Forms.CheckBox();
            this.customGroupBox2 = new CustomGroupBox.CustomGroupBox();
            this.TbIntMqttPort = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.TbMqttPassword = new System.Windows.Forms.TextBox();
            this.TbMqttUsername = new System.Windows.Forms.TextBox();
            this.TbMqttAddress = new System.Windows.Forms.TextBox();
            this.CbMqttTls = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnHelp = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnAbout = new Syncfusion.WinForms.Controls.SfButton();
            this.customGroupBox1.SuspendLayout();
            this.GpStartup.SuspendLayout();
            this.GpConfig.SuspendLayout();
            this.GpNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TbIntNotifierApiPort)).BeginInit();
            this.customGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TbIntMqttPort)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnStore
            // 
            this.BtnStore.AccessibleName = "Button";
            this.BtnStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnStore.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.BtnStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Location = new System.Drawing.Point(0, 653);
            this.BtnStore.Name = "BtnStore";
            this.BtnStore.Size = new System.Drawing.Size(674, 37);
            this.BtnStore.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStore.TabIndex = 0;
            this.BtnStore.Text = "store configuration";
            this.BtnStore.UseVisualStyleBackColor = false;
            this.BtnStore.Click += new System.EventHandler(this.BtnStore_Click);
            // 
            // customGroupBox1
            // 
            this.customGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.customGroupBox1.Controls.Add(this.TbQuickActionsHotkey);
            this.customGroupBox1.Controls.Add(this.CbEnableQuickActionsHotkey);
            this.customGroupBox1.Controls.Add(this.label5);
            this.customGroupBox1.Location = new System.Drawing.Point(284, 401);
            this.customGroupBox1.Name = "customGroupBox1";
            this.customGroupBox1.Size = new System.Drawing.Size(369, 111);
            this.customGroupBox1.TabIndex = 4;
            this.customGroupBox1.TabStop = false;
            this.customGroupBox1.Text = "quick actions hotkey config";
            // 
            // TbQuickActionsHotkey
            // 
            this.TbQuickActionsHotkey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbQuickActionsHotkey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbQuickActionsHotkey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbQuickActionsHotkey.Location = new System.Drawing.Point(174, 34);
            this.TbQuickActionsHotkey.Name = "TbQuickActionsHotkey";
            this.TbQuickActionsHotkey.Size = new System.Drawing.Size(161, 22);
            this.TbQuickActionsHotkey.TabIndex = 8;
            // 
            // CbEnableQuickActionsHotkey
            // 
            this.CbEnableQuickActionsHotkey.AutoSize = true;
            this.CbEnableQuickActionsHotkey.Location = new System.Drawing.Point(174, 76);
            this.CbEnableQuickActionsHotkey.Name = "CbEnableQuickActionsHotkey";
            this.CbEnableQuickActionsHotkey.Size = new System.Drawing.Size(170, 17);
            this.CbEnableQuickActionsHotkey.TabIndex = 7;
            this.CbEnableQuickActionsHotkey.Text = "enable quick actions hotkey";
            this.CbEnableQuickActionsHotkey.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "hotkey combination:";
            // 
            // GpStartup
            // 
            this.GpStartup.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.GpStartup.Controls.Add(this.BtnScheduledTaskReadme);
            this.GpStartup.Controls.Add(this.BtnCreateLaunchOnBootTask);
            this.GpStartup.Controls.Add(this.LblLaunchOnBootActive);
            this.GpStartup.Controls.Add(this.label4);
            this.GpStartup.Location = new System.Drawing.Point(284, 21);
            this.GpStartup.Name = "GpStartup";
            this.GpStartup.Size = new System.Drawing.Size(369, 191);
            this.GpStartup.TabIndex = 3;
            this.GpStartup.TabStop = false;
            this.GpStartup.Text = "startup config";
            // 
            // BtnScheduledTaskReadme
            // 
            this.BtnScheduledTaskReadme.AccessibleName = "Button";
            this.BtnScheduledTaskReadme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnScheduledTaskReadme.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.BtnScheduledTaskReadme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnScheduledTaskReadme.Location = new System.Drawing.Point(40, 106);
            this.BtnScheduledTaskReadme.Name = "BtnScheduledTaskReadme";
            this.BtnScheduledTaskReadme.Size = new System.Drawing.Size(295, 31);
            this.BtnScheduledTaskReadme.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnScheduledTaskReadme.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnScheduledTaskReadme.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnScheduledTaskReadme.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnScheduledTaskReadme.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnScheduledTaskReadme.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnScheduledTaskReadme.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnScheduledTaskReadme.TabIndex = 6;
            this.BtnScheduledTaskReadme.Text = "scheduled task readme";
            this.BtnScheduledTaskReadme.UseVisualStyleBackColor = false;
            this.BtnScheduledTaskReadme.Click += new System.EventHandler(this.BtnScheduledTaskReadme_Click);
            // 
            // BtnCreateLaunchOnBootTask
            // 
            this.BtnCreateLaunchOnBootTask.AccessibleName = "Button";
            this.BtnCreateLaunchOnBootTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCreateLaunchOnBootTask.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.BtnCreateLaunchOnBootTask.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCreateLaunchOnBootTask.Location = new System.Drawing.Point(40, 143);
            this.BtnCreateLaunchOnBootTask.Name = "BtnCreateLaunchOnBootTask";
            this.BtnCreateLaunchOnBootTask.Size = new System.Drawing.Size(295, 31);
            this.BtnCreateLaunchOnBootTask.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCreateLaunchOnBootTask.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCreateLaunchOnBootTask.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCreateLaunchOnBootTask.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCreateLaunchOnBootTask.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCreateLaunchOnBootTask.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCreateLaunchOnBootTask.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnCreateLaunchOnBootTask.TabIndex = 5;
            this.BtnCreateLaunchOnBootTask.Text = "create launch-on-login scheduled task";
            this.BtnCreateLaunchOnBootTask.UseVisualStyleBackColor = false;
            this.BtnCreateLaunchOnBootTask.Click += new System.EventHandler(this.BtnCreateLaunchOnBootTask_Click);
            // 
            // LblLaunchOnBootActive
            // 
            this.LblLaunchOnBootActive.AutoSize = true;
            this.LblLaunchOnBootActive.Location = new System.Drawing.Point(208, 53);
            this.LblLaunchOnBootActive.Name = "LblLaunchOnBootActive";
            this.LblLaunchOnBootActive.Size = new System.Drawing.Size(11, 13);
            this.LblLaunchOnBootActive.TabIndex = 3;
            this.LblLaunchOnBootActive.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "launch-on-login task status:";
            // 
            // GpConfig
            // 
            this.GpConfig.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.GpConfig.Controls.Add(this.TbHassApiToken);
            this.GpConfig.Controls.Add(this.TbHassIp);
            this.GpConfig.Controls.Add(this.label3);
            this.GpConfig.Controls.Add(this.label2);
            this.GpConfig.Location = new System.Drawing.Point(24, 233);
            this.GpConfig.Name = "GpConfig";
            this.GpConfig.Size = new System.Drawing.Size(629, 140);
            this.GpConfig.TabIndex = 2;
            this.GpConfig.TabStop = false;
            this.GpConfig.Text = "hass api config";
            // 
            // TbHassApiToken
            // 
            this.TbHassApiToken.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbHassApiToken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbHassApiToken.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbHassApiToken.Location = new System.Drawing.Point(111, 87);
            this.TbHassApiToken.Name = "TbHassApiToken";
            this.TbHassApiToken.Size = new System.Drawing.Size(484, 22);
            this.TbHassApiToken.TabIndex = 8;
            // 
            // TbHassIp
            // 
            this.TbHassIp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbHassIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbHassIp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbHassIp.Location = new System.Drawing.Point(111, 41);
            this.TbHassIp.Name = "TbHassIp";
            this.TbHassIp.Size = new System.Drawing.Size(484, 22);
            this.TbHassIp.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "api token:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "server uri:";
            // 
            // GpNotifications
            // 
            this.GpNotifications.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.GpNotifications.Controls.Add(this.TbIntNotifierApiPort);
            this.GpNotifications.Controls.Add(this.BtnNotificationsReadme);
            this.GpNotifications.Controls.Add(this.label1);
            this.GpNotifications.Controls.Add(this.CbAcceptNotifications);
            this.GpNotifications.Location = new System.Drawing.Point(24, 21);
            this.GpNotifications.Name = "GpNotifications";
            this.GpNotifications.Size = new System.Drawing.Size(232, 191);
            this.GpNotifications.TabIndex = 1;
            this.GpNotifications.TabStop = false;
            this.GpNotifications.Text = "hass notifications";
            // 
            // TbIntNotifierApiPort
            // 
            this.TbIntNotifierApiPort.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbIntNotifierApiPort.BeforeTouchSize = new System.Drawing.Size(92, 22);
            this.TbIntNotifierApiPort.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntNotifierApiPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbIntNotifierApiPort.CurrentCultureRefresh = true;
            this.TbIntNotifierApiPort.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntNotifierApiPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntNotifierApiPort.IntegerValue = ((long)(1883));
            this.TbIntNotifierApiPort.Location = new System.Drawing.Point(67, 83);
            this.TbIntNotifierApiPort.MaxValue = ((long)(66000));
            this.TbIntNotifierApiPort.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntNotifierApiPort.MinValue = ((long)(1));
            this.TbIntNotifierApiPort.Name = "TbIntNotifierApiPort";
            this.TbIntNotifierApiPort.PositiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntNotifierApiPort.Size = new System.Drawing.Size(92, 22);
            this.TbIntNotifierApiPort.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.UICulture;
            this.TbIntNotifierApiPort.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.TbIntNotifierApiPort.TabIndex = 18;
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
            // BtnNotificationsReadme
            // 
            this.BtnNotificationsReadme.AccessibleName = "Button";
            this.BtnNotificationsReadme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnNotificationsReadme.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.BtnNotificationsReadme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnNotificationsReadme.Location = new System.Drawing.Point(21, 143);
            this.BtnNotificationsReadme.Name = "BtnNotificationsReadme";
            this.BtnNotificationsReadme.Size = new System.Drawing.Size(191, 31);
            this.BtnNotificationsReadme.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnNotificationsReadme.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnNotificationsReadme.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnNotificationsReadme.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnNotificationsReadme.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnNotificationsReadme.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnNotificationsReadme.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnNotificationsReadme.TabIndex = 3;
            this.BtnNotificationsReadme.Text = "notifications readme";
            this.BtnNotificationsReadme.UseVisualStyleBackColor = false;
            this.BtnNotificationsReadme.Click += new System.EventHandler(this.BtnNotificationsReadme_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "port:";
            // 
            // CbAcceptNotifications
            // 
            this.CbAcceptNotifications.AutoSize = true;
            this.CbAcceptNotifications.Location = new System.Drawing.Point(32, 39);
            this.CbAcceptNotifications.Name = "CbAcceptNotifications";
            this.CbAcceptNotifications.Size = new System.Drawing.Size(127, 17);
            this.CbAcceptNotifications.TabIndex = 0;
            this.CbAcceptNotifications.Text = "accept notifications";
            this.CbAcceptNotifications.UseVisualStyleBackColor = true;
            // 
            // customGroupBox2
            // 
            this.customGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.customGroupBox2.Controls.Add(this.TbIntMqttPort);
            this.customGroupBox2.Controls.Add(this.TbMqttPassword);
            this.customGroupBox2.Controls.Add(this.TbMqttUsername);
            this.customGroupBox2.Controls.Add(this.TbMqttAddress);
            this.customGroupBox2.Controls.Add(this.CbMqttTls);
            this.customGroupBox2.Controls.Add(this.label9);
            this.customGroupBox2.Controls.Add(this.label8);
            this.customGroupBox2.Controls.Add(this.label7);
            this.customGroupBox2.Controls.Add(this.label6);
            this.customGroupBox2.Location = new System.Drawing.Point(24, 401);
            this.customGroupBox2.Name = "customGroupBox2";
            this.customGroupBox2.Size = new System.Drawing.Size(232, 235);
            this.customGroupBox2.TabIndex = 5;
            this.customGroupBox2.TabStop = false;
            this.customGroupBox2.Text = "mqtt config";
            // 
            // TbIntMqttPort
            // 
            this.TbIntMqttPort.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbIntMqttPort.BeforeTouchSize = new System.Drawing.Size(92, 22);
            this.TbIntMqttPort.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntMqttPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbIntMqttPort.CurrentCultureRefresh = true;
            this.TbIntMqttPort.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntMqttPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntMqttPort.IntegerValue = ((long)(1883));
            this.TbIntMqttPort.Location = new System.Drawing.Point(54, 88);
            this.TbIntMqttPort.MaxValue = ((long)(66000));
            this.TbIntMqttPort.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntMqttPort.MinValue = ((long)(1));
            this.TbIntMqttPort.Name = "TbIntMqttPort";
            this.TbIntMqttPort.PositiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntMqttPort.Size = new System.Drawing.Size(92, 22);
            this.TbIntMqttPort.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.UICulture;
            this.TbIntMqttPort.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.TbIntMqttPort.TabIndex = 17;
            this.TbIntMqttPort.Text = "1,883";
            this.TbIntMqttPort.ThemeName = "Metro";
            this.TbIntMqttPort.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbIntMqttPort.ThemeStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntMqttPort.ThemeStyle.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntMqttPort.ThemeStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntMqttPort.ThemeStyle.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntMqttPort.ThemeStyle.ZeroForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntMqttPort.ZeroColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            // 
            // TbMqttPassword
            // 
            this.TbMqttPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttPassword.Location = new System.Drawing.Point(19, 191);
            this.TbMqttPassword.Name = "TbMqttPassword";
            this.TbMqttPassword.Size = new System.Drawing.Size(191, 22);
            this.TbMqttPassword.TabIndex = 16;
            this.TbMqttPassword.UseSystemPasswordChar = true;
            // 
            // TbMqttUsername
            // 
            this.TbMqttUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttUsername.Location = new System.Drawing.Point(21, 144);
            this.TbMqttUsername.Name = "TbMqttUsername";
            this.TbMqttUsername.Size = new System.Drawing.Size(191, 22);
            this.TbMqttUsername.TabIndex = 15;
            // 
            // TbMqttAddress
            // 
            this.TbMqttAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttAddress.Location = new System.Drawing.Point(21, 46);
            this.TbMqttAddress.Name = "TbMqttAddress";
            this.TbMqttAddress.Size = new System.Drawing.Size(191, 22);
            this.TbMqttAddress.TabIndex = 14;
            // 
            // CbMqttTls
            // 
            this.CbMqttTls.AutoSize = true;
            this.CbMqttTls.Location = new System.Drawing.Point(169, 93);
            this.CbMqttTls.Name = "CbMqttTls";
            this.CbMqttTls.Size = new System.Drawing.Size(43, 17);
            this.CbMqttTls.TabIndex = 13;
            this.CbMqttTls.Text = "TLS";
            this.CbMqttTls.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "password";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "username";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "port:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "ip address or hostname";
            // 
            // BtnHelp
            // 
            this.BtnHelp.AccessibleName = "Button";
            this.BtnHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHelp.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.BtnHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHelp.Location = new System.Drawing.Point(481, 605);
            this.BtnHelp.Name = "BtnHelp";
            this.BtnHelp.Size = new System.Drawing.Size(172, 31);
            this.BtnHelp.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHelp.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHelp.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHelp.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHelp.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnHelp.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnHelp.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnHelp.TabIndex = 6;
            this.BtnHelp.Text = "help && documentation";
            this.BtnHelp.UseVisualStyleBackColor = false;
            this.BtnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // BtnAbout
            // 
            this.BtnAbout.AccessibleName = "Button";
            this.BtnAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAbout.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.BtnAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAbout.Location = new System.Drawing.Point(284, 605);
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(172, 31);
            this.BtnAbout.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAbout.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAbout.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAbout.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAbout.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAbout.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAbout.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnAbout.TabIndex = 7;
            this.BtnAbout.Text = "about";
            this.BtnAbout.UseVisualStyleBackColor = false;
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(674, 690);
            this.Controls.Add(this.BtnAbout);
            this.Controls.Add(this.BtnHelp);
            this.Controls.Add(this.customGroupBox2);
            this.Controls.Add(this.customGroupBox1);
            this.Controls.Add(this.GpStartup);
            this.Controls.Add(this.GpConfig);
            this.Controls.Add(this.GpNotifications);
            this.Controls.Add(this.BtnStore);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(131)))));
            this.Name = "Configuration";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Configuration_FormClosing);
            this.Load += new System.EventHandler(this.AppSettings_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Configuration_KeyUp);
            this.customGroupBox1.ResumeLayout(false);
            this.customGroupBox1.PerformLayout();
            this.GpStartup.ResumeLayout(false);
            this.GpStartup.PerformLayout();
            this.GpConfig.ResumeLayout(false);
            this.GpConfig.PerformLayout();
            this.GpNotifications.ResumeLayout(false);
            this.GpNotifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TbIntNotifierApiPort)).EndInit();
            this.customGroupBox2.ResumeLayout(false);
            this.customGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TbIntMqttPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Syncfusion.WinForms.Controls.SfButton BtnStore;
        private CustomGroupBox.CustomGroupBox GpNotifications;
        private System.Windows.Forms.CheckBox CbAcceptNotifications;
        private System.Windows.Forms.Label label1;
        private CustomGroupBox.CustomGroupBox GpConfig;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Syncfusion.WinForms.Controls.SfButton BtnNotificationsReadme;
        private CustomGroupBox.CustomGroupBox GpStartup;
        private System.Windows.Forms.Label LblLaunchOnBootActive;
        private System.Windows.Forms.Label label4;
        private Syncfusion.WinForms.Controls.SfButton BtnCreateLaunchOnBootTask;
        private Syncfusion.WinForms.Controls.SfButton BtnScheduledTaskReadme;
        private CustomGroupBox.CustomGroupBox customGroupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox CbEnableQuickActionsHotkey;
        private CustomGroupBox.CustomGroupBox customGroupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox CbMqttTls;
        private System.Windows.Forms.TextBox TbHassIp;
        private System.Windows.Forms.TextBox TbQuickActionsHotkey;
        private System.Windows.Forms.TextBox TbHassApiToken;
        private System.Windows.Forms.TextBox TbMqttPassword;
        private System.Windows.Forms.TextBox TbMqttUsername;
        private System.Windows.Forms.TextBox TbMqttAddress;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox TbIntMqttPort;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox TbIntNotifierApiPort;
        private Syncfusion.WinForms.Controls.SfButton BtnHelp;
        private Syncfusion.WinForms.Controls.SfButton BtnAbout;
    }
}

