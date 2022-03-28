namespace HASS.Agent.Forms.ChildApplications
{
    partial class ServiceSetState
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceSetState));
            this.label1 = new System.Windows.Forms.Label();
            this.PbStep1Configure = new System.Windows.Forms.PictureBox();
            this.LblStep1Configure = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep1Configure)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(150, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please wait while the satellite service is configured ..";
            // 
            // PbStep1Configure
            // 
            this.PbStep1Configure.Image = global::HASS.Agent.Properties.Resources.todo_32;
            this.PbStep1Configure.Location = new System.Drawing.Point(211, 148);
            this.PbStep1Configure.Name = "PbStep1Configure";
            this.PbStep1Configure.Size = new System.Drawing.Size(32, 32);
            this.PbStep1Configure.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbStep1Configure.TabIndex = 54;
            this.PbStep1Configure.TabStop = false;
            // 
            // LblStep1Configure
            // 
            this.LblStep1Configure.AutoSize = true;
            this.LblStep1Configure.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblStep1Configure.Location = new System.Drawing.Point(261, 154);
            this.LblStep1Configure.Name = "LblStep1Configure";
            this.LblStep1Configure.Size = new System.Drawing.Size(146, 19);
            this.LblStep1Configure.TabIndex = 55;
            this.LblStep1Configure.Text = "Enable Satellite Service";
            // 
            // ServiceSetState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(619, 284);
            this.Controls.Add(this.LblStep1Configure);
            this.Controls.Add(this.PbStep1Configure);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.Name = "ServiceSetState";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HASS.Agent Configure Satellite Service";
            this.Load += new System.EventHandler(this.ServiceSetState_Load);
            this.ResizeEnd += new System.EventHandler(this.ServiceSetState_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.PbStep1Configure)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PbStep1Configure;
        private System.Windows.Forms.Label LblStep1Configure;
    }
}

