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
            this.LblInfo1.AutoSize = true;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(180, 20);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(564, 114);
            this.LblInfo1.TabIndex = 13;
            this.LblInfo1.Text = Languages.OnboardingApi_LblInfo1;
            // 
            // BtnTest
            // 
            this.BtnTest.AccessibleName = "Button";
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
            this.BtnTest.Text = Languages.OnboardingApi_BtnTest;
            this.BtnTest.UseVisualStyleBackColor = false;
            this.BtnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // LblTip1
            // 
            this.LblTip1.AutoSize = true;
            this.LblTip1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip1.Location = new System.Drawing.Point(180, 416);
            this.LblTip1.Name = "LblTip1";
            this.LblTip1.Size = new System.Drawing.Size(358, 13);
            this.LblTip1.TabIndex = 36;
            this.LblTip1.Text = Languages.OnboardingApi_LblTip1;
            // 
            // API
            // 
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
            this.Name = "API";
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
