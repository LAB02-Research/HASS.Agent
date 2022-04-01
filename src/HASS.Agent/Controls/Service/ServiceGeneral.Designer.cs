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
            ((System.ComponentModel.ISupportInitialize)(this.NumDisconnectGrace)).BeginInit();
            this.SuspendLayout();
            // 
            // LblInfo1
            // 
            this.LblInfo1.AutoSize = true;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(27, 19);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(717, 19);
            this.LblInfo1.TabIndex = 57;
            this.LblInfo1.Text = "This page contains general configuration items. For MQTT settings, sensors and co" +
    "mmands, browse the tabs on top.";
            this.LblInfo1.Visible = false;
            // 
            // LblAuthId
            // 
            this.LblAuthId.AutoSize = true;
            this.LblAuthId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblAuthId.Location = new System.Drawing.Point(194, 181);
            this.LblAuthId.Name = "LblAuthId";
            this.LblAuthId.Size = new System.Drawing.Size(52, 19);
            this.LblAuthId.TabIndex = 61;
            this.LblAuthId.Text = "auth id";
            // 
            // TbAuthId
            // 
            this.TbAuthId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbAuthId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbAuthId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbAuthId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbAuthId.Location = new System.Drawing.Point(285, 177);
            this.TbAuthId.Name = "TbAuthId";
            this.TbAuthId.Size = new System.Drawing.Size(268, 25);
            this.TbAuthId.TabIndex = 63;
            this.TbAuthId.DoubleClick += new System.EventHandler(this.TbAuthId_DoubleClick);
            // 
            // TbDeviceName
            // 
            this.TbDeviceName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbDeviceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbDeviceName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbDeviceName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbDeviceName.Location = new System.Drawing.Point(285, 248);
            this.TbDeviceName.Name = "TbDeviceName";
            this.TbDeviceName.Size = new System.Drawing.Size(268, 25);
            this.TbDeviceName.TabIndex = 65;
            // 
            // LblDeviceName
            // 
            this.LblDeviceName.AutoSize = true;
            this.LblDeviceName.Cursor = System.Windows.Forms.Cursors.Help;
            this.LblDeviceName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDeviceName.Location = new System.Drawing.Point(162, 250);
            this.LblDeviceName.Name = "LblDeviceName";
            this.LblDeviceName.Size = new System.Drawing.Size(85, 19);
            this.LblDeviceName.TabIndex = 64;
            this.LblDeviceName.Text = "device name";
            // 
            // LblTip1
            // 
            this.LblTip1.AutoSize = true;
            this.LblTip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip1.Location = new System.Drawing.Point(649, 447);
            this.LblTip1.Name = "LblTip1";
            this.LblTip1.Size = new System.Drawing.Size(143, 15);
            this.LblTip1.TabIndex = 75;
            this.LblTip1.Text = "tip: doubleclick to browse";
            // 
            // TbExternalExecutorBinary
            // 
            this.TbExternalExecutorBinary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbExternalExecutorBinary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbExternalExecutorBinary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbExternalExecutorBinary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbExternalExecutorBinary.Location = new System.Drawing.Point(285, 443);
            this.TbExternalExecutorBinary.Name = "TbExternalExecutorBinary";
            this.TbExternalExecutorBinary.Size = new System.Drawing.Size(358, 25);
            this.TbExternalExecutorBinary.TabIndex = 73;
            this.TbExternalExecutorBinary.DoubleClick += new System.EventHandler(this.TbExternalExecutorBinary_DoubleClick);
            // 
            // LblCustomExecBinary
            // 
            this.LblCustomExecBinary.AutoSize = true;
            this.LblCustomExecBinary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblCustomExecBinary.Location = new System.Drawing.Point(95, 443);
            this.LblCustomExecBinary.Name = "LblCustomExecBinary";
            this.LblCustomExecBinary.Size = new System.Drawing.Size(152, 19);
            this.LblCustomExecBinary.TabIndex = 74;
            this.LblCustomExecBinary.Text = "custom executor binary";
            // 
            // TbExternalExecutorName
            // 
            this.TbExternalExecutorName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbExternalExecutorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbExternalExecutorName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbExternalExecutorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbExternalExecutorName.Location = new System.Drawing.Point(285, 486);
            this.TbExternalExecutorName.Name = "TbExternalExecutorName";
            this.TbExternalExecutorName.Size = new System.Drawing.Size(358, 25);
            this.TbExternalExecutorName.TabIndex = 70;
            // 
            // LblCustomExecName
            // 
            this.LblCustomExecName.AutoSize = true;
            this.LblCustomExecName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblCustomExecName.Location = new System.Drawing.Point(99, 488);
            this.LblCustomExecName.Name = "LblCustomExecName";
            this.LblCustomExecName.Size = new System.Drawing.Size(148, 19);
            this.LblCustomExecName.TabIndex = 71;
            this.LblCustomExecName.Text = "custom executor name";
            // 
            // NumDisconnectGrace
            // 
            this.NumDisconnectGrace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.NumDisconnectGrace.BeforeTouchSize = new System.Drawing.Size(92, 25);
            this.NumDisconnectGrace.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.NumDisconnectGrace.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.NumDisconnectGrace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumDisconnectGrace.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumDisconnectGrace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.NumDisconnectGrace.Location = new System.Drawing.Point(285, 326);
            this.NumDisconnectGrace.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.NumDisconnectGrace.MaxLength = 10;
            this.NumDisconnectGrace.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumDisconnectGrace.Name = "NumDisconnectGrace";
            this.NumDisconnectGrace.Size = new System.Drawing.Size(92, 25);
            this.NumDisconnectGrace.TabIndex = 78;
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
            this.LblSeconds.AutoSize = true;
            this.LblSeconds.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblSeconds.Location = new System.Drawing.Point(383, 328);
            this.LblSeconds.Name = "LblSeconds";
            this.LblSeconds.Size = new System.Drawing.Size(58, 19);
            this.LblSeconds.TabIndex = 77;
            this.LblSeconds.Text = "seconds";
            // 
            // LblDisconGrace
            // 
            this.LblDisconGrace.AutoSize = true;
            this.LblDisconGrace.Cursor = System.Windows.Forms.Cursors.Help;
            this.LblDisconGrace.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDisconGrace.Location = new System.Drawing.Point(78, 328);
            this.LblDisconGrace.Name = "LblDisconGrace";
            this.LblDisconGrace.Size = new System.Drawing.Size(169, 19);
            this.LblDisconGrace.TabIndex = 76;
            this.LblDisconGrace.Text = "disconnected grace period";
            // 
            // BtnStoreAuthId
            // 
            this.BtnStoreAuthId.AccessibleName = "Button";
            this.BtnStoreAuthId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreAuthId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStoreAuthId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreAuthId.Location = new System.Drawing.Point(564, 177);
            this.BtnStoreAuthId.Name = "BtnStoreAuthId";
            this.BtnStoreAuthId.Size = new System.Drawing.Size(147, 25);
            this.BtnStoreAuthId.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreAuthId.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreAuthId.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreAuthId.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreAuthId.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreAuthId.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreAuthId.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStoreAuthId.TabIndex = 85;
            this.BtnStoreAuthId.Text = global::HASS.Agent.Resources.Localization.Languages.ServiceGeneral_Apply;
            this.BtnStoreAuthId.UseVisualStyleBackColor = false;
            this.BtnStoreAuthId.Click += new System.EventHandler(this.BtnStoreAuthId_Click);
            // 
            // BtnStoreDeviceName
            // 
            this.BtnStoreDeviceName.AccessibleName = "Button";
            this.BtnStoreDeviceName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreDeviceName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStoreDeviceName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreDeviceName.Location = new System.Drawing.Point(564, 248);
            this.BtnStoreDeviceName.Name = "BtnStoreDeviceName";
            this.BtnStoreDeviceName.Size = new System.Drawing.Size(147, 25);
            this.BtnStoreDeviceName.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreDeviceName.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreDeviceName.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreDeviceName.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreDeviceName.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreDeviceName.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreDeviceName.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStoreDeviceName.TabIndex = 86;
            this.BtnStoreDeviceName.Text = global::HASS.Agent.Resources.Localization.Languages.ServiceGeneral_Apply;
            this.BtnStoreDeviceName.UseVisualStyleBackColor = false;
            this.BtnStoreDeviceName.Click += new System.EventHandler(this.BtnStoreDeviceName_Click);
            // 
            // BtnStoreDisconGrace
            // 
            this.BtnStoreDisconGrace.AccessibleName = "Button";
            this.BtnStoreDisconGrace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreDisconGrace.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStoreDisconGrace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreDisconGrace.Location = new System.Drawing.Point(564, 326);
            this.BtnStoreDisconGrace.Name = "BtnStoreDisconGrace";
            this.BtnStoreDisconGrace.Size = new System.Drawing.Size(147, 25);
            this.BtnStoreDisconGrace.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreDisconGrace.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreDisconGrace.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreDisconGrace.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreDisconGrace.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreDisconGrace.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreDisconGrace.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStoreDisconGrace.TabIndex = 87;
            this.BtnStoreDisconGrace.Text = global::HASS.Agent.Resources.Localization.Languages.ServiceGeneral_Apply;
            this.BtnStoreDisconGrace.UseVisualStyleBackColor = false;
            this.BtnStoreDisconGrace.Click += new System.EventHandler(this.BtnStoreDisconGrace_Click);
            // 
            // BtnStoreCustomExecutor
            // 
            this.BtnStoreCustomExecutor.AccessibleName = "Button";
            this.BtnStoreCustomExecutor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreCustomExecutor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStoreCustomExecutor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreCustomExecutor.Location = new System.Drawing.Point(496, 526);
            this.BtnStoreCustomExecutor.Name = "BtnStoreCustomExecutor";
            this.BtnStoreCustomExecutor.Size = new System.Drawing.Size(147, 25);
            this.BtnStoreCustomExecutor.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreCustomExecutor.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreCustomExecutor.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreCustomExecutor.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreCustomExecutor.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStoreCustomExecutor.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStoreCustomExecutor.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStoreCustomExecutor.TabIndex = 88;
            this.BtnStoreCustomExecutor.Text = global::HASS.Agent.Resources.Localization.Languages.ServiceGeneral_Apply;
            this.BtnStoreCustomExecutor.UseVisualStyleBackColor = false;
            this.BtnStoreCustomExecutor.Click += new System.EventHandler(this.BtnStoreCustomExecutor_Click);
            // 
            // LblVersionInfo
            // 
            this.LblVersionInfo.AutoSize = true;
            this.LblVersionInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblVersionInfo.Location = new System.Drawing.Point(194, 100);
            this.LblVersionInfo.Name = "LblVersionInfo";
            this.LblVersionInfo.Size = new System.Drawing.Size(53, 19);
            this.LblVersionInfo.TabIndex = 94;
            this.LblVersionInfo.Text = "version";
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.LblVersion.Location = new System.Drawing.Point(285, 100);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(15, 19);
            this.LblVersion.TabIndex = 95;
            this.LblVersion.Text = "-";
            // 
            // LblTip2
            // 
            this.LblTip2.AutoSize = true;
            this.LblTip2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTip2.Location = new System.Drawing.Point(357, 205);
            this.LblTip2.Name = "LblTip2";
            this.LblTip2.Size = new System.Drawing.Size(196, 15);
            this.LblTip2.TabIndex = 96;
            this.LblTip2.Text = Languages.ServiceGeneral_LblTip2;
            // 
            // LblAuthStored
            // 
            this.LblAuthStored.AutoSize = true;
            this.LblAuthStored.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblAuthStored.ForeColor = System.Drawing.Color.LimeGreen;
            this.LblAuthStored.Location = new System.Drawing.Point(717, 179);
            this.LblAuthStored.Name = "LblAuthStored";
            this.LblAuthStored.Size = new System.Drawing.Size(52, 19);
            this.LblAuthStored.TabIndex = 97;
            this.LblAuthStored.Text = Languages.ServiceGeneral_Stored;
            this.LblAuthStored.Visible = false;
            // 
            // LblDeviceNameStored
            // 
            this.LblDeviceNameStored.AutoSize = true;
            this.LblDeviceNameStored.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDeviceNameStored.ForeColor = System.Drawing.Color.LimeGreen;
            this.LblDeviceNameStored.Location = new System.Drawing.Point(717, 250);
            this.LblDeviceNameStored.Name = "LblDeviceNameStored";
            this.LblDeviceNameStored.Size = new System.Drawing.Size(52, 19);
            this.LblDeviceNameStored.TabIndex = 98;
            this.LblDeviceNameStored.Text = Languages.ServiceGeneral_Stored;
            this.LblDeviceNameStored.Visible = false;
            // 
            // LblDisconGraceStored
            // 
            this.LblDisconGraceStored.AutoSize = true;
            this.LblDisconGraceStored.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDisconGraceStored.ForeColor = System.Drawing.Color.LimeGreen;
            this.LblDisconGraceStored.Location = new System.Drawing.Point(717, 328);
            this.LblDisconGraceStored.Name = "LblDisconGraceStored";
            this.LblDisconGraceStored.Size = new System.Drawing.Size(52, 19);
            this.LblDisconGraceStored.TabIndex = 99;
            this.LblDisconGraceStored.Text = Languages.ServiceGeneral_Stored;
            this.LblDisconGraceStored.Visible = false;
            // 
            // LblCustomExecutorStored
            // 
            this.LblCustomExecutorStored.AutoSize = true;
            this.LblCustomExecutorStored.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblCustomExecutorStored.ForeColor = System.Drawing.Color.LimeGreen;
            this.LblCustomExecutorStored.Location = new System.Drawing.Point(649, 530);
            this.LblCustomExecutorStored.Name = "LblCustomExecutorStored";
            this.LblCustomExecutorStored.Size = new System.Drawing.Size(52, 19);
            this.LblCustomExecutorStored.TabIndex = 100;
            this.LblCustomExecutorStored.Text = Languages.ServiceGeneral_Stored;
            this.LblCustomExecutorStored.Visible = false;
            // 
            // LblAuthIdInfo
            // 
            this.LblAuthIdInfo.AutoSize = true;
            this.LblAuthIdInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblAuthIdInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblAuthIdInfo.Location = new System.Drawing.Point(262, 178);
            this.LblAuthIdInfo.Name = "LblAuthIdInfo";
            this.LblAuthIdInfo.Size = new System.Drawing.Size(17, 21);
            this.LblAuthIdInfo.TabIndex = 101;
            this.LblAuthIdInfo.Text = "?";
            this.LblAuthIdInfo.Click += new System.EventHandler(this.LblAuthIdInfo_Click);
            // 
            // LblDeviceNameInfo
            // 
            this.LblDeviceNameInfo.AutoSize = true;
            this.LblDeviceNameInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblDeviceNameInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblDeviceNameInfo.Location = new System.Drawing.Point(262, 250);
            this.LblDeviceNameInfo.Name = "LblDeviceNameInfo";
            this.LblDeviceNameInfo.Size = new System.Drawing.Size(17, 21);
            this.LblDeviceNameInfo.TabIndex = 102;
            this.LblDeviceNameInfo.Text = "?";
            this.LblDeviceNameInfo.Click += new System.EventHandler(this.LblDeviceNameInfo_Click);
            // 
            // LblDisconGraceInfo
            // 
            this.LblDisconGraceInfo.AutoSize = true;
            this.LblDisconGraceInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblDisconGraceInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblDisconGraceInfo.Location = new System.Drawing.Point(262, 328);
            this.LblDisconGraceInfo.Name = "LblDisconGraceInfo";
            this.LblDisconGraceInfo.Size = new System.Drawing.Size(17, 21);
            this.LblDisconGraceInfo.TabIndex = 103;
            this.LblDisconGraceInfo.Text = "?";
            this.LblDisconGraceInfo.Click += new System.EventHandler(this.LblDisconGraceInfo_Click);
            // 
            // ServiceGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
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
    }
}
