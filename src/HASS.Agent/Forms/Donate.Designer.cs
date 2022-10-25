
using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Forms
{
    partial class Donate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Donate));
            this.BtnClose = new Syncfusion.WinForms.Controls.SfButton();
            this.LblHassAgentProject = new System.Windows.Forms.Label();
            this.PbBMAC = new System.Windows.Forms.PictureBox();
            this.PbHassAgentLogo = new System.Windows.Forms.PictureBox();
            this.PbGithubSponsor = new System.Windows.Forms.PictureBox();
            this.PbKoFi = new System.Windows.Forms.PictureBox();
            this.LblInfo = new System.Windows.Forms.Label();
            this.PbPayPal = new System.Windows.Forms.PictureBox();
            this.CbHideDonateButton = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbBMAC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbGithubSponsor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbKoFi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbPayPal)).BeginInit();
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
            this.BtnClose.Location = new System.Drawing.Point(0, 466);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(693, 37);
            this.BtnClose.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClose.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClose.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClose.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClose.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClose.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClose.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnClose.TabIndex = 0;
            this.BtnClose.Text = Languages.Donate_BtnClose;
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
            this.LblHassAgentProject.Size = new System.Drawing.Size(63, 47);
            this.LblHassAgentProject.TabIndex = 2;
            this.LblHassAgentProject.Text = "<3";
            this.LblHassAgentProject.Click += new System.EventHandler(this.LblHassAgentProject_Click);
            // 
            // PbBMAC
            // 
            this.PbBMAC.AccessibleDescription = "Opens the \'buy me a coffee\' donation website.";
            this.PbBMAC.AccessibleName = "BMAC donation";
            this.PbBMAC.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.PbBMAC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbBMAC.Image = ((System.Drawing.Image)(resources.GetObject("PbBMAC.Image")));
            this.PbBMAC.Location = new System.Drawing.Point(166, 290);
            this.PbBMAC.Name = "PbBMAC";
            this.PbBMAC.Size = new System.Drawing.Size(153, 43);
            this.PbBMAC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbBMAC.TabIndex = 29;
            this.PbBMAC.TabStop = false;
            this.PbBMAC.Click += new System.EventHandler(this.PbBMAC_Click);
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
            // PbGithubSponsor
            // 
            this.PbGithubSponsor.AccessibleDescription = "Opens the \'sponsor on gituhb\' donation website.";
            this.PbGithubSponsor.AccessibleName = "GitHub donation";
            this.PbGithubSponsor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.PbGithubSponsor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbGithubSponsor.Image = ((System.Drawing.Image)(resources.GetObject("PbGithubSponsor.Image")));
            this.PbGithubSponsor.Location = new System.Drawing.Point(166, 354);
            this.PbGithubSponsor.Name = "PbGithubSponsor";
            this.PbGithubSponsor.Size = new System.Drawing.Size(235, 43);
            this.PbGithubSponsor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbGithubSponsor.TabIndex = 33;
            this.PbGithubSponsor.TabStop = false;
            this.PbGithubSponsor.Click += new System.EventHandler(this.PbGithubSponsor_Click);
            // 
            // PbKoFi
            // 
            this.PbKoFi.AccessibleDescription = "Opens the \'ko-fi\' donation website.";
            this.PbKoFi.AccessibleName = "Kofi donation";
            this.PbKoFi.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.PbKoFi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbKoFi.Image = ((System.Drawing.Image)(resources.GetObject("PbKoFi.Image")));
            this.PbKoFi.Location = new System.Drawing.Point(509, 290);
            this.PbKoFi.Name = "PbKoFi";
            this.PbKoFi.Size = new System.Drawing.Size(171, 43);
            this.PbKoFi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbKoFi.TabIndex = 36;
            this.PbKoFi.TabStop = false;
            this.PbKoFi.Click += new System.EventHandler(this.PbKoFi_Click);
            // 
            // LblInfo
            // 
            this.LblInfo.AccessibleDescription = "Donating for HASS.Agent message.";
            this.LblInfo.AccessibleName = "Donating info";
            this.LblInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo.Location = new System.Drawing.Point(166, 84);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(514, 185);
            this.LblInfo.TabIndex = 38;
            this.LblInfo.Text = Languages.Donate_LblInfo;
            // 
            // PbPayPal
            // 
            this.PbPayPal.AccessibleDescription = "Opens the \'paypal\' donation website.";
            this.PbPayPal.AccessibleName = "PayPal donation";
            this.PbPayPal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.PbPayPal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbPayPal.Image = ((System.Drawing.Image)(resources.GetObject("PbPayPal.Image")));
            this.PbPayPal.Location = new System.Drawing.Point(338, 290);
            this.PbPayPal.Name = "PbPayPal";
            this.PbPayPal.Size = new System.Drawing.Size(152, 43);
            this.PbPayPal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbPayPal.TabIndex = 39;
            this.PbPayPal.TabStop = false;
            // 
            // CbHideDonateButton
            // 
            this.CbHideDonateButton.AutoSize = true;
            this.CbHideDonateButton.Location = new System.Drawing.Point(166, 426);
            this.CbHideDonateButton.Name = "CbHideDonateButton";
            this.CbHideDonateButton.Size = new System.Drawing.Size(320, 19);
            this.CbHideDonateButton.TabIndex = 40;
            this.CbHideDonateButton.Text = Languages.Donate_CbHideDonateButton;
            this.CbHideDonateButton.UseVisualStyleBackColor = true;
            // 
            // Donate
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
            this.ClientSize = new System.Drawing.Size(693, 503);
            this.Controls.Add(this.CbHideDonateButton);
            this.Controls.Add(this.PbPayPal);
            this.Controls.Add(this.PbKoFi);
            this.Controls.Add(this.PbGithubSponsor);
            this.Controls.Add(this.PbBMAC);
            this.Controls.Add(this.LblHassAgentProject);
            this.Controls.Add(this.PbHassAgentLogo);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.LblInfo);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.Name = "Donate";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Languages.Donate_Title;
            this.Load += new System.EventHandler(this.Donate_Load);
            this.ResizeEnd += new System.EventHandler(this.Donate_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Donate_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.PbBMAC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbGithubSponsor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbKoFi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbPayPal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Syncfusion.WinForms.Controls.SfButton BtnClose;
        private System.Windows.Forms.PictureBox PbHassAgentLogo;
        private System.Windows.Forms.Label LblHassAgentProject;
        private System.Windows.Forms.PictureBox PbBMAC;
        private PictureBox PbGithubSponsor;
        private PictureBox PbKoFi;
        private Label LblInfo;
        private PictureBox PbPayPal;
        private CheckBox CbHideDonateButton;
    }
}

