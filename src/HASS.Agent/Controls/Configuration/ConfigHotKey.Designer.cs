using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Configuration
{
    partial class ConfigHotKey
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
            this.BtnClearHotKey = new Syncfusion.WinForms.Controls.SfButton();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.TbQuickActionsHotkey = new System.Windows.Forms.TextBox();
            this.CbEnableQuickActionsHotkey = new System.Windows.Forms.CheckBox();
            this.LblHotkeyCombo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnClearHotKey
            // 
            this.BtnClearHotKey.AccessibleDescription = "Clears the hotkey combination.";
            this.BtnClearHotKey.AccessibleName = "Clear hotkey";
            this.BtnClearHotKey.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnClearHotKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClearHotKey.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnClearHotKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClearHotKey.Location = new System.Drawing.Point(438, 279);
            this.BtnClearHotKey.Name = "BtnClearHotKey";
            this.BtnClearHotKey.Size = new System.Drawing.Size(102, 25);
            this.BtnClearHotKey.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClearHotKey.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClearHotKey.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClearHotKey.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClearHotKey.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClearHotKey.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClearHotKey.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnClearHotKey.TabIndex = 2;
            this.BtnClearHotKey.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigHotKey_BtnClearHotKey;
            this.BtnClearHotKey.UseVisualStyleBackColor = false;
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "Hotkey information.";
            this.LblInfo1.AccessibleName = "Information";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(70, 36);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(594, 108);
            this.LblInfo1.TabIndex = 17;
            this.LblInfo1.Text = Languages.ConfigHotKey_LblInfo1;
            // 
            // TbQuickActionsHotkey
            // 
            this.TbQuickActionsHotkey.AccessibleDescription = "The hotkey combination that will show your Quick Actions when triggered.";
            this.TbQuickActionsHotkey.AccessibleName = "Hotkey combination";
            this.TbQuickActionsHotkey.AccessibleRole = System.Windows.Forms.AccessibleRole.HotkeyField;
            this.TbQuickActionsHotkey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbQuickActionsHotkey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbQuickActionsHotkey.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbQuickActionsHotkey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbQuickActionsHotkey.Location = new System.Drawing.Point(201, 279);
            this.TbQuickActionsHotkey.Name = "TbQuickActionsHotkey";
            this.TbQuickActionsHotkey.Size = new System.Drawing.Size(231, 25);
            this.TbQuickActionsHotkey.TabIndex = 1;
            // 
            // CbEnableQuickActionsHotkey
            // 
            this.CbEnableQuickActionsHotkey.AccessibleDescription = "Enable the quick actions hotkey.";
            this.CbEnableQuickActionsHotkey.AccessibleName = "Quick actions hotkey";
            this.CbEnableQuickActionsHotkey.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.CbEnableQuickActionsHotkey.AutoSize = true;
            this.CbEnableQuickActionsHotkey.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbEnableQuickActionsHotkey.Location = new System.Drawing.Point(201, 181);
            this.CbEnableQuickActionsHotkey.Name = "CbEnableQuickActionsHotkey";
            this.CbEnableQuickActionsHotkey.Size = new System.Drawing.Size(197, 23);
            this.CbEnableQuickActionsHotkey.TabIndex = 0;
            this.CbEnableQuickActionsHotkey.Text = global::HASS.Agent.Resources.Localization.Languages.ConfigHotKey_CbEnableQuickActionsHotkey;
            this.CbEnableQuickActionsHotkey.UseVisualStyleBackColor = true;
            // 
            // LblHotkeyCombo
            // 
            this.LblHotkeyCombo.AccessibleDescription = "Hotkey textbox description";
            this.LblHotkeyCombo.AccessibleName = "Hotkey info";
            this.LblHotkeyCombo.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblHotkeyCombo.AutoSize = true;
            this.LblHotkeyCombo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblHotkeyCombo.Location = new System.Drawing.Point(201, 257);
            this.LblHotkeyCombo.Name = "LblHotkeyCombo";
            this.LblHotkeyCombo.Size = new System.Drawing.Size(131, 19);
            this.LblHotkeyCombo.TabIndex = 14;
            this.LblHotkeyCombo.Text = Languages.ConfigHotKey_LblHotkeyCombo;
            // 
            // ConfigHotKey
            // 
            this.AccessibleDescription = "Panel containing the hotkey configuration.";
            this.AccessibleName = "Hotkey";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.BtnClearHotKey);
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.TbQuickActionsHotkey);
            this.Controls.Add(this.CbEnableQuickActionsHotkey);
            this.Controls.Add(this.LblHotkeyCombo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfigHotKey";
            this.Size = new System.Drawing.Size(700, 544);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblInfo1;
        private System.Windows.Forms.Label LblHotkeyCombo;
        internal Syncfusion.WinForms.Controls.SfButton BtnClearHotKey;
        internal System.Windows.Forms.TextBox TbQuickActionsHotkey;
        internal System.Windows.Forms.CheckBox CbEnableQuickActionsHotkey;
    }
}
