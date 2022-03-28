namespace HASS.Agent.Controls.Configuration
{
    partial class Logging
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Logging));
            this.label23 = new System.Windows.Forms.Label();
            this.CbExtendedLogging = new System.Windows.Forms.CheckBox();
            this.BtnShowLogs = new Syncfusion.WinForms.Controls.SfButton();
            this.SuspendLayout();
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label23.Location = new System.Drawing.Point(70, 36);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(601, 82);
            this.label23.TabIndex = 31;
            this.label23.Text = resources.GetString("label23.Text");
            // 
            // CbExtendedLogging
            // 
            this.CbExtendedLogging.AutoSize = true;
            this.CbExtendedLogging.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbExtendedLogging.Location = new System.Drawing.Point(70, 175);
            this.CbExtendedLogging.Name = "CbExtendedLogging";
            this.CbExtendedLogging.Size = new System.Drawing.Size(178, 23);
            this.CbExtendedLogging.TabIndex = 30;
            this.CbExtendedLogging.Text = "enable extended logging";
            this.CbExtendedLogging.UseVisualStyleBackColor = true;
            // 
            // BtnShowLogs
            // 
            this.BtnShowLogs.AccessibleName = "Button";
            this.BtnShowLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnShowLogs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnShowLogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnShowLogs.Location = new System.Drawing.Point(70, 461);
            this.BtnShowLogs.Name = "BtnShowLogs";
            this.BtnShowLogs.Size = new System.Drawing.Size(601, 31);
            this.BtnShowLogs.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnShowLogs.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnShowLogs.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnShowLogs.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnShowLogs.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnShowLogs.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnShowLogs.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnShowLogs.TabIndex = 47;
            this.BtnShowLogs.Text = "open logs folder";
            this.BtnShowLogs.UseVisualStyleBackColor = false;
            this.BtnShowLogs.Click += new System.EventHandler(this.BtnShowLogs_Click);
            // 
            // Logging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.BtnShowLogs);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.CbExtendedLogging);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Logging";
            this.Size = new System.Drawing.Size(740, 544);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label23;
        internal System.Windows.Forms.CheckBox CbExtendedLogging;
        internal Syncfusion.WinForms.Controls.SfButton BtnShowLogs;
    }
}
