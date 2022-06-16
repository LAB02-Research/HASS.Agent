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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigLocalStorage));
            this.BtnClearImageCache = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnOpenImageCache = new Syncfusion.WinForms.Controls.SfButton();
            this.TbImageCacheLocation = new System.Windows.Forms.TextBox();
            this.LblImageCacheLocation = new System.Windows.Forms.Label();
            this.LblImageCacheDays = new System.Windows.Forms.Label();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.NumImageRetention = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.LblKeepImages = new System.Windows.Forms.Label();
            this.LblKeepAudio = new System.Windows.Forms.Label();
            this.NumAudioRetention = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.BtnClearAudioCache = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnOpenAudioCache = new Syncfusion.WinForms.Controls.SfButton();
            this.TbAudioCacheLocation = new System.Windows.Forms.TextBox();
            this.LblAudioCacheLocation = new System.Windows.Forms.Label();
            this.LblAudioCacheDays = new System.Windows.Forms.Label();
            this.PbLine1 = new System.Windows.Forms.PictureBox();
            this.PbLine2 = new System.Windows.Forms.PictureBox();
            this.PbLine3 = new System.Windows.Forms.PictureBox();
            this.BtnClearWebViewCache = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnOpenWebViewCache = new Syncfusion.WinForms.Controls.SfButton();
            this.TbWebViewCacheLocation = new System.Windows.Forms.TextBox();
            this.LblWebViewCacheLocation = new System.Windows.Forms.Label();
            this.LblKeepWebView = new System.Windows.Forms.Label();
            this.NumWebViewRetention = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.LblWebViewCacheDays = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumImageRetention)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumAudioRetention)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLine2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLine3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumWebViewRetention)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnClearImageCache
            // 
            this.BtnClearImageCache.AccessibleDescription = "Completely clears the image cache.";
            this.BtnClearImageCache.AccessibleName = "Clear image cache";
            this.BtnClearImageCache.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
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
            this.BtnClearImageCache.TabIndex = 1;
            this.BtnClearImageCache.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigLocalStorage_BtnClearImageCache;
            this.BtnClearImageCache.UseVisualStyleBackColor = false;
            this.BtnClearImageCache.Click += new System.EventHandler(this.BtnClearImageCache_Click);
            // 
            // BtnOpenImageCache
            // 
            this.BtnOpenImageCache.AccessibleDescription = "Open the image cache storage path in Explorer.";
            this.BtnOpenImageCache.AccessibleName = "Open image cache";
            this.BtnOpenImageCache.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
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
            this.BtnOpenImageCache.TabIndex = 3;
            this.BtnOpenImageCache.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigLocalStorage_BtnOpenImageCache;
            this.BtnOpenImageCache.UseVisualStyleBackColor = false;
            this.BtnOpenImageCache.Click += new System.EventHandler(this.BtnOpenImageCache_Click);
            // 
            // TbImageCacheLocation
            // 
            this.TbImageCacheLocation.AccessibleDescription = "The storage path of the image cache.";
            this.TbImageCacheLocation.AccessibleName = "Image cache location";
            this.TbImageCacheLocation.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbImageCacheLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbImageCacheLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbImageCacheLocation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbImageCacheLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbImageCacheLocation.Location = new System.Drawing.Point(101, 234);
            this.TbImageCacheLocation.Name = "TbImageCacheLocation";
            this.TbImageCacheLocation.ReadOnly = true;
            this.TbImageCacheLocation.Size = new System.Drawing.Size(539, 25);
            this.TbImageCacheLocation.TabIndex = 2;
            // 
            // LblImageCacheLocation
            // 
            this.LblImageCacheLocation.AccessibleDescription = "Image cache location textbox description.";
            this.LblImageCacheLocation.AccessibleName = "Image cache location info";
            this.LblImageCacheLocation.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblImageCacheLocation.AutoSize = true;
            this.LblImageCacheLocation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblImageCacheLocation.Location = new System.Drawing.Point(101, 212);
            this.LblImageCacheLocation.Name = "LblImageCacheLocation";
            this.LblImageCacheLocation.Size = new System.Drawing.Size(136, 19);
            this.LblImageCacheLocation.TabIndex = 33;
            this.LblImageCacheLocation.Text = Languages.ConfigLocalStorage_LblImageCacheLocation;
            // 
            // LblImageCacheDays
            // 
            this.LblImageCacheDays.AccessibleDescription = "Image cache retention time unit.";
            this.LblImageCacheDays.AccessibleName = "Image cache time unit";
            this.LblImageCacheDays.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblImageCacheDays.AutoSize = true;
            this.LblImageCacheDays.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblImageCacheDays.Location = new System.Drawing.Point(300, 158);
            this.LblImageCacheDays.Name = "LblImageCacheDays";
            this.LblImageCacheDays.Size = new System.Drawing.Size(37, 19);
            this.LblImageCacheDays.TabIndex = 32;
            this.LblImageCacheDays.Text = Languages.ConfigLocalStorage_LblImageCacheDays;
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "Local storage information.";
            this.LblInfo1.AccessibleName = "Information";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(70, 25);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(576, 76);
            this.LblInfo1.TabIndex = 30;
            this.LblInfo1.Text = Languages.ConfigLocalStorage_LblInfo1;
            // 
            // NumImageRetention
            // 
            this.NumImageRetention.AccessibleDescription = "The amount of days images will be stored before being deleted. Only accepts numer" +
    "ic values.";
            this.NumImageRetention.AccessibleName = "Image cache";
            this.NumImageRetention.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.NumImageRetention.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.NumImageRetention.BeforeTouchSize = new System.Drawing.Size(83, 25);
            this.NumImageRetention.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.NumImageRetention.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.NumImageRetention.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumImageRetention.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumImageRetention.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.NumImageRetention.Location = new System.Drawing.Point(211, 156);
            this.NumImageRetention.Maximum = new decimal(new int[] {
            3650,
            0,
            0,
            0});
            this.NumImageRetention.MaxLength = 10;
            this.NumImageRetention.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumImageRetention.Name = "NumImageRetention";
            this.NumImageRetention.Size = new System.Drawing.Size(83, 25);
            this.NumImageRetention.TabIndex = 0;
            this.NumImageRetention.ThemeName = "Metro";
            this.NumImageRetention.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.NumImageRetention.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // LblKeepImages
            // 
            this.LblKeepImages.AccessibleDescription = "Image cache retention description.";
            this.LblKeepImages.AccessibleName = "Image cache info";
            this.LblKeepImages.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblKeepImages.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblKeepImages.Location = new System.Drawing.Point(10, 158);
            this.LblKeepImages.Name = "LblKeepImages";
            this.LblKeepImages.Size = new System.Drawing.Size(195, 19);
            this.LblKeepImages.TabIndex = 38;
            this.LblKeepImages.Text = Languages.ConfigLocalStorage_LblKeepImages;
            this.LblKeepImages.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblKeepAudio
            // 
            this.LblKeepAudio.AccessibleDescription = "Audio cache retention description.";
            this.LblKeepAudio.AccessibleName = "Audio cache info";
            this.LblKeepAudio.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblKeepAudio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblKeepAudio.Location = new System.Drawing.Point(7, 365);
            this.LblKeepAudio.Name = "LblKeepAudio";
            this.LblKeepAudio.Size = new System.Drawing.Size(195, 19);
            this.LblKeepAudio.TabIndex = 45;
            this.LblKeepAudio.Text = Languages.ConfigLocalStorage_LblKeepAudio;
            this.LblKeepAudio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumAudioRetention
            // 
            this.NumAudioRetention.AccessibleDescription = "The amount of days audio will be stored before being deleted. Only accepts numeri" +
    "c values.";
            this.NumAudioRetention.AccessibleName = "Audio cache";
            this.NumAudioRetention.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.NumAudioRetention.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.NumAudioRetention.BeforeTouchSize = new System.Drawing.Size(83, 25);
            this.NumAudioRetention.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.NumAudioRetention.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.NumAudioRetention.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumAudioRetention.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumAudioRetention.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.NumAudioRetention.Location = new System.Drawing.Point(208, 363);
            this.NumAudioRetention.Maximum = new decimal(new int[] {
            3650,
            0,
            0,
            0});
            this.NumAudioRetention.MaxLength = 10;
            this.NumAudioRetention.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumAudioRetention.Name = "NumAudioRetention";
            this.NumAudioRetention.Size = new System.Drawing.Size(83, 25);
            this.NumAudioRetention.TabIndex = 4;
            this.NumAudioRetention.ThemeName = "Metro";
            this.NumAudioRetention.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.NumAudioRetention.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // BtnClearAudioCache
            // 
            this.BtnClearAudioCache.AccessibleDescription = "Completely clears the audio cache.";
            this.BtnClearAudioCache.AccessibleName = "Clear audio cache";
            this.BtnClearAudioCache.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnClearAudioCache.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClearAudioCache.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnClearAudioCache.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClearAudioCache.Location = new System.Drawing.Point(443, 361);
            this.BtnClearAudioCache.Name = "BtnClearAudioCache";
            this.BtnClearAudioCache.Size = new System.Drawing.Size(197, 25);
            this.BtnClearAudioCache.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClearAudioCache.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClearAudioCache.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClearAudioCache.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClearAudioCache.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClearAudioCache.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClearAudioCache.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnClearAudioCache.TabIndex = 5;
            this.BtnClearAudioCache.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigLocalStorage_BtnClearAudioCache;
            this.BtnClearAudioCache.UseVisualStyleBackColor = false;
            this.BtnClearAudioCache.Click += new System.EventHandler(this.BtnClearAudioCache_Click);
            // 
            // BtnOpenAudioCache
            // 
            this.BtnOpenAudioCache.AccessibleDescription = "Open the audio cache storage path in Explorer.";
            this.BtnOpenAudioCache.AccessibleName = "Open audio cache";
            this.BtnOpenAudioCache.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnOpenAudioCache.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnOpenAudioCache.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnOpenAudioCache.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnOpenAudioCache.Location = new System.Drawing.Point(515, 472);
            this.BtnOpenAudioCache.Name = "BtnOpenAudioCache";
            this.BtnOpenAudioCache.Size = new System.Drawing.Size(125, 25);
            this.BtnOpenAudioCache.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnOpenAudioCache.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnOpenAudioCache.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnOpenAudioCache.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnOpenAudioCache.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnOpenAudioCache.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnOpenAudioCache.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnOpenAudioCache.TabIndex = 7;
            this.BtnOpenAudioCache.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigLocalStorage_BtnOpenImageCache;
            this.BtnOpenAudioCache.UseVisualStyleBackColor = false;
            this.BtnOpenAudioCache.Click += new System.EventHandler(this.BtnOpenAudioCache_Click);
            // 
            // TbAudioCacheLocation
            // 
            this.TbAudioCacheLocation.AccessibleDescription = "The storage path of the audio cache.";
            this.TbAudioCacheLocation.AccessibleName = "Audio cache location";
            this.TbAudioCacheLocation.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbAudioCacheLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbAudioCacheLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbAudioCacheLocation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbAudioCacheLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbAudioCacheLocation.Location = new System.Drawing.Point(101, 441);
            this.TbAudioCacheLocation.Name = "TbAudioCacheLocation";
            this.TbAudioCacheLocation.ReadOnly = true;
            this.TbAudioCacheLocation.Size = new System.Drawing.Size(539, 25);
            this.TbAudioCacheLocation.TabIndex = 6;
            // 
            // LblAudioCacheLocation
            // 
            this.LblAudioCacheLocation.AccessibleDescription = "Audio cache location textbox description.";
            this.LblAudioCacheLocation.AccessibleName = "Audio cache location info";
            this.LblAudioCacheLocation.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblAudioCacheLocation.AutoSize = true;
            this.LblAudioCacheLocation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblAudioCacheLocation.Location = new System.Drawing.Point(101, 419);
            this.LblAudioCacheLocation.Name = "LblAudioCacheLocation";
            this.LblAudioCacheLocation.Size = new System.Drawing.Size(133, 19);
            this.LblAudioCacheLocation.TabIndex = 40;
            this.LblAudioCacheLocation.Text = Languages.ConfigLocalStorage_LblAudioCacheLocation;
            // 
            // LblAudioCacheDays
            // 
            this.LblAudioCacheDays.AccessibleDescription = "Audio cache retention time unit.";
            this.LblAudioCacheDays.AccessibleName = "Audio cache time unit";
            this.LblAudioCacheDays.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblAudioCacheDays.AutoSize = true;
            this.LblAudioCacheDays.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblAudioCacheDays.Location = new System.Drawing.Point(297, 365);
            this.LblAudioCacheDays.Name = "LblAudioCacheDays";
            this.LblAudioCacheDays.Size = new System.Drawing.Size(37, 19);
            this.LblAudioCacheDays.TabIndex = 39;
            this.LblAudioCacheDays.Text = Languages.ConfigLocalStorage_LblImageCacheDays;
            // 
            // PbLine1
            // 
            this.PbLine1.AccessibleDescription = "Seperator line.";
            this.PbLine1.AccessibleName = "Seperator";
            this.PbLine1.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbLine1.Image = global::HASS.Agent.Properties.Resources.line;
            this.PbLine1.Location = new System.Drawing.Point(70, 122);
            this.PbLine1.Name = "PbLine1";
            this.PbLine1.Size = new System.Drawing.Size(576, 1);
            this.PbLine1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbLine1.TabIndex = 46;
            this.PbLine1.TabStop = false;
            // 
            // PbLine2
            // 
            this.PbLine2.AccessibleDescription = "Seperator line.";
            this.PbLine2.AccessibleName = "Seperator";
            this.PbLine2.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbLine2.Image = global::HASS.Agent.Properties.Resources.line;
            this.PbLine2.Location = new System.Drawing.Point(70, 326);
            this.PbLine2.Name = "PbLine2";
            this.PbLine2.Size = new System.Drawing.Size(576, 1);
            this.PbLine2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbLine2.TabIndex = 47;
            this.PbLine2.TabStop = false;
            // 
            // PbLine3
            // 
            this.PbLine3.AccessibleDescription = "Seperator line.";
            this.PbLine3.AccessibleName = "Seperator";
            this.PbLine3.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbLine3.Image = global::HASS.Agent.Properties.Resources.line;
            this.PbLine3.Location = new System.Drawing.Point(70, 531);
            this.PbLine3.Name = "PbLine3";
            this.PbLine3.Size = new System.Drawing.Size(576, 1);
            this.PbLine3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbLine3.TabIndex = 51;
            this.PbLine3.TabStop = false;
            // 
            // BtnClearWebViewCache
            // 
            this.BtnClearWebViewCache.AccessibleDescription = "Completely clears the WebView cache.";
            this.BtnClearWebViewCache.AccessibleName = "Clear webview cache";
            this.BtnClearWebViewCache.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnClearWebViewCache.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClearWebViewCache.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnClearWebViewCache.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClearWebViewCache.Location = new System.Drawing.Point(441, 566);
            this.BtnClearWebViewCache.Name = "BtnClearWebViewCache";
            this.BtnClearWebViewCache.Size = new System.Drawing.Size(197, 25);
            this.BtnClearWebViewCache.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClearWebViewCache.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClearWebViewCache.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClearWebViewCache.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClearWebViewCache.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClearWebViewCache.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClearWebViewCache.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnClearWebViewCache.TabIndex = 9;
            this.BtnClearWebViewCache.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigLocalStorage_BtnClearWebViewCache;
            this.BtnClearWebViewCache.UseVisualStyleBackColor = false;
            this.BtnClearWebViewCache.Click += new System.EventHandler(this.BtnClearWebViewCache_Click);
            // 
            // BtnOpenWebViewCache
            // 
            this.BtnOpenWebViewCache.AccessibleDescription = "Open the WebView cache storage path in Explorer.";
            this.BtnOpenWebViewCache.AccessibleName = "Open WebView cache";
            this.BtnOpenWebViewCache.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnOpenWebViewCache.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnOpenWebViewCache.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnOpenWebViewCache.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnOpenWebViewCache.Location = new System.Drawing.Point(513, 677);
            this.BtnOpenWebViewCache.Name = "BtnOpenWebViewCache";
            this.BtnOpenWebViewCache.Size = new System.Drawing.Size(125, 25);
            this.BtnOpenWebViewCache.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnOpenWebViewCache.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnOpenWebViewCache.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnOpenWebViewCache.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnOpenWebViewCache.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnOpenWebViewCache.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnOpenWebViewCache.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnOpenWebViewCache.TabIndex = 11;
            this.BtnOpenWebViewCache.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigLocalStorage_BtnOpenImageCache;
            this.BtnOpenWebViewCache.UseVisualStyleBackColor = false;
            this.BtnOpenWebViewCache.Click += new System.EventHandler(this.BtnOpenWebViewCache_Click);
            // 
            // TbWebViewCacheLocation
            // 
            this.TbWebViewCacheLocation.AccessibleDescription = "The storage path of the WebView cache.";
            this.TbWebViewCacheLocation.AccessibleName = "WebView cache location";
            this.TbWebViewCacheLocation.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbWebViewCacheLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbWebViewCacheLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbWebViewCacheLocation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbWebViewCacheLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbWebViewCacheLocation.Location = new System.Drawing.Point(99, 646);
            this.TbWebViewCacheLocation.Name = "TbWebViewCacheLocation";
            this.TbWebViewCacheLocation.ReadOnly = true;
            this.TbWebViewCacheLocation.Size = new System.Drawing.Size(539, 25);
            this.TbWebViewCacheLocation.TabIndex = 10;
            // 
            // LblWebViewCacheLocation
            // 
            this.LblWebViewCacheLocation.AccessibleDescription = "WebView cache location textbox description.";
            this.LblWebViewCacheLocation.AccessibleName = "WebView cache location info";
            this.LblWebViewCacheLocation.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblWebViewCacheLocation.AutoSize = true;
            this.LblWebViewCacheLocation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblWebViewCacheLocation.Location = new System.Drawing.Point(101, 624);
            this.LblWebViewCacheLocation.Name = "LblWebViewCacheLocation";
            this.LblWebViewCacheLocation.Size = new System.Drawing.Size(151, 19);
            this.LblWebViewCacheLocation.TabIndex = 52;
            this.LblWebViewCacheLocation.Text = Languages.ConfigLocalStorage_LblWebViewCacheLocation;
            // 
            // LblKeepWebView
            // 
            this.LblKeepWebView.AccessibleDescription = "WebView cache removal description.";
            this.LblKeepWebView.AccessibleName = "WebView cache info";
            this.LblKeepWebView.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblKeepWebView.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblKeepWebView.Location = new System.Drawing.Point(7, 568);
            this.LblKeepWebView.Name = "LblKeepWebView";
            this.LblKeepWebView.Size = new System.Drawing.Size(195, 19);
            this.LblKeepWebView.TabIndex = 55;
            this.LblKeepWebView.Text = Languages.ConfigLocalStorage_LblKeepWebView;
            this.LblKeepWebView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumWebViewRetention
            // 
            this.NumWebViewRetention.AccessibleDescription = "The WebView cache will be cleared every x days, where x stands for this value. On" +
    "ly accepts numeric values.";
            this.NumWebViewRetention.AccessibleName = "WebView cache";
            this.NumWebViewRetention.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.NumWebViewRetention.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.NumWebViewRetention.BeforeTouchSize = new System.Drawing.Size(83, 25);
            this.NumWebViewRetention.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.NumWebViewRetention.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.NumWebViewRetention.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumWebViewRetention.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumWebViewRetention.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.NumWebViewRetention.Location = new System.Drawing.Point(208, 566);
            this.NumWebViewRetention.Maximum = new decimal(new int[] {
            3650,
            0,
            0,
            0});
            this.NumWebViewRetention.MaxLength = 10;
            this.NumWebViewRetention.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumWebViewRetention.Name = "NumWebViewRetention";
            this.NumWebViewRetention.Size = new System.Drawing.Size(83, 25);
            this.NumWebViewRetention.TabIndex = 8;
            this.NumWebViewRetention.ThemeName = "Metro";
            this.NumWebViewRetention.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // LblWebViewCacheDays
            // 
            this.LblWebViewCacheDays.AccessibleDescription = "WebView cache retention time unit.";
            this.LblWebViewCacheDays.AccessibleName = "WebView cache time unit";
            this.LblWebViewCacheDays.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblWebViewCacheDays.AutoSize = true;
            this.LblWebViewCacheDays.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblWebViewCacheDays.Location = new System.Drawing.Point(297, 568);
            this.LblWebViewCacheDays.Name = "LblWebViewCacheDays";
            this.LblWebViewCacheDays.Size = new System.Drawing.Size(37, 19);
            this.LblWebViewCacheDays.TabIndex = 53;
            this.LblWebViewCacheDays.Text = Languages.ConfigLocalStorage_LblImageCacheDays;
            // 
            // ConfigLocalStorage
            // 
            this.AccessibleDescription = "Panel containing the local storage configuration.";
            this.AccessibleName = "Local storage";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.LblKeepWebView);
            this.Controls.Add(this.NumWebViewRetention);
            this.Controls.Add(this.LblWebViewCacheDays);
            this.Controls.Add(this.LblWebViewCacheLocation);
            this.Controls.Add(this.PbLine3);
            this.Controls.Add(this.BtnClearWebViewCache);
            this.Controls.Add(this.BtnOpenWebViewCache);
            this.Controls.Add(this.TbWebViewCacheLocation);
            this.Controls.Add(this.PbLine2);
            this.Controls.Add(this.PbLine1);
            this.Controls.Add(this.LblKeepAudio);
            this.Controls.Add(this.NumAudioRetention);
            this.Controls.Add(this.BtnClearAudioCache);
            this.Controls.Add(this.BtnOpenAudioCache);
            this.Controls.Add(this.TbAudioCacheLocation);
            this.Controls.Add(this.LblAudioCacheLocation);
            this.Controls.Add(this.LblAudioCacheDays);
            this.Controls.Add(this.LblKeepImages);
            this.Controls.Add(this.NumImageRetention);
            this.Controls.Add(this.BtnClearImageCache);
            this.Controls.Add(this.BtnOpenImageCache);
            this.Controls.Add(this.TbImageCacheLocation);
            this.Controls.Add(this.LblImageCacheLocation);
            this.Controls.Add(this.LblImageCacheDays);
            this.Controls.Add(this.LblInfo1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfigLocalStorage";
            this.Size = new System.Drawing.Size(700, 733);
            this.Load += new System.EventHandler(this.ConfigLocalStorage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumImageRetention)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumAudioRetention)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLine2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLine3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumWebViewRetention)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblImageCacheLocation;
        private System.Windows.Forms.Label LblImageCacheDays;
        private System.Windows.Forms.Label LblInfo1;
        internal Syncfusion.WinForms.Controls.SfButton BtnClearImageCache;
        internal Syncfusion.WinForms.Controls.SfButton BtnOpenImageCache;
        internal System.Windows.Forms.TextBox TbImageCacheLocation;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumImageRetention;
        private Label LblKeepImages;
        private Label LblKeepAudio;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumAudioRetention;
        internal Syncfusion.WinForms.Controls.SfButton BtnClearAudioCache;
        internal Syncfusion.WinForms.Controls.SfButton BtnOpenAudioCache;
        internal TextBox TbAudioCacheLocation;
        private Label LblAudioCacheLocation;
        private Label LblAudioCacheDays;
        private PictureBox PbLine1;
        private PictureBox PbLine2;
        private PictureBox PbLine3;
        internal Syncfusion.WinForms.Controls.SfButton BtnClearWebViewCache;
        internal Syncfusion.WinForms.Controls.SfButton BtnOpenWebViewCache;
        internal TextBox TbWebViewCacheLocation;
        private Label LblWebViewCacheLocation;
        private Label LblKeepWebView;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumWebViewRetention;
        private Label LblWebViewCacheDays;
    }
}
