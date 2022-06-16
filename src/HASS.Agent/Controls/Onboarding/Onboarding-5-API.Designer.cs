using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Onboarding
{
    partial class OnboardingApi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnboardingApi));
            this.PbHassAgentLogo = new System.Windows.Forms.PictureBox();
            this.TbHassApiToken = new System.Windows.Forms.TextBox();
            this.TbHassIp = new System.Windows.Forms.TextBox();
            this.LblApiToken = new System.Windows.Forms.Label();
            this.LblServerUri = new System.Windows.Forms.Label();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.BtnTest = new Syncfusion.WinForms.Controls.SfButton();
            this.LblTip1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).BeginInit();
            this.SuspendLayout();
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
            // TbHassApiToken
            // 
            this.TbHassApiToken.AccessibleDescription = "The API token to use when connecting to your Home Assistant instance.";
            this.TbHassApiToken.AccessibleName = "API token";
            this.TbHassApiToken.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbHassApiToken.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbHassApiToken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbHassApiToken.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbHassApiToken.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbHassApiToken.Location = new System.Drawing.Point(180, 297);
            this.TbHassApiToken.Name = "TbHassApiToken";
            this.TbHassApiToken.Size = new System.Drawing.Size(392, 25);
            this.TbHassApiToken.TabIndex = 1;
            // 
            // TbHassIp
            // 
            this.TbHassIp.AccessibleDescription = "The URI of your Home Assistant instance. The default should be okay.";
            this.TbHassIp.AccessibleName = "HA URI";
            this.TbHassIp.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbHassIp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbHassIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbHassIp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbHassIp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbHassIp.Location = new System.Drawing.Point(180, 209);
            this.TbHassIp.Name = "TbHassIp";
            this.TbHassIp.Size = new System.Drawing.Size(392, 25);
            this.TbHassIp.TabIndex = 0;
            this.TbHassIp.Text = "http://hass.local:8123";
            // 
            // LblApiToken
            // 
            this.LblApiToken.AccessibleDescription = "API token textbox description.";
            this.LblApiToken.AccessibleName = "API token info";
            this.LblApiToken.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblApiToken.AutoSize = true;
            this.LblApiToken.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblApiToken.Location = new System.Drawing.Point(180, 275);
            this.LblApiToken.Name = "LblApiToken";
            this.LblApiToken.Size = new System.Drawing.Size(66, 19);
            this.LblApiToken.TabIndex = 15;
            this.LblApiToken.Text = Languages.OnboardingApi_LblApiToken;
            // 
            // LblServerUri
            // 
            this.LblServerUri.AccessibleDescription = "Home Assistant server URI textbox label";
            this.LblServerUri.AccessibleName = "URI info";
            this.LblServerUri.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblServerUri.AutoSize = true;
            this.LblServerUri.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblServerUri.Location = new System.Drawing.Point(180, 187);
            this.LblServerUri.Name = "LblServerUri";
            this.LblServerUri.Size = new System.Drawing.Size(207, 19);
            this.LblServerUri.TabIndex = 14;
            this.LblServerUri.Text = Languages.OnboardingApi_LblServerUri;
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "Home Assistant API information.";
            this.LblInfo1.AccessibleName = "Information";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(180, 20);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(584, 141);
            this.LblInfo1.TabIndex = 13;
            this.LblInfo1.Text = Languages.OnboardingApi_LblInfo1;
            // 
            // BtnTest
            // 
            this.BtnTest.AccessibleDescription = "Perform a test connection with your Home Assistant instance.";
            this.BtnTest.AccessibleName = "Test connection";
            this.BtnTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnTest.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnTest.Location = new System.Drawing.Point(392, 328);
            this.BtnTest.Name = "BtnTest";
            this.BtnTest.Size = new System.Drawing.Size(180, 23);
            this.BtnTest.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnTest.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnTest.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnTest.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnTest.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnTest.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnTest.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnTest.TabIndex = 2;
            this.BtnTest.Text = global::HASS.Agent.Resources.Localization.Languages.OnboardingApi_BtnTest;
            this.BtnTest.UseVisualStyleBackColor = false;
            this.BtnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // LblTip1
            // 
            this.LblTip1.AccessibleDescription = "Contains a configuration tip.";
            this.LblTip1.AccessibleName = "Configuration tip";
            this.LblTip1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblTip1.AutoSize = true;
            this.LblTip1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip1.Location = new System.Drawing.Point(180, 416);
            this.LblTip1.Name = "LblTip1";
            this.LblTip1.Size = new System.Drawing.Size(358, 13);
            this.LblTip1.TabIndex = 36;
            this.LblTip1.Text = Languages.OnboardingApi_LblTip1;
            // 
            // OnboardingApi
            // 
            this.AccessibleDescription = "Panel containing the onboarding Home Assistant API configuration.";
            this.AccessibleName = "Home Assistant API";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.LblTip1);
            this.Controls.Add(this.BtnTest);
            this.Controls.Add(this.TbHassApiToken);
            this.Controls.Add(this.TbHassIp);
            this.Controls.Add(this.LblApiToken);
            this.Controls.Add(this.LblServerUri);
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.PbHassAgentLogo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OnboardingApi";
            this.Size = new System.Drawing.Size(803, 457);
            this.Load += new System.EventHandler(this.OnboardingApi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PbHassAgentLogo;
        private System.Windows.Forms.TextBox TbHassApiToken;
        private System.Windows.Forms.TextBox TbHassIp;
        private System.Windows.Forms.Label LblApiToken;
        private System.Windows.Forms.Label LblServerUri;
        private System.Windows.Forms.Label LblInfo1;
        private Syncfusion.WinForms.Controls.SfButton BtnTest;
        private System.Windows.Forms.Label LblTip1;
    }
}
