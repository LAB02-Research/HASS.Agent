using HASS.Agent.Resources.Localization;

namespace HASS.Agent.Controls.Configuration
{
    partial class ConfigLocalApi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigLocalApi));
            this.LblInfo1 = new System.Windows.Forms.Label();
            this.LblPort = new System.Windows.Forms.Label();
            this.NumLocalApiPort = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.BtnExecutePortReservation = new Syncfusion.WinForms.Controls.SfButton();
            this.CbLocalApiActive = new System.Windows.Forms.CheckBox();
            this.LblInfo2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumLocalApiPort)).BeginInit();
            this.SuspendLayout();
            // 
            // LblInfo1
            // 
            this.LblInfo1.AccessibleDescription = "Local API information.";
            this.LblInfo1.AccessibleName = "Information";
            this.LblInfo1.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo1.Location = new System.Drawing.Point(70, 36);
            this.LblInfo1.Name = "LblInfo1";
            this.LblInfo1.Size = new System.Drawing.Size(566, 153);
            this.LblInfo1.TabIndex = 36;
            this.LblInfo1.Text = Languages.ConfigLocalApi_LblInfo1;
            // 
            // LblPort
            // 
            this.LblPort.AccessibleDescription = "Local API port numeric textbox description.";
            this.LblPort.AccessibleName = "Local API port info";
            this.LblPort.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblPort.AutoSize = true;
            this.LblPort.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblPort.Location = new System.Drawing.Point(283, 277);
            this.LblPort.Name = "LblPort";
            this.LblPort.Size = new System.Drawing.Size(35, 19);
            this.LblPort.TabIndex = 34;
            this.LblPort.Text = Languages.ConfigLocalApi_LblPort;
            // 
            // NumLocalApiPort
            // 
            this.NumLocalApiPort.AccessibleDescription = "The port the local API will bind to. Only accepts numeric values.";
            this.NumLocalApiPort.AccessibleName = "Local API port";
            this.NumLocalApiPort.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.NumLocalApiPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.NumLocalApiPort.BeforeTouchSize = new System.Drawing.Size(83, 25);
            this.NumLocalApiPort.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.NumLocalApiPort.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.NumLocalApiPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumLocalApiPort.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumLocalApiPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.NumLocalApiPort.Location = new System.Drawing.Point(335, 275);
            this.NumLocalApiPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumLocalApiPort.MaxLength = 10;
            this.NumLocalApiPort.MetroColor = System.Drawing.SystemColors.WindowFrame;
            this.NumLocalApiPort.Name = "NumLocalApiPort";
            this.NumLocalApiPort.Size = new System.Drawing.Size(83, 25);
            this.NumLocalApiPort.TabIndex = 1;
            this.NumLocalApiPort.ThemeName = "Metro";
            this.NumLocalApiPort.Value = new decimal(new int[] {
            5115,
            0,
            0,
            0});
            this.NumLocalApiPort.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro;
            // 
            // BtnExecutePortReservation
            // 
            this.BtnExecutePortReservation.AccessibleDescription = "Executes a port reservation, and opens the port in the firewall. This will show a" +
    "n UAC prompt, asking for elevation.";
            this.BtnExecutePortReservation.AccessibleName = "Port reservation";
            this.BtnExecutePortReservation.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnExecutePortReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExecutePortReservation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnExecutePortReservation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExecutePortReservation.Location = new System.Drawing.Point(200, 454);
            this.BtnExecutePortReservation.Name = "BtnExecutePortReservation";
            this.BtnExecutePortReservation.Size = new System.Drawing.Size(301, 31);
            this.BtnExecutePortReservation.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExecutePortReservation.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExecutePortReservation.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExecutePortReservation.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExecutePortReservation.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnExecutePortReservation.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnExecutePortReservation.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnExecutePortReservation.TabIndex = 2;
            this.BtnExecutePortReservation.Text = Languages.ConfigLocalApi_BtnExecutePortReservation;
            this.BtnExecutePortReservation.UseVisualStyleBackColor = false;
            this.BtnExecutePortReservation.Click += new System.EventHandler(this.BtnExecutePortReservation_Click);
            // 
            // CbLocalApiActive
            // 
            this.CbLocalApiActive.AccessibleDescription = "Enable the local API.";
            this.CbLocalApiActive.AccessibleName = "Enable Local API";
            this.CbLocalApiActive.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.CbLocalApiActive.AutoSize = true;
            this.CbLocalApiActive.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbLocalApiActive.Location = new System.Drawing.Point(290, 216);
            this.CbLocalApiActive.Name = "CbLocalApiActive";
            this.CbLocalApiActive.Size = new System.Drawing.Size(121, 23);
            this.CbLocalApiActive.TabIndex = 0;
            this.CbLocalApiActive.Text = Languages.ConfigLocalApi_CbLocalApiActive;
            this.CbLocalApiActive.UseVisualStyleBackColor = true;
            // 
            // LblInfo2
            // 
            this.LblInfo2.AccessibleDescription = "Port reservation information.";
            this.LblInfo2.AccessibleName = "Port reservation info";
            this.LblInfo2.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            this.LblInfo2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblInfo2.Location = new System.Drawing.Point(70, 362);
            this.LblInfo2.Name = "LblInfo2";
            this.LblInfo2.Size = new System.Drawing.Size(566, 74);
            this.LblInfo2.TabIndex = 76;
            this.LblInfo2.Text = Languages.ConfigLocalApi_LblInfo2;
            // 
            // ConfigLocalApi
            // 
            this.AccessibleDescription = "Panel containing the local API\'s configuration.";
            this.AccessibleName = "Local API";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.LblInfo2);
            this.Controls.Add(this.CbLocalApiActive);
            this.Controls.Add(this.BtnExecutePortReservation);
            this.Controls.Add(this.NumLocalApiPort);
            this.Controls.Add(this.LblInfo1);
            this.Controls.Add(this.LblPort);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfigLocalApi";
            this.Size = new System.Drawing.Size(700, 544);
            this.Load += new System.EventHandler(this.ConfigLocalApi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumLocalApiPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblInfo1;
        private System.Windows.Forms.Label LblPort;
        internal Syncfusion.Windows.Forms.Tools.NumericUpDownExt NumLocalApiPort;
        internal Syncfusion.WinForms.Controls.SfButton BtnExecutePortReservation;
        internal CheckBox CbLocalApiActive;
        private Label LblInfo2;
    }
}
