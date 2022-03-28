namespace HASS.Agent.Forms
{
    partial class UpdatePending
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatePending));
            this.BtnDownload = new Syncfusion.WinForms.Controls.SfButton();
            this.LblNewReleaseInfo = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblUpdateQuestion = new System.Windows.Forms.Label();
            this.BtnIgnore = new Syncfusion.WinForms.Controls.SfButton();
            this.PbUpdate = new System.Windows.Forms.PictureBox();
            this.LblRelease = new System.Windows.Forms.Label();
            this.TbReleaseNotes = new System.Windows.Forms.RichTextBox();
            this.PnlReleaseNotes = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.PbUpdate)).BeginInit();
            this.PnlReleaseNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnDownload
            // 
            this.BtnDownload.AccessibleName = "Button";
            this.BtnDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnDownload.Enabled = false;
            this.BtnDownload.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnDownload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnDownload.Location = new System.Drawing.Point(165, 465);
            this.BtnDownload.Name = "BtnDownload";
            this.BtnDownload.Size = new System.Drawing.Size(455, 31);
            this.BtnDownload.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnDownload.Style.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnDownload.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnDownload.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnDownload.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnDownload.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnDownload.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnDownload.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnDownload.TabIndex = 0;
            this.BtnDownload.Text = "one sec, fetching info ..";
            this.BtnDownload.UseVisualStyleBackColor = false;
            this.BtnDownload.Click += new System.EventHandler(this.BtnDownload_Click);
            // 
            // LblNewReleaseInfo
            // 
            this.LblNewReleaseInfo.AutoSize = true;
            this.LblNewReleaseInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblNewReleaseInfo.Location = new System.Drawing.Point(22, 26);
            this.LblNewReleaseInfo.Name = "LblNewReleaseInfo";
            this.LblNewReleaseInfo.Size = new System.Drawing.Size(197, 19);
            this.LblNewReleaseInfo.TabIndex = 1;
            this.LblNewReleaseInfo.Text = "There\'s a new release available:";
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblVersion.Location = new System.Drawing.Point(280, 24);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(16, 21);
            this.LblVersion.TabIndex = 2;
            this.LblVersion.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(1, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Release notes";
            // 
            // LblUpdateQuestion
            // 
            this.LblUpdateQuestion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblUpdateQuestion.Location = new System.Drawing.Point(165, 437);
            this.LblUpdateQuestion.Name = "LblUpdateQuestion";
            this.LblUpdateQuestion.Size = new System.Drawing.Size(455, 17);
            this.LblUpdateQuestion.TabIndex = 5;
            this.LblUpdateQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnIgnore
            // 
            this.BtnIgnore.AccessibleName = "Button";
            this.BtnIgnore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnIgnore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnIgnore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnIgnore.Location = new System.Drawing.Point(-2, 465);
            this.BtnIgnore.Name = "BtnIgnore";
            this.BtnIgnore.Size = new System.Drawing.Size(158, 31);
            this.BtnIgnore.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnIgnore.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnIgnore.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnIgnore.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnIgnore.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnIgnore.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnIgnore.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnIgnore.TabIndex = 6;
            this.BtnIgnore.Text = "ignore this update";
            this.BtnIgnore.UseVisualStyleBackColor = false;
            this.BtnIgnore.Click += new System.EventHandler(this.BtnIgnore_Click);
            // 
            // PbUpdate
            // 
            this.PbUpdate.Image = global::HASS.Agent.Properties.Resources.update;
            this.PbUpdate.Location = new System.Drawing.Point(541, 12);
            this.PbUpdate.Name = "PbUpdate";
            this.PbUpdate.Size = new System.Drawing.Size(70, 70);
            this.PbUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbUpdate.TabIndex = 7;
            this.PbUpdate.TabStop = false;
            // 
            // LblRelease
            // 
            this.LblRelease.AutoSize = true;
            this.LblRelease.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblRelease.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblRelease.Location = new System.Drawing.Point(2, 435);
            this.LblRelease.Name = "LblRelease";
            this.LblRelease.Size = new System.Drawing.Size(85, 19);
            this.LblRelease.TabIndex = 8;
            this.LblRelease.Text = "release page";
            this.LblRelease.Click += new System.EventHandler(this.LblRelease_Click);
            // 
            // TbReleaseNotes
            // 
            this.TbReleaseNotes.AutoWordSelection = true;
            this.TbReleaseNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbReleaseNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbReleaseNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbReleaseNotes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbReleaseNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbReleaseNotes.Location = new System.Drawing.Point(0, 0);
            this.TbReleaseNotes.Name = "TbReleaseNotes";
            this.TbReleaseNotes.ReadOnly = true;
            this.TbReleaseNotes.Size = new System.Drawing.Size(617, 321);
            this.TbReleaseNotes.TabIndex = 19;
            this.TbReleaseNotes.Text = "";
            this.TbReleaseNotes.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.TbReleaseNotes_LinkClicked);
            // 
            // PnlReleaseNotes
            // 
            this.PnlReleaseNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlReleaseNotes.Controls.Add(this.TbReleaseNotes);
            this.PnlReleaseNotes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PnlReleaseNotes.Location = new System.Drawing.Point(1, 104);
            this.PnlReleaseNotes.Name = "PnlReleaseNotes";
            this.PnlReleaseNotes.Size = new System.Drawing.Size(619, 323);
            this.PnlReleaseNotes.TabIndex = 20;
            // 
            // UpdatePending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(620, 497);
            this.Controls.Add(this.PnlReleaseNotes);
            this.Controls.Add(this.LblRelease);
            this.Controls.Add(this.PbUpdate);
            this.Controls.Add(this.BtnIgnore);
            this.Controls.Add(this.LblUpdateQuestion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.LblNewReleaseInfo);
            this.Controls.Add(this.BtnDownload);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.Name = "UpdatePending";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HASS.Agent Update";
            this.Load += new System.EventHandler(this.UpdatePending_Load);
            this.ResizeEnd += new System.EventHandler(this.UpdatePending_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.PbUpdate)).EndInit();
            this.PnlReleaseNotes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Syncfusion.WinForms.Controls.SfButton BtnDownload;
        private System.Windows.Forms.Label LblNewReleaseInfo;
        private System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblUpdateQuestion;
        private Syncfusion.WinForms.Controls.SfButton BtnIgnore;
        private System.Windows.Forms.PictureBox PbUpdate;
        private System.Windows.Forms.Label LblRelease;
        private System.Windows.Forms.RichTextBox TbReleaseNotes;
        private System.Windows.Forms.Panel PnlReleaseNotes;
    }
}

