using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Forms.ChildApplications
{
    partial class PostUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostUpdate));
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.PbStep1InstallSatelliteService = new System.Windows.Forms.PictureBox();
            this.LblTask1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep1InstallSatelliteService)).BeginInit();
            this.SuspendLayout();
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "Information about the task that\'s being performed.";
            this.LblInfo1.AccessibleName = "Task information";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(12, 9);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(604, 57);
            this.LblInfo1.TabIndex = 1;
            this.LblInfo1.Text = Languages.PostUpdate_LblInfo1;
            this.LblInfo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // PbStep1InstallSatelliteService
            // 
            this.PbStep1InstallSatelliteService.AccessibleDescription = "Step one status visualisation.";
            this.PbStep1InstallSatelliteService.AccessibleName = "Step one status";
            this.PbStep1InstallSatelliteService.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbStep1InstallSatelliteService.Image = ((System.Drawing.Image)(resources.GetObject("PbStep1InstallSatelliteService.Image")));
            this.PbStep1InstallSatelliteService.Location = new System.Drawing.Point(195, 140);
            this.PbStep1InstallSatelliteService.Name = "PbStep1InstallSatelliteService";
            this.PbStep1InstallSatelliteService.Size = new System.Drawing.Size(32, 32);
            this.PbStep1InstallSatelliteService.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbStep1InstallSatelliteService.TabIndex = 54;
            this.PbStep1InstallSatelliteService.TabStop = false;
            // 
            // LblTask1
            // 
            this.LblTask1.AccessibleDescription = "Step one description.";
            this.LblTask1.AccessibleName = "Step one description";
            this.LblTask1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblTask1.AutoSize = true;
            this.LblTask1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTask1.Location = new System.Drawing.Point(245, 146);
            this.LblTask1.Name = "LblTask1";
            this.LblTask1.Size = new System.Drawing.Size(178, 19);
            this.LblTask1.TabIndex = 55;
            this.LblTask1.Text = Languages.PostUpdate_LblTask1;
            // 
            // PostUpdate
            // 
            this.AccessibleDescription = "Executes post-update tasks, like configuring the satellite service.";
            this.AccessibleName = "Post update";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(619, 284);
            this.Controls.Add(this.LblTask1);
            this.Controls.Add(this.PbStep1InstallSatelliteService);
            this.Controls.Add(this.LblInfo1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.Name = "PostUpdate";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Languages.PostUpdate_PostUpdate;
            this.Load += new System.EventHandler(this.PostUpdate_Load);
            this.ResizeEnd += new System.EventHandler(this.PostUpdate_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.PbStep1InstallSatelliteService)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblInfo1;
        private System.Windows.Forms.PictureBox PbStep1InstallSatelliteService;
        private System.Windows.Forms.Label LblTask1;
    }
}

