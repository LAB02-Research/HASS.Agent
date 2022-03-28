namespace HASS.Agent.Controls.Configuration
{
    partial class Service
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Service));
            this.label12 = new System.Windows.Forms.Label();
            this.LblServiceStatus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnStartService = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnDisableService = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnStopService = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnEnableService = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnReinstallService = new Syncfusion.WinForms.Controls.SfButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnShowLogs = new Syncfusion.WinForms.Controls.SfButton();
            this.BtnRescanStatus = new Syncfusion.WinForms.Controls.SfButton();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(70, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(581, 38);
            this.label12.TabIndex = 36;
            this.label12.Text = "The satellite service allows you to run sensors and commands even when no user\'s " +
    "logged in. \r\nUse the \'satellite service\' button on the main window to manage it." +
    "";
            // 
            // LblServiceStatus
            // 
            this.LblServiceStatus.AutoSize = true;
            this.LblServiceStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblServiceStatus.Location = new System.Drawing.Point(290, 107);
            this.LblServiceStatus.Name = "LblServiceStatus";
            this.LblServiceStatus.Size = new System.Drawing.Size(15, 19);
            this.LblServiceStatus.TabIndex = 38;
            this.LblServiceStatus.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(154, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 19);
            this.label4.TabIndex = 37;
            this.label4.Text = "service status:";
            // 
            // BtnStartService
            // 
            this.BtnStartService.AccessibleName = "Button";
            this.BtnStartService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStartService.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStartService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStartService.Location = new System.Drawing.Point(396, 161);
            this.BtnStartService.Name = "BtnStartService";
            this.BtnStartService.Size = new System.Drawing.Size(188, 31);
            this.BtnStartService.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStartService.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStartService.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStartService.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStartService.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStartService.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStartService.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStartService.TabIndex = 39;
            this.BtnStartService.Text = "start service";
            this.BtnStartService.UseVisualStyleBackColor = false;
            this.BtnStartService.Click += new System.EventHandler(this.BtnStartService_Click);
            // 
            // BtnDisableService
            // 
            this.BtnDisableService.AccessibleName = "Button";
            this.BtnDisableService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnDisableService.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnDisableService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnDisableService.Location = new System.Drawing.Point(156, 290);
            this.BtnDisableService.Name = "BtnDisableService";
            this.BtnDisableService.Size = new System.Drawing.Size(188, 31);
            this.BtnDisableService.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnDisableService.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnDisableService.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnDisableService.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnDisableService.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnDisableService.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnDisableService.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnDisableService.TabIndex = 40;
            this.BtnDisableService.Text = "disable service";
            this.BtnDisableService.UseVisualStyleBackColor = false;
            this.BtnDisableService.Click += new System.EventHandler(this.BtnDisableService_Click);
            // 
            // BtnStopService
            // 
            this.BtnStopService.AccessibleName = "Button";
            this.BtnStopService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStopService.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnStopService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStopService.Location = new System.Drawing.Point(156, 161);
            this.BtnStopService.Name = "BtnStopService";
            this.BtnStopService.Size = new System.Drawing.Size(188, 31);
            this.BtnStopService.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStopService.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStopService.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStopService.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStopService.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStopService.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStopService.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStopService.TabIndex = 41;
            this.BtnStopService.Text = "stop service";
            this.BtnStopService.UseVisualStyleBackColor = false;
            this.BtnStopService.Click += new System.EventHandler(this.BtnStopService_Click);
            // 
            // BtnEnableService
            // 
            this.BtnEnableService.AccessibleName = "Button";
            this.BtnEnableService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnEnableService.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnEnableService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnEnableService.Location = new System.Drawing.Point(396, 290);
            this.BtnEnableService.Name = "BtnEnableService";
            this.BtnEnableService.Size = new System.Drawing.Size(188, 31);
            this.BtnEnableService.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnEnableService.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnEnableService.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnEnableService.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnEnableService.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnEnableService.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnEnableService.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnEnableService.TabIndex = 42;
            this.BtnEnableService.Text = "enable service";
            this.BtnEnableService.UseVisualStyleBackColor = false;
            this.BtnEnableService.Click += new System.EventHandler(this.BtnEnableService_Click);
            // 
            // BtnReinstallService
            // 
            this.BtnReinstallService.AccessibleName = "Button";
            this.BtnReinstallService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnReinstallService.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnReinstallService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnReinstallService.Location = new System.Drawing.Point(154, 403);
            this.BtnReinstallService.Name = "BtnReinstallService";
            this.BtnReinstallService.Size = new System.Drawing.Size(432, 31);
            this.BtnReinstallService.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnReinstallService.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnReinstallService.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnReinstallService.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnReinstallService.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnReinstallService.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnReinstallService.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnReinstallService.TabIndex = 43;
            this.BtnReinstallService.Text = "reinstall service";
            this.BtnReinstallService.UseVisualStyleBackColor = false;
            this.BtnReinstallService.Click += new System.EventHandler(this.BtnReinstallService_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(47, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(646, 38);
            this.label1.TabIndex = 44;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(177, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(386, 38);
            this.label2.TabIndex = 45;
            this.label2.Text = "You can try reinstalling the service if it\'s not working correctly.\r\nYour configu" +
    "ration and entities won\'t be removed.";
            // 
            // BtnShowLogs
            // 
            this.BtnShowLogs.AccessibleName = "Button";
            this.BtnShowLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnShowLogs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnShowLogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnShowLogs.Location = new System.Drawing.Point(154, 491);
            this.BtnShowLogs.Name = "BtnShowLogs";
            this.BtnShowLogs.Size = new System.Drawing.Size(432, 31);
            this.BtnShowLogs.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnShowLogs.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnShowLogs.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnShowLogs.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnShowLogs.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnShowLogs.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnShowLogs.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnShowLogs.TabIndex = 46;
            this.BtnShowLogs.Text = "open service logs folder";
            this.BtnShowLogs.UseVisualStyleBackColor = false;
            this.BtnShowLogs.Click += new System.EventHandler(this.BtnShowLogs_Click);
            // 
            // BtnRescanStatus
            // 
            this.BtnRescanStatus.AccessibleName = "Button";
            this.BtnRescanStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRescanStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnRescanStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRescanStatus.ImageSize = new System.Drawing.Size(24, 24);
            this.BtnRescanStatus.Location = new System.Drawing.Point(535, 100);
            this.BtnRescanStatus.Name = "BtnRescanStatus";
            this.BtnRescanStatus.Size = new System.Drawing.Size(51, 31);
            this.BtnRescanStatus.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRescanStatus.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRescanStatus.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRescanStatus.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRescanStatus.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRescanStatus.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRescanStatus.Style.Image = global::HASS.Agent.Properties.Resources.reset_24;
            this.BtnRescanStatus.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnRescanStatus.TabIndex = 47;
            this.BtnRescanStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.BtnRescanStatus.UseVisualStyleBackColor = false;
            this.BtnRescanStatus.Click += new System.EventHandler(this.BtnRescanStatus_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(68, 454);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(605, 19);
            this.label3.TabIndex = 48;
            this.label3.Text = "If the service still fails after reinstalling, please open a ticket and send the " +
    "content of the latest log.";
            // 
            // Service
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnRescanStatus);
            this.Controls.Add(this.BtnShowLogs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnReinstallService);
            this.Controls.Add(this.BtnEnableService);
            this.Controls.Add(this.BtnStopService);
            this.Controls.Add(this.BtnDisableService);
            this.Controls.Add(this.BtnStartService);
            this.Controls.Add(this.LblServiceStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label12);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Service";
            this.Size = new System.Drawing.Size(740, 544);
            this.Load += new System.EventHandler(this.Service_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label12;
        internal Label LblServiceStatus;
        private Label label4;
        internal Syncfusion.WinForms.Controls.SfButton BtnStartService;
        internal Syncfusion.WinForms.Controls.SfButton BtnDisableService;
        internal Syncfusion.WinForms.Controls.SfButton BtnStopService;
        internal Syncfusion.WinForms.Controls.SfButton BtnEnableService;
        internal Syncfusion.WinForms.Controls.SfButton BtnReinstallService;
        private Label label1;
        private Label label2;
        internal Syncfusion.WinForms.Controls.SfButton BtnShowLogs;
        internal Syncfusion.WinForms.Controls.SfButton BtnRescanStatus;
        private Label label3;
    }
}
