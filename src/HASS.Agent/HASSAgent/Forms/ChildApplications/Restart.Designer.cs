namespace HASSAgent.Forms.ChildApplications
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
            this.label1 = new System.Windows.Forms.Label();
            this.PbStep1WaitForInstances = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PbStep2Restart = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep1WaitForInstances)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep2Restart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please wait a bit while HASS.Agent restarts ..";
            // 
            // PbStep1WaitForInstances
            // 
            this.PbStep1WaitForInstances.Image = global::HASSAgent.Properties.Resources.todo_32;
            this.PbStep1WaitForInstances.Location = new System.Drawing.Point(43, 89);
            this.PbStep1WaitForInstances.Name = "PbStep1WaitForInstances";
            this.PbStep1WaitForInstances.Size = new System.Drawing.Size(32, 32);
            this.PbStep1WaitForInstances.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbStep1WaitForInstances.TabIndex = 54;
            this.PbStep1WaitForInstances.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 17);
            this.label2.TabIndex = 55;
            this.label2.Text = "Waiting for previous instance to close";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(93, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 57;
            this.label3.Text = "Relaunch HASS.Agent";
            // 
            // PbStep2Restart
            // 
            this.PbStep2Restart.Image = global::HASSAgent.Properties.Resources.todo_32;
            this.PbStep2Restart.Location = new System.Drawing.Point(43, 155);
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
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(443, 227);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PbStep2Restart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PbStep1WaitForInstances);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(131)))));
            this.Name = "Restart";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HASS.Agent Restarter";
            this.Load += new System.EventHandler(this.Restart_Load);
            this.ResizeEnd += new System.EventHandler(this.Restart_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.PbStep1WaitForInstances)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep2Restart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PbStep1WaitForInstances;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox PbStep2Restart;
    }
}

