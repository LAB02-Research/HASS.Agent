namespace HASSAgent.Controls.Service
{
    partial class Connect
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
            this.BtnRetryAuthId = new Syncfusion.WinForms.Controls.SfButton();
            this.TbRetryAuthId = new System.Windows.Forms.TextBox();
            this.LblRetryAuthId = new System.Windows.Forms.Label();
            this.LblConnectionMessage = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PbStep2Authenticate = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PbStep1Connect = new System.Windows.Forms.PictureBox();
            this.LblLoading = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PbStep3Config = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep2Authenticate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep1Connect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep3Config)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnRetryAuthId
            // 
            this.BtnRetryAuthId.AccessibleName = "Button";
            this.BtnRetryAuthId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRetryAuthId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnRetryAuthId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRetryAuthId.Location = new System.Drawing.Point(565, 524);
            this.BtnRetryAuthId.Name = "BtnRetryAuthId";
            this.BtnRetryAuthId.Size = new System.Drawing.Size(147, 25);
            this.BtnRetryAuthId.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRetryAuthId.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRetryAuthId.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRetryAuthId.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRetryAuthId.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnRetryAuthId.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnRetryAuthId.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnRetryAuthId.TabIndex = 98;
            this.BtnRetryAuthId.Text = "apply";
            this.BtnRetryAuthId.UseVisualStyleBackColor = false;
            this.BtnRetryAuthId.Visible = false;
            this.BtnRetryAuthId.Click += new System.EventHandler(this.BtnRetryAuthId_Click);
            // 
            // TbRetryAuthId
            // 
            this.TbRetryAuthId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbRetryAuthId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbRetryAuthId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbRetryAuthId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbRetryAuthId.Location = new System.Drawing.Point(286, 524);
            this.TbRetryAuthId.Name = "TbRetryAuthId";
            this.TbRetryAuthId.Size = new System.Drawing.Size(268, 25);
            this.TbRetryAuthId.TabIndex = 97;
            this.TbRetryAuthId.Visible = false;
            // 
            // LblRetryAuthId
            // 
            this.LblRetryAuthId.AutoSize = true;
            this.LblRetryAuthId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblRetryAuthId.Location = new System.Drawing.Point(196, 526);
            this.LblRetryAuthId.Name = "LblRetryAuthId";
            this.LblRetryAuthId.Size = new System.Drawing.Size(52, 19);
            this.LblRetryAuthId.TabIndex = 96;
            this.LblRetryAuthId.Text = "auth id";
            this.LblRetryAuthId.Visible = false;
            // 
            // LblConnectionMessage
            // 
            this.LblConnectionMessage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblConnectionMessage.Location = new System.Drawing.Point(16, 399);
            this.LblConnectionMessage.Name = "LblConnectionMessage";
            this.LblConnectionMessage.Size = new System.Drawing.Size(871, 87);
            this.LblConnectionMessage.TabIndex = 95;
            this.LblConnectionMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(399, 254);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 19);
            this.label8.TabIndex = 94;
            this.label8.Text = "Authenticate";
            // 
            // PbStep2Authenticate
            // 
            this.PbStep2Authenticate.Image = global::HASSAgent.Properties.Resources.todo_32;
            this.PbStep2Authenticate.Location = new System.Drawing.Point(349, 247);
            this.PbStep2Authenticate.Name = "PbStep2Authenticate";
            this.PbStep2Authenticate.Size = new System.Drawing.Size(32, 32);
            this.PbStep2Authenticate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbStep2Authenticate.TabIndex = 93;
            this.PbStep2Authenticate.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(399, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 19);
            this.label9.TabIndex = 92;
            this.label9.Text = "Connect with service";
            // 
            // PbStep1Connect
            // 
            this.PbStep1Connect.Image = global::HASSAgent.Properties.Resources.todo_32;
            this.PbStep1Connect.Location = new System.Drawing.Point(349, 185);
            this.PbStep1Connect.Name = "PbStep1Connect";
            this.PbStep1Connect.Size = new System.Drawing.Size(32, 32);
            this.PbStep1Connect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbStep1Connect.TabIndex = 91;
            this.PbStep1Connect.TabStop = false;
            // 
            // LblLoading
            // 
            this.LblLoading.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblLoading.Location = new System.Drawing.Point(16, 71);
            this.LblLoading.Name = "LblLoading";
            this.LblLoading.Size = new System.Drawing.Size(871, 57);
            this.LblLoading.TabIndex = 90;
            this.LblLoading.Text = "connecting with the satellite service, one moment please ..";
            this.LblLoading.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(399, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 19);
            this.label1.TabIndex = 101;
            this.label1.Text = "Fetch configuration";
            // 
            // PbStep3Config
            // 
            this.PbStep3Config.Image = global::HASSAgent.Properties.Resources.todo_32;
            this.PbStep3Config.Location = new System.Drawing.Point(349, 309);
            this.PbStep3Config.Name = "PbStep3Config";
            this.PbStep3Config.Size = new System.Drawing.Size(32, 32);
            this.PbStep3Config.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbStep3Config.TabIndex = 100;
            this.PbStep3Config.TabStop = false;
            // 
            // Connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PbStep3Config);
            this.Controls.Add(this.BtnRetryAuthId);
            this.Controls.Add(this.TbRetryAuthId);
            this.Controls.Add(this.LblRetryAuthId);
            this.Controls.Add(this.LblConnectionMessage);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.PbStep2Authenticate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.PbStep1Connect);
            this.Controls.Add(this.LblLoading);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Connect";
            this.Size = new System.Drawing.Size(903, 622);
            this.Load += new System.EventHandler(this.Connect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbStep2Authenticate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep1Connect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbStep3Config)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Syncfusion.WinForms.Controls.SfButton BtnRetryAuthId;
        internal TextBox TbRetryAuthId;
        private Label LblRetryAuthId;
        private Label LblConnectionMessage;
        private Label label8;
        private PictureBox PbStep2Authenticate;
        private Label label9;
        private PictureBox PbStep1Connect;
        private Label LblLoading;
        private Label label1;
        private PictureBox PbStep3Config;
    }
}
