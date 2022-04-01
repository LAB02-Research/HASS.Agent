using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Onboarding
{
    partial class OnboardingHotKey
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
            this.PbHassAgentLogo = new System.Windows.Forms.PictureBox();
            this.TbQuickActionsHotkey = new System.Windows.Forms.TextBox();
            this.LblHotkeyCombo = new System.Windows.Forms.Label();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.BtnClear = new Syncfusion.WinForms.Controls.SfButton();
            this.LblLanguageWarning = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // PbHassAgentLogo
            // 
            this.PbHassAgentLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbHassAgentLogo.Image = global::HASS.Agent.Properties.Resources.logo_128;
            this.PbHassAgentLogo.Location = new System.Drawing.Point(24, 20);
            this.PbHassAgentLogo.Name = "PbHassAgentLogo";
            this.PbHassAgentLogo.Size = new System.Drawing.Size(128, 128);
            this.PbHassAgentLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbHassAgentLogo.TabIndex = 2;
            this.PbHassAgentLogo.TabStop = false;
            // 
            // TbQuickActionsHotkey
            // 
            this.TbQuickActionsHotkey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbQuickActionsHotkey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbQuickActionsHotkey.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbQuickActionsHotkey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbQuickActionsHotkey.Location = new System.Drawing.Point(180, 197);
            this.TbQuickActionsHotkey.Name = "TbQuickActionsHotkey";
            this.TbQuickActionsHotkey.Size = new System.Drawing.Size(248, 25);
            this.TbQuickActionsHotkey.TabIndex = 0;
            // 
            // LblHotkeyCombo
            // 
            this.LblHotkeyCombo.AutoSize = true;
            this.LblHotkeyCombo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblHotkeyCombo.Location = new System.Drawing.Point(180, 175);
            this.LblHotkeyCombo.Name = "LblHotkeyCombo";
            this.LblHotkeyCombo.Size = new System.Drawing.Size(131, 19);
            this.LblHotkeyCombo.TabIndex = 12;
            this.LblHotkeyCombo.Text = Languages.OnboardingHotKey_LblHotkeyCombo;
            // 
            // LblInfo1
            // 
            this.LblInfo1.AutoSize = true;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(180, 20);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(594, 57);
            this.LblInfo1.TabIndex = 11;
            this.LblInfo1.Text = Languages.OnboardingHotKey_LblInfo1;
            // 
            // BtnClear
            // 
            this.BtnClear.AccessibleName = "Button";
            this.BtnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClear.Location = new System.Drawing.Point(434, 197);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(102, 25);
            this.BtnClear.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClear.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClear.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClear.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClear.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClear.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClear.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnClear.TabIndex = 1;
            this.BtnClear.Text = Languages.OnboardingHotKey_BtnClear;
            this.BtnClear.UseVisualStyleBackColor = false;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // LblLanguageWarning
            // 
            this.LblLanguageWarning.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblLanguageWarning.ForeColor = System.Drawing.Color.OrangeRed;
            this.LblLanguageWarning.Location = new System.Drawing.Point(180, 247);
            this.LblLanguageWarning.Name = "LblLanguageWarning";
            this.LblLanguageWarning.Size = new System.Drawing.Size(401, 89);
            this.LblLanguageWarning.TabIndex = 13;
            // 
            // HotKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.LblLanguageWarning);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.TbQuickActionsHotkey);
            this.Controls.Add(this.LblHotkeyCombo);
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.PbHassAgentLogo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HotKey";
            this.Size = new System.Drawing.Size(803, 457);
            this.Load += new System.EventHandler(this.OnboardingHotKey_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbHassAgentLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PbHassAgentLogo;
        private System.Windows.Forms.TextBox TbQuickActionsHotkey;
        private System.Windows.Forms.Label LblHotkeyCombo;
        private System.Windows.Forms.Label LblInfo1;
        private Syncfusion.WinForms.Controls.SfButton BtnClear;
        private System.Windows.Forms.Label LblLanguageWarning;
    }
}
