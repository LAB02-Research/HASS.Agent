using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Service
{
    partial class ServiceGeneral
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
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.LblAuthId = new System.Windows.Forms.Label();
            this.TbAuthId = new System.Windows.Forms.TextBox();
            this.TbDeviceName = new System.Windows.Forms.TextBox();
            this.LblDeviceName = new System.Windows.Forms.Label();
            this.LblTip1 = new System.Windows.Forms.Label();
            this.TbExternalExecutorBinary = new System.Windows.Forms.TextBox();
            this.LblCustomExecBinary = new System.Windows.Forms.Label();
            this.TbExternalExecutorName = new System.Windows.Forms.TextBox();
            this.LblCustomExecName = new System.Windows.Forms.Label();
            this.NumDisconnectGrace = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.LblSeconds = new System.Windows.Forms.Label();
            this.LblDisconGrace = new System.Windows.Forms.Label();
            this.BtnStoreAuthId = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnStoreDeviceName = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnStoreDisconGrace = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnStoreCustomExecutor = new Syncfusion.WinForms.Controls.SfButton();
            this.LblVersionInfo = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.LblTip2 = new System.Windows.Forms.Label();
            this.LblAuthStored = new System.Windows.Forms.Label();
            this.LblDeviceNameStored = new System.Windows.Forms.Label();
            this.LblDisconGraceStored = new System.Windows.Forms.Label();
            this.LblCustomExecutorStored = new System.Windows.Forms.Label();
            this.LblAuthIdInfo = new System.Windows.Forms.Label();
            this.LblDeviceNameInfo = new System.Windows.Forms.Label();
            this.LblDisconGraceInfo = new System.Windows.Forms.Label();
            this.LblInfo2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumDisconnectGrace)).BeginInit();
            this.SuspendLayout();
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "MQTT configuration pointer.";
            this.LblInfo1.AccessibleName = "Pointer info";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(16, 94);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(852, 44);
            this.LblInfo1.TabIndex = 57;
            this.LblInfo1.Text = Languages.ServiceGeneral_LblInfo1;
            // 
            // LblAuthId
            // 
            this.LblAuthId.AccessibleDescription = "Auth ID textbox description.";
            this.LblAuthId.AccessibleName = "Auth ID info";
            this.LblAuthId.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblAuthId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblAuthId.Location = new System.Drawing.Point(16, 219);
            this.LblAuthId.Name = "LblAuthId";
            this.LblAuthId.Size = new System.Drawing.Size(230, 19);
            this.LblAuthId.TabIndex = 61;
            this.LblAuthId.Text = Languages.ServiceGeneral_LblAuthId;
            this.LblAuthId.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TbAuthId
            // 
            this.TbAuthId.AccessibleDescription = "Auth ID, used to authentica with the satellite service. Mostly relevant when you " +
    "don\'t want other users to communicate with the service.";
            this.TbAuthId.AccessibleName = "Auth ID";
            this.TbAuthId.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbAuthId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbAuthId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbAuthId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbAuthId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbAuthId.Location = new System.Drawing.Point(285, 215);
            this.TbAuthId.Name = "TbAuthId";
            this.TbAuthId.Size = new System.Drawing.Size(268, 25);
            this.TbAuthId.TabIndex = 0;
            this.TbAuthId.DoubleClick += new System.EventHandler(this.TbAuthId_DoubleClick);
            // 
            // TbDeviceName
            // 
            this.TbDeviceName.AccessibleDescription = "The name with which the satellite service will show up in your Home Assistant ins" +
    "tance.";
            this.TbDeviceName.AccessibleName = "Device name";
            this.TbDeviceName.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbDeviceName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbDeviceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbDeviceName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbDeviceName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbDeviceName.Location = new System.Drawing.Point(285, 286);
            this.TbDeviceName.Name = "TbDeviceName";
            this.TbDeviceName.Size = new System.Drawing.Size(268, 25);
            this.TbDeviceName.TabIndex = 2;
            // 
            // LblDeviceName
            // 
            this.LblDeviceName.AccessibleDescription = "Device name textbox description.";
            this.LblDeviceName.AccessibleName = "Device name info";
            this.LblDeviceName.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblDeviceName.Cursor = System.Windows.Forms.Cursors.Help;
            this.LblDeviceName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDeviceName.Location = new System.Drawing.Point(16, 288);
            this.LblDeviceName.Name = "LblDeviceName";
            this.LblDeviceName.Size = new System.Drawing.Size(231, 19);
            this.LblDeviceName.TabIndex = 64;
            this.LblDeviceName.Text = Languages.ServiceGeneral_LblDeviceName;
            this.LblDeviceName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblTip1
            // 
            this.LblTip1.AccessibleDescription = "Contains a usage tip.";
            this.LblTip1.AccessibleName = "Custom executor binary tip";
            this.LblTip1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblTip1.AutoSize = true;
            this.LblTip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip1.Location = new System.Drawing.Point(649, 485);
            this.LblTip1.Name = "LblTip1";
            this.LblTip1.Size = new System.Drawing.Size(143, 15);
            this.LblTip1.TabIndex = 75;
            this.LblTip1.Text = Languages.ServiceGeneral_LblTip1;
            // 
            // TbExternalExecutorBinary
            // 
            this.TbExternalExecutorBinary.AccessibleDescription = "The local executable to use when executing a custom executor command.";
            this.TbExternalExecutorBinary.AccessibleName = "Custom executor binary";
            this.TbExternalExecutorBinary.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbExternalExecutorBinary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbExternalExecutorBinary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbExternalExecutorBinary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbExternalExecutorBinary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbExternalExecutorBinary.Location = new System.Drawing.Point(285, 481);
            this.TbExternalExecutorBinary.Name = "TbExternalExecutorBinary";
            this.TbExternalExecutorBinary.Size = new System.Drawing.Size(358, 25);
            this.TbExternalExecutorBinary.TabIndex = 6;
            this.TbExternalExecutorBinary.DoubleClick += new System.EventHandler(this.TbExternalExecutorBinary_DoubleClick);
            // 
            // LblCustomExecBinary
            // 
            this.LblCustomExecBinary.AccessibleDescription = "Custom executor binary textbox description.";
            this.LblCustomExecBinary.AccessibleName = "Custom executor binary info";
            this.LblCustomExecBinary.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblCustomExecBinary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblCustomExecBinary.Location = new System.Drawing.Point(16, 481);
            this.LblCustomExecBinary.Name = "LblCustomExecBinary";
            this.LblCustomExecBinary.Size = new System.Drawing.Size(231, 19);
            this.LblCustomExecBinary.TabIndex = 74;
            this.LblCustomExecBinary.Text = Languages.ServiceGeneral_LblCustomExecBinary;
            this.LblCustomExecBinary.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TbExternalExecutorName
            // 
            this.TbExternalExecutorName.AccessibleDescription = "The name of the custom executor.";
            this.TbExternalExecutorName.AccessibleName = "Custom executor name";
            this.TbExternalExecutorName.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbExternalExecutorName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbExternalExecutorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbExternalExecutorName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbExternalExecutorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbExternalExecutorName.Location = new System.Drawing.Point(285, 524);
            this.TbExternalExecutorName.Name = "TbExternalExecutorName";
            this.TbExternalExecutorName.Size = new System.Drawing.Size(358, 25);
            this.TbExternalExecutorName.TabIndex = 7;
            // 
            // LblCustomExecName
            // 
            this.LblCustomExecName.AccessibleDescription = "Custom executor textbox description.";
            this.LblCustomExecName.AccessibleName = "Custom executor info";
            this.LblCustomExecName.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblCustomExecName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblCustomExecName.Location = new System.Drawing.Point(16, 526);
            this.LblCustomExecName.Name = "LblCustomExecName";
            this.LblCustomExecName.Size = new System.Drawing.Size(231, 19);
            this.LblCustomExecName.TabIndex = 71;
            this.LblCustomExecName.Text = Languages.ServiceGeneral_LblCustomExecName;
            this.LblCustomExecName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // NumDisconnectGrace
            // 
            this.NumDisconnectGrace.AccessibleDescription = "The amount of seconds the service waits before logging a disconnect. Only accepts" +
    " numeric values.";
            this.NumDisconnectGrace.AccessibleName = "Disconnected grace period";
            this.NumDisconnectGrace.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.NumDisconnectGrace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.NumDisconnectGrace.BeforeTouchSize = new System.Drawing.Size(92, 25);
            this.NumDisconnectGrace.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.NumDisconnectGrace.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.NumDisconnectGrace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumDisconnectGrace.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumDisconnectGrace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.NumDisconnectGrace.Location = new System.Drawing.Point(285, 364);
            this.NumDisconnectGrace.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.NumDisconnectGrace.MaxLength = 10;
            this.NumDisconnectGrace.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumDisconnectGrace.Name = "NumDisconnectGrace";
            this.NumDisconnectGrace.Size = new System.Drawing.Size(92, 25);
            this.NumDisconnectGrace.TabIndex = 4;
            this.NumDisconnectGrace.ThemeName = "Metro";
            this.NumDisconnectGrace.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.NumDisconnectGrace.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // LblSeconds
            // 
            this.LblSeconds.AccessibleDescription = "Disconnected grace period time unit.";
            this.LblSeconds.AccessibleName = "Disconnected grace period time unit";
            this.LblSeconds.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblSeconds.AutoSize = true;
            this.LblSeconds.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblSeconds.Location = new System.Drawing.Point(383, 366);
            this.LblSeconds.Name = "LblSeconds";
            this.LblSeconds.Size = new System.Drawing.Size(58, 19);
            this.LblSeconds.TabIndex = 77;
            this.LblSeconds.Text = Languages.ServiceGeneral_LblSeconds;
            // 
            // LblDisconGrace
            // 
            this.LblDisconGrace.AccessibleDescription = "Disconnected grace period textbox description.";
            this.LblDisconGrace.AccessibleName = "Disconnected grace period info";
            this.LblDisconGrace.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblDisconGrace.Cursor = System.Windows.Forms.Cursors.Help;
            this.LblDisconGrace.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDisconGrace.Location = new System.Drawing.Point(16, 366);
            this.LblDisconGrace.Name = "LblDisconGrace";
            this.LblDisconGrace.Size = new System.Drawing.Size(231, 19);
            this.LblDisconGrace.TabIndex = 76;
            this.LblDisconGrace.Text = Languages.ServiceGeneral_LblDisconGrace;
            this.LblDisconGrace.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BtnStoreAuthId
            // 
            this.BtnStoreAuthId.AccessibleDescription = "Applies the new auth ID.";
            this.BtnStoreAuthId.AccessibleName = "Apply auth ID";
            this.BtnStoreAuthId.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnStoreAuthId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreAuthId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStoreAuthId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreAuthId.Location = new System.Drawing.Point(564, 215);
            this.BtnStoreAuthId.Name = "BtnStoreAuthId";
            this.BtnStoreAuthId.Size = new System.Drawing.Size(147, 25);
            this.BtnStoreAuthId.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreAuthId.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreAuthId.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreAuthId.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreAuthId.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreAuthId.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreAuthId.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStoreAuthId.TabIndex = 1;
            this.BtnStoreAuthId.Text = global::HASS.Agent.Resources.Localization.Languages.ServiceGeneral_Apply;
            this.BtnStoreAuthId.UseVisualStyleBackColor = false;
            this.BtnStoreAuthId.Click += new System.EventHandler(this.BtnStoreAuthId_Click);
            // 
            // BtnStoreDeviceName
            // 
            this.BtnStoreDeviceName.AccessibleDescription = "Applies the new device name.";
            this.BtnStoreDeviceName.AccessibleName = "Apply device name";
            this.BtnStoreDeviceName.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnStoreDeviceName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreDeviceName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStoreDeviceName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreDeviceName.Location = new System.Drawing.Point(564, 286);
            this.BtnStoreDeviceName.Name = "BtnStoreDeviceName";
            this.BtnStoreDeviceName.Size = new System.Drawing.Size(147, 25);
            this.BtnStoreDeviceName.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreDeviceName.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreDeviceName.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreDeviceName.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreDeviceName.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreDeviceName.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreDeviceName.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStoreDeviceName.TabIndex = 3;
            this.BtnStoreDeviceName.Text = global::HASS.Agent.Resources.Localization.Languages.ServiceGeneral_Apply;
            this.BtnStoreDeviceName.UseVisualStyleBackColor = false;
            this.BtnStoreDeviceName.Click += new System.EventHandler(this.BtnStoreDeviceName_Click);
            // 
            // BtnStoreDisconGrace
            // 
            this.BtnStoreDisconGrace.AccessibleDescription = "Applies the new disconnected grace period.";
            this.BtnStoreDisconGrace.AccessibleName = "Apply grace period";
            this.BtnStoreDisconGrace.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnStoreDisconGrace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreDisconGrace.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStoreDisconGrace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreDisconGrace.Location = new System.Drawing.Point(564, 364);
            this.BtnStoreDisconGrace.Name = "BtnStoreDisconGrace";
            this.BtnStoreDisconGrace.Size = new System.Drawing.Size(147, 25);
            this.BtnStoreDisconGrace.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreDisconGrace.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreDisconGrace.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreDisconGrace.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreDisconGrace.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreDisconGrace.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreDisconGrace.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStoreDisconGrace.TabIndex = 5;
            this.BtnStoreDisconGrace.Text = global::HASS.Agent.Resources.Localization.Languages.ServiceGeneral_Apply;
            this.BtnStoreDisconGrace.UseVisualStyleBackColor = false;
            this.BtnStoreDisconGrace.Click += new System.EventHandler(this.BtnStoreDisconGrace_Click);
            // 
            // BtnStoreCustomExecutor
            // 
            this.BtnStoreCustomExecutor.AccessibleDescription = "Applies the custom executor configuration.";
            this.BtnStoreCustomExecutor.AccessibleName = "Apply custom executor";
            this.BtnStoreCustomExecutor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnStoreCustomExecutor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreCustomExecutor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStoreCustomExecutor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreCustomExecutor.Location = new System.Drawing.Point(496, 564);
            this.BtnStoreCustomExecutor.Name = "BtnStoreCustomExecutor";
            this.BtnStoreCustomExecutor.Size = new System.Drawing.Size(147, 25);
            this.BtnStoreCustomExecutor.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreCustomExecutor.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreCustomExecutor.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreCustomExecutor.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreCustomExecutor.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreCustomExecutor.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreCustomExecutor.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStoreCustomExecutor.TabIndex = 8;
            this.BtnStoreCustomExecutor.Text = global::HASS.Agent.Resources.Localization.Languages.ServiceGeneral_Apply;
            this.BtnStoreCustomExecutor.UseVisualStyleBackColor = false;
            this.BtnStoreCustomExecutor.Click += new System.EventHandler(this.BtnStoreCustomExecutor_Click);
            // 
            // LblVersionInfo
            // 
            this.LblVersionInfo.AccessibleDescription = "Version description.";
            this.LblVersionInfo.AccessibleName = "Version description info";
            this.LblVersionInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblVersionInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblVersionInfo.Location = new System.Drawing.Point(16, 149);
            this.LblVersionInfo.Name = "LblVersionInfo";
            this.LblVersionInfo.Size = new System.Drawing.Size(231, 19);
            this.LblVersionInfo.TabIndex = 94;
            this.LblVersionInfo.Text = Languages.ServiceGeneral_LblVersionInfo;
            this.LblVersionInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblVersion
            // 
            this.LblVersion.AccessibleDescription = "The current version of the satellite service.";
            this.LblVersion.AccessibleName = "Version";
            this.LblVersion.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblVersion.AutoSize = true;
            this.LblVersion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.LblVersion.Location = new System.Drawing.Point(285, 149);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(15, 19);
            this.LblVersion.TabIndex = 95;
            this.LblVersion.Text = "-";
            // 
            // LblTip2
            // 
            this.LblTip2.AccessibleDescription = "Contains a usage tip.";
            this.LblTip2.AccessibleName = "Auth ID tip";
            this.LblTip2.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblTip2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip2.Location = new System.Drawing.Point(285, 243);
            this.LblTip2.Name = "LblTip2";
            this.LblTip2.Size = new System.Drawing.Size(268, 15);
            this.LblTip2.TabIndex = 96;
            this.LblTip2.Text = Languages.ServiceGeneral_LblTip2;
            this.LblTip2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LblAuthStored
            // 
            this.LblAuthStored.AccessibleDescription = "Briefly shows a \'succesfully stored\' message for the auth ID.";
            this.LblAuthStored.AccessibleName = "Auth ID stored info";
            this.LblAuthStored.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblAuthStored.AutoSize = true;
            this.LblAuthStored.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblAuthStored.ForeColor = System.Drawing.Color.LimeGreen;
            this.LblAuthStored.Location = new System.Drawing.Point(717, 217);
            this.LblAuthStored.Name = "LblAuthStored";
            this.LblAuthStored.Size = new System.Drawing.Size(52, 19);
            this.LblAuthStored.TabIndex = 97;
            this.LblAuthStored.Text = Languages.ServiceGeneral_LblAuthStored;
            this.LblAuthStored.Visible = false;
            // 
            // LblDeviceNameStored
            // 
            this.LblDeviceNameStored.AccessibleDescription = "Briefly shows a \'succesfully stored\' message for the device name.";
            this.LblDeviceNameStored.AccessibleName = "Device name stored info";
            this.LblDeviceNameStored.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblDeviceNameStored.AutoSize = true;
            this.LblDeviceNameStored.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDeviceNameStored.ForeColor = System.Drawing.Color.LimeGreen;
            this.LblDeviceNameStored.Location = new System.Drawing.Point(717, 288);
            this.LblDeviceNameStored.Name = "LblDeviceNameStored";
            this.LblDeviceNameStored.Size = new System.Drawing.Size(52, 19);
            this.LblDeviceNameStored.TabIndex = 98;
            this.LblDeviceNameStored.Text = Languages.ServiceGeneral_LblAuthStored;
            this.LblDeviceNameStored.Visible = false;
            // 
            // LblDisconGraceStored
            // 
            this.LblDisconGraceStored.AccessibleDescription = "Briefly shows a \'succesfully stored\' message for the disconnected grace period.";
            this.LblDisconGraceStored.AccessibleName = "Grace period stored info";
            this.LblDisconGraceStored.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblDisconGraceStored.AutoSize = true;
            this.LblDisconGraceStored.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDisconGraceStored.ForeColor = System.Drawing.Color.LimeGreen;
            this.LblDisconGraceStored.Location = new System.Drawing.Point(717, 366);
            this.LblDisconGraceStored.Name = "LblDisconGraceStored";
            this.LblDisconGraceStored.Size = new System.Drawing.Size(52, 19);
            this.LblDisconGraceStored.TabIndex = 99;
            this.LblDisconGraceStored.Text = Languages.ServiceGeneral_LblAuthStored;
            this.LblDisconGraceStored.Visible = false;
            // 
            // LblCustomExecutorStored
            // 
            this.LblCustomExecutorStored.AccessibleDescription = "Briefly shows a \'succesfully stored\' message for the custom executor.";
            this.LblCustomExecutorStored.AccessibleName = "Custom executor stored info";
            this.LblCustomExecutorStored.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblCustomExecutorStored.AutoSize = true;
            this.LblCustomExecutorStored.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblCustomExecutorStored.ForeColor = System.Drawing.Color.LimeGreen;
            this.LblCustomExecutorStored.Location = new System.Drawing.Point(649, 568);
            this.LblCustomExecutorStored.Name = "LblCustomExecutorStored";
            this.LblCustomExecutorStored.Size = new System.Drawing.Size(52, 19);
            this.LblCustomExecutorStored.TabIndex = 100;
            this.LblCustomExecutorStored.Text = Languages.ServiceGeneral_LblAuthStored;
            this.LblCustomExecutorStored.Visible = false;
            // 
            // LblAuthIdInfo
            // 
            this.LblAuthIdInfo.AccessibleDescription = "Shows extra info regarding the auth ID when clicked.";
            this.LblAuthIdInfo.AccessibleName = "Auth ID extra info";
            this.LblAuthIdInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.LblAuthIdInfo.AutoSize = true;
            this.LblAuthIdInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblAuthIdInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblAuthIdInfo.Location = new System.Drawing.Point(262, 216);
            this.LblAuthIdInfo.Name = "LblAuthIdInfo";
            this.LblAuthIdInfo.Size = new System.Drawing.Size(17, 21);
            this.LblAuthIdInfo.TabIndex = 101;
            this.LblAuthIdInfo.Text = "?";
            this.LblAuthIdInfo.Click += new System.EventHandler(this.LblAuthIdInfo_Click);
            // 
            // LblDeviceNameInfo
            // 
            this.LblDeviceNameInfo.AccessibleDescription = "Shows extra info regarding the device name when clicked.";
            this.LblDeviceNameInfo.AccessibleName = "Device name extra info";
            this.LblDeviceNameInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.LblDeviceNameInfo.AutoSize = true;
            this.LblDeviceNameInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblDeviceNameInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblDeviceNameInfo.Location = new System.Drawing.Point(262, 288);
            this.LblDeviceNameInfo.Name = "LblDeviceNameInfo";
            this.LblDeviceNameInfo.Size = new System.Drawing.Size(17, 21);
            this.LblDeviceNameInfo.TabIndex = 102;
            this.LblDeviceNameInfo.Text = "?";
            this.LblDeviceNameInfo.Click += new System.EventHandler(this.LblDeviceNameInfo_Click);
            // 
            // LblDisconGraceInfo
            // 
            this.LblDisconGraceInfo.AccessibleDescription = "Shows extra info regarding the disconnected grace period when clicked.";
            this.LblDisconGraceInfo.AccessibleName = "Grace period extra info";
            this.LblDisconGraceInfo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.LblDisconGraceInfo.AutoSize = true;
            this.LblDisconGraceInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblDisconGraceInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblDisconGraceInfo.Location = new System.Drawing.Point(262, 366);
            this.LblDisconGraceInfo.Name = "LblDisconGraceInfo";
            this.LblDisconGraceInfo.Size = new System.Drawing.Size(17, 21);
            this.LblDisconGraceInfo.TabIndex = 103;
            this.LblDisconGraceInfo.Text = "?";
            this.LblDisconGraceInfo.Click += new System.EventHandler(this.LblDisconGraceInfo_Click);
            // 
            // LblInfo2
            // 
            this.LblInfo2.AccessibleDescription = "General satellite service information.";
            this.LblInfo2.AccessibleName = "Information";
            this.LblInfo2.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo2.Location = new System.Drawing.Point(16, 17);
            this.LblInfo2.Name = "LblInfo2";
            this.LblInfo2.Size = new System.Drawing.Size(852, 63);
            this.LblInfo2.TabIndex = 104;
            this.LblInfo2.Text = Languages.ServiceGeneral_LblInfo2;
            // 
            // ServiceGeneral
            // 
            this.AccessibleDescription = "Panel showing general service configuration.";
            this.AccessibleName = "General";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.LblInfo2);
            this.Controls.Add(this.LblDisconGraceInfo);
            this.Controls.Add(this.LblDeviceNameInfo);
            this.Controls.Add(this.LblAuthIdInfo);
            this.Controls.Add(this.LblCustomExecutorStored);
            this.Controls.Add(this.LblDisconGraceStored);
            this.Controls.Add(this.LblDeviceNameStored);
            this.Controls.Add(this.LblAuthStored);
            this.Controls.Add(this.LblTip2);
            this.Controls.Add(this.LblVersionInfo);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.BtnStoreCustomExecutor);
            this.Controls.Add(this.BtnStoreDisconGrace);
            this.Controls.Add(this.BtnStoreDeviceName);
            this.Controls.Add(this.BtnStoreAuthId);
            this.Controls.Add(this.NumDisconnectGrace);
            this.Controls.Add(this.LblSeconds);
            this.Controls.Add(this.LblDisconGrace);
            this.Controls.Add(this.LblTip1);
            this.Controls.Add(this.TbExternalExecutorBinary);
            this.Controls.Add(this.LblCustomExecBinary);
            this.Controls.Add(this.TbExternalExecutorName);
            this.Controls.Add(this.LblCustomExecName);
            this.Controls.Add(this.TbDeviceName);
            this.Controls.Add(this.LblDeviceName);
            this.Controls.Add(this.TbAuthId);
            this.Controls.Add(this.LblAuthId);
            this.Controls.Add(this.LblInfo1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ServiceGeneral";
            this.Size = new System.Drawing.Size(903, 622);
            this.Load += new System.EventHandler(this.ServiceGeneral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumDisconnectGrace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblInfo1;
        private Label LblAuthId;
        internal TextBox TbAuthId;
        internal TextBox TbDeviceName;
        private Label LblDeviceName;
        private Label LblTip1;
        internal TextBox TbExternalExecutorBinary;
        private Label LblCustomExecBinary;
        internal TextBox TbExternalExecutorName;
        private Label LblCustomExecName;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumDisconnectGrace;
        private Label LblSeconds;
        private Label LblDisconGrace;
        internal Syncfusion.WinForms.Controls.SfButton BtnStoreAuthId;
        internal Syncfusion.WinForms.Controls.SfButton BtnStoreDeviceName;
        internal Syncfusion.WinForms.Controls.SfButton BtnStoreDisconGrace;
        internal Syncfusion.WinForms.Controls.SfButton BtnStoreCustomExecutor;
        private Label LblVersionInfo;
        private Label LblVersion;
        private Label LblTip2;
        private Label LblAuthStored;
        private Label LblDeviceNameStored;
        private Label LblDisconGraceStored;
        private Label LblCustomExecutorStored;
        private Label LblAuthIdInfo;
        private Label LblDeviceNameInfo;
        private Label LblDisconGraceInfo;
        private Label LblInfo2;
    }
}
