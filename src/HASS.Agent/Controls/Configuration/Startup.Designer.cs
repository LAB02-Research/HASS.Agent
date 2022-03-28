namespace HASS.Agent.Controls.Configuration
{
    partial class Startup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Startup));
            this.label15 = new System.Windows.Forms.Label();
            this.BtnSetStartOnLogin = new Syncfusion.WinForms.Controls.SfButton();
            this.LblStartOnLoginStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(70, 36);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(580, 87);
            this.label15.TabIndex = 15;
            this.label15.Text = resources.GetString("label15.Text");
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
            this.BtnSetStartOnLogin.Text = "enable start-on-login";
            this.BtnSetStartOnLogin.UseVisualStyleBackColor = false;
            this.BtnSetStartOnLogin.Click += new System.EventHandler(this.BtnSetStartOnLogin_Click);
            // 
            // LblStartOnLoginStatus
            // 
            this.LblStartOnLoginStatus.AutoSize = true;
            this.LblStartOnLoginStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblStartOnLoginStatus.Location = new System.Drawing.Point(398, 205);
            this.LblStartOnLoginStatus.Name = "LblStartOnLoginStatus";
            this.LblStartOnLoginStatus.Size = new System.Drawing.Size(15, 19);
            this.LblStartOnLoginStatus.TabIndex = 13;
            this.LblStartOnLoginStatus.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(222, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "start-on-login status:";
            // 
            // Startup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.label15);
            this.Controls.Add(this.BtnSetStartOnLogin);
            this.Controls.Add(this.LblStartOnLoginStatus);
            this.Controls.Add(this.label4);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Startup";
            this.Size = new System.Drawing.Size(740, 544);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label4;
        internal Syncfusion.WinForms.Controls.SfButton BtnSetStartOnLogin;
        internal System.Windows.Forms.Label LblStartOnLoginStatus;
    }
}
