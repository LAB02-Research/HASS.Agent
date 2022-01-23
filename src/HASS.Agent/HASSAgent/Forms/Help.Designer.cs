
namespace HASSAgent.Forms
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
            this.label2 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.PbDiscord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbGitHub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbHAForum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.AccessibleName = "Button";
            this.BtnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClose.Location = new System.Drawing.Point(0, 402);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(579, 37);
            this.BtnClose.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClose.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClose.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClose.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClose.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClose.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClose.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnClose.TabIndex = 0;
            this.BtnClose.Text = "close";
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(173, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(396, 82);
            this.label2.TabIndex = 3;
            this.label2.Text = "Stuck while using HASS.Agent, need some help integrating the sensors/commands or " +
    "have a great idea for the next version?\r\n\r\nThere are a few channels through whic" +
    "h you can reach us:";
            // 
            // LblAbout
            // 
            this.LblAbout.AutoSize = true;
            this.LblAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblAbout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAbout.Location = new System.Drawing.Point(-3, 382);
            this.LblAbout.Name = "LblAbout";
            this.LblAbout.Size = new System.Drawing.Size(43, 17);
            this.LblAbout.TabIndex = 22;
            this.LblAbout.Text = "About";
            this.LblAbout.Click += new System.EventHandler(this.LblAbout_Click);
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVersion.Location = new System.Drawing.Point(12, 154);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(13, 17);
            this.LblVersion.TabIndex = 24;
            this.LblVersion.Text = "-";
            // 
            // LblHAForum
            // 
            this.LblHAForum.AutoSize = true;
            this.LblHAForum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblHAForum.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHAForum.Location = new System.Drawing.Point(258, 303);
            this.LblHAForum.Name = "LblHAForum";
            this.LblHAForum.Size = new System.Drawing.Size(137, 17);
            this.LblHAForum.TabIndex = 26;
            this.LblHAForum.Text = "Home Assistant forum";
            this.LblHAForum.Click += new System.EventHandler(this.LblHAForum_Click);
            // 
            // LblGitHub
            // 
            this.LblGitHub.AutoSize = true;
            this.LblGitHub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblGitHub.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGitHub.Location = new System.Drawing.Point(258, 127);
            this.LblGitHub.Name = "LblGitHub";
            this.LblGitHub.Size = new System.Drawing.Size(88, 17);
            this.LblGitHub.TabIndex = 28;
            this.LblGitHub.Text = "GitHub tickets";
            this.LblGitHub.Click += new System.EventHandler(this.LblGitHub_Click);
            // 
            // LblDiscord
            // 
            this.LblDiscord.AutoSize = true;
            this.LblDiscord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblDiscord.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDiscord.Location = new System.Drawing.Point(258, 215);
            this.LblDiscord.Name = "LblDiscord";
            this.LblDiscord.Size = new System.Drawing.Size(101, 17);
            this.LblDiscord.TabIndex = 30;
            this.LblDiscord.Text = "Discord channel";
            this.LblDiscord.Click += new System.EventHandler(this.LblDiscord_Click);
            // 
            // LblHAInfo
            // 
            this.LblHAInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblHAInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHAInfo.Location = new System.Drawing.Point(258, 333);
            this.LblHAInfo.Name = "LblHAInfo";
            this.LblHAInfo.Size = new System.Drawing.Size(292, 35);
            this.LblHAInfo.TabIndex = 31;
            this.LblHAInfo.Text = "Bit of both, with the addition that other HA users can help as well.";
            this.LblHAInfo.Click += new System.EventHandler(this.LblHAInfo_Click);
            // 
            // LblGitHubInfo
            // 
            this.LblGitHubInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblGitHubInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGitHubInfo.Location = new System.Drawing.Point(258, 157);
            this.LblGitHubInfo.Name = "LblGitHubInfo";
            this.LblGitHubInfo.Size = new System.Drawing.Size(292, 35);
            this.LblGitHubInfo.TabIndex = 32;
            this.LblGitHubInfo.Text = "Report bugs, feature requests, ideas, tips, ..";
            this.LblGitHubInfo.Click += new System.EventHandler(this.LblGitHubInfo_Click);
            // 
            // LblDiscordInfo
            // 
            this.LblDiscordInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblDiscordInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDiscordInfo.Location = new System.Drawing.Point(258, 245);
            this.LblDiscordInfo.Name = "LblDiscordInfo";
            this.LblDiscordInfo.Size = new System.Drawing.Size(292, 35);
            this.LblDiscordInfo.TabIndex = 33;
            this.LblDiscordInfo.Text = "Get help with setting up and using HASS.Agent, report bugs or just talk about wha" +
    "tever.";
            this.LblDiscordInfo.Click += new System.EventHandler(this.LblDiscordInfo_Click);
            // 
            // PbDiscord
            // 
            this.PbDiscord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbDiscord.Image = global::HASSAgent.Properties.Resources.discord_avatar;
            this.PbDiscord.Location = new System.Drawing.Point(176, 215);
            this.PbDiscord.Name = "PbDiscord";
            this.PbDiscord.Size = new System.Drawing.Size(65, 65);
            this.PbDiscord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbDiscord.TabIndex = 29;
            this.PbDiscord.TabStop = false;
            this.PbDiscord.Click += new System.EventHandler(this.PbDiscord_Click);
            // 
            // PbGitHub
            // 
            this.PbGitHub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbGitHub.Image = global::HASSAgent.Properties.Resources.github_avatar;
            this.PbGitHub.Location = new System.Drawing.Point(176, 127);
            this.PbGitHub.Name = "PbGitHub";
            this.PbGitHub.Size = new System.Drawing.Size(65, 65);
            this.PbGitHub.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbGitHub.TabIndex = 27;
            this.PbGitHub.TabStop = false;
            this.PbGitHub.Click += new System.EventHandler(this.PbGitHub_Click);
            // 
            // PbHAForum
            // 
            this.PbHAForum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbHAForum.Image = global::HASSAgent.Properties.Resources.hass_avatar;
            this.PbHAForum.Location = new System.Drawing.Point(176, 303);
            this.PbHAForum.Name = "PbHAForum";
            this.PbHAForum.Size = new System.Drawing.Size(65, 65);
            this.PbHAForum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbHAForum.TabIndex = 25;
            this.PbHAForum.TabStop = false;
            this.PbHAForum.Click += new System.EventHandler(this.PbHAForum_Click);
            // 
            // PbHassAgentLogo
            // 
            this.PbHassAgentLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbHassAgentLogo.Image = global::HASSAgent.Properties.Resources.logo_128;
            this.PbHassAgentLogo.Location = new System.Drawing.Point(12, 23);
            this.PbHassAgentLogo.Name = "PbHassAgentLogo";
            this.PbHassAgentLogo.Size = new System.Drawing.Size(128, 128);
            this.PbHassAgentLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbHassAgentLogo.TabIndex = 1;
            this.PbHassAgentLogo.TabStop = false;
            this.PbHassAgentLogo.Click += new System.EventHandler(this.PbHassAgentLogo_Click);
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(579, 439);
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
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PbHassAgentLogo);
            this.Controls.Add(this.BtnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(131)))));
            this.Name = "Help";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help";
            this.Load += new System.EventHandler(this.Help_Load);
            this.ResizeEnd += new System.EventHandler(this.Help_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.PbDiscord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbGitHub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbHAForum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Syncfusion.WinForms.Controls.SfButton BtnClose;
        private System.Windows.Forms.PictureBox PbHassAgentLogo;
        private System.Windows.Forms.Label label2;
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
    }
}

