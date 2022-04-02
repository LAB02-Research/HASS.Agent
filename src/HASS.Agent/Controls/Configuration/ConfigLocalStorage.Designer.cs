using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Configuration
{
    partial class ConfigLocalStorage
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
            this.LblCacheLocations = new System.Windows.Forms.Label();
            this.LblCacheDays = new System.Windows.Forms.Label();
            this.LblInfo1 = new System.Windows.Forms.Label();
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
            this.BtnClearImageCache.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigLocalStorage_BtnClearImageCache;
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
            this.BtnOpenImageCache.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigLocalStorage_BtnOpenImageCache;
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
            // LblCacheLocations
            // 
            this.LblCacheLocations.AutoSize = true;
            this.LblCacheLocations.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblCacheLocations.Location = new System.Drawing.Point(101, 212);
            this.LblCacheLocations.Name = "LblCacheLocations";
            this.LblCacheLocations.Size = new System.Drawing.Size(136, 19);
            this.LblCacheLocations.TabIndex = 33;
            this.LblCacheLocations.Text = Languages.ConfigLocalStorage_LblCacheLocations;
            // 
            // LblCacheDays
            // 
            this.LblCacheDays.AutoSize = true;
            this.LblCacheDays.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblCacheDays.Location = new System.Drawing.Point(190, 158);
            this.LblCacheDays.Name = "LblCacheDays";
            this.LblCacheDays.Size = new System.Drawing.Size(37, 19);
            this.LblCacheDays.TabIndex = 32;
            this.LblCacheDays.Text = Languages.ConfigLocalStorage_LblCacheDays;
            // 
            // LblInfo1
            // 
            this.LblInfo1.AutoSize = true;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(70, 36);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(625, 38);
            this.LblInfo1.TabIndex = 30;
            this.LblInfo1.Text = Languages.ConfigLocalStorage_LblInfo1;
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
            // ConfigLocalStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.NumImageRetention);
            this.Controls.Add(this.BtnClearImageCache);
            this.Controls.Add(this.BtnOpenImageCache);
            this.Controls.Add(this.TbImageCacheLocation);
            this.Controls.Add(this.LblCacheLocations);
            this.Controls.Add(this.LblCacheDays);
            this.Controls.Add(this.LblInfo1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfigLocalStorage";
            this.Size = new System.Drawing.Size(700, 544);
            ((System.ComponentModel.ISupportInitialize)(this.NumImageRetention)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblCacheLocations;
        private System.Windows.Forms.Label LblCacheDays;
        private System.Windows.Forms.Label LblInfo1;
        internal Syncfusion.WinForms.Controls.SfButton BtnClearImageCache;
        internal Syncfusion.WinForms.Controls.SfButton BtnOpenImageCache;
        internal System.Windows.Forms.TextBox TbImageCacheLocation;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumImageRetention;
    }
}
