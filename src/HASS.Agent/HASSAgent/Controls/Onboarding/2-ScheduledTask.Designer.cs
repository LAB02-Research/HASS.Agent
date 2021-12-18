namespace HASSAgent.Controls.Onboarding
{
    partial class ScheduledTask
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduledTask));
            this.PbHassAgentLogo = new System.Windows.Forms.PictureBox();
            this.BtnCreateScheduledTask = new Syncfusion.WinForms.Controls.SfButton();
            this.LblCreateInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // PbHassAgentLogo
            // 
            this.PbHassAgentLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbHassAgentLogo.Image = global::HASSAgent.Properties.Resources.logo_128;
            this.PbHassAgentLogo.Location = new System.Drawing.Point(24, 20);
            this.PbHassAgentLogo.Name = "PbHassAgentLogo";
            this.PbHassAgentLogo.Size = new System.Drawing.Size(128, 128);
            this.PbHassAgentLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbHassAgentLogo.TabIndex = 2;
            this.PbHassAgentLogo.TabStop = false;
            // 
            // BtnCreateScheduledTask
            // 
            this.BtnCreateScheduledTask.AccessibleName = "Button";
            this.BtnCreateScheduledTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCreateScheduledTask.Enabled = false;
            this.BtnCreateScheduledTask.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCreateScheduledTask.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCreateScheduledTask.Location = new System.Drawing.Point(183, 266);
            this.BtnCreateScheduledTask.Name = "BtnCreateScheduledTask";
            this.BtnCreateScheduledTask.Size = new System.Drawing.Size(402, 31);
            this.BtnCreateScheduledTask.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCreateScheduledTask.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCreateScheduledTask.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCreateScheduledTask.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCreateScheduledTask.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCreateScheduledTask.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCreateScheduledTask.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnCreateScheduledTask.TabIndex = 0;
            this.BtnCreateScheduledTask.Text = "yes, create scheduled task";
            this.BtnCreateScheduledTask.UseVisualStyleBackColor = false;
            this.BtnCreateScheduledTask.Click += new System.EventHandler(this.BtnCreateScheduledTask_Click);
            // 
            // LblCreateInfo
            // 
            this.LblCreateInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCreateInfo.Location = new System.Drawing.Point(180, 189);
            this.LblCreateInfo.Name = "LblCreateInfo";
            this.LblCreateInfo.Size = new System.Drawing.Size(405, 56);
            this.LblCreateInfo.TabIndex = 6;
            this.LblCreateInfo.Text = "One sec, determining the current task state (if any) ..";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(180, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(405, 128);
            this.label1.TabIndex = 5;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // ScheduledTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.BtnCreateScheduledTask);
            this.Controls.Add(this.LblCreateInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PbHassAgentLogo);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ScheduledTask";
            this.Size = new System.Drawing.Size(610, 364);
            this.Load += new System.EventHandler(this.ScheduledTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PbHassAgentLogo;
        private Syncfusion.WinForms.Controls.SfButton BtnCreateScheduledTask;
        private System.Windows.Forms.Label LblCreateInfo;
        private System.Windows.Forms.Label label1;
    }
}
