using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Forms.ChildApplications
{
    partial class Restart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Restart));
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.PbStep1WaitForInstances = new System.Windows.Forms.PictureBox();
            this.LblTask1 = new System.Windows.Forms.Label();
            this.LblTask2 = new System.Windows.Forms.Label();
            this.PbStep2Restart = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep1WaitForInstances)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep2Restart)).BeginInit();
            this.SuspendLayout();
            // 
            // LblInfo1
            // 
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(3, 9);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(612, 57);
            this.LblInfo1.TabIndex = 1;
            this.LblInfo1.Text = Languages.Restart_LblInfo1;
            this.LblInfo1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // PbStep1WaitForInstances
            // 
            this.PbStep1WaitForInstances.Image = global::HASS.Agent.Properties.Resources.todo_32;
            this.PbStep1WaitForInstances.Location = new System.Drawing.Point(166, 123);
            this.PbStep1WaitForInstances.Name = "PbStep1WaitForInstances";
            this.PbStep1WaitForInstances.Size = new System.Drawing.Size(32, 32);
            this.PbStep1WaitForInstances.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbStep1WaitForInstances.TabIndex = 54;
            this.PbStep1WaitForInstances.TabStop = false;
            // 
            // LblTask1
            // 
            this.LblTask1.AutoSize = true;
            this.LblTask1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTask1.Location = new System.Drawing.Point(216, 129);
            this.LblTask1.Name = "LblTask1";
            this.LblTask1.Size = new System.Drawing.Size(237, 19);
            this.LblTask1.TabIndex = 55;
            this.LblTask1.Text = Languages.Restart_LblTask1;
            // 
            // LblTask2
            // 
            this.LblTask2.AutoSize = true;
            this.LblTask2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTask2.Location = new System.Drawing.Point(216, 195);
            this.LblTask2.Name = "LblTask2";
            this.LblTask2.Size = new System.Drawing.Size(141, 19);
            this.LblTask2.TabIndex = 57;
            this.LblTask2.Text = Languages.Restart_LblTask2;
            // 
            // PbStep2Restart
            // 
            this.PbStep2Restart.Image = global::HASS.Agent.Properties.Resources.todo_32;
            this.PbStep2Restart.Location = new System.Drawing.Point(166, 189);
            this.PbStep2Restart.Name = "PbStep2Restart";
            this.PbStep2Restart.Size = new System.Drawing.Size(32, 32);
            this.PbStep2Restart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbStep2Restart.TabIndex = 56;
            this.PbStep2Restart.TabStop = false;
            // 
            // Restart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(619, 284);
            this.Controls.Add(this.LblTask2);
            this.Controls.Add(this.PbStep2Restart);
            this.Controls.Add(this.LblTask1);
            this.Controls.Add(this.PbStep1WaitForInstances);
            this.Controls.Add(this.LblInfo1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.Name = "Restart";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Languages.Restart_Title;
            this.Load += new System.EventHandler(this.Restart_Load);
            this.ResizeEnd += new System.EventHandler(this.Restart_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.PbStep1WaitForInstances)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep2Restart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblInfo1;
        private System.Windows.Forms.PictureBox PbStep1WaitForInstances;
        private System.Windows.Forms.Label LblTask1;
        private System.Windows.Forms.Label LblTask2;
        private System.Windows.Forms.PictureBox PbStep2Restart;
    }
}

