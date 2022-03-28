
namespace HASS.Agent.Forms.Commands
{
    partial class CommandsMod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandsMod));
            this.BtnStore = new Syncfusion.WinForms.Controls.SfButton();
            this.TbSetting = new System.Windows.Forms.TextBox();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LblSetting = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PnlDescription = new System.Windows.Forms.Panel();
            this.TbDescription = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CbRunAsLowIntegrity = new System.Windows.Forms.CheckBox();
            this.LblIntegrityInfo = new System.Windows.Forms.Label();
            this.CbCommandSpecific = new System.Windows.Forms.CheckBox();
            this.LblInfo = new System.Windows.Forms.Label();
            this.LvCommands = new System.Windows.Forms.ListView();
            this.ClmSensorName = new System.Windows.Forms.ColumnHeader();
            this.ClmAgentCompatible = new System.Windows.Forms.ColumnHeader("agent_16_header");
            this.ClmSatelliteCompatible = new System.Windows.Forms.ColumnHeader("service_16_header");
            this.ClmEmpty = new System.Windows.Forms.ColumnHeader();
            this.ImgLv = new System.Windows.Forms.ImageList(this.components);
            this.TbSelectedType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PbService = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PbAgent = new System.Windows.Forms.PictureBox();
            this.LblSpecificClient = new System.Windows.Forms.Label();
            this.PnlDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbAgent)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnStore
            // 
            this.BtnStore.AccessibleName = "Button";
            this.BtnStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnStore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Location = new System.Drawing.Point(0, 417);
            this.BtnStore.Name = "BtnStore";
            this.BtnStore.Size = new System.Drawing.Size(1319, 38);
            this.BtnStore.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStore.TabIndex = 3;
            this.BtnStore.Text = "store command";
            this.BtnStore.UseVisualStyleBackColor = false;
            this.BtnStore.Click += new System.EventHandler(this.BtnStore_Click);
            // 
            // TbSetting
            // 
            this.TbSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbSetting.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbSetting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbSetting.Location = new System.Drawing.Point(566, 191);
            this.TbSetting.Name = "TbSetting";
            this.TbSetting.Size = new System.Drawing.Size(328, 25);
            this.TbSetting.TabIndex = 2;
            this.TbSetting.Visible = false;
            // 
            // TbName
            // 
            this.TbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbName.Location = new System.Drawing.Point(566, 113);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(328, 25);
            this.TbName.TabIndex = 1;
            // 
            // LblSetting
            // 
            this.LblSetting.AutoSize = true;
            this.LblSetting.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblSetting.Location = new System.Drawing.Point(566, 171);
            this.LblSetting.Name = "LblSetting";
            this.LblSetting.Size = new System.Drawing.Size(46, 19);
            this.LblSetting.TabIndex = 12;
            this.LblSetting.Text = "config";
            this.LblSetting.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(566, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "name";
            // 
            // PnlDescription
            // 
            this.PnlDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlDescription.Controls.Add(this.TbDescription);
            this.PnlDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PnlDescription.Location = new System.Drawing.Point(955, 39);
            this.PnlDescription.Name = "PnlDescription";
            this.PnlDescription.Size = new System.Drawing.Size(354, 349);
            this.PnlDescription.TabIndex = 21;
            // 
            // TbDescription
            // 
            this.TbDescription.AutoWordSelection = true;
            this.TbDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TbDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbDescription.Location = new System.Drawing.Point(0, 0);
            this.TbDescription.Name = "TbDescription";
            this.TbDescription.ReadOnly = true;
            this.TbDescription.Size = new System.Drawing.Size(352, 347);
            this.TbDescription.TabIndex = 18;
            this.TbDescription.Text = "";
            this.TbDescription.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.TbDescription_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(955, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 19);
            this.label5.TabIndex = 20;
            this.label5.Text = "description";
            // 
            // CbRunAsLowIntegrity
            // 
            this.CbRunAsLowIntegrity.AutoSize = true;
            this.CbRunAsLowIntegrity.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbRunAsLowIntegrity.Location = new System.Drawing.Point(566, 243);
            this.CbRunAsLowIntegrity.Name = "CbRunAsLowIntegrity";
            this.CbRunAsLowIntegrity.Size = new System.Drawing.Size(152, 23);
            this.CbRunAsLowIntegrity.TabIndex = 26;
            this.CbRunAsLowIntegrity.Text = "run as \'low integrity\'";
            this.CbRunAsLowIntegrity.UseVisualStyleBackColor = true;
            this.CbRunAsLowIntegrity.Visible = false;
            // 
            // LblIntegrityInfo
            // 
            this.LblIntegrityInfo.AutoSize = true;
            this.LblIntegrityInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblIntegrityInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblIntegrityInfo.Location = new System.Drawing.Point(739, 249);
            this.LblIntegrityInfo.Name = "LblIntegrityInfo";
            this.LblIntegrityInfo.Size = new System.Drawing.Size(68, 15);
            this.LblIntegrityInfo.TabIndex = 27;
            this.LblIntegrityInfo.Text = "what\'s this?";
            this.LblIntegrityInfo.Visible = false;
            this.LblIntegrityInfo.Click += new System.EventHandler(this.LblIntegrityInfo_Click);
            // 
            // CbCommandSpecific
            // 
            this.CbCommandSpecific.AutoSize = true;
            this.CbCommandSpecific.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbCommandSpecific.Location = new System.Drawing.Point(566, 284);
            this.CbCommandSpecific.Name = "CbCommandSpecific";
            this.CbCommandSpecific.Size = new System.Drawing.Size(34, 23);
            this.CbCommandSpecific.TabIndex = 28;
            this.CbCommandSpecific.Text = "-";
            this.CbCommandSpecific.UseVisualStyleBackColor = true;
            this.CbCommandSpecific.Visible = false;
            // 
            // LblInfo
            // 
            this.LblInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo.Location = new System.Drawing.Point(566, 219);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(328, 168);
            this.LblInfo.TabIndex = 29;
            this.LblInfo.Text = "-";
            this.LblInfo.Visible = false;
            // 
            // LvCommands
            // 
            this.LvCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.LvCommands.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClmSensorName,
            this.ClmAgentCompatible,
            this.ClmSatelliteCompatible,
            this.ClmEmpty});
            this.LvCommands.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LvCommands.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.LvCommands.FullRowSelect = true;
            this.LvCommands.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LvCommands.HideSelection = true;
            this.LvCommands.LargeImageList = this.ImgLv;
            this.LvCommands.Location = new System.Drawing.Point(12, 15);
            this.LvCommands.MultiSelect = false;
            this.LvCommands.Name = "LvCommands";
            this.LvCommands.OwnerDraw = true;
            this.LvCommands.Size = new System.Drawing.Size(516, 373);
            this.LvCommands.SmallImageList = this.ImgLv;
            this.LvCommands.TabIndex = 30;
            this.LvCommands.UseCompatibleStateImageBehavior = false;
            this.LvCommands.View = System.Windows.Forms.View.Details;
            this.LvCommands.SelectedIndexChanged += new System.EventHandler(this.LvCommands_SelectedIndexChanged);
            // 
            // ClmSensorName
            // 
            this.ClmSensorName.Text = "  type";
            this.ClmSensorName.Width = 350;
            // 
            // ClmAgentCompatible
            // 
            this.ClmAgentCompatible.Text = "";
            // 
            // ClmSatelliteCompatible
            // 
            this.ClmSatelliteCompatible.Text = "";
            // 
            // ClmEmpty
            // 
            this.ClmEmpty.Text = "";
            this.ClmEmpty.Width = 500;
            // 
            // ImgLv
            // 
            this.ImgLv.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.ImgLv.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgLv.ImageStream")));
            this.ImgLv.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgLv.Images.SetKeyName(0, "multivalue_16_header");
            this.ImgLv.Images.SetKeyName(1, "agent_16_header");
            this.ImgLv.Images.SetKeyName(2, "service_16_header");
            // 
            // TbSelectedType
            // 
            this.TbSelectedType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TbSelectedType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbSelectedType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbSelectedType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbSelectedType.Location = new System.Drawing.Point(566, 40);
            this.TbSelectedType.Name = "TbSelectedType";
            this.TbSelectedType.ReadOnly = true;
            this.TbSelectedType.Size = new System.Drawing.Size(328, 25);
            this.TbSelectedType.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(566, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 31;
            this.label1.Text = "selected type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(485, 393);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 15);
            this.label8.TabIndex = 37;
            this.label8.Text = "service";
            // 
            // PbService
            // 
            this.PbService.Image = global::HASS.Agent.Properties.Resources.service_16;
            this.PbService.Location = new System.Drawing.Point(463, 392);
            this.PbService.Name = "PbService";
            this.PbService.Size = new System.Drawing.Size(16, 16);
            this.PbService.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbService.TabIndex = 36;
            this.PbService.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(403, 393);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 35;
            this.label7.Text = "agent";
            // 
            // PbAgent
            // 
            this.PbAgent.Image = global::HASS.Agent.Properties.Resources.agent_16;
            this.PbAgent.Location = new System.Drawing.Point(381, 392);
            this.PbAgent.Name = "PbAgent";
            this.PbAgent.Size = new System.Drawing.Size(16, 16);
            this.PbAgent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbAgent.TabIndex = 34;
            this.PbAgent.TabStop = false;
            // 
            // LblSpecificClient
            // 
            this.LblSpecificClient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblSpecificClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.LblSpecificClient.Location = new System.Drawing.Point(739, 18);
            this.LblSpecificClient.Name = "LblSpecificClient";
            this.LblSpecificClient.Size = new System.Drawing.Size(155, 19);
            this.LblSpecificClient.TabIndex = 38;
            this.LblSpecificClient.Text = "hass.agent only!";
            this.LblSpecificClient.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LblSpecificClient.Visible = false;
            // 
            // CommandsMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1319, 455);
            this.Controls.Add(this.LblSpecificClient);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.PbService);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PbAgent);
            this.Controls.Add(this.TbSelectedType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LvCommands);
            this.Controls.Add(this.CbCommandSpecific);
            this.Controls.Add(this.LblIntegrityInfo);
            this.Controls.Add(this.CbRunAsLowIntegrity);
            this.Controls.Add(this.PnlDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TbSetting);
            this.Controls.Add(this.BtnStore);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LblSetting);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LblInfo);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.Name = "CommandsMod";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Command";
            this.Load += new System.EventHandler(this.CommandsMod_Load);
            this.ResizeEnd += new System.EventHandler(this.CommandsMod_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CommandsMod_KeyUp);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.CommandsMod_Layout);
            this.PnlDescription.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbAgent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.WinForms.Controls.SfButton BtnStore;
        private System.Windows.Forms.Label LblSetting;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.TextBox TbSetting;
        private System.Windows.Forms.Panel PnlDescription;
        private System.Windows.Forms.RichTextBox TbDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox CbRunAsLowIntegrity;
        private System.Windows.Forms.Label LblIntegrityInfo;
        private System.Windows.Forms.CheckBox CbCommandSpecific;
        private System.Windows.Forms.Label LblInfo;
        private ListView LvCommands;
        private ColumnHeader ClmSensorName;
        private ColumnHeader ClmAgentCompatible;
        private ColumnHeader ClmSatelliteCompatible;
        private ColumnHeader ClmEmpty;
        private TextBox TbSelectedType;
        private Label label1;
        private Label label8;
        private PictureBox PbService;
        private Label label7;
        private PictureBox PbAgent;
        private ImageList ImgLv;
        private Label LblSpecificClient;
    }
}

