namespace HASSAgent.Controls.Configuration
{
    partial class LocalStorage
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
            this.BtnClearImageCache = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnOpenImageCache = new Syncfusion.WinForms.Controls.SfButton();
            this.TbImageCacheLocation = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.NumImageRetention = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            ((System.ComponentModel.ISupportInitialize)(this.NumImageRetention)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnClearImageCache
            // 
            this.BtnClearImageCache.AccessibleName = "Button";
            this.BtnClearImageCache.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClearImageCache.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnClearImageCache.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClearImageCache.Location = new System.Drawing.Point(443, 154);
            this.BtnClearImageCache.Name = "BtnClearImageCache";
            this.BtnClearImageCache.Size = new System.Drawing.Size(197, 25);
            this.BtnClearImageCache.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClearImageCache.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClearImageCache.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClearImageCache.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClearImageCache.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClearImageCache.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClearImageCache.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnClearImageCache.TabIndex = 36;
            this.BtnClearImageCache.Text = "clear image cache";
            this.BtnClearImageCache.UseVisualStyleBackColor = false;
            this.BtnClearImageCache.Click += new System.EventHandler(this.BtnClearImageCache_Click);
            // 
            // BtnOpenImageCache
            // 
            this.BtnOpenImageCache.AccessibleName = "Button";
            this.BtnOpenImageCache.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnOpenImageCache.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnOpenImageCache.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnOpenImageCache.Location = new System.Drawing.Point(515, 265);
            this.BtnOpenImageCache.Name = "BtnOpenImageCache";
            this.BtnOpenImageCache.Size = new System.Drawing.Size(125, 25);
            this.BtnOpenImageCache.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnOpenImageCache.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnOpenImageCache.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnOpenImageCache.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnOpenImageCache.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnOpenImageCache.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnOpenImageCache.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnOpenImageCache.TabIndex = 35;
            this.BtnOpenImageCache.Text = "open folder";
            this.BtnOpenImageCache.UseVisualStyleBackColor = false;
            this.BtnOpenImageCache.Click += new System.EventHandler(this.BtnOpenImageCache_Click);
            // 
            // TbImageCacheLocation
            // 
            this.TbImageCacheLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbImageCacheLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbImageCacheLocation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbImageCacheLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbImageCacheLocation.Location = new System.Drawing.Point(101, 234);
            this.TbImageCacheLocation.Name = "TbImageCacheLocation";
            this.TbImageCacheLocation.ReadOnly = true;
            this.TbImageCacheLocation.Size = new System.Drawing.Size(539, 25);
            this.TbImageCacheLocation.TabIndex = 34;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label21.Location = new System.Drawing.Point(101, 212);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(136, 19);
            this.label21.TabIndex = 33;
            this.label21.Text = "image cache location";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label20.Location = new System.Drawing.Point(190, 158);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 19);
            this.label20.TabIndex = 32;
            this.label20.Text = "days";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label19.Location = new System.Drawing.Point(70, 36);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(634, 46);
            this.label19.TabIndex = 30;
            this.label19.Text = "Images shown in notifications have to be temporarily stored locally. You can conf" +
    "igure the amount of days they should be kept before HASS.Agent deletes them. Ent" +
    "er \'0\' to keep them permanently.";
            // 
            // NumImageRetention
            // 
            this.NumImageRetention.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.NumImageRetention.BeforeTouchSize = new System.Drawing.Size(83, 25);
            this.NumImageRetention.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.NumImageRetention.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.NumImageRetention.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumImageRetention.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumImageRetention.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.NumImageRetention.Location = new System.Drawing.Point(101, 156);
            this.NumImageRetention.Maximum = new decimal(new int[] {
            3650,
            0,
            0,
            0});
            this.NumImageRetention.MaxLength = 10;
            this.NumImageRetention.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumImageRetention.Name = "NumImageRetention";
            this.NumImageRetention.Size = new System.Drawing.Size(83, 25);
            this.NumImageRetention.TabIndex = 37;
            this.NumImageRetention.ThemeName = "Metro";
            this.NumImageRetention.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.NumImageRetention.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // LocalStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.NumImageRetention);
            this.Controls.Add(this.BtnClearImageCache);
            this.Controls.Add(this.BtnOpenImageCache);
            this.Controls.Add(this.TbImageCacheLocation);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LocalStorage";
            this.Size = new System.Drawing.Size(740, 544);
            ((System.ComponentModel.ISupportInitialize)(this.NumImageRetention)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        internal Syncfusion.WinForms.Controls.SfButton BtnClearImageCache;
        internal Syncfusion.WinForms.Controls.SfButton BtnOpenImageCache;
        internal System.Windows.Forms.TextBox TbImageCacheLocation;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumImageRetention;
    }
}
