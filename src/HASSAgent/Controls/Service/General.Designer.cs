namespace HASSAgent.Controls.Service
{
    partial class General
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
            this.LblInfo = new System.Windows.Forms.Label();
            this.LblAuthId = new System.Windows.Forms.Label();
            this.TbAuthId = new System.Windows.Forms.TextBox();
            this.TbDeviceName = new System.Windows.Forms.TextBox();
            this.LblDeviceName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TbExternalExecutorBinary = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TbExternalExecutorName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.NumDisconnectGrace = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.label35 = new System.Windows.Forms.Label();
            this.LblDisconGrace = new System.Windows.Forms.Label();
            this.BtnStoreAuthId = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnStoreDeviceName = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnStoreDisconGrace = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnStoreCustomExecutor = new Syncfusion.WinForms.Controls.SfButton();
            this.label5 = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            // LblInfo
            // 
            this.LblInfo.AutoSize = true;
            this.LblInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo.Location = new System.Drawing.Point(27, 19);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(717, 19);
            this.LblInfo.TabIndex = 57;
            this.LblInfo.Text = "This page contains general configuration items. For MQTT settings, sensors and co" +
    "mmands, browse the tabs on top.";
            this.LblInfo.Visible = false;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(649, 447);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 15);
            this.label6.TabIndex = 75;
            this.label6.Text = "tip: doubleclick to browse";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(95, 443);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 19);
            this.label4.TabIndex = 74;
            this.label4.Text = "custom executor binary";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(99, 488);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 19);
            this.label7.TabIndex = 71;
            this.label7.Text = "custom executor name";
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
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label35.Location = new System.Drawing.Point(383, 328);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(58, 19);
            this.label35.TabIndex = 77;
            this.label35.Text = "seconds";
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
            this.BtnStoreAuthId.Text = "apply";
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
            this.BtnStoreDeviceName.Text = "apply";
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
            this.BtnStoreDisconGrace.Text = "apply";
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
            this.BtnStoreCustomExecutor.Text = "apply";
            this.BtnStoreCustomExecutor.UseVisualStyleBackColor = false;
            this.BtnStoreCustomExecutor.Click += new System.EventHandler(this.BtnStoreCustomExecutor_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(194, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 19);
            this.label5.TabIndex = 94;
            this.label5.Text = "version";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(357, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 15);
            this.label1.TabIndex = 96;
            this.label1.Text = "tip: doubleclick to generate random";
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
            this.LblAuthStored.Text = "stored!";
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
            this.LblDeviceNameStored.Text = "stored!";
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
            this.LblDisconGraceStored.Text = "stored!";
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
            this.LblCustomExecutorStored.Text = "stored!";
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
            // General
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
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.BtnStoreCustomExecutor);
            this.Controls.Add(this.BtnStoreDisconGrace);
            this.Controls.Add(this.BtnStoreDeviceName);
            this.Controls.Add(this.BtnStoreAuthId);
            this.Controls.Add(this.NumDisconnectGrace);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.LblDisconGrace);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TbExternalExecutorBinary);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TbExternalExecutorName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TbDeviceName);
            this.Controls.Add(this.LblDeviceName);
            this.Controls.Add(this.TbAuthId);
            this.Controls.Add(this.LblAuthId);
            this.Controls.Add(this.LblInfo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "General";
            this.Size = new System.Drawing.Size(903, 622);
            this.Load += new System.EventHandler(this.General_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumDisconnectGrace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblInfo;
        private Label LblAuthId;
        internal TextBox TbAuthId;
        internal TextBox TbDeviceName;
        private Label LblDeviceName;
        private Label label6;
        internal TextBox TbExternalExecutorBinary;
        private Label label4;
        internal TextBox TbExternalExecutorName;
        private Label label7;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumDisconnectGrace;
        private Label label35;
        private Label LblDisconGrace;
        internal Syncfusion.WinForms.Controls.SfButton BtnStoreAuthId;
        internal Syncfusion.WinForms.Controls.SfButton BtnStoreDeviceName;
        internal Syncfusion.WinForms.Controls.SfButton BtnStoreDisconGrace;
        internal Syncfusion.WinForms.Controls.SfButton BtnStoreCustomExecutor;
        private Label label5;
        private Label LblVersion;
        private Label label1;
        private Label LblAuthStored;
        private Label LblDeviceNameStored;
        private Label LblDisconGraceStored;
        private Label LblCustomExecutorStored;
        private Label LblAuthIdInfo;
        private Label LblDeviceNameInfo;
        private Label LblDisconGraceInfo;
    }
}
