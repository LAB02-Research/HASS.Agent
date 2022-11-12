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
            this.LblEntityInfo = new System.Windows.Forms.Label();
            this.LblAction = new System.Windows.Forms.Label();
            this.LblDescription = new System.Windows.Forms.Label();
            this.LblLoading = new System.Windows.Forms.Label();
            this.TbHotkey = new System.Windows.Forms.TextBox();
            this.CbEnableHotkey = new System.Windows.Forms.CheckBox();
            this.LblHotkey = new System.Windows.Forms.Label();
            this.CbEntity = new System.Windows.Forms.ComboBox();
            this.CbAction = new System.Windows.Forms.ComboBox();
            this.LblTip1 = new System.Windows.Forms.Label();
            this.LvDomain = new System.Windows.Forms.ListView();
            this.ClmDomainId = new System.Windows.Forms.ColumnHeader();
            this.ClmDomain = new System.Windows.Forms.ColumnHeader();
            this.ClmEmpty = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // BtnStore
            // 
            this.BtnStore.AccessibleDescription = "Stores the quick action in the quick actions list. This does not yet activates it" +
    ".";
            this.BtnStore.AccessibleName = "Store";
            this.BtnStore.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnStore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Location = new System.Drawing.Point(0, 365);
            this.BtnStore.Name = "BtnStore";
            this.BtnStore.Size = new System.Drawing.Size(1075, 38);
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
            this.TbDescription.AccessibleDescription = "A description used for the quick action instead of the entity\'s name. Optional.";
            this.TbDescription.AccessibleName = "Description";
            this.TbDescription.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbDescription.Location = new System.Drawing.Point(399, 172);
            this.TbDescription.Name = "TbDescription";
            this.TbDescription.Size = new System.Drawing.Size(657, 25);
            this.TbDescription.TabIndex = 2;
            // 
            // LblEntityInfo
            // 
            this.LblEntityInfo.AccessibleDescription = "Entity dropdown description.";
            this.LblEntityInfo.AccessibleName = "";
            this.LblEntityInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblEntityInfo.AutoSize = true;
            this.LblEntityInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblEntityInfo.Location = new System.Drawing.Point(399, 12);
            this.LblEntityInfo.Name = "LblEntityInfo";
            this.LblEntityInfo.Size = new System.Drawing.Size(44, 19);
            this.LblEntityInfo.TabIndex = 6;
            this.LblEntityInfo.Text = Languages.QuickActionsMod_LblEntityInfo;
            // 
            // LblAction
            // 
            this.LblAction.AccessibleDescription = "Desired action dropdown description";
            this.LblAction.AccessibleName = "";
            this.LblAction.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblAction.AutoSize = true;
            this.LblAction.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblAction.Location = new System.Drawing.Point(398, 79);
            this.LblAction.Name = "LblAction";
            this.LblAction.Size = new System.Drawing.Size(98, 19);
            this.LblAction.TabIndex = 8;
            this.LblAction.Text = Languages.QuickActionsMod_LblAction;
            // 
            // LblDescription
            // 
            this.LblDescription.AccessibleDescription = "Quick action description description label.";
            this.LblDescription.AccessibleName = "Quick action description";
            this.LblDescription.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblDescription.AutoSize = true;
            this.LblDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDescription.Location = new System.Drawing.Point(398, 152);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(78, 19);
            this.LblDescription.TabIndex = 10;
            this.LblDescription.Text = Languages.QuickActionsMod_LblDescription;
            // 
            // LblLoading
            // 
            this.LblLoading.AccessibleDescription = "Notification label showing that your entities are still being fetched from Home A" +
    "ssistant.";
            this.LblLoading.AccessibleName = "Loading";
            this.LblLoading.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblLoading.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblLoading.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.LblLoading.Location = new System.Drawing.Point(398, 313);
            this.LblLoading.Name = "LblLoading";
            this.LblLoading.Size = new System.Drawing.Size(657, 37);
            this.LblLoading.TabIndex = 7;
            this.LblLoading.Text = Languages.QuickActionsMod_LblLoading;
            this.LblLoading.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.LblLoading.Visible = false;
            // 
            // TbHotkey
            // 
            this.TbHotkey.AccessibleDescription = "A hotkey combination that can be pressed to invoke this quick action.";
            this.TbHotkey.AccessibleName = "Hotkey";
            this.TbHotkey.AccessibleRole = System.Windows.Forms.AccessibleRole.HotkeyField;
            this.TbHotkey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbHotkey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbHotkey.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbHotkey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbHotkey.Location = new System.Drawing.Point(399, 257);
            this.TbHotkey.Name = "TbHotkey";
            this.TbHotkey.Size = new System.Drawing.Size(161, 25);
            this.TbHotkey.TabIndex = 3;
            this.TbHotkey.TextChanged += new System.EventHandler(this.TbHotkey_TextChanged);
            // 
            // CbEnableHotkey
            // 
            this.CbEnableHotkey.AccessibleDescription = "Enables the use of the global hotkey.";
            this.CbEnableHotkey.AccessibleName = "Enable hotkey";
            this.CbEnableHotkey.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.CbEnableHotkey.AutoSize = true;
            this.CbEnableHotkey.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbEnableHotkey.Location = new System.Drawing.Point(576, 259);
            this.CbEnableHotkey.Name = "CbEnableHotkey";
            this.CbEnableHotkey.Size = new System.Drawing.Size(114, 23);
            this.CbEnableHotkey.TabIndex = 17;
            this.CbEnableHotkey.Text = global::HASS.Agent.Resources.Localization.Languages.QuickActionsMod_CbEnableHotkey;
            this.CbEnableHotkey.UseVisualStyleBackColor = true;
            // 
            // LblHotkey
            // 
            this.LblHotkey.AccessibleDescription = "Hotkey combination description.";
            this.LblHotkey.AccessibleName = "Hotkey description";
            this.LblHotkey.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblHotkey.AutoSize = true;
            this.LblHotkey.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblHotkey.Location = new System.Drawing.Point(398, 235);
            this.LblHotkey.Name = "LblHotkey";
            this.LblHotkey.Size = new System.Drawing.Size(131, 19);
            this.LblHotkey.TabIndex = 16;
            this.LblHotkey.Text = Languages.QuickActionsMod_LblHotkey;
            // 
            // CbEntity
            // 
            this.CbEntity.AccessibleDescription = "Dropdown list of available entities within the selected domain.";
            this.CbEntity.AccessibleName = "Entity";
            this.CbEntity.AccessibleRole = System.Windows.Forms.AccessibleRole.DropList;
            this.CbEntity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CbEntity.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CbEntity.DropDownHeight = 300;
            this.CbEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbEntity.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbEntity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.CbEntity.FormattingEnabled = true;
            this.CbEntity.IntegralHeight = false;
            this.CbEntity.Location = new System.Drawing.Point(398, 32);
            this.CbEntity.Name = "CbEntity";
            this.CbEntity.Size = new System.Drawing.Size(658, 26);
            this.CbEntity.TabIndex = 0;
            this.CbEntity.SelectedIndexChanged += new System.EventHandler(this.CbEntity_SelectedIndexChanged);
            // 
            // CbAction
            // 
            this.CbAction.AccessibleDescription = "Dropdown list containing the available actions to perform on your entity.";
            this.CbAction.AccessibleName = "Desired action";
            this.CbAction.AccessibleRole = System.Windows.Forms.AccessibleRole.DropList;
            this.CbAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CbAction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CbAction.DropDownHeight = 300;
            this.CbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbAction.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbAction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.CbAction.FormattingEnabled = true;
            this.CbAction.IntegralHeight = false;
            this.CbAction.Location = new System.Drawing.Point(398, 99);
            this.CbAction.Name = "CbAction";
            this.CbAction.Size = new System.Drawing.Size(166, 26);
            this.CbAction.TabIndex = 1;
            this.CbAction.SelectedIndexChanged += new System.EventHandler(this.CbAction_SelectedIndexChanged);
            // 
            // LblTip1
            // 
            this.LblTip1.AccessibleDescription = "Contains a usage tip.";
            this.LblTip1.AccessibleName = "Description tip";
            this.LblTip1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblTip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip1.Location = new System.Drawing.Point(728, 156);
            this.LblTip1.Name = "LblTip1";
            this.LblTip1.Size = new System.Drawing.Size(328, 15);
            this.LblTip1.TabIndex = 28;
            this.LblTip1.Text = Languages.QuickActionsMod_LblTip1;
            this.LblTip1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LvDomain
            // 
            this.LvDomain.AccessibleDescription = "List of available entity domains.";
            this.LvDomain.AccessibleName = "Entity domain types";
            this.LvDomain.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.LvDomain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.LvDomain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClmDomainId,
            this.ClmDomain,
            this.ClmEmpty});
            this.LvDomain.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LvDomain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.LvDomain.FullRowSelect = true;
            this.LvDomain.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LvDomain.HideSelection = true;
            this.LvDomain.Location = new System.Drawing.Point(12, 12);
            this.LvDomain.MultiSelect = false;
            this.LvDomain.Name = "LvDomain";
            this.LvDomain.OwnerDraw = true;
            this.LvDomain.Size = new System.Drawing.Size(340, 338);
            this.LvDomain.TabIndex = 31;
            this.LvDomain.UseCompatibleStateImageBehavior = false;
            this.LvDomain.View = System.Windows.Forms.View.Details;
            this.LvDomain.SelectedIndexChanged += new System.EventHandler(this.LvDomain_SelectedIndexChanged);
            // 
            // ClmDomainId
            // 
            this.ClmDomainId.Text = "id";
            this.ClmDomainId.Width = 0;
            // 
            // ClmDomain
            // 
            this.ClmDomain.Text = Languages.QuickActionsMod_ClmDomain;
            this.ClmDomain.Width = 300;
            // 
            // ClmEmpty
            // 
            this.ClmEmpty.Tag = "hide";
            this.ClmEmpty.Text = "filler column";
            this.ClmEmpty.Width = 500;
            // 
            // QuickActionsMod
            // 
            this.AccessibleDescription = "Create or modify a quick action.";
            this.AccessibleName = "Quick action mod";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1075, 403);
            this.Controls.Add(this.LvDomain);
            this.Controls.Add(this.LblTip1);
            this.Controls.Add(this.CbAction);
            this.Controls.Add(this.CbEntity);
            this.Controls.Add(this.TbHotkey);
            this.Controls.Add(this.CbEnableHotkey);
            this.Controls.Add(this.LblHotkey);
            this.Controls.Add(this.TbDescription);
            this.Controls.Add(this.LblLoading);
            this.Controls.Add(this.BtnStore);
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
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.QuickActionsMod_Layout);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Syncfusion.WinForms.Controls.SfButton BtnStore;
        private System.Windows.Forms.Label LblEntityInfo;
        private System.Windows.Forms.Label LblAction;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.Label LblLoading;
        private System.Windows.Forms.TextBox TbDescription;
        private System.Windows.Forms.TextBox TbHotkey;
        private System.Windows.Forms.CheckBox CbEnableHotkey;
        private System.Windows.Forms.Label LblHotkey;
        private System.Windows.Forms.ComboBox CbEntity;
        private System.Windows.Forms.ComboBox CbAction;
        private System.Windows.Forms.Label LblTip1;
        private ListView LvDomain;
        private ColumnHeader ClmDomain;
        private ColumnHeader ClmDomainId;
        private ColumnHeader ClmEmpty;
    }
}

