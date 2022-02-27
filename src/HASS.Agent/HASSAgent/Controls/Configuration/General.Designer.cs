using System.Globalization;

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
            this.TbDisconnectGrace = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.TbDeviceName = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TbDisconnectGrace)).BeginInit();
            this.SuspendLayout();
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(99, 289);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(522, 34);
            this.label36.TabIndex = 63;
            this.label36.Text = "HASS.Agent will wait a while before notifying you of disconnects from MQTT or HA\'" +
    "s API.\r\nYou can set the amount of seconds here.";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(200, 359);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(56, 17);
            this.label35.TabIndex = 62;
            this.label35.Text = "seconds";
            // 
            // TbDisconnectGrace
            // 
            this.TbDisconnectGrace.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbDisconnectGrace.BeforeTouchSize = new System.Drawing.Size(92, 25);
            this.TbDisconnectGrace.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbDisconnectGrace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbDisconnectGrace.CurrentCultureRefresh = true;
            this.TbDisconnectGrace.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbDisconnectGrace.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbDisconnectGrace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbDisconnectGrace.IntegerValue = ((long)(60));
            this.TbDisconnectGrace.Location = new System.Drawing.Point(102, 357);
            this.TbDisconnectGrace.MaxValue = ((long)(66000));
            this.TbDisconnectGrace.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbDisconnectGrace.MinValue = ((long)(1));
            this.TbDisconnectGrace.Name = "TbDisconnectGrace";
            this.TbDisconnectGrace.PositiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbDisconnectGrace.Size = new System.Drawing.Size(92, 25);
            this.TbDisconnectGrace.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.InstalledCulture;
            this.TbDisconnectGrace.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.TbDisconnectGrace.TabIndex = 60;
            this.TbDisconnectGrace.Text = "60";
            this.TbDisconnectGrace.ThemeName = "Metro";
            this.TbDisconnectGrace.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbDisconnectGrace.ThemeStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbDisconnectGrace.ThemeStyle.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbDisconnectGrace.ThemeStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbDisconnectGrace.ThemeStyle.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbDisconnectGrace.ThemeStyle.ZeroForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbDisconnectGrace.ZeroColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(99, 335);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(165, 17);
            this.label34.TabIndex = 61;
            this.label34.Text = "disconnected grace period";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(99, 186);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(555, 51);
            this.label33.TabIndex = 59;
            this.label33.Text = resources.GetString("label33.Text");
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(99, 80);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(515, 34);
            this.label32.TabIndex = 58;
            this.label32.Text = "Device name is used to identify your machine on HA. \r\nIt\'s also used as a prefix " +
    "for your command/sensor names (can be changed per entity).";
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(27, 19);
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
            this.TbDeviceName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbDeviceName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbDeviceName.Location = new System.Drawing.Point(102, 147);
            this.TbDeviceName.Name = "TbDeviceName";
            this.TbDeviceName.Size = new System.Drawing.Size(358, 25);
            this.TbDeviceName.TabIndex = 55;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(99, 127);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(81, 17);
            this.label30.TabIndex = 56;
            this.label30.Text = "device name";
            // 
            // General
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.TbDisconnectGrace);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.TbDeviceName);
            this.Controls.Add(this.label30);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "General";
            this.Size = new System.Drawing.Size(700, 457);
            ((System.ComponentModel.ISupportInitialize)(this.TbDisconnectGrace)).EndInit();
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
        internal Syncfusion.Windows.Forms.Tools.IntegerTextBox TbDisconnectGrace;
        internal System.Windows.Forms.TextBox TbDeviceName;
    }
}
