using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Configuration
{
    partial class ConfigExternalTools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigExternalTools));
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.TbExternalBrowserName = new System.Windows.Forms.TextBox();
            this.LblBrowserName = new System.Windows.Forms.Label();
            this.LblInfo2 = new System.Windows.Forms.Label();
            this.TbExternalBrowserBinary = new System.Windows.Forms.TextBox();
            this.LblBrowserBinary = new System.Windows.Forms.Label();
            this.TbExternalBrowserIncognito = new System.Windows.Forms.TextBox();
            this.LblLaunchIncogArg = new System.Windows.Forms.Label();
            this.TbExternalExecutorBinary = new System.Windows.Forms.TextBox();
            this.LblCustomExecutorBinary = new System.Windows.Forms.Label();
            this.LblInfo3 = new System.Windows.Forms.Label();
            this.TbExternalExecutorName = new System.Windows.Forms.TextBox();
            this.LblCustomExecutorName = new System.Windows.Forms.Label();
            this.LblTip1 = new System.Windows.Forms.Label();
            this.LblTip2 = new System.Windows.Forms.Label();
            this.BtnExternalBrowserIncognitoTest = new Syncfusion.WinForms.Controls.SfButton();
            this.PbLine1 = new System.Windows.Forms.PictureBox();
            this.PbLine2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbLine1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLine2)).BeginInit();
            this.SuspendLayout();
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "External tools information.";
            this.LblInfo1.AccessibleName = "Information";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.AutoSize = true;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(70, 36);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(388, 19);
            this.LblInfo1.TabIndex = 57;
            this.LblInfo1.Text = Languages.ConfigExternalTools_LblInfo1;
            // 
            // TbExternalBrowserName
            // 
            this.TbExternalBrowserName.AccessibleDescription = "The name of the custom browser.";
            this.TbExternalBrowserName.AccessibleName = "Custom browser name";
            this.TbExternalBrowserName.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbExternalBrowserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbExternalBrowserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbExternalBrowserName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbExternalBrowserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbExternalBrowserName.Location = new System.Drawing.Point(73, 238);
            this.TbExternalBrowserName.Name = "TbExternalBrowserName";
            this.TbExternalBrowserName.Size = new System.Drawing.Size(358, 25);
            this.TbExternalBrowserName.TabIndex = 1;
            // 
            // LblBrowserName
            // 
            this.LblBrowserName.AccessibleDescription = "Custom browser name textbox description.";
            this.LblBrowserName.AccessibleName = "Custom browser name info";
            this.LblBrowserName.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblBrowserName.AutoSize = true;
            this.LblBrowserName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblBrowserName.Location = new System.Drawing.Point(70, 216);
            this.LblBrowserName.Name = "LblBrowserName";
            this.LblBrowserName.Size = new System.Drawing.Size(96, 19);
            this.LblBrowserName.TabIndex = 56;
            this.LblBrowserName.Text = Languages.ConfigExternalTools_LblBrowserName;
            // 
            // LblInfo2
            // 
            this.LblInfo2.AccessibleDescription = "Info about the use and configuration of a custom browser, instead of the system d" +
    "efault.";
            this.LblInfo2.AccessibleName = "Custom browser info";
            this.LblInfo2.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo2.Location = new System.Drawing.Point(70, 89);
            this.LblInfo2.Name = "LblInfo2";
            this.LblInfo2.Size = new System.Drawing.Size(579, 57);
            this.LblInfo2.TabIndex = 58;
            this.LblInfo2.Text = Languages.ConfigExternalTools_LblInfo2;
            // 
            // TbExternalBrowserBinary
            // 
            this.TbExternalBrowserBinary.AccessibleDescription = "The location of the custom browser\'s binary.";
            this.TbExternalBrowserBinary.AccessibleName = "Custom browser binary";
            this.TbExternalBrowserBinary.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbExternalBrowserBinary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbExternalBrowserBinary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbExternalBrowserBinary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbExternalBrowserBinary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbExternalBrowserBinary.Location = new System.Drawing.Point(73, 180);
            this.TbExternalBrowserBinary.Name = "TbExternalBrowserBinary";
            this.TbExternalBrowserBinary.Size = new System.Drawing.Size(358, 25);
            this.TbExternalBrowserBinary.TabIndex = 0;
            this.TbExternalBrowserBinary.DoubleClick += new System.EventHandler(this.TbExternalBrowserBinary_DoubleClick);
            // 
            // LblBrowserBinary
            // 
            this.LblBrowserBinary.AccessibleDescription = "Custom browser binary textbox description.";
            this.LblBrowserBinary.AccessibleName = "Custom browser binary info";
            this.LblBrowserBinary.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblBrowserBinary.AutoSize = true;
            this.LblBrowserBinary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblBrowserBinary.Location = new System.Drawing.Point(70, 158);
            this.LblBrowserBinary.Name = "LblBrowserBinary";
            this.LblBrowserBinary.Size = new System.Drawing.Size(100, 19);
            this.LblBrowserBinary.TabIndex = 60;
            this.LblBrowserBinary.Text = Languages.ConfigExternalTools_LblBrowserBinary;
            // 
            // TbExternalBrowserIncognito
            // 
            this.TbExternalBrowserIncognito.AccessibleDescription = "Arguments to launch the custom browser in incognito mode.";
            this.TbExternalBrowserIncognito.AccessibleName = "Custom browser incognito arguments info";
            this.TbExternalBrowserIncognito.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbExternalBrowserIncognito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbExternalBrowserIncognito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbExternalBrowserIncognito.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbExternalBrowserIncognito.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbExternalBrowserIncognito.Location = new System.Drawing.Point(73, 301);
            this.TbExternalBrowserIncognito.Name = "TbExternalBrowserIncognito";
            this.TbExternalBrowserIncognito.Size = new System.Drawing.Size(358, 25);
            this.TbExternalBrowserIncognito.TabIndex = 2;
            // 
            // LblLaunchIncogArg
            // 
            this.LblLaunchIncogArg.AccessibleDescription = "Custom browser incognito arguments textbox description.";
            this.LblLaunchIncogArg.AccessibleName = "Custom browser incognito arguments info";
            this.LblLaunchIncogArg.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblLaunchIncogArg.AutoSize = true;
            this.LblLaunchIncogArg.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblLaunchIncogArg.Location = new System.Drawing.Point(70, 279);
            this.LblLaunchIncogArg.Name = "LblLaunchIncogArg";
            this.LblLaunchIncogArg.Size = new System.Drawing.Size(134, 19);
            this.LblLaunchIncogArg.TabIndex = 62;
            this.LblLaunchIncogArg.Text = Languages.ConfigExternalTools_LblLaunchIncogArg;
            // 
            // TbExternalExecutorBinary
            // 
            this.TbExternalExecutorBinary.AccessibleDescription = "The location of the custom executor\'s binary.";
            this.TbExternalExecutorBinary.AccessibleName = "Custom executor binary";
            this.TbExternalExecutorBinary.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbExternalExecutorBinary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbExternalExecutorBinary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbExternalExecutorBinary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbExternalExecutorBinary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbExternalExecutorBinary.Location = new System.Drawing.Point(73, 471);
            this.TbExternalExecutorBinary.Name = "TbExternalExecutorBinary";
            this.TbExternalExecutorBinary.Size = new System.Drawing.Size(358, 25);
            this.TbExternalExecutorBinary.TabIndex = 4;
            this.TbExternalExecutorBinary.DoubleClick += new System.EventHandler(this.TbExternalExecutorBinary_DoubleClick);
            // 
            // LblCustomExecutorBinary
            // 
            this.LblCustomExecutorBinary.AccessibleDescription = "Custom executor binary textbox description.";
            this.LblCustomExecutorBinary.AccessibleName = "Custom executor binary info";
            this.LblCustomExecutorBinary.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblCustomExecutorBinary.AutoSize = true;
            this.LblCustomExecutorBinary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblCustomExecutorBinary.Location = new System.Drawing.Point(70, 449);
            this.LblCustomExecutorBinary.Name = "LblCustomExecutorBinary";
            this.LblCustomExecutorBinary.Size = new System.Drawing.Size(152, 19);
            this.LblCustomExecutorBinary.TabIndex = 67;
            this.LblCustomExecutorBinary.Text = Languages.ConfigExternalTools_LblCustomExecutorBinary;
            // 
            // LblInfo3
            // 
            this.LblInfo3.AccessibleDescription = "Info about the use and configuration of a custom executor.";
            this.LblInfo3.AccessibleName = "Custom executor info";
            this.LblInfo3.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo3.Location = new System.Drawing.Point(70, 399);
            this.LblInfo3.Name = "LblInfo3";
            this.LblInfo3.Size = new System.Drawing.Size(579, 38);
            this.LblInfo3.TabIndex = 65;
            this.LblInfo3.Text = Languages.ConfigExternalTools_LblInfo3;
            // 
            // TbExternalExecutorName
            // 
            this.TbExternalExecutorName.AccessibleDescription = "The name of the custom executor.";
            this.TbExternalExecutorName.AccessibleName = "Custom executor name";
            this.TbExternalExecutorName.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbExternalExecutorName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbExternalExecutorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbExternalExecutorName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbExternalExecutorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbExternalExecutorName.Location = new System.Drawing.Point(73, 531);
            this.TbExternalExecutorName.Name = "TbExternalExecutorName";
            this.TbExternalExecutorName.Size = new System.Drawing.Size(358, 25);
            this.TbExternalExecutorName.TabIndex = 5;
            // 
            // LblCustomExecutorName
            // 
            this.LblCustomExecutorName.AccessibleDescription = "Custom executor name textbox description.";
            this.LblCustomExecutorName.AccessibleName = "Custom executor name info";
            this.LblCustomExecutorName.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblCustomExecutorName.AutoSize = true;
            this.LblCustomExecutorName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblCustomExecutorName.Location = new System.Drawing.Point(70, 509);
            this.LblCustomExecutorName.Name = "LblCustomExecutorName";
            this.LblCustomExecutorName.Size = new System.Drawing.Size(148, 19);
            this.LblCustomExecutorName.TabIndex = 64;
            this.LblCustomExecutorName.Text = Languages.ConfigExternalTools_LblCustomExecutorName;
            // 
            // LblTip1
            // 
            this.LblTip1.AccessibleDescription = "Contains a usage tip.";
            this.LblTip1.AccessibleName = "Custom browser binary tip";
            this.LblTip1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblTip1.AutoSize = true;
            this.LblTip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip1.Location = new System.Drawing.Point(437, 184);
            this.LblTip1.Name = "LblTip1";
            this.LblTip1.Size = new System.Drawing.Size(143, 15);
            this.LblTip1.TabIndex = 68;
            this.LblTip1.Text = Languages.ConfigExternalTools_LblTip1;
            // 
            // LblTip2
            // 
            this.LblTip2.AccessibleDescription = "Contains a usage tip.";
            this.LblTip2.AccessibleName = "Custom executor binary tip";
            this.LblTip2.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblTip2.AutoSize = true;
            this.LblTip2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip2.Location = new System.Drawing.Point(437, 475);
            this.LblTip2.Name = "LblTip2";
            this.LblTip2.Size = new System.Drawing.Size(143, 15);
            this.LblTip2.TabIndex = 69;
            this.LblTip2.Text = Languages.ConfigExternalTools_LblTip1;
            // 
            // BtnExternalBrowserIncognitoTest
            // 
            this.BtnExternalBrowserIncognitoTest.AccessibleDescription = "Tests the provided custom browser incognito arguments.";
            this.BtnExternalBrowserIncognitoTest.AccessibleName = "Custom browser test";
            this.BtnExternalBrowserIncognitoTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnExternalBrowserIncognitoTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExternalBrowserIncognitoTest.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnExternalBrowserIncognitoTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExternalBrowserIncognitoTest.Location = new System.Drawing.Point(437, 301);
            this.BtnExternalBrowserIncognitoTest.Name = "BtnExternalBrowserIncognitoTest";
            this.BtnExternalBrowserIncognitoTest.Size = new System.Drawing.Size(138, 25);
            this.BtnExternalBrowserIncognitoTest.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExternalBrowserIncognitoTest.Style.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExternalBrowserIncognitoTest.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExternalBrowserIncognitoTest.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExternalBrowserIncognitoTest.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExternalBrowserIncognitoTest.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExternalBrowserIncognitoTest.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExternalBrowserIncognitoTest.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnExternalBrowserIncognitoTest.TabIndex = 3;
            this.BtnExternalBrowserIncognitoTest.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigExternalTools_BtnExternalBrowserIncognitoTest;
            this.BtnExternalBrowserIncognitoTest.UseVisualStyleBackColor = false;
            this.BtnExternalBrowserIncognitoTest.Click += new System.EventHandler(this.BtnExternalBrowserIncognitoTest_Click);
            // 
            // PbLine1
            // 
            this.PbLine1.AccessibleDescription = "Seperator line.";
            this.PbLine1.AccessibleName = "Seperator";
            this.PbLine1.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbLine1.Image = global::HASS.Agent.Properties.Resources.line;
            this.PbLine1.Location = new System.Drawing.Point(73, 76);
            this.PbLine1.Name = "PbLine1";
            this.PbLine1.Size = new System.Drawing.Size(576, 1);
            this.PbLine1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbLine1.TabIndex = 71;
            this.PbLine1.TabStop = false;
            // 
            // PbLine2
            // 
            this.PbLine2.AccessibleDescription = "Seperator line.";
            this.PbLine2.AccessibleName = "Seperator";
            this.PbLine2.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbLine2.Image = global::HASS.Agent.Properties.Resources.line;
            this.PbLine2.Location = new System.Drawing.Point(73, 368);
            this.PbLine2.Name = "PbLine2";
            this.PbLine2.Size = new System.Drawing.Size(576, 1);
            this.PbLine2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbLine2.TabIndex = 72;
            this.PbLine2.TabStop = false;
            // 
            // ConfigExternalTools
            // 
            this.AccessibleDescription = "Panel containing the configuration of the \'external tools\'.";
            this.AccessibleName = "External tools";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.PbLine2);
            this.Controls.Add(this.PbLine1);
            this.Controls.Add(this.BtnExternalBrowserIncognitoTest);
            this.Controls.Add(this.LblTip2);
            this.Controls.Add(this.LblTip1);
            this.Controls.Add(this.TbExternalExecutorBinary);
            this.Controls.Add(this.LblCustomExecutorBinary);
            this.Controls.Add(this.LblInfo3);
            this.Controls.Add(this.TbExternalExecutorName);
            this.Controls.Add(this.LblCustomExecutorName);
            this.Controls.Add(this.TbExternalBrowserIncognito);
            this.Controls.Add(this.LblLaunchIncogArg);
            this.Controls.Add(this.TbExternalBrowserBinary);
            this.Controls.Add(this.LblBrowserBinary);
            this.Controls.Add(this.LblInfo2);
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.TbExternalBrowserName);
            this.Controls.Add(this.LblBrowserName);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfigExternalTools";
            this.Size = new System.Drawing.Size(700, 592);
            ((System.ComponentModel.ISupportInitialize)(this.PbLine1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbLine2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblInfo1;
        private System.Windows.Forms.Label LblBrowserName;
        internal System.Windows.Forms.TextBox TbExternalBrowserName;
        private System.Windows.Forms.Label LblInfo2;
        internal System.Windows.Forms.TextBox TbExternalBrowserBinary;
        private System.Windows.Forms.Label LblBrowserBinary;
        internal System.Windows.Forms.TextBox TbExternalBrowserIncognito;
        private System.Windows.Forms.Label LblLaunchIncogArg;
        internal System.Windows.Forms.TextBox TbExternalExecutorBinary;
        private System.Windows.Forms.Label LblCustomExecutorBinary;
        private System.Windows.Forms.Label LblInfo3;
        internal System.Windows.Forms.TextBox TbExternalExecutorName;
        private System.Windows.Forms.Label LblCustomExecutorName;
        private System.Windows.Forms.Label LblTip1;
        private System.Windows.Forms.Label LblTip2;
        internal Syncfusion.WinForms.Controls.SfButton BtnExternalBrowserIncognitoTest;
        private PictureBox PbLine1;
        private PictureBox PbLine2;
    }
}
