﻿
using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Forms
{
    partial class Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.BtnClose = new Syncfusion.WinForms.Controls.SfButton();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.LblAbout = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.LblHAForum = new System.Windows.Forms.Label();
            this.LblGitHub = new System.Windows.Forms.Label();
            this.LblDiscord = new System.Windows.Forms.Label();
            this.LblHAInfo = new System.Windows.Forms.Label();
            this.LblGitHubInfo = new System.Windows.Forms.Label();
            this.LblDiscordInfo = new System.Windows.Forms.Label();
            this.PbDiscord = new System.Windows.Forms.PictureBox();
            this.PbGitHub = new System.Windows.Forms.PictureBox();
            this.PbHAForum = new System.Windows.Forms.PictureBox();
            this.PbHassAgentLogo = new System.Windows.Forms.PictureBox();
            this.PbDocumentation = new System.Windows.Forms.PictureBox();
            this.LblDocumentationInfo = new System.Windows.Forms.Label();
            this.LblDocumentation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbDiscord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbGitHub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbHAForum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbDocumentation)).BeginInit();
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
            this.BtnClose.Location = new System.Drawing.Point(0, 569);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(626, 37);
            this.BtnClose.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClose.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClose.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClose.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClose.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClose.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClose.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnClose.TabIndex = 0;
            this.BtnClose.Text = global::HASS.Agent.Resources.Localization.Languages.Help_BtnClose;
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "Introduction text.";
            this.LblInfo1.AccessibleName = "Introduction";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(171, 23);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(443, 76);
            this.LblInfo1.TabIndex = 3;
            this.LblInfo1.Text = Languages.Help_LblInfo1;
            // 
            // LblAbout
            // 
            this.LblAbout.AccessibleDescription = "Opens the \'about\' window.";
            this.LblAbout.AccessibleName = "About";
            this.LblAbout.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblAbout.AutoSize = true;
            this.LblAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblAbout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblAbout.Location = new System.Drawing.Point(0, 547);
            this.LblAbout.Name = "LblAbout";
            this.LblAbout.Size = new System.Drawing.Size(47, 19);
            this.LblAbout.TabIndex = 22;
            this.LblAbout.Text = Languages.Help_LblAbout;
            this.LblAbout.Click += new System.EventHandler(this.LblAbout_Click);
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
            // LblHAForum
            // 
            this.LblHAForum.AccessibleDescription = "Opens the Home Assistant forum topic for HASS.Agent.";
            this.LblHAForum.AccessibleName = "HA forum";
            this.LblHAForum.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblHAForum.AutoSize = true;
            this.LblHAForum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblHAForum.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblHAForum.Location = new System.Drawing.Point(258, 473);
            this.LblHAForum.Name = "LblHAForum";
            this.LblHAForum.Size = new System.Drawing.Size(146, 19);
            this.LblHAForum.TabIndex = 26;
            this.LblHAForum.Text = Languages.Help_LblHAForum;
            this.LblHAForum.Click += new System.EventHandler(this.LblHAForum_Click);
            // 
            // LblGitHub
            // 
            this.LblGitHub.AccessibleDescription = "Opens the \'github tickets\' webpage.";
            this.LblGitHub.AccessibleName = "GitHub tickets";
            this.LblGitHub.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblGitHub.AutoSize = true;
            this.LblGitHub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblGitHub.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblGitHub.Location = new System.Drawing.Point(258, 163);
            this.LblGitHub.Name = "LblGitHub";
            this.LblGitHub.Size = new System.Drawing.Size(96, 19);
            this.LblGitHub.TabIndex = 28;
            this.LblGitHub.Text = Languages.Help_LblGitHub;
            this.LblGitHub.Click += new System.EventHandler(this.LblGitHub_Click);
            // 
            // LblDiscord
            // 
            this.LblDiscord.AccessibleDescription = "Opens the discord invite link.";
            this.LblDiscord.AccessibleName = "Discord";
            this.LblDiscord.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblDiscord.AutoSize = true;
            this.LblDiscord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblDiscord.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblDiscord.Location = new System.Drawing.Point(258, 369);
            this.LblDiscord.Name = "LblDiscord";
            this.LblDiscord.Size = new System.Drawing.Size(55, 19);
            this.LblDiscord.TabIndex = 30;
            this.LblDiscord.Text = "Discord";
            this.LblDiscord.Click += new System.EventHandler(this.LblDiscord_Click);
            // 
            // LblHAInfo
            // 
            this.LblHAInfo.AccessibleDescription = "Home Assistant forum information.";
            this.LblHAInfo.AccessibleName = "HA forum info";
            this.LblHAInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblHAInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblHAInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblHAInfo.Location = new System.Drawing.Point(258, 503);
            this.LblHAInfo.Name = "LblHAInfo";
            this.LblHAInfo.Size = new System.Drawing.Size(356, 63);
            this.LblHAInfo.TabIndex = 31;
            this.LblHAInfo.Text = Languages.Help_LblHAInfo;
            this.LblHAInfo.Click += new System.EventHandler(this.LblHAInfo_Click);
            // 
            // LblGitHubInfo
            // 
            this.LblGitHubInfo.AccessibleDescription = "GitHub tickets information.";
            this.LblGitHubInfo.AccessibleName = "GitHub info";
            this.LblGitHubInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblGitHubInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblGitHubInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblGitHubInfo.Location = new System.Drawing.Point(258, 193);
            this.LblGitHubInfo.Name = "LblGitHubInfo";
            this.LblGitHubInfo.Size = new System.Drawing.Size(356, 65);
            this.LblGitHubInfo.TabIndex = 32;
            this.LblGitHubInfo.Text = Languages.Help_LblGitHubInfo;
            this.LblGitHubInfo.Click += new System.EventHandler(this.LblGitHubInfo_Click);
            // 
            // LblDiscordInfo
            // 
            this.LblDiscordInfo.AccessibleDescription = "Discord information.";
            this.LblDiscordInfo.AccessibleName = "Discord info";
            this.LblDiscordInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblDiscordInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblDiscordInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDiscordInfo.Location = new System.Drawing.Point(258, 399);
            this.LblDiscordInfo.Name = "LblDiscordInfo";
            this.LblDiscordInfo.Size = new System.Drawing.Size(356, 64);
            this.LblDiscordInfo.TabIndex = 33;
            this.LblDiscordInfo.Text = Languages.Help_LblDiscordInfo;
            this.LblDiscordInfo.Click += new System.EventHandler(this.LblDiscordInfo_Click);
            // 
            // PbDiscord
            // 
            this.PbDiscord.AccessibleDescription = "Discord logo.";
            this.PbDiscord.AccessibleName = "Discord logo";
            this.PbDiscord.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbDiscord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbDiscord.Image = global::HASS.Agent.Properties.Resources.discord_avatar;
            this.PbDiscord.Location = new System.Drawing.Point(171, 369);
            this.PbDiscord.Name = "PbDiscord";
            this.PbDiscord.Size = new System.Drawing.Size(65, 65);
            this.PbDiscord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbDiscord.TabIndex = 29;
            this.PbDiscord.TabStop = false;
            this.PbDiscord.Click += new System.EventHandler(this.PbDiscord_Click);
            // 
            // PbGitHub
            // 
            this.PbGitHub.AccessibleDescription = "GitHub logo.";
            this.PbGitHub.AccessibleName = "GitHub logo";
            this.PbGitHub.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbGitHub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbGitHub.Image = global::HASS.Agent.Properties.Resources.github_avatar;
            this.PbGitHub.Location = new System.Drawing.Point(171, 163);
            this.PbGitHub.Name = "PbGitHub";
            this.PbGitHub.Size = new System.Drawing.Size(65, 65);
            this.PbGitHub.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbGitHub.TabIndex = 27;
            this.PbGitHub.TabStop = false;
            this.PbGitHub.Click += new System.EventHandler(this.PbGitHub_Click);
            // 
            // PbHAForum
            // 
            this.PbHAForum.AccessibleDescription = "Home Assistant logo.";
            this.PbHAForum.AccessibleName = "HA logo";
            this.PbHAForum.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbHAForum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbHAForum.Image = global::HASS.Agent.Properties.Resources.hass_avatar;
            this.PbHAForum.Location = new System.Drawing.Point(171, 472);
            this.PbHAForum.Name = "PbHAForum";
            this.PbHAForum.Size = new System.Drawing.Size(65, 65);
            this.PbHAForum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbHAForum.TabIndex = 25;
            this.PbHAForum.TabStop = false;
            this.PbHAForum.Click += new System.EventHandler(this.PbHAForum_Click);
            // 
            // PbHassAgentLogo
            // 
            this.PbHassAgentLogo.AccessibleDescription = "HASS.Agent logo.";
            this.PbHassAgentLogo.AccessibleName = "HASS.Agent logo";
            this.PbHassAgentLogo.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbHassAgentLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbHassAgentLogo.Image = global::HASS.Agent.Properties.Resources.logo_128;
            this.PbHassAgentLogo.Location = new System.Drawing.Point(12, 23);
            this.PbHassAgentLogo.Name = "PbHassAgentLogo";
            this.PbHassAgentLogo.Size = new System.Drawing.Size(128, 128);
            this.PbHassAgentLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbHassAgentLogo.TabIndex = 1;
            this.PbHassAgentLogo.TabStop = false;
            this.PbHassAgentLogo.Click += new System.EventHandler(this.PbHassAgentLogo_Click);
            // 
            // PbDocumentation
            // 
            this.PbDocumentation.AccessibleDescription = "Read The Docs logo.";
            this.PbDocumentation.AccessibleName = "Read The Docs logo";
            this.PbDocumentation.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbDocumentation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbDocumentation.Image = global::HASS.Agent.Properties.Resources.readthedocs_avatar;
            this.PbDocumentation.Location = new System.Drawing.Point(171, 266);
            this.PbDocumentation.Name = "PbDocumentation";
            this.PbDocumentation.Size = new System.Drawing.Size(65, 65);
            this.PbDocumentation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbDocumentation.TabIndex = 36;
            this.PbDocumentation.TabStop = false;
            this.PbDocumentation.Click += new System.EventHandler(this.PbDocumentation_Click);
            // 
            // LblDocumentationInfo
            // 
            this.LblDocumentationInfo.AccessibleDescription = "Documentation information.";
            this.LblDocumentationInfo.AccessibleName = "Documentation info";
            this.LblDocumentationInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblDocumentationInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblDocumentationInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDocumentationInfo.Location = new System.Drawing.Point(258, 296);
            this.LblDocumentationInfo.Name = "LblDocumentationInfo";
            this.LblDocumentationInfo.Size = new System.Drawing.Size(356, 61);
            this.LblDocumentationInfo.TabIndex = 38;
            this.LblDocumentationInfo.Text = Languages.Help_LblDocumentationInfo;
            this.LblDocumentationInfo.Click += new System.EventHandler(this.LblDocumentationInfo_Click);
            // 
            // LblDocumentation
            // 
            this.LblDocumentation.AccessibleDescription = "Opens the documentation webpage.";
            this.LblDocumentation.AccessibleName = "Documentation";
            this.LblDocumentation.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblDocumentation.AutoSize = true;
            this.LblDocumentation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblDocumentation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblDocumentation.Location = new System.Drawing.Point(258, 266);
            this.LblDocumentation.Name = "LblDocumentation";
            this.LblDocumentation.Size = new System.Drawing.Size(104, 19);
            this.LblDocumentation.TabIndex = 37;
            this.LblDocumentation.Text = Languages.Help_LblDocumentation;
            this.LblDocumentation.Click += new System.EventHandler(this.LblDocumentation_Click);
            // 
            // Help
            // 
            this.AccessibleDescription = "Pointers to various support resources.";
            this.AccessibleName = "Help";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(626, 606);
            this.Controls.Add(this.LblDocumentationInfo);
            this.Controls.Add(this.LblDocumentation);
            this.Controls.Add(this.PbDocumentation);
            this.Controls.Add(this.LblDiscordInfo);
            this.Controls.Add(this.LblGitHubInfo);
            this.Controls.Add(this.LblHAInfo);
            this.Controls.Add(this.LblDiscord);
            this.Controls.Add(this.PbDiscord);
            this.Controls.Add(this.LblGitHub);
            this.Controls.Add(this.PbGitHub);
            this.Controls.Add(this.LblHAForum);
            this.Controls.Add(this.PbHAForum);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.LblAbout);
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.PbHassAgentLogo);
            this.Controls.Add(this.BtnClose);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.Name = "Help";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Languages.Help_Title;
            this.Load += new System.EventHandler(this.Help_Load);
            this.ResizeEnd += new System.EventHandler(this.Help_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Help_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.PbDiscord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbGitHub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbHAForum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbDocumentation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Syncfusion.WinForms.Controls.SfButton BtnClose;
        private System.Windows.Forms.PictureBox PbHassAgentLogo;
        private System.Windows.Forms.Label LblInfo1;
        private System.Windows.Forms.Label LblAbout;
        private System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.PictureBox PbHAForum;
        private System.Windows.Forms.Label LblHAForum;
        private System.Windows.Forms.Label LblGitHub;
        private System.Windows.Forms.PictureBox PbGitHub;
        private System.Windows.Forms.Label LblDiscord;
        private System.Windows.Forms.PictureBox PbDiscord;
        private System.Windows.Forms.Label LblHAInfo;
        private System.Windows.Forms.Label LblGitHubInfo;
        private System.Windows.Forms.Label LblDiscordInfo;
        private System.Windows.Forms.PictureBox PbDocumentation;
        private System.Windows.Forms.Label LblDocumentationInfo;
        private System.Windows.Forms.Label LblDocumentation;
    }
}

