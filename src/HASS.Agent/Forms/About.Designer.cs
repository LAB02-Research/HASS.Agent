
using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Forms
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.BtnClose = new Syncfusion.WinForms.Controls.SfButton();
            this.LblHassAgentProject = new System.Windows.Forms.Label();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.LblInfo3 = new System.Windows.Forms.Label();
            this.LblCoreAudio = new System.Windows.Forms.Label();
            this.LblGrapevine = new System.Windows.Forms.Label();
            this.LblHADotNet = new System.Windows.Forms.Label();
            this.LblMicrosoftToolkitUwpNotifications = new System.Windows.Forms.Label();
            this.LblLibreHardwareMonitor = new System.Windows.Forms.Label();
            this.LblHotkeyListener = new System.Windows.Forms.Label();
            this.LblSerilog = new System.Windows.Forms.Label();
            this.LblNewtonsoftJson = new System.Windows.Forms.Label();
            this.LblMQTTnet = new System.Windows.Forms.Label();
            this.LblSyncfusion = new System.Windows.Forms.Label();
            this.LblInfo4 = new System.Windows.Forms.Label();
            this.LblInfo5 = new System.Windows.Forms.Label();
            this.LblInfo2 = new System.Windows.Forms.Label();
            this.LblLab02Research = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.LblOctokit = new System.Windows.Forms.Label();
            this.LblCliWrap = new System.Windows.Forms.Label();
            this.LblInfo6 = new System.Windows.Forms.Label();
            this.PbHassLogo = new System.Windows.Forms.PictureBox();
            this.PbHassAgentLogo = new System.Windows.Forms.PictureBox();
            this.LblCassia = new System.Windows.Forms.Label();
            this.LblGrpcDotNetNamedPipes = new System.Windows.Forms.Label();
            this.LblGrpc = new System.Windows.Forms.Label();
            this.LblByteSize = new System.Windows.Forms.Label();
            this.PbPayPal = new System.Windows.Forms.PictureBox();
            this.PbKoFi = new System.Windows.Forms.PictureBox();
            this.PbGithubSponsor = new System.Windows.Forms.PictureBox();
            this.PbBMAC = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbPayPal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbKoFi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbGithubSponsor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBMAC)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.AccessibleDescription = "Closes the window.";
            this.BtnClose.AccessibleName = "Close";
            this.BtnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClose.Location = new System.Drawing.Point(0, 666);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(747, 37);
            this.BtnClose.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClose.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClose.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClose.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClose.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClose.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClose.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnClose.TabIndex = 0;
            this.BtnClose.Text = Languages.About_BtnClose;
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // LblHassAgentProject
            // 
            this.LblHassAgentProject.AccessibleDescription = "Application name.";
            this.LblHassAgentProject.AccessibleName = "Name";
            this.LblHassAgentProject.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblHassAgentProject.AutoSize = true;
            this.LblHassAgentProject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblHassAgentProject.Font = new System.Drawing.Font("Segoe UI Semibold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblHassAgentProject.Location = new System.Drawing.Point(166, 12);
            this.LblHassAgentProject.Name = "LblHassAgentProject";
            this.LblHassAgentProject.Size = new System.Drawing.Size(213, 47);
            this.LblHassAgentProject.TabIndex = 2;
            this.LblHassAgentProject.Text = "HASS.Agent";
            this.LblHassAgentProject.Click += new System.EventHandler(this.LblHassAgentProject_Click);
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "Application description.";
            this.LblInfo1.AccessibleName = "Description";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.AutoSize = true;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(173, 70);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(360, 19);
            this.LblInfo1.TabIndex = 3;
            this.LblInfo1.Text = Languages.About_LblInfo1;
            // 
            // LblInfo3
            // 
            this.LblInfo3.AccessibleDescription = "Used components information.";
            this.LblInfo3.AccessibleName = "Components info";
            this.LblInfo3.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo3.Location = new System.Drawing.Point(176, 134);
            this.LblInfo3.Name = "LblInfo3";
            this.LblInfo3.Size = new System.Drawing.Size(536, 38);
            this.LblInfo3.TabIndex = 4;
            this.LblInfo3.Text = Languages.About_LblInfo3;
            // 
            // LblCoreAudio
            // 
            this.LblCoreAudio.AccessibleDescription = "Opens the \'CoreAudio\' website.";
            this.LblCoreAudio.AccessibleName = "CoreAudio";
            this.LblCoreAudio.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblCoreAudio.AutoSize = true;
            this.LblCoreAudio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblCoreAudio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblCoreAudio.Location = new System.Drawing.Point(176, 186);
            this.LblCoreAudio.Name = "LblCoreAudio";
            this.LblCoreAudio.Size = new System.Drawing.Size(74, 19);
            this.LblCoreAudio.TabIndex = 5;
            this.LblCoreAudio.Text = "CoreAudio";
            this.LblCoreAudio.Click += new System.EventHandler(this.LblCoreAudio_Click);
            // 
            // LblGrapevine
            // 
            this.LblGrapevine.AccessibleDescription = "Opens the \'Grapevine\' website.";
            this.LblGrapevine.AccessibleName = "Grapevine";
            this.LblGrapevine.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblGrapevine.AutoSize = true;
            this.LblGrapevine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblGrapevine.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblGrapevine.Location = new System.Drawing.Point(294, 186);
            this.LblGrapevine.Name = "LblGrapevine";
            this.LblGrapevine.Size = new System.Drawing.Size(71, 19);
            this.LblGrapevine.TabIndex = 6;
            this.LblGrapevine.Text = "Grapevine";
            this.LblGrapevine.Click += new System.EventHandler(this.LblGrapevine_Click);
            // 
            // LblHADotNet
            // 
            this.LblHADotNet.AccessibleDescription = "Opens the \'HADotNet\' website.";
            this.LblHADotNet.AccessibleName = "HADotNet";
            this.LblHADotNet.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblHADotNet.AutoSize = true;
            this.LblHADotNet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblHADotNet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblHADotNet.Location = new System.Drawing.Point(294, 336);
            this.LblHADotNet.Name = "LblHADotNet";
            this.LblHADotNet.Size = new System.Drawing.Size(73, 19);
            this.LblHADotNet.TabIndex = 7;
            this.LblHADotNet.Text = "HADotNet";
            this.LblHADotNet.Click += new System.EventHandler(this.LblHADotNet_Click);
            // 
            // LblMicrosoftToolkitUwpNotifications
            // 
            this.LblMicrosoftToolkitUwpNotifications.AccessibleDescription = "Opens the \'Microsoft.Toolkit.Uwp.Notifications\' website.";
            this.LblMicrosoftToolkitUwpNotifications.AccessibleName = "MicrosoftToolkitUwpNotifications";
            this.LblMicrosoftToolkitUwpNotifications.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblMicrosoftToolkitUwpNotifications.AutoSize = true;
            this.LblMicrosoftToolkitUwpNotifications.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblMicrosoftToolkitUwpNotifications.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblMicrosoftToolkitUwpNotifications.Location = new System.Drawing.Point(455, 186);
            this.LblMicrosoftToolkitUwpNotifications.Name = "LblMicrosoftToolkitUwpNotifications";
            this.LblMicrosoftToolkitUwpNotifications.Size = new System.Drawing.Size(220, 19);
            this.LblMicrosoftToolkitUwpNotifications.TabIndex = 10;
            this.LblMicrosoftToolkitUwpNotifications.Text = "Microsoft.Toolkit.Uwp.Notifications";
            this.LblMicrosoftToolkitUwpNotifications.Click += new System.EventHandler(this.LblMicrosoftToolkitUwpNotifications_Click);
            // 
            // LblLibreHardwareMonitor
            // 
            this.LblLibreHardwareMonitor.AccessibleDescription = "Opens the \'LibreHardwareMonitor\' website.";
            this.LblLibreHardwareMonitor.AccessibleName = "LibreHardwareMonitor";
            this.LblLibreHardwareMonitor.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblLibreHardwareMonitor.AutoSize = true;
            this.LblLibreHardwareMonitor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblLibreHardwareMonitor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblLibreHardwareMonitor.Location = new System.Drawing.Point(294, 216);
            this.LblLibreHardwareMonitor.Name = "LblLibreHardwareMonitor";
            this.LblLibreHardwareMonitor.Size = new System.Drawing.Size(148, 19);
            this.LblLibreHardwareMonitor.TabIndex = 9;
            this.LblLibreHardwareMonitor.Text = "LibreHardwareMonitor";
            this.LblLibreHardwareMonitor.Click += new System.EventHandler(this.LblLibreHardwareMonitor_Click);
            // 
            // LblHotkeyListener
            // 
            this.LblHotkeyListener.AccessibleDescription = "Opens the \'HotkeyListener\' website.";
            this.LblHotkeyListener.AccessibleName = "HotkeyListener";
            this.LblHotkeyListener.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblHotkeyListener.AutoSize = true;
            this.LblHotkeyListener.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblHotkeyListener.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblHotkeyListener.Location = new System.Drawing.Point(176, 216);
            this.LblHotkeyListener.Name = "LblHotkeyListener";
            this.LblHotkeyListener.Size = new System.Drawing.Size(101, 19);
            this.LblHotkeyListener.TabIndex = 8;
            this.LblHotkeyListener.Text = "HotkeyListener";
            this.LblHotkeyListener.Click += new System.EventHandler(this.LblHotkeyListener_Click);
            // 
            // LblSerilog
            // 
            this.LblSerilog.AccessibleDescription = "Opens the \'Serilog\' website.";
            this.LblSerilog.AccessibleName = "Serilog";
            this.LblSerilog.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblSerilog.AutoSize = true;
            this.LblSerilog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblSerilog.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblSerilog.Location = new System.Drawing.Point(294, 276);
            this.LblSerilog.Name = "LblSerilog";
            this.LblSerilog.Size = new System.Drawing.Size(50, 19);
            this.LblSerilog.TabIndex = 13;
            this.LblSerilog.Text = "Serilog";
            this.LblSerilog.Click += new System.EventHandler(this.LblSerilog_Click);
            // 
            // LblNewtonsoftJson
            // 
            this.LblNewtonsoftJson.AccessibleDescription = "Opens the \'NewtonsoftJson\' website.";
            this.LblNewtonsoftJson.AccessibleName = "NewtonsoftJson";
            this.LblNewtonsoftJson.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblNewtonsoftJson.AutoSize = true;
            this.LblNewtonsoftJson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblNewtonsoftJson.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblNewtonsoftJson.Location = new System.Drawing.Point(294, 246);
            this.LblNewtonsoftJson.Name = "LblNewtonsoftJson";
            this.LblNewtonsoftJson.Size = new System.Drawing.Size(110, 19);
            this.LblNewtonsoftJson.TabIndex = 12;
            this.LblNewtonsoftJson.Text = "Newtonsoft.Json";
            this.LblNewtonsoftJson.Click += new System.EventHandler(this.LblNewtonsoftJson_Click);
            // 
            // LblMQTTnet
            // 
            this.LblMQTTnet.AccessibleDescription = "Opens the \'MQTTnet\' website.";
            this.LblMQTTnet.AccessibleName = "MQTTnet";
            this.LblMQTTnet.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblMQTTnet.AutoSize = true;
            this.LblMQTTnet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblMQTTnet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblMQTTnet.Location = new System.Drawing.Point(176, 246);
            this.LblMQTTnet.Name = "LblMQTTnet";
            this.LblMQTTnet.Size = new System.Drawing.Size(65, 19);
            this.LblMQTTnet.TabIndex = 11;
            this.LblMQTTnet.Text = "MQTTnet";
            this.LblMQTTnet.Click += new System.EventHandler(this.LblMQTTnet_Click);
            // 
            // LblSyncfusion
            // 
            this.LblSyncfusion.AccessibleDescription = "Opens the \'Syncfusion\' website.";
            this.LblSyncfusion.AccessibleName = "Syncfusion";
            this.LblSyncfusion.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblSyncfusion.AutoSize = true;
            this.LblSyncfusion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblSyncfusion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblSyncfusion.Location = new System.Drawing.Point(176, 276);
            this.LblSyncfusion.Name = "LblSyncfusion";
            this.LblSyncfusion.Size = new System.Drawing.Size(74, 19);
            this.LblSyncfusion.TabIndex = 14;
            this.LblSyncfusion.Text = "Syncfusion";
            this.LblSyncfusion.Click += new System.EventHandler(this.LblSyncfusion_Click);
            // 
            // LblInfo4
            // 
            this.LblInfo4.AccessibleDescription = "Components thanks message.";
            this.LblInfo4.AccessibleName = "Components thanks";
            this.LblInfo4.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo4.Location = new System.Drawing.Point(176, 377);
            this.LblInfo4.Name = "LblInfo4";
            this.LblInfo4.Size = new System.Drawing.Size(536, 38);
            this.LblInfo4.TabIndex = 16;
            this.LblInfo4.Text = Languages.About_LblInfo4;
            // 
            // LblInfo5
            // 
            this.LblInfo5.AccessibleDescription = "Home Assistant thanks message.";
            this.LblInfo5.AccessibleName = "HA thanks";
            this.LblInfo5.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo5.Location = new System.Drawing.Point(176, 431);
            this.LblInfo5.Name = "LblInfo5";
            this.LblInfo5.Size = new System.Drawing.Size(536, 38);
            this.LblInfo5.TabIndex = 18;
            this.LblInfo5.Text = Languages.About_LblInfo5;
            // 
            // LblInfo2
            // 
            this.LblInfo2.AccessibleDescription = "Created info.";
            this.LblInfo2.AccessibleName = "Created info";
            this.LblInfo2.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo2.AutoSize = true;
            this.LblInfo2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo2.Location = new System.Drawing.Point(173, 105);
            this.LblInfo2.Name = "LblInfo2";
            this.LblInfo2.Size = new System.Drawing.Size(135, 19);
            this.LblInfo2.TabIndex = 21;
            this.LblInfo2.Text = Languages.About_LblInfo2;
            // 
            // LblLab02Research
            // 
            this.LblLab02Research.AccessibleDescription = "Created by link. Opens the LAB02 Research webpage.";
            this.LblLab02Research.AccessibleName = "Created by";
            this.LblLab02Research.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblLab02Research.AutoSize = true;
            this.LblLab02Research.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblLab02Research.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblLab02Research.Location = new System.Drawing.Point(390, 105);
            this.LblLab02Research.Name = "LblLab02Research";
            this.LblLab02Research.Size = new System.Drawing.Size(107, 19);
            this.LblLab02Research.TabIndex = 22;
            this.LblLab02Research.Text = "LAB02 Research";
            this.LblLab02Research.Click += new System.EventHandler(this.LblLab02Research_Click);
            // 
            // LblVersion
            // 
            this.LblVersion.AccessibleDescription = "HASS.Agent\'s current version.";
            this.LblVersion.AccessibleName = "Version";
            this.LblVersion.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblVersion.AutoSize = true;
            this.LblVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblVersion.Location = new System.Drawing.Point(12, 154);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(12, 15);
            this.LblVersion.TabIndex = 24;
            this.LblVersion.Text = "-";
            // 
            // LblOctokit
            // 
            this.LblOctokit.AccessibleDescription = "Opens the \'Octokit\' website.";
            this.LblOctokit.AccessibleName = "Octokit";
            this.LblOctokit.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblOctokit.AutoSize = true;
            this.LblOctokit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblOctokit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblOctokit.Location = new System.Drawing.Point(175, 306);
            this.LblOctokit.Name = "LblOctokit";
            this.LblOctokit.Size = new System.Drawing.Size(54, 19);
            this.LblOctokit.TabIndex = 26;
            this.LblOctokit.Text = "Octokit";
            this.LblOctokit.Click += new System.EventHandler(this.LblOctokit_Click);
            // 
            // LblCliWrap
            // 
            this.LblCliWrap.AccessibleDescription = "Opens the \'CliWrap\' website.";
            this.LblCliWrap.AccessibleName = "CliWrap";
            this.LblCliWrap.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblCliWrap.AutoSize = true;
            this.LblCliWrap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblCliWrap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblCliWrap.Location = new System.Drawing.Point(294, 306);
            this.LblCliWrap.Name = "LblCliWrap";
            this.LblCliWrap.Size = new System.Drawing.Size(57, 19);
            this.LblCliWrap.TabIndex = 27;
            this.LblCliWrap.Text = "CliWrap";
            this.LblCliWrap.Click += new System.EventHandler(this.LblCliWrap_Click);
            // 
            // LblInfo6
            // 
            this.LblInfo6.AccessibleDescription = "Donating for HASS.Agent message.";
            this.LblInfo6.AccessibleName = "Donating info";
            this.LblInfo6.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo6.Location = new System.Drawing.Point(173, 483);
            this.LblInfo6.Name = "LblInfo6";
            this.LblInfo6.Size = new System.Drawing.Size(562, 42);
            this.LblInfo6.TabIndex = 28;
            this.LblInfo6.Text = Languages.About_LblInfo6;
            this.LblInfo6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // PbHassLogo
            // 
            this.PbHassLogo.AccessibleDescription = "Home Assistant logo.";
            this.PbHassLogo.AccessibleName = "HA logo";
            this.PbHassLogo.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbHassLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbHassLogo.Image = ((System.Drawing.Image)(resources.GetObject("PbHassLogo.Image")));
            this.PbHassLogo.Location = new System.Drawing.Point(12, 453);
            this.PbHassLogo.Name = "PbHassLogo";
            this.PbHassLogo.Size = new System.Drawing.Size(128, 128);
            this.PbHassLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbHassLogo.TabIndex = 17;
            this.PbHassLogo.TabStop = false;
            this.PbHassLogo.Click += new System.EventHandler(this.PbHassLogo_Click);
            // 
            // PbHassAgentLogo
            // 
            this.PbHassAgentLogo.AccessibleDescription = "HASS.Agent logo.";
            this.PbHassAgentLogo.AccessibleName = "HASS.Agent logo";
            this.PbHassAgentLogo.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbHassAgentLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbHassAgentLogo.Image = ((System.Drawing.Image)(resources.GetObject("PbHassAgentLogo.Image")));
            this.PbHassAgentLogo.Location = new System.Drawing.Point(12, 23);
            this.PbHassAgentLogo.Name = "PbHassAgentLogo";
            this.PbHassAgentLogo.Size = new System.Drawing.Size(128, 128);
            this.PbHassAgentLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbHassAgentLogo.TabIndex = 1;
            this.PbHassAgentLogo.TabStop = false;
            this.PbHassAgentLogo.Click += new System.EventHandler(this.PbHassAgentLogo_Click);
            // 
            // LblCassia
            // 
            this.LblCassia.AccessibleDescription = "Opens the \'Cassia\' website.";
            this.LblCassia.AccessibleName = "Cassia";
            this.LblCassia.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblCassia.AutoSize = true;
            this.LblCassia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblCassia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblCassia.Location = new System.Drawing.Point(176, 336);
            this.LblCassia.Name = "LblCassia";
            this.LblCassia.Size = new System.Drawing.Size(47, 19);
            this.LblCassia.TabIndex = 30;
            this.LblCassia.Text = "Cassia";
            this.LblCassia.Click += new System.EventHandler(this.LblCassia_Click);
            // 
            // LblGrpcDotNetNamedPipes
            // 
            this.LblGrpcDotNetNamedPipes.AccessibleDescription = "Opens the \'GrpcDotNetNamedPipes\' website.";
            this.LblGrpcDotNetNamedPipes.AccessibleName = "GrpcDotNetNamedPipes";
            this.LblGrpcDotNetNamedPipes.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblGrpcDotNetNamedPipes.AutoSize = true;
            this.LblGrpcDotNetNamedPipes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblGrpcDotNetNamedPipes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblGrpcDotNetNamedPipes.Location = new System.Drawing.Point(455, 216);
            this.LblGrpcDotNetNamedPipes.Name = "LblGrpcDotNetNamedPipes";
            this.LblGrpcDotNetNamedPipes.Size = new System.Drawing.Size(159, 19);
            this.LblGrpcDotNetNamedPipes.TabIndex = 31;
            this.LblGrpcDotNetNamedPipes.Text = "GrpcDotNetNamedPipes";
            this.LblGrpcDotNetNamedPipes.Click += new System.EventHandler(this.LblGrpcDotNetNamedPipes_Click);
            // 
            // LblGrpc
            // 
            this.LblGrpc.AccessibleDescription = "Opens the \'gRPC\' website.";
            this.LblGrpc.AccessibleName = "Grpc";
            this.LblGrpc.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblGrpc.AutoSize = true;
            this.LblGrpc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblGrpc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblGrpc.Location = new System.Drawing.Point(455, 246);
            this.LblGrpc.Name = "LblGrpc";
            this.LblGrpc.Size = new System.Drawing.Size(42, 19);
            this.LblGrpc.TabIndex = 34;
            this.LblGrpc.Text = "gRPC";
            this.LblGrpc.Click += new System.EventHandler(this.LblGrpc_Click);
            // 
            // LblByteSize
            // 
            this.LblByteSize.AccessibleDescription = "Opens the \'ByteSize\' website.";
            this.LblByteSize.AccessibleName = "ByteSize";
            this.LblByteSize.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblByteSize.AutoSize = true;
            this.LblByteSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblByteSize.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblByteSize.Location = new System.Drawing.Point(455, 276);
            this.LblByteSize.Name = "LblByteSize";
            this.LblByteSize.Size = new System.Drawing.Size(59, 19);
            this.LblByteSize.TabIndex = 35;
            this.LblByteSize.Text = "ByteSize";
            this.LblByteSize.Click += new System.EventHandler(this.LblByteSize_Click);
            // 
            // PbPayPal
            // 
            this.PbPayPal.AccessibleDescription = "Opens the \'paypal\' donation website.";
            this.PbPayPal.AccessibleName = "PayPal donation";
            this.PbPayPal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.PbPayPal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbPayPal.Image = ((System.Drawing.Image)(resources.GetObject("PbPayPal.Image")));
            this.PbPayPal.Location = new System.Drawing.Point(359, 538);
            this.PbPayPal.Name = "PbPayPal";
            this.PbPayPal.Size = new System.Drawing.Size(152, 43);
            this.PbPayPal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbPayPal.TabIndex = 43;
            this.PbPayPal.TabStop = false;
            this.PbPayPal.Click += new System.EventHandler(this.PbPayPal_Click);
            // 
            // PbKoFi
            // 
            this.PbKoFi.AccessibleDescription = "Opens the \'ko-fi\' donation website.";
            this.PbKoFi.AccessibleName = "Kofi donation";
            this.PbKoFi.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.PbKoFi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbKoFi.Image = ((System.Drawing.Image)(resources.GetObject("PbKoFi.Image")));
            this.PbKoFi.Location = new System.Drawing.Point(541, 538);
            this.PbKoFi.Name = "PbKoFi";
            this.PbKoFi.Size = new System.Drawing.Size(171, 43);
            this.PbKoFi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbKoFi.TabIndex = 42;
            this.PbKoFi.TabStop = false;
            this.PbKoFi.Click += new System.EventHandler(this.PbKoFi_Click);
            // 
            // PbGithubSponsor
            // 
            this.PbGithubSponsor.AccessibleDescription = "Opens the \'sponsor on gituhb\' donation website.";
            this.PbGithubSponsor.AccessibleName = "GitHub donation";
            this.PbGithubSponsor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.PbGithubSponsor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbGithubSponsor.Image = ((System.Drawing.Image)(resources.GetObject("PbGithubSponsor.Image")));
            this.PbGithubSponsor.Location = new System.Drawing.Point(176, 602);
            this.PbGithubSponsor.Name = "PbGithubSponsor";
            this.PbGithubSponsor.Size = new System.Drawing.Size(235, 43);
            this.PbGithubSponsor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbGithubSponsor.TabIndex = 41;
            this.PbGithubSponsor.TabStop = false;
            this.PbGithubSponsor.Click += new System.EventHandler(this.PbGithubSponsor_Click);
            // 
            // PbBMAC
            // 
            this.PbBMAC.AccessibleDescription = "Opens the \'buy me a coffee\' donation website.";
            this.PbBMAC.AccessibleName = "BMAC donation";
            this.PbBMAC.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.PbBMAC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbBMAC.Image = ((System.Drawing.Image)(resources.GetObject("PbBMAC.Image")));
            this.PbBMAC.Location = new System.Drawing.Point(176, 538);
            this.PbBMAC.Name = "PbBMAC";
            this.PbBMAC.Size = new System.Drawing.Size(153, 43);
            this.PbBMAC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbBMAC.TabIndex = 40;
            this.PbBMAC.TabStop = false;
            this.PbBMAC.Click += new System.EventHandler(this.PbBMAC_Click);
            // 
            // About
            // 
            this.AccessibleDescription = "General info about HASS.Agent.";
            this.AccessibleName = "About";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(747, 703);
            this.Controls.Add(this.PbPayPal);
            this.Controls.Add(this.PbKoFi);
            this.Controls.Add(this.PbGithubSponsor);
            this.Controls.Add(this.PbBMAC);
            this.Controls.Add(this.LblByteSize);
            this.Controls.Add(this.LblGrpc);
            this.Controls.Add(this.LblGrpcDotNetNamedPipes);
            this.Controls.Add(this.LblCassia);
            this.Controls.Add(this.LblInfo6);
            this.Controls.Add(this.LblCliWrap);
            this.Controls.Add(this.LblOctokit);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.LblLab02Research);
            this.Controls.Add(this.LblInfo2);
            this.Controls.Add(this.LblInfo5);
            this.Controls.Add(this.PbHassLogo);
            this.Controls.Add(this.LblInfo4);
            this.Controls.Add(this.LblSyncfusion);
            this.Controls.Add(this.LblSerilog);
            this.Controls.Add(this.LblNewtonsoftJson);
            this.Controls.Add(this.LblMQTTnet);
            this.Controls.Add(this.LblMicrosoftToolkitUwpNotifications);
            this.Controls.Add(this.LblLibreHardwareMonitor);
            this.Controls.Add(this.LblHotkeyListener);
            this.Controls.Add(this.LblHADotNet);
            this.Controls.Add(this.LblGrapevine);
            this.Controls.Add(this.LblCoreAudio);
            this.Controls.Add(this.LblInfo3);
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.LblHassAgentProject);
            this.Controls.Add(this.PbHassAgentLogo);
            this.Controls.Add(this.BtnClose);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.Name = "About";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Languages.About_Title;
            this.Load += new System.EventHandler(this.About_Load);
            this.ResizeEnd += new System.EventHandler(this.About_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.About_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.PbHassLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbPayPal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbKoFi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbGithubSponsor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbBMAC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Syncfusion.WinForms.Controls.SfButton BtnClose;
        private System.Windows.Forms.PictureBox PbHassAgentLogo;
        private System.Windows.Forms.Label LblHassAgentProject;
        private System.Windows.Forms.Label LblInfo1;
        private System.Windows.Forms.Label LblInfo3;
        private System.Windows.Forms.Label LblCoreAudio;
        private System.Windows.Forms.Label LblGrapevine;
        private System.Windows.Forms.Label LblHADotNet;
        private System.Windows.Forms.Label LblMicrosoftToolkitUwpNotifications;
        private System.Windows.Forms.Label LblLibreHardwareMonitor;
        private System.Windows.Forms.Label LblHotkeyListener;
        private System.Windows.Forms.Label LblSerilog;
        private System.Windows.Forms.Label LblNewtonsoftJson;
        private System.Windows.Forms.Label LblMQTTnet;
        private System.Windows.Forms.Label LblSyncfusion;
        private System.Windows.Forms.Label LblInfo4;
        private System.Windows.Forms.PictureBox PbHassLogo;
        private System.Windows.Forms.Label LblInfo5;
        private System.Windows.Forms.Label LblInfo2;
        private System.Windows.Forms.Label LblLab02Research;
        private System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.Label LblOctokit;
        private System.Windows.Forms.Label LblCliWrap;
        private System.Windows.Forms.Label LblInfo6;
        private System.Windows.Forms.Label LblCassia;
        private Label LblGrpcDotNetNamedPipes;
        private Label LblGrpc;
        private Label LblByteSize;
        private PictureBox PbPayPal;
        private PictureBox PbKoFi;
        private PictureBox PbGithubSponsor;
        private PictureBox PbBMAC;
    }
}

