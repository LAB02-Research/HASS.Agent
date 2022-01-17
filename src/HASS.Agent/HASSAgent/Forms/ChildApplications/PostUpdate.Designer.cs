namespace HASSAgent.Forms.ChildApplications
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
            this.label1 = new System.Windows.Forms.Label();
            this.PbStep1ScheduledTask = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PbStep2PortBinding = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep1ScheduledTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep2PortBinding)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please wait a bit while some post-update tasks are performed ..";
            // 
            // PbStep1ScheduledTask
            // 
            this.PbStep1ScheduledTask.Image = global::HASSAgent.Properties.Resources.todo_32;
            this.PbStep1ScheduledTask.Location = new System.Drawing.Point(43, 89);
            this.PbStep1ScheduledTask.Name = "PbStep1ScheduledTask";
            this.PbStep1ScheduledTask.Size = new System.Drawing.Size(32, 32);
            this.PbStep1ScheduledTask.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbStep1ScheduledTask.TabIndex = 54;
            this.PbStep1ScheduledTask.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 17);
            this.label2.TabIndex = 55;
            this.label2.Text = "Remove legacy scheduled task";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(93, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 17);
            this.label3.TabIndex = 57;
            this.label3.Text = "Create API port binding";
            // 
            // PbStep2PortBinding
            // 
            this.PbStep2PortBinding.Image = global::HASSAgent.Properties.Resources.todo_32;
            this.PbStep2PortBinding.Location = new System.Drawing.Point(43, 155);
            this.PbStep2PortBinding.Name = "PbStep2PortBinding";
            this.PbStep2PortBinding.Size = new System.Drawing.Size(32, 32);
            this.PbStep2PortBinding.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbStep2PortBinding.TabIndex = 56;
            this.PbStep2PortBinding.TabStop = false;
            // 
            // PostUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(443, 227);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PbStep2PortBinding);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PbStep1ScheduledTask);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(131)))));
            this.Name = "PostUpdate";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HASS.Agent Post Update";
            this.Load += new System.EventHandler(this.PostUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbStep1ScheduledTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep2PortBinding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PbStep1ScheduledTask;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox PbStep2PortBinding;
    }
}

