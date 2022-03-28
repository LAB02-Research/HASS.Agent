namespace HASS.Agent.Controls.Onboarding
{
    partial class Welcome
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
            this.label1 = new System.Windows.Forms.Label();
            this.PbHassAgentLogo = new System.Windows.Forms.PictureBox();
            this.label32 = new System.Windows.Forms.Label();
            this.TbDeviceName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(180, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(466, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "It looks like this is the first time you\'ve launched HASS.Agent.\r\n\r\nIf you want, " +
    "we can go through the configuration. If not, just click \'close\'.\r\n";
            // 
            // PbHassAgentLogo
            // 
            this.PbHassAgentLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbHassAgentLogo.Image = global::HASS.Agent.Properties.Resources.logo_128;
            this.PbHassAgentLogo.Location = new System.Drawing.Point(24, 20);
            this.PbHassAgentLogo.Name = "PbHassAgentLogo";
            this.PbHassAgentLogo.Size = new System.Drawing.Size(128, 128);
            this.PbHassAgentLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbHassAgentLogo.TabIndex = 2;
            this.PbHassAgentLogo.TabStop = false;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label32.Location = new System.Drawing.Point(180, 241);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(424, 38);
            this.label32.TabIndex = 51;
            this.label32.Text = "Device name is used to identify your machine on HA. \r\nIt\'s also used as a suggest" +
    "ed prefix for your commands and sensors.\r\n";
            // 
            // TbDeviceName
            // 
            this.TbDeviceName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbDeviceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbDeviceName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbDeviceName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbDeviceName.Location = new System.Drawing.Point(183, 196);
            this.TbDeviceName.Name = "TbDeviceName";
            this.TbDeviceName.Size = new System.Drawing.Size(372, 25);
            this.TbDeviceName.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(180, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 52;
            this.label3.Text = "device name";
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.TbDeviceName);
            this.Controls.Add(this.PbHassAgentLogo);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Welcome";
            this.Size = new System.Drawing.Size(803, 457);
            this.Load += new System.EventHandler(this.Welcome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PbHassAgentLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox TbDeviceName;
        private System.Windows.Forms.Label label3;
    }
}
