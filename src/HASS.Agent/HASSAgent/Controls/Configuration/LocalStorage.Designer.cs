using System.Globalization;

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
            this.TbIntImageRetention = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TbIntImageRetention)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnClearImageCache
            // 
            this.BtnClearImageCache.AccessibleName = "Button";
            this.BtnClearImageCache.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClearImageCache.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClearImageCache.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClearImageCache.Location = new System.Drawing.Point(436, 92);
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
            this.BtnOpenImageCache.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpenImageCache.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnOpenImageCache.Location = new System.Drawing.Point(508, 203);
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
            this.TbImageCacheLocation.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbImageCacheLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbImageCacheLocation.Location = new System.Drawing.Point(94, 172);
            this.TbImageCacheLocation.Name = "TbImageCacheLocation";
            this.TbImageCacheLocation.ReadOnly = true;
            this.TbImageCacheLocation.Size = new System.Drawing.Size(539, 25);
            this.TbImageCacheLocation.TabIndex = 34;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(91, 152);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(131, 17);
            this.label21.TabIndex = 33;
            this.label21.Text = "image cache location";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(170, 96);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 17);
            this.label20.TabIndex = 32;
            this.label20.Text = "days";
            // 
            // TbIntImageRetention
            // 
            this.TbIntImageRetention.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbIntImageRetention.BeforeTouchSize = new System.Drawing.Size(67, 25);
            this.TbIntImageRetention.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntImageRetention.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbIntImageRetention.CurrentCultureRefresh = true;
            this.TbIntImageRetention.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntImageRetention.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbIntImageRetention.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntImageRetention.IntegerValue = ((long)(7));
            this.TbIntImageRetention.Location = new System.Drawing.Point(94, 92);
            this.TbIntImageRetention.MaxValue = ((long)(365));
            this.TbIntImageRetention.Metrocolor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntImageRetention.MinValue = ((long)(0));
            this.TbIntImageRetention.Name = "TbIntImageRetention";
            this.TbIntImageRetention.PositiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntImageRetention.Size = new System.Drawing.Size(67, 25);
            this.TbIntImageRetention.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.InstalledCulture;
            this.TbIntImageRetention.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro;
            this.TbIntImageRetention.TabIndex = 31;
            this.TbIntImageRetention.Text = "7";
            this.TbIntImageRetention.ThemeName = "Metro";
            this.TbIntImageRetention.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbIntImageRetention.ThemeStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntImageRetention.ThemeStyle.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntImageRetention.ThemeStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntImageRetention.ThemeStyle.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.TbIntImageRetention.ThemeStyle.ZeroForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbIntImageRetention.ZeroColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(27, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(634, 46);
            this.label19.TabIndex = 30;
            this.label19.Text = "Images shown in notifications have to be temporarily stored locally. You can conf" +
    "igure the amount of days they should be kept before HASS.Agent deletes them. Ent" +
    "er \'0\' to keep them permanently.";
            // 
            // LocalStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.BtnClearImageCache);
            this.Controls.Add(this.BtnOpenImageCache);
            this.Controls.Add(this.TbImageCacheLocation);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.TbIntImageRetention);
            this.Controls.Add(this.label19);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LocalStorage";
            this.Size = new System.Drawing.Size(700, 457);
            ((System.ComponentModel.ISupportInitialize)(this.TbIntImageRetention)).EndInit();
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
        internal Syncfusion.Windows.Forms.Tools.IntegerTextBox TbIntImageRetention;
    }
}
