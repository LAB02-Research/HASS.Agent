
namespace HASSAgent.Forms.Commands
{
    partial class CommandsMod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandsMod));
            this.BtnStore = new Syncfusion.WinForms.Controls.SfButton();
            this.TbSetting = new System.Windows.Forms.TextBox();
            this.TbName = new System.Windows.Forms.TextBox();
            this.LblSetting = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PnlDescription = new System.Windows.Forms.Panel();
            this.TbDescription = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CbType = new System.Windows.Forms.ComboBox();
            this.CbRunAsLowIntegrity = new System.Windows.Forms.CheckBox();
            this.LblIntegrityInfo = new System.Windows.Forms.Label();
            this.PnlDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnStore
            // 
            this.BtnStore.AccessibleName = "Button";
            this.BtnStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnStore.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Location = new System.Drawing.Point(0, 264);
            this.BtnStore.Name = "BtnStore";
            this.BtnStore.Size = new System.Drawing.Size(756, 38);
            this.BtnStore.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.FocusedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Style.HoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Style.PressedForeColor = System.Drawing.Color.Black;
            this.BtnStore.TabIndex = 3;
            this.BtnStore.Text = "store command";
            this.BtnStore.UseVisualStyleBackColor = false;
            this.BtnStore.Click += new System.EventHandler(this.BtnStore_Click);
            // 
            // TbSetting
            // 
            this.TbSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbSetting.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbSetting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbSetting.Location = new System.Drawing.Point(12, 156);
            this.TbSetting.Name = "TbSetting";
            this.TbSetting.Size = new System.Drawing.Size(328, 25);
            this.TbSetting.TabIndex = 2;
            this.TbSetting.Visible = false;
            // 
            // TbName
            // 
            this.TbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbName.Location = new System.Drawing.Point(12, 95);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(328, 25);
            this.TbName.TabIndex = 1;
            // 
            // LblSetting
            // 
            this.LblSetting.AutoSize = true;
            this.LblSetting.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSetting.Location = new System.Drawing.Point(9, 136);
            this.LblSetting.Name = "LblSetting";
            this.LblSetting.Size = new System.Drawing.Size(44, 17);
            this.LblSetting.TabIndex = 12;
            this.LblSetting.Text = "config";
            this.LblSetting.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "name";
            // 
            // PnlDescription
            // 
            this.PnlDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlDescription.Controls.Add(this.TbDescription);
            this.PnlDescription.Location = new System.Drawing.Point(387, 39);
            this.PnlDescription.Name = "PnlDescription";
            this.PnlDescription.Size = new System.Drawing.Size(354, 205);
            this.PnlDescription.TabIndex = 21;
            // 
            // TbDescription
            // 
            this.TbDescription.AutoWordSelection = true;
            this.TbDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbDescription.Location = new System.Drawing.Point(0, 0);
            this.TbDescription.Name = "TbDescription";
            this.TbDescription.ReadOnly = true;
            this.TbDescription.Size = new System.Drawing.Size(352, 203);
            this.TbDescription.TabIndex = 18;
            this.TbDescription.Text = "";
            this.TbDescription.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.TbDescription_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(384, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "command description";
            // 
            // CbType
            // 
            this.CbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CbType.DropDownHeight = 300;
            this.CbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.CbType.FormattingEnabled = true;
            this.CbType.IntegralHeight = false;
            this.CbType.Location = new System.Drawing.Point(12, 40);
            this.CbType.Name = "CbType";
            this.CbType.Size = new System.Drawing.Size(328, 26);
            this.CbType.TabIndex = 25;
            this.CbType.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.CbType_DrawItem);
            this.CbType.SelectedIndexChanged += new System.EventHandler(this.CbType_SelectedIndexChanged);
            // 
            // CbRunAsLowIntegrity
            // 
            this.CbRunAsLowIntegrity.AutoSize = true;
            this.CbRunAsLowIntegrity.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbRunAsLowIntegrity.Location = new System.Drawing.Point(12, 207);
            this.CbRunAsLowIntegrity.Name = "CbRunAsLowIntegrity";
            this.CbRunAsLowIntegrity.Size = new System.Drawing.Size(144, 21);
            this.CbRunAsLowIntegrity.TabIndex = 26;
            this.CbRunAsLowIntegrity.Text = "run as \'low integrity\'";
            this.CbRunAsLowIntegrity.UseVisualStyleBackColor = true;
            // 
            // LblIntegrityInfo
            // 
            this.LblIntegrityInfo.AutoSize = true;
            this.LblIntegrityInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblIntegrityInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIntegrityInfo.Location = new System.Drawing.Point(187, 208);
            this.LblIntegrityInfo.Name = "LblIntegrityInfo";
            this.LblIntegrityInfo.Size = new System.Drawing.Size(74, 17);
            this.LblIntegrityInfo.TabIndex = 27;
            this.LblIntegrityInfo.Text = "what\'s this?";
            this.LblIntegrityInfo.Visible = false;
            this.LblIntegrityInfo.Click += new System.EventHandler(this.LblIntegrityInfo_Click);
            // 
            // CommandsMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(756, 302);
            this.Controls.Add(this.LblIntegrityInfo);
            this.Controls.Add(this.CbRunAsLowIntegrity);
            this.Controls.Add(this.CbType);
            this.Controls.Add(this.PnlDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TbSetting);
            this.Controls.Add(this.BtnStore);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.LblSetting);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(129)))), ((int)(((byte)(131)))));
            this.Name = "CommandsMod";
            this.ShowMaximizeBox = false;
            this.ShowMinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Command";
            this.Load += new System.EventHandler(this.CommandsMod_Load);
            this.ResizeEnd += new System.EventHandler(this.CommandsMod_ResizeEnd);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CommandsMod_KeyUp);
            this.PnlDescription.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.WinForms.Controls.SfButton BtnStore;
        private System.Windows.Forms.Label LblSetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.TextBox TbSetting;
        private System.Windows.Forms.Panel PnlDescription;
        private System.Windows.Forms.RichTextBox TbDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CbType;
        private System.Windows.Forms.CheckBox CbRunAsLowIntegrity;
        private System.Windows.Forms.Label LblIntegrityInfo;
    }
}

