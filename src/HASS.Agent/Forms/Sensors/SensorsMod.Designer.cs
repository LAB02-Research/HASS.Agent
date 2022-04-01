
using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Forms.Sensors
{
    partial class SensorsMod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SensorsMod));
            this.BtnStore = new Syncfusion.WinForms.Controls.SfButton();
            this.LblSetting1 = new System.Windows.Forms.Label();
            this.TbSetting1 = new System.Windows.Forms.TextBox();
            this.LblType = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LblUpdate = new System.Windows.Forms.Label();
            this.LblSeconds = new System.Windows.Forms.Label();
            this.LblDescription = new System.Windows.Forms.Label();
            this.TbDescription = new System.Windows.Forms.RichTextBox();
            this.PnlDescription = new System.Windows.Forms.Panel();
            this.LblSetting2 = new System.Windows.Forms.Label();
            this.TbSetting2 = new System.Windows.Forms.TextBox();
            this.LblSetting3 = new System.Windows.Forms.Label();
            this.TbSetting3 = new System.Windows.Forms.TextBox();
            this.NumInterval = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.LvSensors = new System.Windows.Forms.ListView();
            this.ClmSensorName = new System.Windows.Forms.ColumnHeader();
            this.ClmMultiValue = new System.Windows.Forms.ColumnHeader("multivalue_16_header");
            this.ClmAgentCompatible = new System.Windows.Forms.ColumnHeader("agent_16_header");
            this.ClmSatelliteCompatible = new System.Windows.Forms.ColumnHeader("service_16_header");
            this.ClmEmpty = new System.Windows.Forms.ColumnHeader();
            this.ImgLv = new System.Windows.Forms.ImageList(this.components);
            this.TbSelectedType = new System.Windows.Forms.TextBox();
            this.PbMultiValue = new System.Windows.Forms.PictureBox();
            this.LblMultiValue = new System.Windows.Forms.Label();
            this.LblAgent = new System.Windows.Forms.Label();
            this.PbAgent = new System.Windows.Forms.PictureBox();
            this.LblService = new System.Windows.Forms.Label();
            this.PbService = new System.Windows.Forms.PictureBox();
            this.LblSpecificClient = new System.Windows.Forms.Label();
            this.PnlDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbMultiValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbAgent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbService)).BeginInit();
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
            this.BtnStore.TabIndex = 5;
            this.BtnStore.Text = Languages.SensorsMod_BtnStore;
            this.BtnStore.UseVisualStyleBackColor = false;
            this.BtnStore.Click += new System.EventHandler(this.BtnStore_Click);
            // 
            // LblSetting1
            // 
            this.LblSetting1.AutoSize = true;
            this.LblSetting1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblSetting1.Location = new System.Drawing.Point(566, 235);
            this.LblSetting1.Name = "LblSetting1";
            this.LblSetting1.Size = new System.Drawing.Size(63, 19);
            this.LblSetting1.TabIndex = 12;
            this.LblSetting1.Text = Languages.SensorsMod_LblSetting1;
            this.LblSetting1.Visible = false;
            // 
            // TbSetting1
            // 
            this.TbSetting1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbSetting1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbSetting1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbSetting1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbSetting1.Location = new System.Drawing.Point(566, 257);
            this.TbSetting1.Name = "TbSetting1";
            this.TbSetting1.Size = new System.Drawing.Size(328, 25);
            this.TbSetting1.TabIndex = 2;
            this.TbSetting1.Visible = false;
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblType.Location = new System.Drawing.Point(566, 18);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(89, 19);
            this.LblType.TabIndex = 3;
            this.LblType.Text = Languages.SensorsMod_LblType;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblName.Location = new System.Drawing.Point(566, 91);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(43, 19);
            this.LblName.TabIndex = 10;
            this.LblName.Text = Languages.SensorsMod_LblName;
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
            // LblUpdate
            // 
            this.LblUpdate.AutoSize = true;
            this.LblUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblUpdate.Location = new System.Drawing.Point(566, 174);
            this.LblUpdate.Name = "LblUpdate";
            this.LblUpdate.Size = new System.Drawing.Size(89, 19);
            this.LblUpdate.TabIndex = 13;
            this.LblUpdate.Text = Languages.SensorsMod_LblUpdate;
            // 
            // LblSeconds
            // 
            this.LblSeconds.AutoSize = true;
            this.LblSeconds.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblSeconds.Location = new System.Drawing.Point(750, 176);
            this.LblSeconds.Name = "LblSeconds";
            this.LblSeconds.Size = new System.Drawing.Size(58, 19);
            this.LblSeconds.TabIndex = 15;
            this.LblSeconds.Text = Languages.SensorsMod_LblSeconds;
            // 
            // LblDescription
            // 
            this.LblDescription.AutoSize = true;
            this.LblDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDescription.Location = new System.Drawing.Point(955, 17);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(76, 19);
            this.LblDescription.TabIndex = 17;
            this.LblDescription.Text = Languages.SensorsMod_LblDescription;
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
            // PnlDescription
            // 
            this.PnlDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlDescription.Controls.Add(this.TbDescription);
            this.PnlDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PnlDescription.Location = new System.Drawing.Point(955, 39);
            this.PnlDescription.Name = "PnlDescription";
            this.PnlDescription.Size = new System.Drawing.Size(354, 349);
            this.PnlDescription.TabIndex = 19;
            // 
            // LblSetting2
            // 
            this.LblSetting2.AutoSize = true;
            this.LblSetting2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblSetting2.Location = new System.Drawing.Point(566, 288);
            this.LblSetting2.Name = "LblSetting2";
            this.LblSetting2.Size = new System.Drawing.Size(59, 19);
            this.LblSetting2.TabIndex = 21;
            this.LblSetting2.Text = Languages.SensorsMod_LblSetting2;
            this.LblSetting2.Visible = false;
            // 
            // TbSetting2
            // 
            this.TbSetting2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbSetting2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbSetting2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbSetting2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbSetting2.Location = new System.Drawing.Point(566, 310);
            this.TbSetting2.Name = "TbSetting2";
            this.TbSetting2.Size = new System.Drawing.Size(328, 25);
            this.TbSetting2.TabIndex = 3;
            this.TbSetting2.Visible = false;
            // 
            // LblSetting3
            // 
            this.LblSetting3.AutoSize = true;
            this.LblSetting3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblSetting3.Location = new System.Drawing.Point(566, 341);
            this.LblSetting3.Name = "LblSetting3";
            this.LblSetting3.Size = new System.Drawing.Size(63, 19);
            this.LblSetting3.TabIndex = 23;
            this.LblSetting3.Text = Languages.SensorsMod_LblSetting3;
            this.LblSetting3.Visible = false;
            // 
            // TbSetting3
            // 
            this.TbSetting3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbSetting3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbSetting3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbSetting3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbSetting3.Location = new System.Drawing.Point(566, 363);
            this.TbSetting3.Name = "TbSetting3";
            this.TbSetting3.Size = new System.Drawing.Size(328, 25);
            this.TbSetting3.TabIndex = 4;
            this.TbSetting3.Visible = false;
            // 
            // NumInterval
            // 
            this.NumInterval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.NumInterval.BeforeTouchSize = new System.Drawing.Size(83, 25);
            this.NumInterval.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.NumInterval.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.NumInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumInterval.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumInterval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.NumInterval.Location = new System.Drawing.Point(661, 174);
            this.NumInterval.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.NumInterval.MaxLength = 10;
            this.NumInterval.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumInterval.Name = "NumInterval";
            this.NumInterval.Size = new System.Drawing.Size(83, 25);
            this.NumInterval.TabIndex = 25;
            this.NumInterval.ThemeName = "Metro";
            this.NumInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumInterval.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // LvSensors
            // 
            this.LvSensors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.LvSensors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClmSensorName,
            this.ClmMultiValue,
            this.ClmAgentCompatible,
            this.ClmSatelliteCompatible,
            this.ClmEmpty});
            this.LvSensors.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LvSensors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.LvSensors.FullRowSelect = true;
            this.LvSensors.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.LvSensors.HideSelection = true;
            this.LvSensors.LargeImageList = this.ImgLv;
            this.LvSensors.Location = new System.Drawing.Point(12, 15);
            this.LvSensors.MultiSelect = false;
            this.LvSensors.Name = "LvSensors";
            this.LvSensors.OwnerDraw = true;
            this.LvSensors.Size = new System.Drawing.Size(516, 373);
            this.LvSensors.SmallImageList = this.ImgLv;
            this.LvSensors.TabIndex = 26;
            this.LvSensors.UseCompatibleStateImageBehavior = false;
            this.LvSensors.View = System.Windows.Forms.View.Details;
            this.LvSensors.SelectedIndexChanged += new System.EventHandler(this.LvSensors_SelectedIndexChanged);
            // 
            // ClmSensorName
            // 
            this.ClmSensorName.Text = Languages.SensorsMod_ClmSensorName;
            this.ClmSensorName.Width = 300;
            // 
            // ClmMultiValue
            // 
            this.ClmMultiValue.Text = "";
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
            this.TbSelectedType.TabIndex = 27;
            // 
            // PbMultiValue
            // 
            this.PbMultiValue.Image = global::HASS.Agent.Properties.Resources.multivalue_16;
            this.PbMultiValue.Location = new System.Drawing.Point(273, 392);
            this.PbMultiValue.Name = "PbMultiValue";
            this.PbMultiValue.Size = new System.Drawing.Size(16, 16);
            this.PbMultiValue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbMultiValue.TabIndex = 28;
            this.PbMultiValue.TabStop = false;
            // 
            // LblMultiValue
            // 
            this.LblMultiValue.AutoSize = true;
            this.LblMultiValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblMultiValue.Location = new System.Drawing.Point(295, 393);
            this.LblMultiValue.Name = "LblMultiValue";
            this.LblMultiValue.Size = new System.Drawing.Size(63, 15);
            this.LblMultiValue.TabIndex = 29;
            this.LblMultiValue.Text = Languages.SensorsMod_LblMultiValue;
            // 
            // LblAgent
            // 
            this.LblAgent.AutoSize = true;
            this.LblAgent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblAgent.Location = new System.Drawing.Point(403, 393);
            this.LblAgent.Name = "LblAgent";
            this.LblAgent.Size = new System.Drawing.Size(37, 15);
            this.LblAgent.TabIndex = 31;
            this.LblAgent.Text = Languages.SensorsMod_LblAgent;
            // 
            // PbAgent
            // 
            this.PbAgent.Image = global::HASS.Agent.Properties.Resources.agent_16;
            this.PbAgent.Location = new System.Drawing.Point(381, 392);
            this.PbAgent.Name = "PbAgent";
            this.PbAgent.Size = new System.Drawing.Size(16, 16);
            this.PbAgent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbAgent.TabIndex = 30;
            this.PbAgent.TabStop = false;
            // 
            // LblService
            // 
            this.LblService.AutoSize = true;
            this.LblService.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblService.Location = new System.Drawing.Point(485, 393);
            this.LblService.Name = "LblService";
            this.LblService.Size = new System.Drawing.Size(43, 15);
            this.LblService.TabIndex = 33;
            this.LblService.Text = Languages.SensorsMod_LblService;
            // 
            // PbService
            // 
            this.PbService.Image = global::HASS.Agent.Properties.Resources.service_16;
            this.PbService.Location = new System.Drawing.Point(463, 392);
            this.PbService.Name = "PbService";
            this.PbService.Size = new System.Drawing.Size(16, 16);
            this.PbService.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbService.TabIndex = 32;
            this.PbService.TabStop = false;
            // 
            // LblSpecificClient
            // 
            this.LblSpecificClient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblSpecificClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.LblSpecificClient.Location = new System.Drawing.Point(739, 18);
            this.LblSpecificClient.Name = "LblSpecificClient";
            this.LblSpecificClient.Size = new System.Drawing.Size(155, 19);
            this.LblSpecificClient.TabIndex = 39;
            this.LblSpecificClient.Text = Languages.SensorsMod_LblSpecificClient;
            this.LblSpecificClient.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LblSpecificClient.Visible = false;
            // 
            // SensorsMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1319, 455);
            this.Controls.Add(this.LblSpecificClient);
            this.Controls.Add(this.LblService);
            this.Controls.Add(this.PbService);
            this.Controls.Add(this.LblAgent);
            this.Controls.Add(this.PbAgent);
            this.Controls.Add(this.LblMultiValue);
            this.Controls.Add(this.PbMultiValue);
            this.Controls.Add(this.TbSelectedType);
            this.Controls.Add(this.LvSensors);
            this.Controls.Add(this.NumInterval);
            this.Controls.Add(this.LblSetting3);
            this.Controls.Add(this.TbSetting3);
            this.Controls.Add(this.LblSetting2);
            this.Controls.Add(this.TbSetting2);
            this.Controls.Add(this.PnlDescription);
            this.Controls.Add(this.LblDescription);
            this.Controls.Add(this.LblSetting1);
            this.Controls.Add(this.BtnStore);
            this.Controls.Add(this.TbSetting1);
            this.Controls.Add(this.LblType);
            this.Controls.Add(this.LblSeconds);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.LblUpdate);
            this.Controls.Add(this.TbName);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.Name = "SensorsMod";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Languages.SensorsMod_Title;
            this.Load += new System.EventHandler(this.SensorMod_Load);
            this.ResizeEnd += new System.EventHandler(this.SensorsMod_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SensorsMod_KeyUp);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.SensorsMod_Layout);
            this.PnlDescription.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbMultiValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbAgent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbService)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.WinForms.Controls.SfButton BtnStore;
        private System.Windows.Forms.Label LblSetting1;
        private System.Windows.Forms.TextBox TbSetting1;
        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.Label LblSeconds;
        private System.Windows.Forms.Label LblUpdate;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.RichTextBox TbDescription;
        private System.Windows.Forms.Panel PnlDescription;
        private System.Windows.Forms.Label LblSetting2;
        private System.Windows.Forms.TextBox TbSetting2;
        private System.Windows.Forms.Label LblSetting3;
        private System.Windows.Forms.TextBox TbSetting3;
        private Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumInterval;
        private ListView LvSensors;
        private ColumnHeader ClmSensorName;
        private ColumnHeader ClmMultiValue;
        private ColumnHeader ClmAgentCompatible;
        private ColumnHeader ClmSatelliteCompatible;
        private ColumnHeader ClmEmpty;
        private TextBox TbSelectedType;
        private ImageList ImgLv;
        private PictureBox PbMultiValue;
        private Label LblMultiValue;
        private Label LblAgent;
        private PictureBox PbAgent;
        private Label LblService;
        private PictureBox PbService;
        private Label LblSpecificClient;
    }
}

