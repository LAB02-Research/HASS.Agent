using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Forms.QuickActions
{
    partial class QuickActionsMod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickActionsMod));
            this.BtnStore = new Syncfusion.WinForms.Controls.SfButton();
            this.TbDescription = new System.Windows.Forms.TextBox();
            this.LblDomain = new System.Windows.Forms.Label();
            this.LblEntityInfo = new System.Windows.Forms.Label();
            this.LblAction = new System.Windows.Forms.Label();
            this.LblDescription = new System.Windows.Forms.Label();
            this.LblLoading = new System.Windows.Forms.Label();
            this.LblEntity = new System.Windows.Forms.Label();
            this.TbHotkey = new System.Windows.Forms.TextBox();
            this.CbEnableHotkey = new System.Windows.Forms.CheckBox();
            this.LblHotkey = new System.Windows.Forms.Label();
            this.CbDomain = new System.Windows.Forms.ComboBox();
            this.CbEntity = new System.Windows.Forms.ComboBox();
            this.CbAction = new System.Windows.Forms.ComboBox();
            this.LblTip1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnStore
            // 
            this.BtnStore.AccessibleName = "Button";
            this.BtnStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnStore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Location = new System.Drawing.Point(0, 457);
            this.BtnStore.Name = "BtnStore";
            this.BtnStore.Size = new System.Drawing.Size(352, 38);
            this.BtnStore.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStore.TabIndex = 4;
            this.BtnStore.Text = global::HASS.Agent.Resources.Localization.Languages.QuickActionsMod_BtnStore;
            this.BtnStore.UseVisualStyleBackColor = false;
            this.BtnStore.Click += new System.EventHandler(this.BtnStore_Click);
            // 
            // TbDescription
            // 
            this.TbDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbDescription.Location = new System.Drawing.Point(13, 291);
            this.TbDescription.Name = "TbDescription";
            this.TbDescription.Size = new System.Drawing.Size(328, 25);
            this.TbDescription.TabIndex = 3;
            // 
            // LblDomain
            // 
            this.LblDomain.AutoSize = true;
            this.LblDomain.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDomain.Location = new System.Drawing.Point(13, 19);
            this.LblDomain.Name = "LblDomain";
            this.LblDomain.Size = new System.Drawing.Size(55, 19);
            this.LblDomain.TabIndex = 3;
            this.LblDomain.Text = Languages.QuickActionsMod_LblDomain;
            // 
            // LblEntityInfo
            // 
            this.LblEntityInfo.AutoSize = true;
            this.LblEntityInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblEntityInfo.Location = new System.Drawing.Point(13, 78);
            this.LblEntityInfo.Name = "LblEntityInfo";
            this.LblEntityInfo.Size = new System.Drawing.Size(44, 19);
            this.LblEntityInfo.TabIndex = 6;
            this.LblEntityInfo.Text = Languages.QuickActionsMod_LblEntityInfo;
            // 
            // LblAction
            // 
            this.LblAction.AutoSize = true;
            this.LblAction.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblAction.Location = new System.Drawing.Point(13, 209);
            this.LblAction.Name = "LblAction";
            this.LblAction.Size = new System.Drawing.Size(46, 19);
            this.LblAction.TabIndex = 8;
            this.LblAction.Text = Languages.QuickActionsMod_LblAction;
            // 
            // LblDescription
            // 
            this.LblDescription.AutoSize = true;
            this.LblDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDescription.Location = new System.Drawing.Point(12, 271);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(76, 19);
            this.LblDescription.TabIndex = 10;
            this.LblDescription.Text = Languages.QuickActionsMod_LblDescription;
            // 
            // LblLoading
            // 
            this.LblLoading.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblLoading.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.LblLoading.Location = new System.Drawing.Point(0, 410);
            this.LblLoading.Name = "LblLoading";
            this.LblLoading.Size = new System.Drawing.Size(352, 41);
            this.LblLoading.TabIndex = 7;
            this.LblLoading.Text = Languages.QuickActionsMod_LblLoading;
            this.LblLoading.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.LblLoading.Visible = false;
            // 
            // LblEntity
            // 
            this.LblEntity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblEntity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblEntity.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblEntity.Location = new System.Drawing.Point(12, 127);
            this.LblEntity.Name = "LblEntity";
            this.LblEntity.Size = new System.Drawing.Size(328, 69);
            this.LblEntity.TabIndex = 15;
            // 
            // TbHotkey
            // 
            this.TbHotkey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbHotkey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbHotkey.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbHotkey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbHotkey.Location = new System.Drawing.Point(179, 353);
            this.TbHotkey.Name = "TbHotkey";
            this.TbHotkey.Size = new System.Drawing.Size(161, 25);
            this.TbHotkey.TabIndex = 18;
            this.TbHotkey.TextChanged += new System.EventHandler(this.TbHotkey_TextChanged);
            // 
            // CbEnableHotkey
            // 
            this.CbEnableHotkey.AutoSize = true;
            this.CbEnableHotkey.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbEnableHotkey.Location = new System.Drawing.Point(179, 384);
            this.CbEnableHotkey.Name = "CbEnableHotkey";
            this.CbEnableHotkey.Size = new System.Drawing.Size(114, 23);
            this.CbEnableHotkey.TabIndex = 17;
            this.CbEnableHotkey.Text = global::HASS.Agent.Resources.Localization.Languages.QuickActionsMod_CbEnableHotkey;
            this.CbEnableHotkey.UseVisualStyleBackColor = true;
            // 
            // LblHotkey
            // 
            this.LblHotkey.AutoSize = true;
            this.LblHotkey.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblHotkey.Location = new System.Drawing.Point(12, 355);
            this.LblHotkey.Name = "LblHotkey";
            this.LblHotkey.Size = new System.Drawing.Size(134, 19);
            this.LblHotkey.TabIndex = 16;
            this.LblHotkey.Text = Languages.QuickActionsMod_LblHotkey;
            // 
            // CbDomain
            // 
            this.CbDomain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CbDomain.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CbDomain.DropDownHeight = 300;
            this.CbDomain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbDomain.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbDomain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.CbDomain.FormattingEnabled = true;
            this.CbDomain.IntegralHeight = false;
            this.CbDomain.Location = new System.Drawing.Point(12, 39);
            this.CbDomain.Name = "CbDomain";
            this.CbDomain.Size = new System.Drawing.Size(328, 26);
            this.CbDomain.TabIndex = 25;
            this.CbDomain.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.CbDomain_DrawItem);
            this.CbDomain.SelectedIndexChanged += new System.EventHandler(this.CbDomain_SelectedIndexChanged);
            // 
            // CbEntity
            // 
            this.CbEntity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CbEntity.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CbEntity.DropDownHeight = 300;
            this.CbEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbEntity.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbEntity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.CbEntity.FormattingEnabled = true;
            this.CbEntity.IntegralHeight = false;
            this.CbEntity.Location = new System.Drawing.Point(12, 98);
            this.CbEntity.Name = "CbEntity";
            this.CbEntity.Size = new System.Drawing.Size(328, 26);
            this.CbEntity.TabIndex = 26;
            this.CbEntity.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.CbEntity_DrawItem);
            this.CbEntity.SelectedIndexChanged += new System.EventHandler(this.CbEntity_SelectedIndexChanged);
            // 
            // CbAction
            // 
            this.CbAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CbAction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CbAction.DropDownHeight = 300;
            this.CbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbAction.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbAction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.CbAction.FormattingEnabled = true;
            this.CbAction.IntegralHeight = false;
            this.CbAction.Location = new System.Drawing.Point(13, 229);
            this.CbAction.Name = "CbAction";
            this.CbAction.Size = new System.Drawing.Size(166, 26);
            this.CbAction.TabIndex = 27;
            this.CbAction.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.CbAction_DrawItem);
            this.CbAction.SelectedIndexChanged += new System.EventHandler(this.CbAction_SelectedIndexChanged);
            // 
            // LblTip1
            // 
            this.LblTip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip1.Location = new System.Drawing.Point(12, 319);
            this.LblTip1.Name = "LblTip1";
            this.LblTip1.Size = new System.Drawing.Size(328, 15);
            this.LblTip1.TabIndex = 28;
            this.LblTip1.Text = Languages.QuickActionsMod_LblTip1;
            this.LblTip1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // QuickActionsMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(352, 495);
            this.Controls.Add(this.LblTip1);
            this.Controls.Add(this.CbAction);
            this.Controls.Add(this.CbEntity);
            this.Controls.Add(this.CbDomain);
            this.Controls.Add(this.TbHotkey);
            this.Controls.Add(this.CbEnableHotkey);
            this.Controls.Add(this.LblHotkey);
            this.Controls.Add(this.LblEntity);
            this.Controls.Add(this.TbDescription);
            this.Controls.Add(this.LblLoading);
            this.Controls.Add(this.BtnStore);
            this.Controls.Add(this.LblDomain);
            this.Controls.Add(this.LblDescription);
            this.Controls.Add(this.LblEntityInfo);
            this.Controls.Add(this.LblAction);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.Name = "QuickActionsMod";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Languages.QuickActionsMod_Title;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuickActionsMod_FormClosing);
            this.Load += new System.EventHandler(this.QuickActionsMod_Load);
            this.ResizeEnd += new System.EventHandler(this.QuickActionsMod_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.QuickActionsMod_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Syncfusion.WinForms.Controls.SfButton BtnStore;
        private System.Windows.Forms.Label LblDomain;
        private System.Windows.Forms.Label LblEntityInfo;
        private System.Windows.Forms.Label LblAction;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.Label LblLoading;
        private System.Windows.Forms.TextBox TbDescription;
        private System.Windows.Forms.Label LblEntity;
        private System.Windows.Forms.TextBox TbHotkey;
        private System.Windows.Forms.CheckBox CbEnableHotkey;
        private System.Windows.Forms.Label LblHotkey;
        private System.Windows.Forms.ComboBox CbDomain;
        private System.Windows.Forms.ComboBox CbEntity;
        private System.Windows.Forms.ComboBox CbAction;
        private System.Windows.Forms.Label LblTip1;
    }
}

