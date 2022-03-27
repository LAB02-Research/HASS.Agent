namespace HASSAgent.Controls.Configuration
{
    partial class Updates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Updates));
            this.CbBetaUpdates = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.CbExecuteUpdater = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.CbUpdates = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // CbBetaUpdates
            // 
            this.CbBetaUpdates.AutoSize = true;
            this.CbBetaUpdates.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbBetaUpdates.Location = new System.Drawing.Point(207, 209);
            this.CbBetaUpdates.Name = "CbBetaUpdates";
            this.CbBetaUpdates.Size = new System.Drawing.Size(229, 23);
            this.CbBetaUpdates.TabIndex = 39;
            this.CbBetaUpdates.Text = "notify me of beta releases as well";
            this.CbBetaUpdates.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label24.Location = new System.Drawing.Point(70, 293);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(598, 79);
            this.label24.TabIndex = 38;
            this.label24.Text = resources.GetString("label24.Text");
            // 
            // CbExecuteUpdater
            // 
            this.CbExecuteUpdater.AutoSize = true;
            this.CbExecuteUpdater.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbExecuteUpdater.Location = new System.Drawing.Point(207, 422);
            this.CbExecuteUpdater.Name = "CbExecuteUpdater";
            this.CbExecuteUpdater.Size = new System.Drawing.Size(327, 23);
            this.CbExecuteUpdater.TabIndex = 37;
            this.CbExecuteUpdater.Text = "offer to download and launch the installer for me";
            this.CbExecuteUpdater.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(70, 36);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(616, 69);
            this.label17.TabIndex = 36;
            this.label17.Text = "If you want, HASS.Agent can check for updates in the background. \r\n\r\nYou\'ll get a" +
    " notification (once per update) , letting you know a new version is ready to be " +
    "installed.";
            // 
            // CbUpdates
            // 
            this.CbUpdates.AutoSize = true;
            this.CbUpdates.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbUpdates.Location = new System.Drawing.Point(207, 158);
            this.CbUpdates.Name = "CbUpdates";
            this.CbUpdates.Size = new System.Drawing.Size(278, 23);
            this.CbUpdates.TabIndex = 35;
            this.CbUpdates.Text = "notify me when a new release is available";
            this.CbUpdates.UseVisualStyleBackColor = true;
            // 
            // Updates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.CbBetaUpdates);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.CbExecuteUpdater);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.CbUpdates);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Updates";
            this.Size = new System.Drawing.Size(740, 544);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label17;
        internal System.Windows.Forms.CheckBox CbBetaUpdates;
        internal System.Windows.Forms.CheckBox CbExecuteUpdater;
        internal System.Windows.Forms.CheckBox CbUpdates;
    }
}
