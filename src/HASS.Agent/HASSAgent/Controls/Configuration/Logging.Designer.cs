namespace HASSAgent.Controls.Configuration
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
            this.LblCoderr = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.CbExceptionReporting = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.CbExtendedLogging = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // LblCoderr
            // 
            this.LblCoderr.AutoSize = true;
            this.LblCoderr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblCoderr.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCoderr.Location = new System.Drawing.Point(632, 426);
            this.LblCoderr.Name = "LblCoderr";
            this.LblCoderr.Size = new System.Drawing.Size(49, 17);
            this.LblCoderr.TabIndex = 34;
            this.LblCoderr.Text = "Coderr";
            this.LblCoderr.Click += new System.EventHandler(this.LblCoderr_Click);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(110, 194);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(535, 124);
            this.label22.TabIndex = 33;
            this.label22.Text = resources.GetString("label22.Text");
            // 
            // CbExceptionReporting
            // 
            this.CbExceptionReporting.AutoSize = true;
            this.CbExceptionReporting.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbExceptionReporting.Location = new System.Drawing.Point(113, 331);
            this.CbExceptionReporting.Name = "CbExceptionReporting";
            this.CbExceptionReporting.Size = new System.Drawing.Size(185, 21);
            this.CbExceptionReporting.TabIndex = 32;
            this.CbExceptionReporting.Text = "enable exception reporting";
            this.CbExceptionReporting.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(110, 40);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(535, 82);
            this.label23.TabIndex = 31;
            this.label23.Text = resources.GetString("label23.Text");
            // 
            // CbExtendedLogging
            // 
            this.CbExtendedLogging.AutoSize = true;
            this.CbExtendedLogging.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbExtendedLogging.Location = new System.Drawing.Point(113, 125);
            this.CbExtendedLogging.Name = "CbExtendedLogging";
            this.CbExtendedLogging.Size = new System.Drawing.Size(173, 21);
            this.CbExtendedLogging.TabIndex = 30;
            this.CbExtendedLogging.Text = "enable extended logging";
            this.CbExtendedLogging.UseVisualStyleBackColor = true;
            // 
            // Logging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.LblCoderr);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.CbExceptionReporting);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.CbExtendedLogging);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Logging";
            this.Size = new System.Drawing.Size(700, 457);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        internal System.Windows.Forms.Label LblCoderr;
        internal System.Windows.Forms.CheckBox CbExceptionReporting;
        internal System.Windows.Forms.CheckBox CbExtendedLogging;
    }
}
