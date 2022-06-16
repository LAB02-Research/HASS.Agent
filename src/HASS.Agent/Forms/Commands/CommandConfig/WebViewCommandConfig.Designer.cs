
using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Forms.Commands.CommandConfig
{
    partial class WebViewCommandConfig
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebViewCommandConfig));
            this.BtnSave = new Syncfusion.WinForms.Controls.SfButton();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.TbUrl = new System.Windows.Forms.TextBox();
            this.LblUrl = new System.Windows.Forms.Label();
            this.LblSize = new System.Windows.Forms.Label();
            this.LblX = new System.Windows.Forms.Label();
            this.LblBy = new System.Windows.Forms.Label();
            this.LblLocation = new System.Windows.Forms.Label();
            this.CbShowTitleBar = new System.Windows.Forms.CheckBox();
            this.CbCenterScreen = new System.Windows.Forms.CheckBox();
            this.CbTopMost = new System.Windows.Forms.CheckBox();
            this.LblTip1 = new System.Windows.Forms.Label();
            this.NumLocationX = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.NumLocationY = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.NumSizeWidth = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.NumSizeHeight = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            ((System.ComponentModel.ISupportInitialize)(this.NumLocationX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumLocationY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSizeWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSizeHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSave
            // 
            this.BtnSave.AccessibleDescription = "Saves and closes the window.";
            this.BtnSave.AccessibleName = "Save";
            this.BtnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSave.Location = new System.Drawing.Point(0, 303);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(588, 37);
            this.BtnSave.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSave.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSave.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSave.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSave.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnSave.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnSave.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnSave.TabIndex = 8;
            this.BtnSave.Text = global::HASS.Agent.Resources.Localization.Languages.WebViewCommandConfig_BtnSave;
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "Information regarding the window\'s functions.";
            this.LblInfo1.AccessibleName = "General information";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(34, 9);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(521, 45);
            this.LblInfo1.TabIndex = 3;
            this.LblInfo1.Text = Languages.WebViewCommandConfig_LblInfo1;
            this.LblInfo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbUrl
            // 
            this.TbUrl.AccessibleDescription = "The URL that the webview will load.";
            this.TbUrl.AccessibleName = "URL";
            this.TbUrl.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbUrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbUrl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbUrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbUrl.Location = new System.Drawing.Point(34, 86);
            this.TbUrl.Name = "TbUrl";
            this.TbUrl.Size = new System.Drawing.Size(521, 25);
            this.TbUrl.TabIndex = 0;
            // 
            // LblUrl
            // 
            this.LblUrl.AccessibleDescription = "URL textbox description";
            this.LblUrl.AccessibleName = "URL description";
            this.LblUrl.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblUrl.AutoSize = true;
            this.LblUrl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblUrl.Location = new System.Drawing.Point(34, 64);
            this.LblUrl.Name = "LblUrl";
            this.LblUrl.Size = new System.Drawing.Size(34, 19);
            this.LblUrl.TabIndex = 5;
            this.LblUrl.Text = Languages.WebViewCommandConfig_LblUrl;
            // 
            // LblSize
            // 
            this.LblSize.AccessibleDescription = "Size description.";
            this.LblSize.AccessibleName = "Size";
            this.LblSize.AutoSize = true;
            this.LblSize.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblSize.Location = new System.Drawing.Point(29, 203);
            this.LblSize.Name = "LblSize";
            this.LblSize.Size = new System.Drawing.Size(31, 19);
            this.LblSize.TabIndex = 7;
            this.LblSize.Text = Languages.WebViewCommandConfig_LblSize;
            // 
            // LblX
            // 
            this.LblX.AccessibleDescription = "X depicting the word \'by\'.";
            this.LblX.AccessibleName = "X";
            this.LblX.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblX.AutoSize = true;
            this.LblX.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblX.Location = new System.Drawing.Point(128, 227);
            this.LblX.Name = "LblX";
            this.LblX.Size = new System.Drawing.Size(17, 19);
            this.LblX.TabIndex = 9;
            this.LblX.Text = "X";
            // 
            // LblBy
            // 
            this.LblBy.AccessibleDescription = "Comma depicting the word \'by\'.";
            this.LblBy.AccessibleName = "Comma";
            this.LblBy.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblBy.AutoSize = true;
            this.LblBy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblBy.Location = new System.Drawing.Point(131, 162);
            this.LblBy.Name = "LblBy";
            this.LblBy.Size = new System.Drawing.Size(12, 19);
            this.LblBy.TabIndex = 13;
            this.LblBy.Text = ",";
            // 
            // LblLocation
            // 
            this.LblLocation.AccessibleDescription = "Location description.";
            this.LblLocation.AccessibleName = "Location";
            this.LblLocation.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblLocation.AutoSize = true;
            this.LblLocation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblLocation.Location = new System.Drawing.Point(34, 138);
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Size = new System.Drawing.Size(57, 19);
            this.LblLocation.TabIndex = 11;
            this.LblLocation.Text = Languages.WebViewCommandConfig_LblLocation;
            // 
            // CbShowTitleBar
            // 
            this.CbShowTitleBar.AccessibleDescription = "Enable showing the webview\'s titlebar.";
            this.CbShowTitleBar.AccessibleName = "Titlebar";
            this.CbShowTitleBar.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.CbShowTitleBar.AutoSize = true;
            this.CbShowTitleBar.Checked = true;
            this.CbShowTitleBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbShowTitleBar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbShowTitleBar.Location = new System.Drawing.Point(284, 187);
            this.CbShowTitleBar.Name = "CbShowTitleBar";
            this.CbShowTitleBar.Size = new System.Drawing.Size(195, 23);
            this.CbShowTitleBar.TabIndex = 6;
            this.CbShowTitleBar.Text = global::HASS.Agent.Resources.Localization.Languages.WebViewCommandConfig_CbShowTitleBar;
            this.CbShowTitleBar.UseVisualStyleBackColor = true;
            this.CbShowTitleBar.CheckedChanged += new System.EventHandler(this.CbShowTitleBar_CheckedChanged);
            // 
            // CbCenterScreen
            // 
            this.CbCenterScreen.AccessibleDescription = "Enable always showing the webview in the center of the screen.";
            this.CbCenterScreen.AccessibleName = "Center screen";
            this.CbCenterScreen.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.CbCenterScreen.AutoSize = true;
            this.CbCenterScreen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbCenterScreen.Location = new System.Drawing.Point(284, 138);
            this.CbCenterScreen.Name = "CbCenterScreen";
            this.CbCenterScreen.Size = new System.Drawing.Size(219, 23);
            this.CbCenterScreen.TabIndex = 5;
            this.CbCenterScreen.Text = global::HASS.Agent.Resources.Localization.Languages.WebViewCommandConfig_CbCenterScreen;
            this.CbCenterScreen.UseVisualStyleBackColor = true;
            // 
            // CbTopMost
            // 
            this.CbTopMost.AccessibleDescription = "Enable showing the webview\'s window on top of the rest.";
            this.CbTopMost.AccessibleName = "Topmost";
            this.CbTopMost.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.CbTopMost.AutoSize = true;
            this.CbTopMost.Checked = true;
            this.CbTopMost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbTopMost.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbTopMost.Location = new System.Drawing.Point(284, 236);
            this.CbTopMost.Name = "CbTopMost";
            this.CbTopMost.Size = new System.Drawing.Size(203, 23);
            this.CbTopMost.TabIndex = 7;
            this.CbTopMost.Text = global::HASS.Agent.Resources.Localization.Languages.WebViewCommandConfig_CbTopMost;
            this.CbTopMost.UseVisualStyleBackColor = true;
            this.CbTopMost.CheckedChanged += new System.EventHandler(this.CbTopMost_CheckedChanged);
            // 
            // LblTip1
            // 
            this.LblTip1.AccessibleDescription = "Contains a usage tip.";
            this.LblTip1.AccessibleName = "Webview usage tip";
            this.LblTip1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblTip1.AutoSize = true;
            this.LblTip1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip1.Location = new System.Drawing.Point(34, 283);
            this.LblTip1.Name = "LblTip1";
            this.LblTip1.Size = new System.Drawing.Size(179, 13);
            this.LblTip1.TabIndex = 30;
            this.LblTip1.Text = Languages.WebViewCommandConfig_LblTip1;
            // 
            // NumLocationX
            // 
            this.NumLocationX.AccessibleDescription = "The X value of the webview\'s location.";
            this.NumLocationX.AccessibleName = "Location X";
            this.NumLocationX.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.NumLocationX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.NumLocationX.BeforeTouchSize = new System.Drawing.Size(91, 25);
            this.NumLocationX.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.NumLocationX.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.NumLocationX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumLocationX.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumLocationX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.NumLocationX.Location = new System.Drawing.Point(34, 160);
            this.NumLocationX.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumLocationX.MaxLength = 10;
            this.NumLocationX.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumLocationX.Name = "NumLocationX";
            this.NumLocationX.Size = new System.Drawing.Size(91, 25);
            this.NumLocationX.TabIndex = 1;
            this.NumLocationX.ThemeName = "Metro";
            this.NumLocationX.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // NumLocationY
            // 
            this.NumLocationY.AccessibleDescription = "The Y value of the webview\'s location.";
            this.NumLocationY.AccessibleName = "Location Y";
            this.NumLocationY.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.NumLocationY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.NumLocationY.BeforeTouchSize = new System.Drawing.Size(91, 25);
            this.NumLocationY.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.NumLocationY.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.NumLocationY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumLocationY.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumLocationY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.NumLocationY.Location = new System.Drawing.Point(149, 160);
            this.NumLocationY.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumLocationY.MaxLength = 10;
            this.NumLocationY.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumLocationY.Name = "NumLocationY";
            this.NumLocationY.Size = new System.Drawing.Size(91, 25);
            this.NumLocationY.TabIndex = 2;
            this.NumLocationY.ThemeName = "Metro";
            this.NumLocationY.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // NumSizeWidth
            // 
            this.NumSizeWidth.AccessibleDescription = "The width value of the webview.";
            this.NumSizeWidth.AccessibleName = "Width";
            this.NumSizeWidth.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.NumSizeWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.NumSizeWidth.BeforeTouchSize = new System.Drawing.Size(91, 25);
            this.NumSizeWidth.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.NumSizeWidth.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.NumSizeWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumSizeWidth.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumSizeWidth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.NumSizeWidth.Location = new System.Drawing.Point(34, 225);
            this.NumSizeWidth.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumSizeWidth.MaxLength = 10;
            this.NumSizeWidth.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumSizeWidth.Name = "NumSizeWidth";
            this.NumSizeWidth.Size = new System.Drawing.Size(91, 25);
            this.NumSizeWidth.TabIndex = 3;
            this.NumSizeWidth.ThemeName = "Metro";
            this.NumSizeWidth.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // NumSizeHeight
            // 
            this.NumSizeHeight.AccessibleDescription = "The height value of the webview.";
            this.NumSizeHeight.AccessibleName = "Height";
            this.NumSizeHeight.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.NumSizeHeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.NumSizeHeight.BeforeTouchSize = new System.Drawing.Size(91, 25);
            this.NumSizeHeight.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.NumSizeHeight.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.NumSizeHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumSizeHeight.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumSizeHeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.NumSizeHeight.Location = new System.Drawing.Point(149, 225);
            this.NumSizeHeight.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumSizeHeight.MaxLength = 10;
            this.NumSizeHeight.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumSizeHeight.Name = "NumSizeHeight";
            this.NumSizeHeight.Size = new System.Drawing.Size(91, 25);
            this.NumSizeHeight.TabIndex = 4;
            this.NumSizeHeight.ThemeName = "Metro";
            this.NumSizeHeight.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // WebViewCommandConfig
            // 
            this.AccessibleDescription = "Configuration for the webview command, like position and url.";
            this.AccessibleName = "Webview configuration";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(588, 340);
            this.Controls.Add(this.NumSizeHeight);
            this.Controls.Add(this.NumSizeWidth);
            this.Controls.Add(this.NumLocationY);
            this.Controls.Add(this.NumLocationX);
            this.Controls.Add(this.LblTip1);
            this.Controls.Add(this.CbTopMost);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.CbCenterScreen);
            this.Controls.Add(this.CbShowTitleBar);
            this.Controls.Add(this.LblBy);
            this.Controls.Add(this.LblLocation);
            this.Controls.Add(this.LblX);
            this.Controls.Add(this.LblSize);
            this.Controls.Add(this.LblUrl);
            this.Controls.Add(this.TbUrl);
            this.Controls.Add(this.LblInfo1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.Name = "WebViewCommandConfig";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Languages.WebViewCommandConfig_Title;
            this.Load += new System.EventHandler(this.WebViewCommandConfig_Load);
            this.ResizeEnd += new System.EventHandler(this.WebViewCommandConfig_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WebViewCommandConfig_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WebViewCommandConfig_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WebViewCommandConfig_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WebViewCommandConfig_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.NumLocationX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumLocationY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSizeWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSizeHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Syncfusion.WinForms.Controls.SfButton BtnSave;
        private System.Windows.Forms.Label LblInfo1;
        private TextBox TbUrl;
        private Label LblUrl;
        private Label LblSize;
        private Label LblX;
        private Label LblBy;
        private Label LblLocation;
        private CheckBox CbShowTitleBar;
        private CheckBox CbCenterScreen;
        private CheckBox CbTopMost;
        private Label LblTip1;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumLocationX;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumLocationY;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumSizeWidth;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumSizeHeight;
    }
}

