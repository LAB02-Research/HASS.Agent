
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
            this.CbType = new System.Windows.Forms.ComboBox();
            this.LblSetting = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnStore
            // 
            this.BtnStore.AccessibleName = "Button";
            this.BtnStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.BtnStore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnStore.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.BtnStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.BtnStore.Location = new System.Drawing.Point(0, 204);
            this.BtnStore.Name = "BtnStore";
            this.BtnStore.Size = new System.Drawing.Size(352, 38);
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
            this.TbSetting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbSetting.Location = new System.Drawing.Point(12, 152);
            this.TbSetting.Name = "TbSetting";
            this.TbSetting.Size = new System.Drawing.Size(328, 22);
            this.TbSetting.TabIndex = 15;
            this.TbSetting.Visible = false;
            // 
            // TbName
            // 
            this.TbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.TbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.TbName.Location = new System.Drawing.Point(12, 91);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(328, 22);
            this.TbName.TabIndex = 14;
            // 
            // CbType
            // 
            this.CbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.CbType.FormattingEnabled = true;
            this.CbType.Location = new System.Drawing.Point(12, 35);
            this.CbType.Name = "CbType";
            this.CbType.Size = new System.Drawing.Size(328, 21);
            this.CbType.TabIndex = 13;
            this.CbType.SelectedIndexChanged += new System.EventHandler(this.CbType_SelectedIndexChanged);
            // 
            // LblSetting
            // 
            this.LblSetting.AutoSize = true;
            this.LblSetting.Location = new System.Drawing.Point(9, 136);
            this.LblSetting.Name = "LblSetting";
            this.LblSetting.Size = new System.Drawing.Size(40, 13);
            this.LblSetting.TabIndex = 12;
            this.LblSetting.Text = "config";
            this.LblSetting.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "name";
            // 
            // CommandsMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.CaptionFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(352, 242);
            this.Controls.Add(this.TbSetting);
            this.Controls.Add(this.BtnStore);
            this.Controls.Add(this.TbName);
            this.Controls.Add(this.CbType);
            this.Controls.Add(this.LblSetting);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.WinForms.Controls.SfButton BtnStore;
        private System.Windows.Forms.Label LblSetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CbType;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.TextBox TbSetting;
    }
}

