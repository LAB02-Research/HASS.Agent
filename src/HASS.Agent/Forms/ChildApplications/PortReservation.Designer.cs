namespace HASS.Agent.Forms.ChildApplications
{
    partial class PortReservation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PortReservation));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PbStep1PortBinding = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PbStep2Firewall = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep1PortBinding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep2Firewall)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(166, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please wait a bit while the task is performed ..";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(257, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 19);
            this.label3.TabIndex = 57;
            this.label3.Text = "Create API port binding";
            // 
            // PbStep1PortBinding
            // 
            this.PbStep1PortBinding.Image = global::HASS.Agent.Properties.Resources.todo_32;
            this.PbStep1PortBinding.Location = new System.Drawing.Point(207, 125);
            this.PbStep1PortBinding.Name = "PbStep1PortBinding";
            this.PbStep1PortBinding.Size = new System.Drawing.Size(32, 32);
            this.PbStep1PortBinding.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbStep1PortBinding.TabIndex = 56;
            this.PbStep1PortBinding.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(257, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 19);
            this.label2.TabIndex = 59;
            this.label2.Text = "Set firewall rule";
            // 
            // PbStep2Firewall
            // 
            this.PbStep2Firewall.Image = global::HASS.Agent.Properties.Resources.todo_32;
            this.PbStep2Firewall.Location = new System.Drawing.Point(207, 184);
            this.PbStep2Firewall.Name = "PbStep2Firewall";
            this.PbStep2Firewall.Size = new System.Drawing.Size(32, 32);
            this.PbStep2Firewall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbStep2Firewall.TabIndex = 58;
            this.PbStep2Firewall.TabStop = false;
            // 
            // PortReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(619, 284);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PbStep2Firewall);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PbStep1PortBinding);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.Name = "PortReservation";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HASS.Agent Port Reservation";
            this.Load += new System.EventHandler(this.PortReservation_Load);
            this.ResizeEnd += new System.EventHandler(this.PortReservation_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.PbStep1PortBinding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep2Firewall)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox PbStep1PortBinding;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox PbStep2Firewall;
    }
}

