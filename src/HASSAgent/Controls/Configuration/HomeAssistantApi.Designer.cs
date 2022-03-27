namespace HASSAgent.Controls.Configuration
{
    partial class HomeAssistantApi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeAssistantApi));
            this.label28 = new System.Windows.Forms.Label();
            this.TbHassClientCertificate = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.CbHassAutoClientCertificate = new System.Windows.Forms.CheckBox();
            this.BtnTestApi = new Syncfusion.WinForms.Controls.SfButton();
            this.label11 = new System.Windows.Forms.Label();
            this.TbHassApiToken = new System.Windows.Forms.TextBox();
            this.TbHassIp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label28.Location = new System.Drawing.Point(471, 340);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(191, 15);
            this.label28.TabIndex = 57;
            this.label28.Text = "tip: doubleclick this field to browse";
            // 
            // TbHassClientCertificate
            // 
            this.TbHassClientCertificate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbHassClientCertificate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbHassClientCertificate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbHassClientCertificate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbHassClientCertificate.Location = new System.Drawing.Point(177, 312);
            this.TbHassClientCertificate.Name = "TbHassClientCertificate";
            this.TbHassClientCertificate.Size = new System.Drawing.Size(484, 25);
            this.TbHassClientCertificate.TabIndex = 55;
            this.TbHassClientCertificate.DoubleClick += new System.EventHandler(this.TbHassClientCertificate_DoubleClick);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label29.Location = new System.Drawing.Point(69, 314);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(103, 19);
            this.label29.TabIndex = 56;
            this.label29.Text = "client certificate";
            // 
            // CbHassAutoClientCertificate
            // 
            this.CbHassAutoClientCertificate.AutoSize = true;
            this.CbHassAutoClientCertificate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbHassAutoClientCertificate.Location = new System.Drawing.Point(177, 378);
            this.CbHassAutoClientCertificate.Name = "CbHassAutoClientCertificate";
            this.CbHassAutoClientCertificate.Size = new System.Drawing.Size(269, 23);
            this.CbHassAutoClientCertificate.TabIndex = 54;
            this.CbHassAutoClientCertificate.Text = "use automatic client certificate selection";
            this.CbHassAutoClientCertificate.UseVisualStyleBackColor = true;
            // 
            // BtnTestApi
            // 
            this.BtnTestApi.AccessibleName = "Button";
            this.BtnTestApi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnTestApi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnTestApi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnTestApi.Location = new System.Drawing.Point(481, 420);
            this.BtnTestApi.Name = "BtnTestApi";
            this.BtnTestApi.Size = new System.Drawing.Size(180, 29);
            this.BtnTestApi.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnTestApi.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnTestApi.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnTestApi.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnTestApi.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnTestApi.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnTestApi.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnTestApi.TabIndex = 52;
            this.BtnTestApi.Text = "test connection";
            this.BtnTestApi.UseVisualStyleBackColor = false;
            this.BtnTestApi.Click += new System.EventHandler(this.BtnTestApi_Click);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(70, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(595, 86);
            this.label11.TabIndex = 53;
            this.label11.Text = resources.GetString("label11.Text");
            // 
            // TbHassApiToken
            // 
            this.TbHassApiToken.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbHassApiToken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbHassApiToken.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbHassApiToken.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbHassApiToken.Location = new System.Drawing.Point(177, 262);
            this.TbHassApiToken.Name = "TbHassApiToken";
            this.TbHassApiToken.Size = new System.Drawing.Size(484, 25);
            this.TbHassApiToken.TabIndex = 49;
            // 
            // TbHassIp
            // 
            this.TbHassIp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbHassIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbHassIp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbHassIp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbHassIp.Location = new System.Drawing.Point(178, 213);
            this.TbHassIp.Name = "TbHassIp";
            this.TbHassIp.Size = new System.Drawing.Size(484, 25);
            this.TbHassIp.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(106, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 51;
            this.label3.Text = "api token";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(106, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 50;
            this.label2.Text = "server uri";
            // 
            // HomeAssistantApi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.label28);
            this.Controls.Add(this.TbHassClientCertificate);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.CbHassAutoClientCertificate);
            this.Controls.Add(this.BtnTestApi);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TbHassApiToken);
            this.Controls.Add(this.TbHassIp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HomeAssistantApi";
            this.Size = new System.Drawing.Size(740, 544);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox TbHassClientCertificate;
        internal System.Windows.Forms.CheckBox CbHassAutoClientCertificate;
        internal Syncfusion.WinForms.Controls.SfButton BtnTestApi;
        internal System.Windows.Forms.TextBox TbHassApiToken;
        internal System.Windows.Forms.TextBox TbHassIp;
    }
}
