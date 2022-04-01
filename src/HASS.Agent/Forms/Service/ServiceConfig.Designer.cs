
using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Forms.Service
{
    partial class ServiceConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceConfig));
            this.PnlTabs = new System.Windows.Forms.Panel();
            this.ServiceTabs = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.TabGeneral = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.TabMqtt = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.TabCommands = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.TabSensors = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.PnlTabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceTabs)).BeginInit();
            this.ServiceTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlTabs
            // 
            this.PnlTabs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlTabs.Controls.Add(this.ServiceTabs);
            this.PnlTabs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PnlTabs.Location = new System.Drawing.Point(0, 6);
            this.PnlTabs.Name = "PnlTabs";
            this.PnlTabs.Size = new System.Drawing.Size(909, 653);
            this.PnlTabs.TabIndex = 42;
            // 
            // ServiceTabs
            // 
            this.ServiceTabs.AccessibleDescription = "2328";
            this.ServiceTabs.ActiveTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ServiceTabs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ServiceTabs.BeforeTouchSize = new System.Drawing.Size(907, 651);
            this.ServiceTabs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ServiceTabs.Controls.Add(this.TabGeneral);
            this.ServiceTabs.Controls.Add(this.TabMqtt);
            this.ServiceTabs.Controls.Add(this.TabCommands);
            this.ServiceTabs.Controls.Add(this.TabSensors);
            this.ServiceTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServiceTabs.FixedSingleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ServiceTabs.FocusOnTabClick = false;
            this.ServiceTabs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ServiceTabs.InactiveTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.ServiceTabs.Location = new System.Drawing.Point(0, 0);
            this.ServiceTabs.Name = "ServiceTabs";
            this.ServiceTabs.RotateTextWhenVertical = true;
            this.ServiceTabs.Size = new System.Drawing.Size(907, 651);
            this.ServiceTabs.TabIndex = 0;
            this.ServiceTabs.TabPanelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ServiceTabs.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererMetro);
            this.ServiceTabs.ThemeName = "TabRendererMetro";
            this.ServiceTabs.ThemesEnabled = true;
            this.ServiceTabs.ThemeStyle.PrimitiveButtonStyle.DisabledNextPageImage = null;
            // 
            // TabGeneral
            // 
            this.TabGeneral.AutoScroll = true;
            this.TabGeneral.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TabGeneral.Image = null;
            this.TabGeneral.ImageSize = new System.Drawing.Size(16, 16);
            this.TabGeneral.Location = new System.Drawing.Point(2, 27);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.ShowCloseButton = false;
            this.TabGeneral.Size = new System.Drawing.Size(903, 622);
            this.TabGeneral.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TabGeneral.TabForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TabGeneral.TabIndex = 9;
            this.TabGeneral.Text = Languages.ServiceConfig_TabGeneral;
            this.TabGeneral.ThemesEnabled = false;
            // 
            // TabMqtt
            // 
            this.TabMqtt.Image = null;
            this.TabMqtt.ImageSize = new System.Drawing.Size(16, 16);
            this.TabMqtt.Location = new System.Drawing.Point(2, 27);
            this.TabMqtt.Name = "TabMqtt";
            this.TabMqtt.ShowCloseButton = true;
            this.TabMqtt.Size = new System.Drawing.Size(903, 622);
            this.TabMqtt.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TabMqtt.TabForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TabMqtt.TabIndex = 11;
            this.TabMqtt.TabVisible = false;
            this.TabMqtt.Text = Languages.ServiceConfig_TabMqtt;
            this.TabMqtt.ThemesEnabled = false;
            // 
            // TabCommands
            // 
            this.TabCommands.AutoScroll = true;
            this.TabCommands.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TabCommands.Image = null;
            this.TabCommands.ImageSize = new System.Drawing.Size(16, 16);
            this.TabCommands.Location = new System.Drawing.Point(2, 27);
            this.TabCommands.Name = "TabCommands";
            this.TabCommands.ShowCloseButton = false;
            this.TabCommands.Size = new System.Drawing.Size(903, 622);
            this.TabCommands.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TabCommands.TabForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TabCommands.TabIndex = 1;
            this.TabCommands.TabVisible = false;
            this.TabCommands.Text = Languages.ServiceConfig_TabCommands;
            this.TabCommands.ThemesEnabled = false;
            // 
            // TabSensors
            // 
            this.TabSensors.AutoScroll = true;
            this.TabSensors.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TabSensors.Image = null;
            this.TabSensors.ImageSize = new System.Drawing.Size(16, 16);
            this.TabSensors.Location = new System.Drawing.Point(2, 27);
            this.TabSensors.Name = "TabSensors";
            this.TabSensors.ShowCloseButton = true;
            this.TabSensors.Size = new System.Drawing.Size(903, 622);
            this.TabSensors.TabBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.TabSensors.TabForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TabSensors.TabIndex = 10;
            this.TabSensors.TabVisible = false;
            this.TabSensors.Text = Languages.ServiceConfig_TabSensors;
            this.TabSensors.ThemesEnabled = false;
            // 
            // ServiceConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(909, 660);
            this.Controls.Add(this.PnlTabs);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.MinimumSize = new System.Drawing.Size(657, 598);
            this.Name = "ServiceConfig";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Languages.ServiceConfig_Title;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SensorsConfig_FormClosing);
            this.Load += new System.EventHandler(this.ServiceConfig_Load);
            this.ResizeEnd += new System.EventHandler(this.SensorsConfig_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SensorsConfig_KeyUp);
            this.PnlTabs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ServiceTabs)).EndInit();
            this.ServiceTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel PnlTabs;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv ServiceTabs;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv TabGeneral;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv TabSensors;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv TabCommands;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv TabMqtt;
    }
}

