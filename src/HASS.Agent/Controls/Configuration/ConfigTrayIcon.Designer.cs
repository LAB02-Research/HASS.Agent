using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Configuration
{
    partial class ConfigTrayIcon
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
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.CbDefaultMenu = new System.Windows.Forms.CheckBox();
            this.CbShowWebView = new System.Windows.Forms.CheckBox();
            this.TbWebViewUrl = new System.Windows.Forms.TextBox();
            this.LblWebViewUrl = new System.Windows.Forms.Label();
            this.LblX = new System.Windows.Forms.Label();
            this.LblWebViewSize = new System.Windows.Forms.Label();
            this.BtnShowWebViewPreview = new Syncfusion.WinForms.Controls.SfButton();
            this.NumWebViewWidth = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.NumWebViewHeight = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.BtnWebViewReset = new Syncfusion.WinForms.Controls.SfButton();
            this.CbWebViewKeepLoaded = new System.Windows.Forms.CheckBox();
            this.LblInfo2 = new System.Windows.Forms.Label();
            this.CbWebViewShowMenuOnLeftClick = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumWebViewWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumWebViewHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "Tray icon information.";
            this.LblInfo1.AccessibleName = "Information";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(70, 36);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(541, 78);
            this.LblInfo1.TabIndex = 31;
            this.LblInfo1.Text = Languages.ConfigTrayIcon_LblInfo1;
            // 
            // CbDefaultMenu
            // 
            this.CbDefaultMenu.AccessibleDescription = "If enabled, right clicking the system tray icon will show the default menu.";
            this.CbDefaultMenu.AccessibleName = "Show default menu";
            this.CbDefaultMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.CbDefaultMenu.AutoSize = true;
            this.CbDefaultMenu.Checked = true;
            this.CbDefaultMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbDefaultMenu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbDefaultMenu.Location = new System.Drawing.Point(70, 117);
            this.CbDefaultMenu.Name = "CbDefaultMenu";
            this.CbDefaultMenu.Size = new System.Drawing.Size(145, 23);
            this.CbDefaultMenu.TabIndex = 0;
            this.CbDefaultMenu.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigTrayIcon_CbDefaultMenu;
            this.CbDefaultMenu.UseVisualStyleBackColor = true;
            this.CbDefaultMenu.CheckedChanged += new System.EventHandler(this.CbDefaultMenu_CheckedChanged);
            // 
            // CbShowWebView
            // 
            this.CbShowWebView.AccessibleDescription = "If enabled, right clicking the system tray icon will show a webview with the url " +
    "you provide.";
            this.CbShowWebView.AccessibleName = "Show webview";
            this.CbShowWebView.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.CbShowWebView.AutoSize = true;
            this.CbShowWebView.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbShowWebView.Location = new System.Drawing.Point(70, 209);
            this.CbShowWebView.Name = "CbShowWebView";
            this.CbShowWebView.Size = new System.Drawing.Size(116, 23);
            this.CbShowWebView.TabIndex = 1;
            this.CbShowWebView.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigTrayIcon_CbShowWebView;
            this.CbShowWebView.UseVisualStyleBackColor = true;
            this.CbShowWebView.CheckedChanged += new System.EventHandler(this.CbShowWebView_CheckedChanged);
            // 
            // TbWebViewUrl
            // 
            this.TbWebViewUrl.AccessibleDescription = "The URL to show. Defaults to the Home Assistant API\'s URL.";
            this.TbWebViewUrl.AccessibleName = "URL";
            this.TbWebViewUrl.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbWebViewUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbWebViewUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbWebViewUrl.Enabled = false;
            this.TbWebViewUrl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbWebViewUrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbWebViewUrl.Location = new System.Drawing.Point(90, 280);
            this.TbWebViewUrl.Name = "TbWebViewUrl";
            this.TbWebViewUrl.Size = new System.Drawing.Size(521, 25);
            this.TbWebViewUrl.TabIndex = 2;
            // 
            // LblWebViewUrl
            // 
            this.LblWebViewUrl.AccessibleDescription = "URL textbox description";
            this.LblWebViewUrl.AccessibleName = "URL info";
            this.LblWebViewUrl.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblWebViewUrl.AutoSize = true;
            this.LblWebViewUrl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblWebViewUrl.Location = new System.Drawing.Point(87, 258);
            this.LblWebViewUrl.Name = "LblWebViewUrl";
            this.LblWebViewUrl.Size = new System.Drawing.Size(349, 19);
            this.LblWebViewUrl.TabIndex = 49;
            this.LblWebViewUrl.Text = Languages.ConfigTrayIcon_LblWebViewUrl;
            // 
            // LblX
            // 
            this.LblX.AccessibleDescription = "Shows X, meaning \'by\' in this context.";
            this.LblX.AccessibleName = "X info";
            this.LblX.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblX.AutoSize = true;
            this.LblX.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblX.Location = new System.Drawing.Point(184, 350);
            this.LblX.Name = "LblX";
            this.LblX.Size = new System.Drawing.Size(17, 19);
            this.LblX.TabIndex = 53;
            this.LblX.Text = "X";
            // 
            // LblWebViewSize
            // 
            this.LblWebViewSize.AccessibleDescription = "Size description.";
            this.LblWebViewSize.AccessibleName = "Size info";
            this.LblWebViewSize.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblWebViewSize.AutoSize = true;
            this.LblWebViewSize.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblWebViewSize.Location = new System.Drawing.Point(85, 326);
            this.LblWebViewSize.Name = "LblWebViewSize";
            this.LblWebViewSize.Size = new System.Drawing.Size(31, 19);
            this.LblWebViewSize.TabIndex = 51;
            this.LblWebViewSize.Text = Languages.ConfigTrayIcon_LblWebViewSize;
            // 
            // BtnShowWebViewPreview
            // 
            this.BtnShowWebViewPreview.AccessibleDescription = "Shows the webview, using the currently configured values.";
            this.BtnShowWebViewPreview.AccessibleName = "Webview preview";
            this.BtnShowWebViewPreview.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnShowWebViewPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnShowWebViewPreview.Enabled = false;
            this.BtnShowWebViewPreview.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnShowWebViewPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnShowWebViewPreview.Location = new System.Drawing.Point(405, 348);
            this.BtnShowWebViewPreview.Name = "BtnShowWebViewPreview";
            this.BtnShowWebViewPreview.Size = new System.Drawing.Size(206, 26);
            this.BtnShowWebViewPreview.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnShowWebViewPreview.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnShowWebViewPreview.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnShowWebViewPreview.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnShowWebViewPreview.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnShowWebViewPreview.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnShowWebViewPreview.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnShowWebViewPreview.TabIndex = 6;
            this.BtnShowWebViewPreview.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigTrayIcon_BtnShowWebViewPreview;
            this.BtnShowWebViewPreview.UseVisualStyleBackColor = false;
            this.BtnShowWebViewPreview.Click += new System.EventHandler(this.BtnShowWebViewPreview_Click);
            // 
            // NumWebViewWidth
            // 
            this.NumWebViewWidth.AccessibleDescription = "The width of the webview. Only accepts numeric values.";
            this.NumWebViewWidth.AccessibleName = "Width";
            this.NumWebViewWidth.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.NumWebViewWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.NumWebViewWidth.BeforeTouchSize = new System.Drawing.Size(83, 25);
            this.NumWebViewWidth.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.NumWebViewWidth.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.NumWebViewWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumWebViewWidth.Enabled = false;
            this.NumWebViewWidth.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumWebViewWidth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.NumWebViewWidth.Location = new System.Drawing.Point(87, 348);
            this.NumWebViewWidth.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumWebViewWidth.MaxLength = 10;
            this.NumWebViewWidth.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumWebViewWidth.Name = "NumWebViewWidth";
            this.NumWebViewWidth.Size = new System.Drawing.Size(83, 25);
            this.NumWebViewWidth.TabIndex = 3;
            this.NumWebViewWidth.ThemeName = "Metro";
            this.NumWebViewWidth.Value = new decimal(new int[] {
            700,
            0,
            0,
            0});
            this.NumWebViewWidth.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // NumWebViewHeight
            // 
            this.NumWebViewHeight.AccessibleDescription = "The height of the webview. Only accepts numeric values.";
            this.NumWebViewHeight.AccessibleName = "Height";
            this.NumWebViewHeight.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.NumWebViewHeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.NumWebViewHeight.BeforeTouchSize = new System.Drawing.Size(83, 25);
            this.NumWebViewHeight.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.NumWebViewHeight.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.NumWebViewHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumWebViewHeight.Enabled = false;
            this.NumWebViewHeight.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumWebViewHeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.NumWebViewHeight.Location = new System.Drawing.Point(218, 348);
            this.NumWebViewHeight.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumWebViewHeight.MaxLength = 10;
            this.NumWebViewHeight.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumWebViewHeight.Name = "NumWebViewHeight";
            this.NumWebViewHeight.Size = new System.Drawing.Size(83, 25);
            this.NumWebViewHeight.TabIndex = 4;
            this.NumWebViewHeight.ThemeName = "Metro";
            this.NumWebViewHeight.Value = new decimal(new int[] {
            560,
            0,
            0,
            0});
            this.NumWebViewHeight.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // BtnWebViewReset
            // 
            this.BtnWebViewReset.AccessibleDescription = "Resets the width and height values to their defaults.";
            this.BtnWebViewReset.AccessibleName = "Reset webview";
            this.BtnWebViewReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnWebViewReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnWebViewReset.Enabled = false;
            this.BtnWebViewReset.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnWebViewReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnWebViewReset.ImageSize = new System.Drawing.Size(24, 24);
            this.BtnWebViewReset.Location = new System.Drawing.Point(317, 348);
            this.BtnWebViewReset.Name = "BtnWebViewReset";
            this.BtnWebViewReset.Size = new System.Drawing.Size(51, 26);
            this.BtnWebViewReset.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnWebViewReset.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnWebViewReset.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnWebViewReset.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnWebViewReset.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnWebViewReset.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnWebViewReset.Style.Image = global::HASS.Agent.Properties.Resources.reset_24;
            this.BtnWebViewReset.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnWebViewReset.TabIndex = 5;
            this.BtnWebViewReset.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.BtnWebViewReset.UseVisualStyleBackColor = false;
            this.BtnWebViewReset.Click += new System.EventHandler(this.BtnWebViewReset_Click);
            // 
            // CbWebViewKeepLoaded
            // 
            this.CbWebViewKeepLoaded.AccessibleDescription = "Keeps the webview loaded in the background, resulting in faster loading when invo" +
    "ked.";
            this.CbWebViewKeepLoaded.AccessibleName = "Background loading";
            this.CbWebViewKeepLoaded.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.CbWebViewKeepLoaded.AutoSize = true;
            this.CbWebViewKeepLoaded.Checked = true;
            this.CbWebViewKeepLoaded.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbWebViewKeepLoaded.Enabled = false;
            this.CbWebViewKeepLoaded.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbWebViewKeepLoaded.Location = new System.Drawing.Point(90, 405);
            this.CbWebViewKeepLoaded.Name = "CbWebViewKeepLoaded";
            this.CbWebViewKeepLoaded.Size = new System.Drawing.Size(252, 23);
            this.CbWebViewKeepLoaded.TabIndex = 7;
            this.CbWebViewKeepLoaded.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigTrayIcon_CbWebViewKeepLoaded;
            this.CbWebViewKeepLoaded.UseVisualStyleBackColor = true;
            // 
            // LblInfo2
            // 
            this.LblInfo2.AccessibleDescription = "Background loading information.";
            this.LblInfo2.AccessibleName = "Background loading info";
            this.LblInfo2.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo2.AutoSize = true;
            this.LblInfo2.Enabled = false;
            this.LblInfo2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo2.Location = new System.Drawing.Point(107, 435);
            this.LblInfo2.Name = "LblInfo2";
            this.LblInfo2.Size = new System.Drawing.Size(320, 19);
            this.LblInfo2.TabIndex = 76;
            this.LblInfo2.Text = Languages.ConfigTrayIcon_LblInfo2;
            // 
            // CbWebViewShowMenuOnLeftClick
            // 
            this.CbWebViewShowMenuOnLeftClick.AccessibleDescription = "If enabled, left clicking the system tray icon will show the default menu.";
            this.CbWebViewShowMenuOnLeftClick.AccessibleName = "Show default menu on left click";
            this.CbWebViewShowMenuOnLeftClick.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.CbWebViewShowMenuOnLeftClick.AutoSize = true;
            this.CbWebViewShowMenuOnLeftClick.Enabled = false;
            this.CbWebViewShowMenuOnLeftClick.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbWebViewShowMenuOnLeftClick.Location = new System.Drawing.Point(90, 487);
            this.CbWebViewShowMenuOnLeftClick.Name = "CbWebViewShowMenuOnLeftClick";
            this.CbWebViewShowMenuOnLeftClick.Size = new System.Drawing.Size(304, 23);
            this.CbWebViewShowMenuOnLeftClick.TabIndex = 77;
            this.CbWebViewShowMenuOnLeftClick.Text = Languages.ConfigTrayIcon_CbWebViewShowMenuOnLeftClick;
            this.CbWebViewShowMenuOnLeftClick.UseVisualStyleBackColor = true;
            // 
            // ConfigTrayIcon
            // 
            this.AccessibleDescription = "Panel containing the tray icon configuration.";
            this.AccessibleName = "Tray icon";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.CbWebViewShowMenuOnLeftClick);
            this.Controls.Add(this.LblInfo2);
            this.Controls.Add(this.CbWebViewKeepLoaded);
            this.Controls.Add(this.BtnWebViewReset);
            this.Controls.Add(this.NumWebViewHeight);
            this.Controls.Add(this.NumWebViewWidth);
            this.Controls.Add(this.BtnShowWebViewPreview);
            this.Controls.Add(this.LblX);
            this.Controls.Add(this.LblWebViewSize);
            this.Controls.Add(this.TbWebViewUrl);
            this.Controls.Add(this.LblWebViewUrl);
            this.Controls.Add(this.CbShowWebView);
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.CbDefaultMenu);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfigTrayIcon";
            this.Size = new System.Drawing.Size(700, 544);
            this.Load += new System.EventHandler(this.ConfigTrayIcon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumWebViewWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumWebViewHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblInfo1;
        internal System.Windows.Forms.CheckBox CbDefaultMenu;
        internal CheckBox CbShowWebView;
        internal TextBox TbWebViewUrl;
        internal Syncfusion.WinForms.Controls.SfButton BtnShowWebViewPreview;
        internal Label LblWebViewUrl;
        internal Label LblX;
        internal Label LblWebViewSize;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumWebViewWidth;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumWebViewHeight;
        internal Syncfusion.WinForms.Controls.SfButton BtnWebViewReset;
        internal CheckBox CbWebViewKeepLoaded;
        internal Label LblInfo2;
        internal CheckBox CbWebViewShowMenuOnLeftClick;
    }
}
