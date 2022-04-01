
using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Forms.Commands
{
    partial class CommandsConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandsConfig));
            this.BtnRemove = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnModify = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnAdd = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnStore = new Syncfusion.WinForms.Controls.SfButton();
            this.LvCommands = new System.Windows.Forms.ListView();
            this.ClmId = new System.Windows.Forms.ColumnHeader();
            this.ClmName = new System.Windows.Forms.ColumnHeader("(none)");
            this.ClmType = new System.Windows.Forms.ColumnHeader("(none)");
            this.ClmLowIntegrity = new System.Windows.Forms.ColumnHeader("shield_16_header");
            this.ClmAction = new System.Windows.Forms.ColumnHeader("action_16_header");
            this.ClmEmpty = new System.Windows.Forms.ColumnHeader();
            this.ImgLv = new System.Windows.Forms.ImageList(this.components);
            this.LblLowIntegrity = new System.Windows.Forms.Label();
            this.PbLowIntegrity = new System.Windows.Forms.PictureBox();
            this.LblActionInfo = new System.Windows.Forms.Label();
            this.PbActionInfo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbLowIntegrity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbActionInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnRemove
            // 
            this.BtnRemove.AccessibleName = "Button";
            this.BtnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRemove.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRemove.Location = new System.Drawing.Point(0, 509);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(197, 35);
            this.BtnRemove.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRemove.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRemove.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRemove.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRemove.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRemove.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRemove.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnRemove.TabIndex = 10;
            this.BtnRemove.Text = Languages.CommandsConfig_BtnRemove;
            this.BtnRemove.UseVisualStyleBackColor = false;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnModify
            // 
            this.BtnModify.AccessibleName = "Button";
            this.BtnModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnModify.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnModify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnModify.Location = new System.Drawing.Point(245, 509);
            this.BtnModify.Name = "BtnModify";
            this.BtnModify.Size = new System.Drawing.Size(197, 35);
            this.BtnModify.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnModify.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnModify.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnModify.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnModify.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnModify.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnModify.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnModify.TabIndex = 9;
            this.BtnModify.Text = Languages.CommandsConfig_BtnModify;
            this.BtnModify.UseVisualStyleBackColor = false;
            this.BtnModify.Click += new System.EventHandler(this.BtnModify_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.AccessibleName = "Button";
            this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAdd.Location = new System.Drawing.Point(448, 509);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(197, 35);
            this.BtnAdd.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAdd.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAdd.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAdd.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAdd.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnAdd.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnAdd.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnAdd.TabIndex = 8;
            this.BtnAdd.Text = Languages.CommandsConfig_BtnAdd;
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnStore
            // 
            this.BtnStore.AccessibleName = "Button";
            this.BtnStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnStore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Location = new System.Drawing.Point(0, 557);
            this.BtnStore.Name = "BtnStore";
            this.BtnStore.Size = new System.Drawing.Size(645, 47);
            this.BtnStore.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStore.TabIndex = 6;
            this.BtnStore.Text = Languages.CommandsConfig_BtnStore;
            this.BtnStore.UseVisualStyleBackColor = false;
            this.BtnStore.Click += new System.EventHandler(this.BtnStore_Click);
            // 
            // LvCommands
            // 
            this.LvCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LvCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.LvCommands.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClmId,
            this.ClmName,
            this.ClmType,
            this.ClmLowIntegrity,
            this.ClmAction,
            this.ClmEmpty});
            this.LvCommands.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LvCommands.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.LvCommands.FullRowSelect = true;
            this.LvCommands.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LvCommands.HideSelection = true;
            this.LvCommands.LargeImageList = this.ImgLv;
            this.LvCommands.Location = new System.Drawing.Point(0, 2);
            this.LvCommands.Name = "LvCommands";
            this.LvCommands.OwnerDraw = true;
            this.LvCommands.Size = new System.Drawing.Size(645, 479);
            this.LvCommands.SmallImageList = this.ImgLv;
            this.LvCommands.TabIndex = 28;
            this.LvCommands.UseCompatibleStateImageBehavior = false;
            this.LvCommands.View = System.Windows.Forms.View.Details;
            this.LvCommands.DoubleClick += new System.EventHandler(this.LvCommands_DoubleClick);
            // 
            // ClmId
            // 
            this.ClmId.Text = "id";
            this.ClmId.Width = 0;
            // 
            // ClmName
            // 
            this.ClmName.Text = Languages.CommandsConfig_ClmName;
            this.ClmName.Width = 300;
            // 
            // ClmType
            // 
            this.ClmType.Text = Languages.CommandsConfig_ClmType;
            this.ClmType.Width = 190;
            // 
            // ClmLowIntegrity
            // 
            this.ClmLowIntegrity.Text = "";
            // 
            // ClmAction
            // 
            this.ClmAction.Text = "";
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
            this.ImgLv.Images.SetKeyName(0, "shield_16_header");
            this.ImgLv.Images.SetKeyName(1, "action_16_header");
            // 
            // LblLowIntegrity
            // 
            this.LblLowIntegrity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblLowIntegrity.AutoSize = true;
            this.LblLowIntegrity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblLowIntegrity.Location = new System.Drawing.Point(487, 487);
            this.LblLowIntegrity.Name = "LblLowIntegrity";
            this.LblLowIntegrity.Size = new System.Drawing.Size(73, 15);
            this.LblLowIntegrity.TabIndex = 39;
            this.LblLowIntegrity.Text = Languages.CommandsConfig_LblLowIntegrity;
            // 
            // PbLowIntegrity
            // 
            this.PbLowIntegrity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PbLowIntegrity.Image = global::HASS.Agent.Properties.Resources.shield_16;
            this.PbLowIntegrity.Location = new System.Drawing.Point(465, 486);
            this.PbLowIntegrity.Name = "PbLowIntegrity";
            this.PbLowIntegrity.Size = new System.Drawing.Size(16, 16);
            this.PbLowIntegrity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbLowIntegrity.TabIndex = 38;
            this.PbLowIntegrity.TabStop = false;
            // 
            // LblActionInfo
            // 
            this.LblActionInfo.AutoSize = true;
            this.LblActionInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblActionInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblActionInfo.Location = new System.Drawing.Point(605, 487);
            this.LblActionInfo.Name = "LblActionInfo";
            this.LblActionInfo.Size = new System.Drawing.Size(40, 15);
            this.LblActionInfo.TabIndex = 45;
            this.LblActionInfo.Text = Languages.CommandsConfig_LblActionInfo;
            this.LblActionInfo.Click += new System.EventHandler(this.LblActionInfo_Click);
            // 
            // PbActionInfo
            // 
            this.PbActionInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbActionInfo.Image = global::HASS.Agent.Properties.Resources.action_16;
            this.PbActionInfo.Location = new System.Drawing.Point(583, 486);
            this.PbActionInfo.Name = "PbActionInfo";
            this.PbActionInfo.Size = new System.Drawing.Size(16, 16);
            this.PbActionInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbActionInfo.TabIndex = 44;
            this.PbActionInfo.TabStop = false;
            this.PbActionInfo.Click += new System.EventHandler(this.PbActionInfo_Click);
            // 
            // CommandsConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(645, 604);
            this.Controls.Add(this.LblActionInfo);
            this.Controls.Add(this.PbActionInfo);
            this.Controls.Add(this.LblLowIntegrity);
            this.Controls.Add(this.PbLowIntegrity);
            this.Controls.Add(this.LvCommands);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.BtnModify);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.BtnStore);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.MinimumSize = new System.Drawing.Size(657, 598);
            this.Name = "CommandsConfig";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Languages.CommandsConfig_Title;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommandsConfig_FormClosing);
            this.Load += new System.EventHandler(this.CommandsConfig_Load);
            this.ResizeBegin += new System.EventHandler(this.CommandsConfig_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.CommandsConfig_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CommandsConfig_KeyUp);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.CommandsConfig_Layout);
            ((System.ComponentModel.ISupportInitialize)(this.PbLowIntegrity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbActionInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.WinForms.Controls.SfButton BtnRemove;
        private Syncfusion.WinForms.Controls.SfButton BtnModify;
        private Syncfusion.WinForms.Controls.SfButton BtnAdd;
        private Syncfusion.WinForms.Controls.SfButton BtnStore;
        private ListView LvCommands;
        private ColumnHeader ClmId;
        private ColumnHeader ClmName;
        private ColumnHeader ClmType;
        private ColumnHeader ClmLowIntegrity;
        private ColumnHeader ClmEmpty;
        private ImageList ImgLv;
        private Label LblLowIntegrity;
        private PictureBox PbLowIntegrity;
        private ColumnHeader ClmAction;
        private Label LblActionInfo;
        private PictureBox PbActionInfo;
    }
}

