using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Configuration
{
    partial class ConfigStartup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigStartup));
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.BtnSetStartOnLogin = new Syncfusion.WinForms.Controls.SfButton();
            this.LblStartOnLoginStatus = new System.Windows.Forms.Label();
            this.LblStartOnLoginStatusInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblInfo1
            // 
            this.LblInfo1.AutoSize = true;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(70, 36);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(575, 76);
            this.LblInfo1.TabIndex = 15;
            this.LblInfo1.Text = Languages.ConfigStartup_LblInfo1;
            // 
            // BtnSetStartOnLogin
            // 
            this.BtnSetStartOnLogin.AccessibleName = "Button";
            this.BtnSetStartOnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSetStartOnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSetStartOnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSetStartOnLogin.Location = new System.Drawing.Point(222, 294);
            this.BtnSetStartOnLogin.Name = "BtnSetStartOnLogin";
            this.BtnSetStartOnLogin.Size = new System.Drawing.Size(295, 31);
            this.BtnSetStartOnLogin.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSetStartOnLogin.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSetStartOnLogin.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSetStartOnLogin.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSetStartOnLogin.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSetStartOnLogin.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSetStartOnLogin.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnSetStartOnLogin.TabIndex = 14;
            this.BtnSetStartOnLogin.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigStartup_BtnSetStartOnLogin;
            this.BtnSetStartOnLogin.UseVisualStyleBackColor = false;
            this.BtnSetStartOnLogin.Click += new System.EventHandler(this.BtnSetStartOnLogin_Click);
            // 
            // LblStartOnLoginStatus
            // 
            this.LblStartOnLoginStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblStartOnLoginStatus.Location = new System.Drawing.Point(398, 205);
            this.LblStartOnLoginStatus.Name = "LblStartOnLoginStatus";
            this.LblStartOnLoginStatus.Size = new System.Drawing.Size(119, 19);
            this.LblStartOnLoginStatus.TabIndex = 13;
            this.LblStartOnLoginStatus.Text = "-";
            this.LblStartOnLoginStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblStartOnLoginStatusInfo
            // 
            this.LblStartOnLoginStatusInfo.AutoSize = true;
            this.LblStartOnLoginStatusInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblStartOnLoginStatusInfo.Location = new System.Drawing.Point(222, 205);
            this.LblStartOnLoginStatusInfo.Name = "LblStartOnLoginStatusInfo";
            this.LblStartOnLoginStatusInfo.Size = new System.Drawing.Size(139, 19);
            this.LblStartOnLoginStatusInfo.TabIndex = 12;
            this.LblStartOnLoginStatusInfo.Text = Languages.ConfigStartup_LblStartOnLoginStatusInfo;
            this.LblStartOnLoginStatusInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ConfigStartup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.BtnSetStartOnLogin);
            this.Controls.Add(this.LblStartOnLoginStatus);
            this.Controls.Add(this.LblStartOnLoginStatusInfo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfigStartup";
            this.Size = new System.Drawing.Size(700, 544);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblInfo1;
        private System.Windows.Forms.Label LblStartOnLoginStatusInfo;
        internal Syncfusion.WinForms.Controls.SfButton BtnSetStartOnLogin;
        internal System.Windows.Forms.Label LblStartOnLoginStatus;
    }
}
