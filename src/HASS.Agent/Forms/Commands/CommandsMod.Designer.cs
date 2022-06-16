
using HASS.Agent.Resources.Localization;

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
            this.LblName = new System.Windows.Forms.Label();
            this.PnlDescription = new System.Windows.Forms.Panel();
            this.TbDescription = new System.Windows.Forms.RichTextBox();
            this.LblDescription = new System.Windows.Forms.Label();
            this.CbRunAsLowIntegrity = new System.Windows.Forms.CheckBox();
            this.LblIntegrityInfo = new System.Windows.Forms.Label();
            this.CbCommandSpecific = new System.Windows.Forms.CheckBox();
            this.LblInfo = new System.Windows.Forms.Label();
            this.LvCommands = new System.Windows.Forms.ListView();
            this.ClmSensorId = new System.Windows.Forms.ColumnHeader();
            this.ClmSensorName = new System.Windows.Forms.ColumnHeader();
            this.ClmAgentCompatible = new System.Windows.Forms.ColumnHeader("agent_16_header");
            this.ClmSatelliteCompatible = new System.Windows.Forms.ColumnHeader("service_16_header");
            this.ClmActionCompatible = new System.Windows.Forms.ColumnHeader("action_16_header");
            this.ClmEmpty = new System.Windows.Forms.ColumnHeader();
            this.ImgLv = new System.Windows.Forms.ImageList(this.components);
            this.TbSelectedType = new System.Windows.Forms.TextBox();
            this.LblSelectedType = new System.Windows.Forms.Label();
            this.LblService = new System.Windows.Forms.Label();
            this.PbService = new System.Windows.Forms.PictureBox();
            this.LblAgent = new System.Windows.Forms.Label();
            this.PbAgent = new System.Windows.Forms.PictureBox();
            this.LblSpecificClient = new System.Windows.Forms.Label();
            this.CbEntityType = new System.Windows.Forms.ComboBox();
            this.LblEntityType = new System.Windows.Forms.Label();
            this.LblMqttTopic = new System.Windows.Forms.Label();
            this.LblActionInfo = new System.Windows.Forms.Label();
            this.PbActionInfo = new System.Windows.Forms.PictureBox();
            this.BtnConfigureCommand = new Syncfusion.WinForms.Controls.SfButton();
            this.PnlDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbAgent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbActionInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnStore
            // 
            this.BtnStore.AccessibleDescription = "Stores the command in the command list. This does not yet activates it.";
            this.BtnStore.AccessibleName = "Store";
            this.BtnStore.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnStore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Location = new System.Drawing.Point(0, 450);
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
            this.BtnStore.Text = Languages.CommandsMod_BtnStore;
            this.BtnStore.UseVisualStyleBackColor = false;
            this.BtnStore.Click += new System.EventHandler(this.BtnStore_Click);
            // 
            // TbSetting
            // 
            this.TbSetting.AccessibleDescription = "Command specific configuration.";
            this.TbSetting.AccessibleName = "Command configuration";
            this.TbSetting.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbSetting.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbSetting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbSetting.Location = new System.Drawing.Point(566, 239);
            this.TbSetting.Name = "TbSetting";
            this.TbSetting.Size = new System.Drawing.Size(328, 25);
            this.TbSetting.TabIndex = 3;
            this.TbSetting.Visible = false;
            // 
            // TbName
            // 
            this.TbName.AccessibleDescription = "The name as which the command will show up in Home Assistant. This has to be uniq" +
    "ue!";
            this.TbName.AccessibleName = "Command name";
            this.TbName.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbName.Location = new System.Drawing.Point(566, 173);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(328, 25);
            this.TbName.TabIndex = 2;
            // 
            // LblSetting
            // 
            this.LblSetting.AccessibleDescription = "Command specific setting description.";
            this.LblSetting.AccessibleName = "Setting description";
            this.LblSetting.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblSetting.AutoSize = true;
            this.LblSetting.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblSetting.Location = new System.Drawing.Point(566, 217);
            this.LblSetting.Name = "LblSetting";
            this.LblSetting.Size = new System.Drawing.Size(46, 19);
            this.LblSetting.TabIndex = 12;
            this.LblSetting.Text = Languages.CommandsMod_LblSetting;
            this.LblSetting.Visible = false;
            // 
            // LblName
            // 
            this.LblName.AccessibleDescription = "Command name textbox description";
            this.LblName.AccessibleName = "Command name description";
            this.LblName.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblName.Location = new System.Drawing.Point(566, 151);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(43, 19);
            this.LblName.TabIndex = 10;
            this.LblName.Text = Languages.CommandsMod_LblName;
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
            this.PnlDescription.Size = new System.Drawing.Size(354, 375);
            this.PnlDescription.TabIndex = 21;
            // 
            // TbDescription
            // 
            this.TbDescription.AccessibleDescription = "Contains a description and extra information regarding the selected command.";
            this.TbDescription.AccessibleName = "Command description";
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
            this.TbDescription.Size = new System.Drawing.Size(352, 373);
            this.TbDescription.TabIndex = 18;
            this.TbDescription.Text = "";
            this.TbDescription.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.TbDescription_LinkClicked);
            // 
            // LblDescription
            // 
            this.LblDescription.AccessibleDescription = "Command description textbox description.";
            this.LblDescription.AccessibleName = "Command description description";
            this.LblDescription.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblDescription.AutoSize = true;
            this.LblDescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDescription.Location = new System.Drawing.Point(955, 19);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(76, 19);
            this.LblDescription.TabIndex = 20;
            this.LblDescription.Text = Languages.CommandsMod_LblDescription;
            // 
            // CbRunAsLowIntegrity
            // 
            this.CbRunAsLowIntegrity.AccessibleDescription = "Runs the command as \'low integrity\', limiting what it\'s allowed to do.";
            this.CbRunAsLowIntegrity.AccessibleName = "Low integrity";
            this.CbRunAsLowIntegrity.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.CbRunAsLowIntegrity.AutoSize = true;
            this.CbRunAsLowIntegrity.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbRunAsLowIntegrity.Location = new System.Drawing.Point(566, 292);
            this.CbRunAsLowIntegrity.Name = "CbRunAsLowIntegrity";
            this.CbRunAsLowIntegrity.Size = new System.Drawing.Size(152, 23);
            this.CbRunAsLowIntegrity.TabIndex = 4;
            this.CbRunAsLowIntegrity.Text = Languages.CommandsMod_CbRunAsLowIntegrity;
            this.CbRunAsLowIntegrity.UseVisualStyleBackColor = true;
            this.CbRunAsLowIntegrity.Visible = false;
            // 
            // LblIntegrityInfo
            // 
            this.LblIntegrityInfo.AccessibleDescription = "Opens a message box, showing extra info about low integrity commands.";
            this.LblIntegrityInfo.AccessibleName = "Low integrity info";
            this.LblIntegrityInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.LblIntegrityInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblIntegrityInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblIntegrityInfo.Location = new System.Drawing.Point(739, 296);
            this.LblIntegrityInfo.Name = "LblIntegrityInfo";
            this.LblIntegrityInfo.Size = new System.Drawing.Size(155, 15);
            this.LblIntegrityInfo.TabIndex = 27;
            this.LblIntegrityInfo.Text = Languages.CommandsMod_LblIntegrityInfo;
            this.LblIntegrityInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LblIntegrityInfo.Visible = false;
            this.LblIntegrityInfo.Click += new System.EventHandler(this.LblIntegrityInfo_Click);
            // 
            // CbCommandSpecific
            // 
            this.CbCommandSpecific.AccessibleDescription = "Command specific setting.";
            this.CbCommandSpecific.AccessibleName = "Command setting";
            this.CbCommandSpecific.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.CbCommandSpecific.AutoSize = true;
            this.CbCommandSpecific.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbCommandSpecific.Location = new System.Drawing.Point(566, 333);
            this.CbCommandSpecific.Name = "CbCommandSpecific";
            this.CbCommandSpecific.Size = new System.Drawing.Size(34, 23);
            this.CbCommandSpecific.TabIndex = 5;
            this.CbCommandSpecific.Text = "-";
            this.CbCommandSpecific.UseVisualStyleBackColor = true;
            this.CbCommandSpecific.Visible = false;
            // 
            // LblInfo
            // 
            this.LblInfo.AccessibleDescription = "Extra info regarding the selected command.";
            this.LblInfo.AccessibleName = "Command extra info";
            this.LblInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo.Location = new System.Drawing.Point(566, 268);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(328, 168);
            this.LblInfo.TabIndex = 29;
            this.LblInfo.Text = "-";
            this.LblInfo.Visible = false;
            // 
            // LvCommands
            // 
            this.LvCommands.AccessibleDescription = "List of available command types.";
            this.LvCommands.AccessibleName = "Command types";
            this.LvCommands.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.LvCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.LvCommands.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClmSensorId,
            this.ClmSensorName,
            this.ClmAgentCompatible,
            this.ClmSatelliteCompatible,
            this.ClmActionCompatible,
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
            this.LvCommands.Size = new System.Drawing.Size(516, 399);
            this.LvCommands.SmallImageList = this.ImgLv;
            this.LvCommands.TabIndex = 30;
            this.LvCommands.UseCompatibleStateImageBehavior = false;
            this.LvCommands.View = System.Windows.Forms.View.Details;
            this.LvCommands.SelectedIndexChanged += new System.EventHandler(this.LvCommands_SelectedIndexChanged);
            // 
            // ClmSensorId
            // 
            this.ClmSensorId.Text = "id";
            this.ClmSensorId.Width = 0;
            // 
            // ClmSensorName
            // 
            this.ClmSensorName.Text = global::HASS.Agent.Resources.Localization.Languages.CommandsMod_ClmSensorName;
            this.ClmSensorName.Width = 300;
            // 
            // ClmAgentCompatible
            // 
            this.ClmAgentCompatible.Text = "agent compatible";
            // 
            // ClmSatelliteCompatible
            // 
            this.ClmSatelliteCompatible.Text = "satellite compatible";
            // 
            // ClmActionCompatible
            // 
            this.ClmActionCompatible.Text = "action compatible";
            // 
            // ClmEmpty
            // 
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
            this.ImgLv.Images.SetKeyName(3, "action_16_header");
            // 
            // TbSelectedType
            // 
            this.TbSelectedType.AccessibleDescription = "Selected command type.";
            this.TbSelectedType.AccessibleName = "Selected command";
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
            // LblSelectedType
            // 
            this.LblSelectedType.AccessibleDescription = "Selected command type textbox description.";
            this.LblSelectedType.AccessibleName = "Selected command description";
            this.LblSelectedType.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblSelectedType.AutoSize = true;
            this.LblSelectedType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblSelectedType.Location = new System.Drawing.Point(566, 18);
            this.LblSelectedType.Name = "LblSelectedType";
            this.LblSelectedType.Size = new System.Drawing.Size(89, 19);
            this.LblSelectedType.TabIndex = 31;
            this.LblSelectedType.Text = Languages.CommandsMod_LblSelectedType;
            // 
            // LblService
            // 
            this.LblService.AccessibleDescription = "Service column description.";
            this.LblService.AccessibleName = "Service info";
            this.LblService.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblService.AutoSize = true;
            this.LblService.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblService.Location = new System.Drawing.Point(409, 421);
            this.LblService.Name = "LblService";
            this.LblService.Size = new System.Drawing.Size(43, 15);
            this.LblService.TabIndex = 37;
            this.LblService.Text = Languages.CommandsMod_LblService;
            // 
            // PbService
            // 
            this.PbService.AccessibleDescription = "Service icon image, as shown in the header of the \'service\' column.";
            this.PbService.AccessibleName = "Service icon";
            this.PbService.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbService.Image = global::HASS.Agent.Properties.Resources.service_16;
            this.PbService.Location = new System.Drawing.Point(387, 420);
            this.PbService.Name = "PbService";
            this.PbService.Size = new System.Drawing.Size(16, 16);
            this.PbService.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbService.TabIndex = 36;
            this.PbService.TabStop = false;
            // 
            // LblAgent
            // 
            this.LblAgent.AccessibleDescription = "Agent column description.";
            this.LblAgent.AccessibleName = "Agent info";
            this.LblAgent.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblAgent.AutoSize = true;
            this.LblAgent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblAgent.Location = new System.Drawing.Point(327, 421);
            this.LblAgent.Name = "LblAgent";
            this.LblAgent.Size = new System.Drawing.Size(37, 15);
            this.LblAgent.TabIndex = 35;
            this.LblAgent.Text = Languages.CommandsMod_LblAgent;
            // 
            // PbAgent
            // 
            this.PbAgent.AccessibleDescription = "Agent icon image, as shown in the header of the \'agent\' column.";
            this.PbAgent.AccessibleName = "Agent icon";
            this.PbAgent.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbAgent.Image = global::HASS.Agent.Properties.Resources.agent_16;
            this.PbAgent.Location = new System.Drawing.Point(305, 420);
            this.PbAgent.Name = "PbAgent";
            this.PbAgent.Size = new System.Drawing.Size(16, 16);
            this.PbAgent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbAgent.TabIndex = 34;
            this.PbAgent.TabStop = false;
            // 
            // LblSpecificClient
            // 
            this.LblSpecificClient.AccessibleDescription = "Warning message that the selected command is only available for the HASS.Agent, n" +
    "ot the satellite service.";
            this.LblSpecificClient.AccessibleName = "Compatibility warning";
            this.LblSpecificClient.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblSpecificClient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblSpecificClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.LblSpecificClient.Location = new System.Drawing.Point(739, 18);
            this.LblSpecificClient.Name = "LblSpecificClient";
            this.LblSpecificClient.Size = new System.Drawing.Size(155, 19);
            this.LblSpecificClient.TabIndex = 38;
            this.LblSpecificClient.Text = Languages.CommandsMod_LblSpecificClient;
            this.LblSpecificClient.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LblSpecificClient.Visible = false;
            // 
            // CbEntityType
            // 
            this.CbEntityType.AccessibleDescription = "List of possible entity types, as which the command will show up in Home Assistan" +
    "t.";
            this.CbEntityType.AccessibleName = "Entity types";
            this.CbEntityType.AccessibleRole = System.Windows.Forms.AccessibleRole.DropList;
            this.CbEntityType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CbEntityType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CbEntityType.DropDownHeight = 300;
            this.CbEntityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbEntityType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbEntityType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.CbEntityType.FormattingEnabled = true;
            this.CbEntityType.IntegralHeight = false;
            this.CbEntityType.Location = new System.Drawing.Point(566, 106);
            this.CbEntityType.Name = "CbEntityType";
            this.CbEntityType.Size = new System.Drawing.Size(328, 26);
            this.CbEntityType.TabIndex = 1;
            this.CbEntityType.SelectedIndexChanged += new System.EventHandler(this.CbEntityType_SelectedIndexChanged);
            // 
            // LblEntityType
            // 
            this.LblEntityType.AccessibleDescription = "Entity type dropdown description.";
            this.LblEntityType.AccessibleName = "Entity type description";
            this.LblEntityType.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblEntityType.AutoSize = true;
            this.LblEntityType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblEntityType.Location = new System.Drawing.Point(566, 84);
            this.LblEntityType.Name = "LblEntityType";
            this.LblEntityType.Size = new System.Drawing.Size(75, 19);
            this.LblEntityType.TabIndex = 40;
            this.LblEntityType.Text = Languages.CommandsMod_LblEntityType;
            // 
            // LblMqttTopic
            // 
            this.LblMqttTopic.AccessibleDescription = "Opens a window with the MQTT topic you can use, to send command actions to.";
            this.LblMqttTopic.AccessibleName = "Mqtt action topic";
            this.LblMqttTopic.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.LblMqttTopic.AutoSize = true;
            this.LblMqttTopic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblMqttTopic.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblMqttTopic.Location = new System.Drawing.Point(955, 421);
            this.LblMqttTopic.Name = "LblMqttTopic";
            this.LblMqttTopic.Size = new System.Drawing.Size(150, 19);
            this.LblMqttTopic.TabIndex = 41;
            this.LblMqttTopic.Text = Languages.CommandsMod_LblMqttTopic;
            this.LblMqttTopic.Visible = false;
            this.LblMqttTopic.Click += new System.EventHandler(this.LblMqttTopic_Click);
            // 
            // LblActionInfo
            // 
            this.LblActionInfo.AccessibleDescription = "Action column description. Click to open the examples webpage.";
            this.LblActionInfo.AccessibleName = "Action info";
            this.LblActionInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblActionInfo.AutoSize = true;
            this.LblActionInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblActionInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblActionInfo.Location = new System.Drawing.Point(490, 421);
            this.LblActionInfo.Name = "LblActionInfo";
            this.LblActionInfo.Size = new System.Drawing.Size(40, 15);
            this.LblActionInfo.TabIndex = 43;
            this.LblActionInfo.Text = Languages.CommandsMod_LblActionInfo;
            this.LblActionInfo.Click += new System.EventHandler(this.LblActionInfo_Click);
            // 
            // PbActionInfo
            // 
            this.PbActionInfo.AccessibleDescription = "Action icon image, as shown in the header of the \'action\' column.";
            this.PbActionInfo.AccessibleName = "Action icon";
            this.PbActionInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.PbActionInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbActionInfo.Image = global::HASS.Agent.Properties.Resources.action_16;
            this.PbActionInfo.Location = new System.Drawing.Point(468, 420);
            this.PbActionInfo.Name = "PbActionInfo";
            this.PbActionInfo.Size = new System.Drawing.Size(16, 16);
            this.PbActionInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbActionInfo.TabIndex = 42;
            this.PbActionInfo.TabStop = false;
            this.PbActionInfo.Click += new System.EventHandler(this.PbActionInfo_Click);
            // 
            // BtnConfigureCommand
            // 
            this.BtnConfigureCommand.AccessibleDescription = "Opens a command specific window with extra settings.";
            this.BtnConfigureCommand.AccessibleName = "Command settings window";
            this.BtnConfigureCommand.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnConfigureCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnConfigureCommand.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnConfigureCommand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnConfigureCommand.Location = new System.Drawing.Point(566, 371);
            this.BtnConfigureCommand.Name = "BtnConfigureCommand";
            this.BtnConfigureCommand.Size = new System.Drawing.Size(328, 43);
            this.BtnConfigureCommand.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnConfigureCommand.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnConfigureCommand.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnConfigureCommand.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnConfigureCommand.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnConfigureCommand.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnConfigureCommand.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnConfigureCommand.TabIndex = 6;
            this.BtnConfigureCommand.Text = Languages.CommandsMod_BtnConfigureCommand;
            this.BtnConfigureCommand.UseVisualStyleBackColor = false;
            this.BtnConfigureCommand.Visible = false;
            this.BtnConfigureCommand.Click += new System.EventHandler(this.BtnConfigureCommand_Click);
            // 
            // CommandsMod
            // 
            this.AccessibleDescription = "Create or modify a command.";
            this.AccessibleName = "Command mod";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1319, 488);
            this.Controls.Add(this.BtnConfigureCommand);
            this.Controls.Add(this.LblActionInfo);
            this.Controls.Add(this.PbActionInfo);
            this.Controls.Add(this.LblMqttTopic);
            this.Controls.Add(this.LblEntityType);
            this.Controls.Add(this.CbEntityType);
            this.Controls.Add(this.LblSpecificClient);
            this.Controls.Add(this.LblService);
            this.Controls.Add(this.PbService);
            this.Controls.Add(this.LblAgent);
            this.Controls.Add(this.PbAgent);
            this.Controls.Add(this.TbSelectedType);
            this.Controls.Add(this.LblSelectedType);
            this.Controls.Add(this.LvCommands);
            this.Controls.Add(this.CbCommandSpecific);
            this.Controls.Add(this.LblIntegrityInfo);
            this.Controls.Add(this.CbRunAsLowIntegrity);
            this.Controls.Add(this.PnlDescription);
            this.Controls.Add(this.LblDescription);
            this.Controls.Add(this.TbSetting);
            this.Controls.Add(this.BtnStore);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LblSetting);
            this.Controls.Add(this.LblName);
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
            this.Text = Languages.CommandsMod_Title;
            this.Load += new System.EventHandler(this.CommandsMod_Load);
            this.ResizeEnd += new System.EventHandler(this.CommandsMod_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CommandsMod_KeyUp);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.CommandsMod_Layout);
            this.PnlDescription.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbAgent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbActionInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.WinForms.Controls.SfButton BtnStore;
        private System.Windows.Forms.Label LblSetting;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.TextBox TbSetting;
        private System.Windows.Forms.Panel PnlDescription;
        private System.Windows.Forms.RichTextBox TbDescription;
        private System.Windows.Forms.Label LblDescription;
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
        private Label LblSelectedType;
        private Label LblService;
        private PictureBox PbService;
        private Label LblAgent;
        private PictureBox PbAgent;
        private ImageList ImgLv;
        private Label LblSpecificClient;
        private ComboBox CbEntityType;
        private Label LblEntityType;
        private Label LblMqttTopic;
        private ColumnHeader ClmActionCompatible;
        private Label LblActionInfo;
        private PictureBox PbActionInfo;
        private ColumnHeader ClmSensorId;
        private Syncfusion.WinForms.Controls.SfButton BtnConfigureCommand;
    }
}

