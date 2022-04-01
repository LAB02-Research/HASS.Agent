using HASS.Agent.Resources.Localization;

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
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.LblTask1 = new System.Windows.Forms.Label();
            this.PbStep1PortBinding = new System.Windows.Forms.PictureBox();
            this.LblTask2 = new System.Windows.Forms.Label();
            this.PbStep2Firewall = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep1PortBinding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep2Firewall)).BeginInit();
            this.SuspendLayout();
            // 
            // LblInfo1
            // 
            this.LblInfo1.AutoSize = true;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(166, 47);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(286, 19);
            this.LblInfo1.TabIndex = 1;
            this.LblInfo1.Text = Languages.PortReservation_LblInfo1;
            // 
            // LblTask1
            // 
            this.LblTask1.AutoSize = true;
            this.LblTask1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTask1.Location = new System.Drawing.Point(257, 131);
            this.LblTask1.Name = "LblTask1";
            this.LblTask1.Size = new System.Drawing.Size(154, 19);
            this.LblTask1.TabIndex = 57;
            this.LblTask1.Text = Languages.PortReservation_LblTask1;
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
            // LblTask2
            // 
            this.LblTask2.AutoSize = true;
            this.LblTask2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTask2.Location = new System.Drawing.Point(257, 192);
            this.LblTask2.Name = "LblTask2";
            this.LblTask2.Size = new System.Drawing.Size(101, 19);
            this.LblTask2.TabIndex = 59;
            this.LblTask2.Text = Languages.PortReservation_LblTask2;
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
            this.Controls.Add(this.LblTask2);
            this.Controls.Add(this.PbStep2Firewall);
            this.Controls.Add(this.LblTask1);
            this.Controls.Add(this.PbStep1PortBinding);
            this.Controls.Add(this.LblInfo1);
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
            this.Text = Languages.PortReservation_Title;
            this.Load += new System.EventHandler(this.PortReservation_Load);
            this.ResizeEnd += new System.EventHandler(this.PortReservation_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.PbStep1PortBinding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep2Firewall)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblInfo1;
        private System.Windows.Forms.Label LblTask1;
        private System.Windows.Forms.PictureBox PbStep1PortBinding;
        private System.Windows.Forms.Label LblTask2;
        private System.Windows.Forms.PictureBox PbStep2Firewall;
    }
}

