using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Onboarding
{
    partial class OnboardingStartup
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
            this.PbHassAgentLogo = new System.Windows.Forms.PictureBox();
            this.BtnSetLaunchOnLogin = new Syncfusion.WinForms.Controls.SfButton();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.LblCreateInfo = new System.Windows.Forms.Label();
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
            // BtnSetLaunchOnLogin
            // 
            this.BtnSetLaunchOnLogin.AccessibleDescription = "Enables (when disabled) launching HASS.Agent when you login to Windows.";
            this.BtnSetLaunchOnLogin.AccessibleName = "Enable launch on login";
            this.BtnSetLaunchOnLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnSetLaunchOnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSetLaunchOnLogin.Enabled = false;
            this.BtnSetLaunchOnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSetLaunchOnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSetLaunchOnLogin.Location = new System.Drawing.Point(180, 277);
            this.BtnSetLaunchOnLogin.Name = "BtnSetLaunchOnLogin";
            this.BtnSetLaunchOnLogin.Size = new System.Drawing.Size(402, 31);
            this.BtnSetLaunchOnLogin.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSetLaunchOnLogin.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSetLaunchOnLogin.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSetLaunchOnLogin.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSetLaunchOnLogin.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSetLaunchOnLogin.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSetLaunchOnLogin.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnSetLaunchOnLogin.TabIndex = 0;
            this.BtnSetLaunchOnLogin.Text = global::HASS.Agent.Resources.Localization.Languages.OnboardingStartup_BtnSetLaunchOnLogin;
            this.BtnSetLaunchOnLogin.UseVisualStyleBackColor = false;
            this.BtnSetLaunchOnLogin.Click += new System.EventHandler(this.BtnSetLaunchOnLogin_Click);
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "Startup information.";
            this.LblInfo1.AccessibleName = "Information";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(180, 20);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(570, 128);
            this.LblInfo1.TabIndex = 5;
            this.LblInfo1.Text = Languages.OnboardingStartup_LblInfo1;
            // 
            // LblCreateInfo
            // 
            this.LblCreateInfo.AccessibleDescription = "Label containing the current \"launch on login\" state. Content changes.";
            this.LblCreateInfo.AccessibleName = "Startup state info";
            this.LblCreateInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblCreateInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblCreateInfo.Location = new System.Drawing.Point(180, 190);
            this.LblCreateInfo.Name = "LblCreateInfo";
            this.LblCreateInfo.Size = new System.Drawing.Size(405, 56);
            this.LblCreateInfo.TabIndex = 6;
            this.LblCreateInfo.Text = Languages.OnboardingStartup_LblCreateInfo;
            // 
            // OnboardingStartup
            // 
            this.AccessibleDescription = "Panel containing the onboarding startup configuration.";
            this.AccessibleName = "Startup";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.BtnSetLaunchOnLogin);
            this.Controls.Add(this.LblCreateInfo);
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.PbHassAgentLogo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OnboardingStartup";
            this.Size = new System.Drawing.Size(803, 457);
            this.Load += new System.EventHandler(this.OnboardingStartup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PbHassAgentLogo;
        private Syncfusion.WinForms.Controls.SfButton BtnSetLaunchOnLogin;
        private System.Windows.Forms.Label LblInfo1;
        private System.Windows.Forms.Label LblCreateInfo;
    }
}
