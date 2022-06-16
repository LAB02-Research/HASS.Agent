using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Configuration
{
    partial class ConfigGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigGeneral));
            this.LblInfo4 = new System.Windows.Forms.Label();
            this.LblDisconGraceSeconds = new System.Windows.Forms.Label();
            this.LblDisconGracePeriod = new System.Windows.Forms.Label();
            this.LblInfo3 = new System.Windows.Forms.Label();
            this.LblInfo2 = new System.Windows.Forms.Label();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.TbDeviceName = new System.Windows.Forms.TextBox();
            this.LblDeviceName = new System.Windows.Forms.Label();
            this.NumDisconnectGrace = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.LblInterfaceLangauge = new System.Windows.Forms.Label();
            this.CbLanguage = new System.Windows.Forms.ComboBox();
            this.PbLine1 = new System.Windows.Forms.PictureBox();
            this.PbLine2 = new System.Windows.Forms.PictureBox();
            this.PbLine3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumDisconnectGrace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLine2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLine3)).BeginInit();
            this.SuspendLayout();
            // 
            // LblInfo4
            // 
            this.LblInfo4.AccessibleDescription = "Disconnected grace period introduction.";
            this.LblInfo4.AccessibleName = "Disconnected grace period introduction";
            this.LblInfo4.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo4.Location = new System.Drawing.Point(73, 436);
            this.LblInfo4.Name = "LblInfo4";
            this.LblInfo4.Size = new System.Drawing.Size(580, 38);
            this.LblInfo4.TabIndex = 63;
            this.LblInfo4.Text = Languages.ConfigGeneral_LblInfo4;
            // 
            // LblDisconGraceSeconds
            // 
            this.LblDisconGraceSeconds.AccessibleDescription = "Disconnected grace period time unit.";
            this.LblDisconGraceSeconds.AccessibleName = "Disconnected grace time unit";
            this.LblDisconGraceSeconds.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblDisconGraceSeconds.AutoSize = true;
            this.LblDisconGraceSeconds.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDisconGraceSeconds.Location = new System.Drawing.Point(171, 514);
            this.LblDisconGraceSeconds.Name = "LblDisconGraceSeconds";
            this.LblDisconGraceSeconds.Size = new System.Drawing.Size(58, 19);
            this.LblDisconGraceSeconds.TabIndex = 62;
            this.LblDisconGraceSeconds.Text = Languages.ConfigGeneral_LblDisconGraceSeconds;
            // 
            // LblDisconGracePeriod
            // 
            this.LblDisconGracePeriod.AccessibleDescription = "Disconnected grace period numeric textbox description.";
            this.LblDisconGracePeriod.AccessibleName = "Disconnected grace period";
            this.LblDisconGracePeriod.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblDisconGracePeriod.AutoSize = true;
            this.LblDisconGracePeriod.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDisconGracePeriod.Location = new System.Drawing.Point(70, 490);
            this.LblDisconGracePeriod.Name = "LblDisconGracePeriod";
            this.LblDisconGracePeriod.Size = new System.Drawing.Size(169, 19);
            this.LblDisconGracePeriod.TabIndex = 61;
            this.LblDisconGracePeriod.Text = Languages.ConfigGeneral_LblDisconGracePeriod;
            // 
            // LblInfo3
            // 
            this.LblInfo3.AccessibleDescription = "Device name extra info.";
            this.LblInfo3.AccessibleName = "Device name extra info";
            this.LblInfo3.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo3.Location = new System.Drawing.Point(73, 315);
            this.LblInfo3.Name = "LblInfo3";
            this.LblInfo3.Size = new System.Drawing.Size(592, 57);
            this.LblInfo3.TabIndex = 59;
            this.LblInfo3.Text = Languages.ConfigGeneral_LblInfo3;
            // 
            // LblInfo2
            // 
            this.LblInfo2.AccessibleDescription = "Device name introduction information.";
            this.LblInfo2.AccessibleName = "Device name introduction";
            this.LblInfo2.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo2.Location = new System.Drawing.Point(70, 193);
            this.LblInfo2.Name = "LblInfo2";
            this.LblInfo2.Size = new System.Drawing.Size(583, 38);
            this.LblInfo2.TabIndex = 58;
            this.LblInfo2.Text = Languages.ConfigGeneral_LblInfo2;
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "General information.";
            this.LblInfo1.AccessibleName = "Information";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.AutoEllipsis = true;
            this.LblInfo1.AutoSize = true;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(70, 36);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(583, 19);
            this.LblInfo1.TabIndex = 57;
            this.LblInfo1.Text = Languages.ConfigGeneral_LblInfo1;
            // 
            // TbDeviceName
            // 
            this.TbDeviceName.AccessibleDescription = "The device\'s name in Home Assistant.";
            this.TbDeviceName.AccessibleName = "Device name";
            this.TbDeviceName.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbDeviceName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbDeviceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbDeviceName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbDeviceName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbDeviceName.Location = new System.Drawing.Point(73, 268);
            this.TbDeviceName.Name = "TbDeviceName";
            this.TbDeviceName.Size = new System.Drawing.Size(358, 25);
            this.TbDeviceName.TabIndex = 1;
            // 
            // LblDeviceName
            // 
            this.LblDeviceName.AccessibleDescription = "Device name textbox description.";
            this.LblDeviceName.AccessibleName = "Device name info";
            this.LblDeviceName.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblDeviceName.AutoSize = true;
            this.LblDeviceName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDeviceName.Location = new System.Drawing.Point(70, 246);
            this.LblDeviceName.Name = "LblDeviceName";
            this.LblDeviceName.Size = new System.Drawing.Size(85, 19);
            this.LblDeviceName.TabIndex = 56;
            this.LblDeviceName.Text = Languages.ConfigGeneral_LblDeviceName;
            // 
            // NumDisconnectGrace
            // 
            this.NumDisconnectGrace.AccessibleDescription = "The amount of seconds HASS.Agent will wait before notifying about disconnects. On" +
    "ly accepts numeric values.";
            this.NumDisconnectGrace.AccessibleName = "Disconnected grace period numeric";
            this.NumDisconnectGrace.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.NumDisconnectGrace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.NumDisconnectGrace.BeforeTouchSize = new System.Drawing.Size(92, 25);
            this.NumDisconnectGrace.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.NumDisconnectGrace.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.NumDisconnectGrace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumDisconnectGrace.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumDisconnectGrace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.NumDisconnectGrace.Location = new System.Drawing.Point(73, 512);
            this.NumDisconnectGrace.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.NumDisconnectGrace.MaxLength = 10;
            this.NumDisconnectGrace.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumDisconnectGrace.Name = "NumDisconnectGrace";
            this.NumDisconnectGrace.Size = new System.Drawing.Size(92, 25);
            this.NumDisconnectGrace.TabIndex = 2;
            this.NumDisconnectGrace.ThemeName = "Metro";
            this.NumDisconnectGrace.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.NumDisconnectGrace.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // LblInterfaceLangauge
            // 
            this.LblInterfaceLangauge.AccessibleDescription = "Interface language droplist description.";
            this.LblInterfaceLangauge.AccessibleName = "Interface language info";
            this.LblInterfaceLangauge.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInterfaceLangauge.AutoSize = true;
            this.LblInterfaceLangauge.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInterfaceLangauge.Location = new System.Drawing.Point(70, 95);
            this.LblInterfaceLangauge.Name = "LblInterfaceLangauge";
            this.LblInterfaceLangauge.Size = new System.Drawing.Size(121, 19);
            this.LblInterfaceLangauge.TabIndex = 65;
            this.LblInterfaceLangauge.Text = Languages.ConfigGeneral_LblInterfaceLangauge;
            // 
            // CbLanguage
            // 
            this.CbLanguage.AccessibleDescription = "HASS.Agent\'s interface language.";
            this.CbLanguage.AccessibleName = "Interface language";
            this.CbLanguage.AccessibleRole = System.Windows.Forms.AccessibleRole.DropList;
            this.CbLanguage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CbLanguage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CbLanguage.DropDownHeight = 300;
            this.CbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbLanguage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbLanguage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.CbLanguage.FormattingEnabled = true;
            this.CbLanguage.IntegralHeight = false;
            this.CbLanguage.Location = new System.Drawing.Point(73, 117);
            this.CbLanguage.Name = "CbLanguage";
            this.CbLanguage.Size = new System.Drawing.Size(358, 26);
            this.CbLanguage.Sorted = true;
            this.CbLanguage.TabIndex = 0;
            // 
            // PbLine1
            // 
            this.PbLine1.AccessibleDescription = "Seperator line.";
            this.PbLine1.AccessibleName = "Seperator";
            this.PbLine1.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbLine1.Image = global::HASS.Agent.Properties.Resources.line;
            this.PbLine1.Location = new System.Drawing.Point(73, 77);
            this.PbLine1.Name = "PbLine1";
            this.PbLine1.Size = new System.Drawing.Size(576, 1);
            this.PbLine1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbLine1.TabIndex = 67;
            this.PbLine1.TabStop = false;
            // 
            // PbLine2
            // 
            this.PbLine2.AccessibleDescription = "Seperator line.";
            this.PbLine2.AccessibleName = "Seperator";
            this.PbLine2.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbLine2.Image = global::HASS.Agent.Properties.Resources.line;
            this.PbLine2.Location = new System.Drawing.Point(73, 174);
            this.PbLine2.Name = "PbLine2";
            this.PbLine2.Size = new System.Drawing.Size(576, 1);
            this.PbLine2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbLine2.TabIndex = 68;
            this.PbLine2.TabStop = false;
            // 
            // PbLine3
            // 
            this.PbLine3.AccessibleDescription = "Seperator line.";
            this.PbLine3.AccessibleName = "Seperator";
            this.PbLine3.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbLine3.Image = global::HASS.Agent.Properties.Resources.line;
            this.PbLine3.Location = new System.Drawing.Point(73, 403);
            this.PbLine3.Name = "PbLine3";
            this.PbLine3.Size = new System.Drawing.Size(576, 1);
            this.PbLine3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbLine3.TabIndex = 69;
            this.PbLine3.TabStop = false;
            // 
            // ConfigGeneral
            // 
            this.AccessibleDescription = "Panel containing general configuration options.";
            this.AccessibleName = "General configuration";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.PbLine3);
            this.Controls.Add(this.PbLine2);
            this.Controls.Add(this.PbLine1);
            this.Controls.Add(this.CbLanguage);
            this.Controls.Add(this.LblInterfaceLangauge);
            this.Controls.Add(this.NumDisconnectGrace);
            this.Controls.Add(this.LblInfo4);
            this.Controls.Add(this.LblDisconGraceSeconds);
            this.Controls.Add(this.LblDisconGracePeriod);
            this.Controls.Add(this.LblInfo3);
            this.Controls.Add(this.LblInfo2);
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.TbDeviceName);
            this.Controls.Add(this.LblDeviceName);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfigGeneral";
            this.Size = new System.Drawing.Size(700, 592);
            this.Load += new System.EventHandler(this.ConfigGeneral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumDisconnectGrace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLine2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLine3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblInfo4;
        private System.Windows.Forms.Label LblDisconGraceSeconds;
        private System.Windows.Forms.Label LblDisconGracePeriod;
        private System.Windows.Forms.Label LblInfo3;
        private System.Windows.Forms.Label LblInfo2;
        private System.Windows.Forms.Label LblInfo1;
        private System.Windows.Forms.Label LblDeviceName;
        internal System.Windows.Forms.TextBox TbDeviceName;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumDisconnectGrace;
        private Label LblInterfaceLangauge;
        internal ComboBox CbLanguage;
        private PictureBox PbLine1;
        private PictureBox PbLine2;
        private PictureBox PbLine3;
    }
}
