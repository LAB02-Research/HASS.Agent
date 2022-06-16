
using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Forms.Commands.CommandConfig
{
    partial class CommandMqttTopic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandMqttTopic));
            this.BtnClose = new Syncfusion.WinForms.Controls.SfButton();
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.TbMqttTopic = new System.Windows.Forms.TextBox();
            this.BtnCopyClipboard = new Syncfusion.WinForms.Controls.SfButton();
            this.LblHelp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.AccessibleDescription = "Closes the form.";
            this.BtnClose.AccessibleName = "Close";
            this.BtnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClose.Location = new System.Drawing.Point(0, 207);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(878, 37);
            this.BtnClose.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClose.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClose.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClose.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClose.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnClose.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnClose.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnClose.TabIndex = 2;
            this.BtnClose.Text = Languages.CommandMqttTopic_BtnClose;
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "MQTT topic information.";
            this.LblInfo1.AccessibleName = "Topic information";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.AutoSize = true;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(31, 29);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(419, 19);
            this.LblInfo1.TabIndex = 3;
            this.LblInfo1.Text = Languages.CommandMqttTopic_LblInfo1;
            // 
            // TbMqttTopic
            // 
            this.TbMqttTopic.AccessibleDescription = "The MQTT topic to use when publishing an action.";
            this.TbMqttTopic.AccessibleName = "MQTT topic";
            this.TbMqttTopic.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.TbMqttTopic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbMqttTopic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbMqttTopic.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbMqttTopic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbMqttTopic.Location = new System.Drawing.Point(31, 76);
            this.TbMqttTopic.Name = "TbMqttTopic";
            this.TbMqttTopic.ReadOnly = true;
            this.TbMqttTopic.Size = new System.Drawing.Size(813, 25);
            this.TbMqttTopic.TabIndex = 0;
            // 
            // BtnCopyClipboard
            // 
            this.BtnCopyClipboard.AccessibleDescription = "Copies the MQTT topic to the clipboard.";
            this.BtnCopyClipboard.AccessibleName = "MQTT copy to clipboard";
            this.BtnCopyClipboard.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnCopyClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCopyClipboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCopyClipboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCopyClipboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCopyClipboard.Location = new System.Drawing.Point(588, 110);
            this.BtnCopyClipboard.Name = "BtnCopyClipboard";
            this.BtnCopyClipboard.Size = new System.Drawing.Size(256, 27);
            this.BtnCopyClipboard.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCopyClipboard.Style.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCopyClipboard.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCopyClipboard.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCopyClipboard.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCopyClipboard.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnCopyClipboard.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnCopyClipboard.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnCopyClipboard.TabIndex = 1;
            this.BtnCopyClipboard.Text = Languages.CommandMqttTopic_BtnCopyClipboard;
            this.BtnCopyClipboard.UseVisualStyleBackColor = false;
            this.BtnCopyClipboard.Click += new System.EventHandler(this.BtnCopyClipboard_Click);
            // 
            // LblHelp
            // 
            this.LblHelp.AccessibleDescription = "Opens the `help and examples` webpage.";
            this.LblHelp.AccessibleName = "Launch help";
            this.LblHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.Link;
            this.LblHelp.AutoSize = true;
            this.LblHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblHelp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LblHelp.Location = new System.Drawing.Point(31, 174);
            this.LblHelp.Name = "LblHelp";
            this.LblHelp.Size = new System.Drawing.Size(122, 19);
            this.LblHelp.TabIndex = 49;
            this.LblHelp.Text = Languages.CommandMqttTopic_LblHelp;
            this.LblHelp.Click += new System.EventHandler(this.LblHelp_Click);
            // 
            // CommandMqttTopic
            // 
            this.AccessibleDescription = "Contains the MQTT action topic for the command.";
            this.AccessibleName = "MQTT action topic";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(878, 244);
            this.Controls.Add(this.LblHelp);
            this.Controls.Add(this.BtnCopyClipboard);
            this.Controls.Add(this.TbMqttTopic);
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.BtnClose);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.Name = "CommandMqttTopic";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Languages.CommandMqttTopic_Title;
            this.Load += new System.EventHandler(this.MqttTopic_Load);
            this.ResizeEnd += new System.EventHandler(this.MqttTopic_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MqttTopic_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Syncfusion.WinForms.Controls.SfButton BtnClose;
        private System.Windows.Forms.Label LblInfo1;
        private TextBox TbMqttTopic;
        private Syncfusion.WinForms.Controls.SfButton BtnCopyClipboard;
        private Label LblHelp;
    }
}

