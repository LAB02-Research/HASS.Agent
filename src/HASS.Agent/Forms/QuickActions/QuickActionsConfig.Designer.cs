
using HASS.Agent.Controls;
using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Forms.QuickActions
{
    partial class QuickActionsConfig
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickActionsConfig));
            this.BtnStore = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnAdd = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnModify = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnRemove = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnPreview = new Syncfusion.WinForms.Controls.SfButton();
            this.LvQuickActions = new System.Windows.Forms.ListView();
            this.ClmId = new System.Windows.Forms.ColumnHeader();
            this.ClmDomain = new System.Windows.Forms.ColumnHeader("(none)");
            this.ClmEntity = new System.Windows.Forms.ColumnHeader("(none)");
            this.ClmAction = new System.Windows.Forms.ColumnHeader("(none)");
            this.ClmHotKeyEnabled = new System.Windows.Forms.ColumnHeader("hotkey_16_header");
            this.ClmHotKey = new System.Windows.Forms.ColumnHeader();
            this.ClmDescription = new System.Windows.Forms.ColumnHeader();
            this.ClmEmpty = new System.Windows.Forms.ColumnHeader();
            this.ImgLv = new System.Windows.Forms.ImageList(this.components);
            this.LblHotkey = new System.Windows.Forms.Label();
            this.PbHotKey = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbHotKey)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnStore
            // 
            this.BtnStore.AccessibleName = "Button";
            this.BtnStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnStore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Location = new System.Drawing.Point(0, 521);
            this.BtnStore.Name = "BtnStore";
            this.BtnStore.Size = new System.Drawing.Size(933, 47);
            this.BtnStore.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStore.TabIndex = 0;
            this.BtnStore.Text = Languages.QuickActionsConfig_BtnStore;
            this.BtnStore.UseVisualStyleBackColor = false;
            this.BtnStore.Click += new System.EventHandler(this.BtnStore_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.AccessibleName = "Button";
            this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAdd.Location = new System.Drawing.Point(736, 473);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(197, 35);
            this.BtnAdd.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAdd.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAdd.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAdd.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAdd.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAdd.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAdd.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnAdd.TabIndex = 2;
            this.BtnAdd.Text = Languages.QuickActionsConfig_BtnAdd;
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnModify
            // 
            this.BtnModify.AccessibleName = "Button";
            this.BtnModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnModify.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnModify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnModify.Location = new System.Drawing.Point(533, 473);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(197, 35);
            this.BtnModify.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnModify.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnModify.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnModify.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnModify.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnModify.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnModify.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnModify.TabIndex = 3;
            this.BtnModify.Text = Languages.QuickActionsConfig_BtnModify;
            this.BtnModify.UseVisualStyleBackColor = false;
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // BtnRemove
            // 
            this.BtnRemove.AccessibleName = "Button";
            this.BtnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRemove.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRemove.Location = new System.Drawing.Point(330, 473);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(197, 35);
            this.BtnRemove.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRemove.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRemove.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRemove.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRemove.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRemove.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRemove.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnRemove.TabIndex = 4;
            this.BtnRemove.Text = Languages.QuickActionsConfig_BtnRemove;
            this.BtnRemove.UseVisualStyleBackColor = false;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnPreview
            // 
            this.BtnPreview.AccessibleName = "Button";
            this.BtnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnPreview.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnPreview.Location = new System.Drawing.Point(0, 473);
            this.BtnPreview.Name = "BtnPreview";
            this.BtnPreview.Size = new System.Drawing.Size(197, 35);
            this.BtnPreview.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnPreview.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnPreview.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnPreview.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnPreview.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnPreview.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnPreview.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnPreview.TabIndex = 5;
            this.BtnPreview.Text = Languages.QuickActionsConfig_BtnPreview;
            this.BtnPreview.UseVisualStyleBackColor = false;
            this.BtnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // LvQuickActions
            // 
            this.LvQuickActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LvQuickActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.LvQuickActions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClmId,
            this.ClmDomain,
            this.ClmEntity,
            this.ClmAction,
            this.ClmHotKeyEnabled,
            this.ClmHotKey,
            this.ClmDescription,
            this.ClmEmpty});
            this.LvQuickActions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LvQuickActions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.LvQuickActions.FullRowSelect = true;
            this.LvQuickActions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LvQuickActions.HideSelection = true;
            this.LvQuickActions.LargeImageList = this.ImgLv;
            this.LvQuickActions.Location = new System.Drawing.Point(0, 2);
            this.LvQuickActions.Name = "LvQuickActions";
            this.LvQuickActions.OwnerDraw = true;
            this.LvQuickActions.Size = new System.Drawing.Size(933, 443);
            this.LvQuickActions.SmallImageList = this.ImgLv;
            this.LvQuickActions.TabIndex = 28;
            this.LvQuickActions.UseCompatibleStateImageBehavior = false;
            this.LvQuickActions.View = System.Windows.Forms.View.Details;
            this.LvQuickActions.DoubleClick += new System.EventHandler(this.LvQuickActions_DoubleClick);
            // 
            // ClmId
            // 
            this.ClmId.Text = "id";
            this.ClmId.Width = 0;
            // 
            // ClmDomain
            // 
            this.ClmDomain.Text = Languages.QuickActionsConfig_ClmDomain;
            this.ClmDomain.Width = 120;
            // 
            // ClmEntity
            // 
            this.ClmEntity.Text = Languages.QuickActionsConfig_ClmEntity;
            this.ClmEntity.Width = 200;
            // 
            // ClmAction
            // 
            this.ClmAction.Text = Languages.QuickActionsConfig_ClmAction;
            this.ClmAction.Width = 100;
            // 
            // ClmHotKeyEnabled
            // 
            this.ClmHotKeyEnabled.Text = "";
            this.ClmHotKeyEnabled.Width = 40;
            // 
            // ClmHotKey
            // 
            this.ClmHotKey.Text = Languages.QuickActionsConfig_ClmHotKey;
            this.ClmHotKey.Width = 200;
            // 
            // ClmDescription
            // 
            this.ClmDescription.Text = Languages.QuickActionsConfig_ClmDescription;
            this.ClmDescription.Width = 250;
            // 
            // ClmEmpty
            // 
            this.ClmEmpty.Text = "";
            this.ClmEmpty.Width = 10000;
            // 
            // ImgLv
            // 
            this.ImgLv.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.ImgLv.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgLv.ImageStream")));
            this.ImgLv.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgLv.Images.SetKeyName(0, "hotkey_16_header");
            // 
            // LblHotkey
            // 
            this.LblHotkey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblHotkey.AutoSize = true;
            this.LblHotkey.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblHotkey.Location = new System.Drawing.Point(831, 449);
            this.LblHotkey.Name = "LblHotkey";
            this.LblHotkey.Size = new System.Drawing.Size(88, 15);
            this.LblHotkey.TabIndex = 43;
            this.LblHotkey.Text = Languages.QuickActionsConfig_LblHotkey;
            // 
            // PbHotKey
            // 
            this.PbHotKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PbHotKey.Image = global::HASS.Agent.Properties.Resources.hotkey_16;
            this.PbHotKey.Location = new System.Drawing.Point(809, 448);
            this.PbHotKey.Name = "PbHotKey";
            this.PbHotKey.Size = new System.Drawing.Size(16, 16);
            this.PbHotKey.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbHotKey.TabIndex = 42;
            this.PbHotKey.TabStop = false;
            // 
            // QuickActionsConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(933, 568);
            this.Controls.Add(this.LblHotkey);
            this.Controls.Add(this.PbHotKey);
            this.Controls.Add(this.LvQuickActions);
            this.Controls.Add(this.BtnPreview);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.BtnModify);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.BtnStore);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.MinimumSize = new System.Drawing.Size(945, 604);
            this.Name = "QuickActionsConfig";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Languages.QuickActionsConfig_Title;
            this.Load += new System.EventHandler(this.QuickActionsConfig_Load);
            this.ResizeBegin += new System.EventHandler(this.QuickActionsConfig_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.QuickActionsConfig_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.QuickActionsConfig_KeyUp);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.QuickActionsConfig_Layout);
            ((System.ComponentModel.ISupportInitialize)(this.PbHotKey)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Syncfusion.WinForms.Controls.SfButton BtnStore;
        private Syncfusion.WinForms.Controls.SfButton BtnAdd;
        private Syncfusion.WinForms.Controls.SfButton BtnModify;
        private Syncfusion.WinForms.Controls.SfButton BtnRemove;
        private Syncfusion.WinForms.Controls.SfButton BtnPreview;
        private ListView LvQuickActions;
        private ColumnHeader ClmId;
        private ColumnHeader ClmDomain;
        private ColumnHeader ClmEntity;
        private ColumnHeader ClmAction;
        private ColumnHeader ClmEmpty;
        private ColumnHeader ClmHotKeyEnabled;
        private ColumnHeader ClmHotKey;
        private ColumnHeader ClmDescription;
        private ImageList ImgLv;
        private Label LblHotkey;
        private PictureBox PbHotKey;
    }
}

