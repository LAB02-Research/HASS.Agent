namespace HASSAgent.Controls.Configuration
{
    partial class General
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(General));
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.TbDeviceName = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.NumDisconnectGrace = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            ((System.ComponentModel.ISupportInitialize)(this.NumDisconnectGrace)).BeginInit();
            this.SuspendLayout();
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label36.Location = new System.Drawing.Point(73, 350);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(550, 38);
            this.label36.TabIndex = 63;
            this.label36.Text = "HASS.Agent will wait a while before notifying you of disconnects from MQTT or HA\'" +
    "s API.\r\nYou can set the amount of seconds here.";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label35.Location = new System.Drawing.Point(171, 428);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(58, 19);
            this.label35.TabIndex = 62;
            this.label35.Text = "seconds";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label34.Location = new System.Drawing.Point(70, 404);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(169, 19);
            this.label34.TabIndex = 61;
            this.label34.Text = "disconnected grace period";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label33.Location = new System.Drawing.Point(73, 221);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(586, 57);
            this.label33.TabIndex = 59;
            this.label33.Text = resources.GetString("label33.Text");
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label32.Location = new System.Drawing.Point(70, 99);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(534, 38);
            this.label32.TabIndex = 58;
            this.label32.Text = "Device name is used to identify your machine on HA. \r\nIt\'s also used as a prefix " +
    "for your command/sensor names (can be changed per entity).";
            // 
            // label31
            // 
            this.label31.AutoEllipsis = true;
            this.label31.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label31.Location = new System.Drawing.Point(70, 36);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(669, 44);
            this.label31.TabIndex = 57;
            this.label31.Text = "This page contains general configuration items. For more settings, browse the tab" +
    "s on the left.";
            // 
            // TbDeviceName
            // 
            this.TbDeviceName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbDeviceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbDeviceName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbDeviceName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbDeviceName.Location = new System.Drawing.Point(73, 174);
            this.TbDeviceName.Name = "TbDeviceName";
            this.TbDeviceName.Size = new System.Drawing.Size(358, 25);
            this.TbDeviceName.TabIndex = 55;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label30.Location = new System.Drawing.Point(70, 152);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(85, 19);
            this.label30.TabIndex = 56;
            this.label30.Text = "device name";
            // 
            // NumDisconnectGrace
            // 
            this.NumDisconnectGrace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.NumDisconnectGrace.BeforeTouchSize = new System.Drawing.Size(92, 25);
            this.NumDisconnectGrace.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.NumDisconnectGrace.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.NumDisconnectGrace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumDisconnectGrace.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumDisconnectGrace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.NumDisconnectGrace.Location = new System.Drawing.Point(73, 426);
            this.NumDisconnectGrace.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.NumDisconnectGrace.MaxLength = 10;
            this.NumDisconnectGrace.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumDisconnectGrace.Name = "NumDisconnectGrace";
            this.NumDisconnectGrace.Size = new System.Drawing.Size(92, 25);
            this.NumDisconnectGrace.TabIndex = 64;
            this.NumDisconnectGrace.ThemeName = "Metro";
            this.NumDisconnectGrace.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.NumDisconnectGrace.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // General
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.NumDisconnectGrace);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.TbDeviceName);
            this.Controls.Add(this.label30);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "General";
            this.Size = new System.Drawing.Size(740, 544);
            this.Load += new System.EventHandler(this.General_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumDisconnectGrace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        internal System.Windows.Forms.TextBox TbDeviceName;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumDisconnectGrace;
    }
}
