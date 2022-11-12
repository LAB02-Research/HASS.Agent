
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
            this.ClmId = new System.Windows.Forms.ColumnHeader();
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
            this.BtnTest = new Syncfusion.WinForms.Controls.SfButton();
            this.CbNetworkCard = new System.Windows.Forms.ComboBox();
            this.PnlDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbMultiValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbAgent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbService)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnStore
            // 
            this.BtnStore.AccessibleDescription = "Stores the sensor in the sensor list. This does not yet activates it.";
            this.BtnStore.AccessibleName = "Store";
            this.BtnStore.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnStore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Location = new System.Drawing.Point(0, 439);
            this.BtnStore.Name = "BtnStore";
            this.BtnStore.Size = new System.Drawing.Size(1319, 38);
            this.BtnStore.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStore.TabIndex = 7;
            this.BtnStore.Text = global::HASS.Agent.Resources.Localization.Languages.SensorsMod_BtnStore;
            this.BtnStore.UseVisualStyleBackColor = false;
            this.BtnStore.Click += new System.EventHandler(this.BtnStore_Click);
            // 
            // LblSetting1
            // 
            this.LblSetting1.AccessibleDescription = "Sensor specific setting 1 description.";
            this.LblSetting1.AccessibleName = "Setting 1 description";
            this.LblSetting1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblSetting1.AutoSize = true;
            this.LblSetting1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblSetting1.Location = new System.Drawing.Point(566, 235);
            this.LblSetting1.Name = "LblSetting1";
            this.LblSetting1.Size = new System.Drawing.Size(63, 19);
            this.LblSetting1.TabIndex = 12;
            this.LblSetting1.Text = "setting 1";
            this.LblSetting1.Visible = false;
            // 
            // TbSetting1
            // 
            this.TbSetting1.AccessibleDescription = "Sensor specific configuration.";
            this.TbSetting1.AccessibleName = "Setting 1";
            this.TbSetting1.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
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
            this.LblType.AccessibleDescription = "Selected sensor type textbox description.";
            this.LblType.AccessibleName = "Selected sensor description";
            this.LblType.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblType.AutoSize = true;
            this.LblType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblType.Location = new System.Drawing.Point(566, 18);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(91, 19);
            this.LblType.TabIndex = 3;
            this.LblType.Text = Languages.SensorsMod_LblType;
            // 
            // LblName
            // 
            this.LblName.AccessibleDescription = "Sensor name textbox description";
            this.LblName.AccessibleName = "Sensor name description";
            this.LblName.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblName.Location = new System.Drawing.Point(566, 91);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(45, 19);
            this.LblName.TabIndex = 10;
            this.LblName.Text = Languages.SensorsMod_LblName;
            // 
            // TbName
            // 
            this.TbName.AccessibleDescription = "The name as which the sensor will show up in Home Assistant. This has to be uniqu" +
    "e!";
            this.TbName.AccessibleName = "Sensor name";
            this.TbName.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
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
            this.LblUpdate.AccessibleDescription = "Update interval numeric textbox description.";
            this.LblUpdate.AccessibleName = "Update interval description";
            this.LblUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblUpdate.AutoSize = true;
            this.LblUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblUpdate.Location = new System.Drawing.Point(566, 174);
            this.LblUpdate.Name = "LblUpdate";
            this.LblUpdate.Size = new System.Drawing.Size(91, 19);
            this.LblUpdate.TabIndex = 13;
            this.LblUpdate.Text = Languages.SensorsMod_LblUpdate;
            // 
            // LblSeconds
            // 
            this.LblSeconds.AccessibleDescription = "Update interval time unit.";
            this.LblSeconds.AccessibleName = "Update interval time unit";
            this.LblSeconds.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblSeconds.AutoSize = true;
            this.LblSeconds.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblSeconds.Location = new System.Drawing.Point(786, 174);
            this.LblSeconds.Name = "LblSeconds";
            this.LblSeconds.Size = new System.Drawing.Size(58, 19);
            this.LblSeconds.TabIndex = 15;
            this.LblSeconds.Text = Languages.SensorsMod_LblSeconds;
            // 
            // LblDescription
            // 
            this.LblDescription.AccessibleDescription = "Sensor description textbox description.";
            this.LblDescription.AccessibleName = "Sensor description description";
            this.LblDescription.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblDescription.AutoSize = true;
            this.LblDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDescription.Location = new System.Drawing.Point(955, 17);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(78, 19);
            this.LblDescription.TabIndex = 17;
            this.LblDescription.Text = Languages.SensorsMod_LblDescription;
            // 
            // TbDescription
            // 
            this.TbDescription.AccessibleDescription = "Contains a description and extra information regarding the selected sensor.";
            this.TbDescription.AccessibleName = "Sensor description";
            this.TbDescription.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
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
            this.PnlDescription.AccessibleDescription = "Contains the description textbox.";
            this.PnlDescription.AccessibleName = "Description panel";
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
            this.LblSetting2.AccessibleDescription = "Sensor specific setting 2 description.";
            this.LblSetting2.AccessibleName = "Setting 2 description";
            this.LblSetting2.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblSetting2.AutoSize = true;
            this.LblSetting2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblSetting2.Location = new System.Drawing.Point(566, 288);
            this.LblSetting2.Name = "LblSetting2";
            this.LblSetting2.Size = new System.Drawing.Size(63, 19);
            this.LblSetting2.TabIndex = 21;
            this.LblSetting2.Text = "setting 2";
            this.LblSetting2.Visible = false;
            // 
            // TbSetting2
            // 
            this.TbSetting2.AccessibleDescription = "Sensor specific configuration.";
            this.TbSetting2.AccessibleName = "Setting 2";
            this.TbSetting2.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbSetting2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbSetting2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbSetting2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbSetting2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbSetting2.Location = new System.Drawing.Point(566, 310);
            this.TbSetting2.Name = "TbSetting2";
            this.TbSetting2.Size = new System.Drawing.Size(328, 25);
            this.TbSetting2.TabIndex = 4;
            this.TbSetting2.Visible = false;
            // 
            // LblSetting3
            // 
            this.LblSetting3.AccessibleDescription = "Sensor specific setting 3 description.";
            this.LblSetting3.AccessibleName = "Setting 3 description";
            this.LblSetting3.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblSetting3.AutoSize = true;
            this.LblSetting3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblSetting3.Location = new System.Drawing.Point(566, 341);
            this.LblSetting3.Name = "LblSetting3";
            this.LblSetting3.Size = new System.Drawing.Size(63, 19);
            this.LblSetting3.TabIndex = 23;
            this.LblSetting3.Text = "setting 3";
            this.LblSetting3.Visible = false;
            // 
            // TbSetting3
            // 
            this.TbSetting3.AccessibleDescription = "Sensor specific configuration.";
            this.TbSetting3.AccessibleName = "Setting 3";
            this.TbSetting3.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbSetting3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbSetting3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbSetting3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbSetting3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbSetting3.Location = new System.Drawing.Point(566, 363);
            this.TbSetting3.Name = "TbSetting3";
            this.TbSetting3.Size = new System.Drawing.Size(328, 25);
            this.TbSetting3.TabIndex = 5;
            this.TbSetting3.Visible = false;
            // 
            // NumInterval
            // 
            this.NumInterval.AccessibleDescription = "The amount of seconds between the updates of this sensor\'s value. Only accepts nu" +
    "meric values.";
            this.NumInterval.AccessibleName = "Update interval";
            this.NumInterval.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.NumInterval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.NumInterval.BeforeTouchSize = new System.Drawing.Size(83, 25);
            this.NumInterval.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.NumInterval.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.NumInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumInterval.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumInterval.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.NumInterval.Location = new System.Drawing.Point(673, 172);
            this.NumInterval.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.NumInterval.MaxLength = 10;
            this.NumInterval.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumInterval.Name = "NumInterval";
            this.NumInterval.Size = new System.Drawing.Size(83, 25);
            this.NumInterval.TabIndex = 2;
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
            this.LvSensors.AccessibleDescription = "List of available sensor types.";
            this.LvSensors.AccessibleName = "Sensor types";
            this.LvSensors.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.LvSensors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.LvSensors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClmId,
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
            // ClmId
            // 
            this.ClmId.Text = "id";
            this.ClmId.Width = 0;
            // 
            // ClmSensorName
            // 
            this.ClmSensorName.Text = global::HASS.Agent.Resources.Localization.Languages.SensorsMod_ClmSensorName;
            this.ClmSensorName.Width = 300;
            // 
            // ClmMultiValue
            // 
            this.ClmMultiValue.Tag = "hide";
            this.ClmMultiValue.Text = global::HASS.Agent.Resources.Localization.Languages.SensorsMod_LblMultiValue;
            // 
            // ClmAgentCompatible
            // 
            this.ClmAgentCompatible.Tag = "hide";
            this.ClmAgentCompatible.Text = "agent compatible";
            // 
            // ClmSatelliteCompatible
            // 
            this.ClmSatelliteCompatible.Tag = "hide";
            this.ClmSatelliteCompatible.Text = "satellite compatible";
            // 
            // ClmEmpty
            // 
            this.ClmEmpty.Tag = "hide";
            this.ClmEmpty.Text = "filler column";
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
            this.TbSelectedType.AccessibleDescription = "Selected sensor type.";
            this.TbSelectedType.AccessibleName = "Selected sensor";
            this.TbSelectedType.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.TbSelectedType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TbSelectedType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbSelectedType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbSelectedType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbSelectedType.Location = new System.Drawing.Point(566, 40);
            this.TbSelectedType.Name = "TbSelectedType";
            this.TbSelectedType.ReadOnly = true;
            this.TbSelectedType.Size = new System.Drawing.Size(328, 25);
            this.TbSelectedType.TabIndex = 0;
            // 
            // PbMultiValue
            // 
            this.PbMultiValue.AccessibleDescription = "Multivalue icon image, as shown in the header of the \'multivalue\' column.";
            this.PbMultiValue.AccessibleName = "Multivalue icon";
            this.PbMultiValue.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbMultiValue.Image = global::HASS.Agent.Properties.Resources.multivalue_16;
            this.PbMultiValue.Location = new System.Drawing.Point(182, 394);
            this.PbMultiValue.Name = "PbMultiValue";
            this.PbMultiValue.Size = new System.Drawing.Size(16, 16);
            this.PbMultiValue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbMultiValue.TabIndex = 28;
            this.PbMultiValue.TabStop = false;
            // 
            // LblMultiValue
            // 
            this.LblMultiValue.AccessibleDescription = "Multivalue column description.";
            this.LblMultiValue.AccessibleName = "Multivalue info";
            this.LblMultiValue.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblMultiValue.AutoSize = true;
            this.LblMultiValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblMultiValue.Location = new System.Drawing.Point(204, 395);
            this.LblMultiValue.Name = "LblMultiValue";
            this.LblMultiValue.Size = new System.Drawing.Size(63, 15);
            this.LblMultiValue.TabIndex = 29;
            this.LblMultiValue.Text = Languages.SensorsMod_LblMultiValue;
            // 
            // LblAgent
            // 
            this.LblAgent.AccessibleDescription = "Agent column description.";
            this.LblAgent.AccessibleName = "Agent info";
            this.LblAgent.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblAgent.AutoSize = true;
            this.LblAgent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblAgent.Location = new System.Drawing.Point(34, 395);
            this.LblAgent.Name = "LblAgent";
            this.LblAgent.Size = new System.Drawing.Size(39, 15);
            this.LblAgent.TabIndex = 31;
            this.LblAgent.Text = "Agent";
            // 
            // PbAgent
            // 
            this.PbAgent.AccessibleDescription = "Agent icon image, as shown in the header of the \'agent\' column.";
            this.PbAgent.AccessibleName = "Agent icon";
            this.PbAgent.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbAgent.Image = global::HASS.Agent.Properties.Resources.agent_16;
            this.PbAgent.Location = new System.Drawing.Point(12, 394);
            this.PbAgent.Name = "PbAgent";
            this.PbAgent.Size = new System.Drawing.Size(16, 16);
            this.PbAgent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbAgent.TabIndex = 30;
            this.PbAgent.TabStop = false;
            // 
            // LblService
            // 
            this.LblService.AccessibleDescription = "Service column description.";
            this.LblService.AccessibleName = "Service info";
            this.LblService.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblService.AutoSize = true;
            this.LblService.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblService.Location = new System.Drawing.Point(116, 395);
            this.LblService.Name = "LblService";
            this.LblService.Size = new System.Drawing.Size(44, 15);
            this.LblService.TabIndex = 33;
            this.LblService.Text = "Service";
            // 
            // PbService
            // 
            this.PbService.AccessibleDescription = "Service icon image, as shown in the header of the \'service\' column.";
            this.PbService.AccessibleName = "Service icon";
            this.PbService.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbService.Image = global::HASS.Agent.Properties.Resources.service_16;
            this.PbService.Location = new System.Drawing.Point(94, 394);
            this.PbService.Name = "PbService";
            this.PbService.Size = new System.Drawing.Size(16, 16);
            this.PbService.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbService.TabIndex = 32;
            this.PbService.TabStop = false;
            // 
            // LblSpecificClient
            // 
            this.LblSpecificClient.AccessibleDescription = "Warning message that the selected sensor is only available for the HASS.Agent, no" +
    "t the satellite service.";
            this.LblSpecificClient.AccessibleName = "Compatibility warning";
            this.LblSpecificClient.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
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
            // BtnTest
            // 
            this.BtnTest.AccessibleDescription = "Tests the provided values to see if they return the expected value.";
            this.BtnTest.AccessibleName = "Test";
            this.BtnTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnTest.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnTest.Location = new System.Drawing.Point(566, 402);
            this.BtnTest.Name = "BtnTest";
            this.BtnTest.Size = new System.Drawing.Size(328, 24);
            this.BtnTest.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnTest.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnTest.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnTest.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnTest.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnTest.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnTest.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnTest.TabIndex = 6;
            this.BtnTest.Text = global::HASS.Agent.Resources.Localization.Languages.SensorsMod_BtnTest;
            this.BtnTest.UseVisualStyleBackColor = false;
            this.BtnTest.Visible = false;
            this.BtnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // CbNetworkCard
            // 
            this.CbNetworkCard.AccessibleDescription = "List of available network cards.";
            this.CbNetworkCard.AccessibleName = "Network cards";
            this.CbNetworkCard.AccessibleRole = System.Windows.Forms.AccessibleRole.DropList;
            this.CbNetworkCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CbNetworkCard.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CbNetworkCard.DropDownHeight = 300;
            this.CbNetworkCard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbNetworkCard.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbNetworkCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.CbNetworkCard.FormattingEnabled = true;
            this.CbNetworkCard.IntegralHeight = false;
            this.CbNetworkCard.Location = new System.Drawing.Point(566, 258);
            this.CbNetworkCard.Name = "CbNetworkCard";
            this.CbNetworkCard.Size = new System.Drawing.Size(328, 26);
            this.CbNetworkCard.TabIndex = 3;
            this.CbNetworkCard.Visible = false;
            // 
            // SensorsMod
            // 
            this.AccessibleDescription = "Create or modify a sensor.";
            this.AccessibleName = "Sensor mod";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1319, 477);
            this.Controls.Add(this.CbNetworkCard);
            this.Controls.Add(this.BtnTest);
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
        private ColumnHeader ClmId;
        private Syncfusion.WinForms.Controls.SfButton BtnTest;
        private ComboBox CbNetworkCard;
    }
}

