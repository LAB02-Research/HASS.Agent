using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Onboarding
{
    partial class OnboardingWelcome
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
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.PbHassAgentLogo = new System.Windows.Forms.PictureBox();
            this.LblInfo2 = new System.Windows.Forms.Label();
            this.TbDeviceName = new System.Windows.Forms.TextBox();
            this.LblDeviceName = new System.Windows.Forms.Label();
            this.CbLanguage = new System.Windows.Forms.ComboBox();
            this.LblInterfaceLangauge = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "Welcome information.";
            this.LblInfo1.AccessibleName = "Information";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(180, 20);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(588, 103);
            this.LblInfo1.TabIndex = 0;
            this.LblInfo1.Text = Languages.OnboardingWelcome_LblInfo1;
            // 
            // PbHassAgentLogo
            // 
            this.PbHassAgentLogo.AccessibleDescription = "HASS Agent logo image.";
            this.PbHassAgentLogo.AccessibleName = "HASS Agent logo";
            this.PbHassAgentLogo.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbHassAgentLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbHassAgentLogo.Image = global::HASS.Agent.Properties.Resources.logo_128;
            this.PbHassAgentLogo.Location = new System.Drawing.Point(24, 20);
            this.PbHassAgentLogo.Name = "PbHassAgentLogo";
            this.PbHassAgentLogo.Size = new System.Drawing.Size(128, 128);
            this.PbHassAgentLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbHassAgentLogo.TabIndex = 2;
            this.PbHassAgentLogo.TabStop = false;
            // 
            // LblInfo2
            // 
            this.LblInfo2.AccessibleDescription = "Device name usage information.";
            this.LblInfo2.AccessibleName = "Device name extra info";
            this.LblInfo2.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo2.Location = new System.Drawing.Point(177, 332);
            this.LblInfo2.Name = "LblInfo2";
            this.LblInfo2.Size = new System.Drawing.Size(591, 82);
            this.LblInfo2.TabIndex = 51;
            this.LblInfo2.Text = Languages.OnboardingWelcome_LblInfo2;
            // 
            // TbDeviceName
            // 
            this.TbDeviceName.AccessibleDescription = "The name as which this device will show up in Home Assistant.";
            this.TbDeviceName.AccessibleName = "Device name";
            this.TbDeviceName.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbDeviceName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbDeviceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbDeviceName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbDeviceName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbDeviceName.Location = new System.Drawing.Point(180, 287);
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
            this.LblDeviceName.Location = new System.Drawing.Point(177, 265);
            this.LblDeviceName.Name = "LblDeviceName";
            this.LblDeviceName.Size = new System.Drawing.Size(85, 19);
            this.LblDeviceName.TabIndex = 52;
            this.LblDeviceName.Text = Languages.OnboardingWelcome_LblDeviceName;
            // 
            // CbLanguage
            // 
            this.CbLanguage.AccessibleDescription = "List of available interface languages.";
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
            this.CbLanguage.Location = new System.Drawing.Point(180, 177);
            this.CbLanguage.Name = "CbLanguage";
            this.CbLanguage.Size = new System.Drawing.Size(358, 26);
            this.CbLanguage.Sorted = true;
            this.CbLanguage.TabIndex = 0;
            this.CbLanguage.SelectedIndexChanged += new System.EventHandler(this.CbLanguage_SelectedIndexChanged);
            // 
            // LblInterfaceLangauge
            // 
            this.LblInterfaceLangauge.AccessibleDescription = "Interface language dropdown description.";
            this.LblInterfaceLangauge.AccessibleName = "Interface language info";
            this.LblInterfaceLangauge.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInterfaceLangauge.AutoSize = true;
            this.LblInterfaceLangauge.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInterfaceLangauge.Location = new System.Drawing.Point(177, 155);
            this.LblInterfaceLangauge.Name = "LblInterfaceLangauge";
            this.LblInterfaceLangauge.Size = new System.Drawing.Size(121, 19);
            this.LblInterfaceLangauge.TabIndex = 67;
            this.LblInterfaceLangauge.Text = Languages.OnboardingWelcome_LblInterfaceLangauge;
            // 
            // OnboardingWelcome
            // 
            this.AccessibleDescription = "Panel containing the initial onboarding info.";
            this.AccessibleName = "Welcome";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.CbLanguage);
            this.Controls.Add(this.LblInterfaceLangauge);
            this.Controls.Add(this.LblDeviceName);
            this.Controls.Add(this.LblInfo2);
            this.Controls.Add(this.TbDeviceName);
            this.Controls.Add(this.PbHassAgentLogo);
            this.Controls.Add(this.LblInfo1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OnboardingWelcome";
            this.Size = new System.Drawing.Size(803, 457);
            this.Load += new System.EventHandler(this.OnboardingWelcome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PbHassAgentLogo;
        private System.Windows.Forms.Label LblInfo1;
        private System.Windows.Forms.Label LblInfo2;
        private System.Windows.Forms.TextBox TbDeviceName;
        private System.Windows.Forms.Label LblDeviceName;
        internal ComboBox CbLanguage;
        private Label LblInterfaceLangauge;
    }
}
