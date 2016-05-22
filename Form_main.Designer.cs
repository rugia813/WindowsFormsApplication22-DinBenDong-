namespace WindowsFormsApplication22_DinBenDong_
{
    partial class Form_main
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
            this.btnEditStu = new System.Windows.Forms.Button();
            this.btnEditSup = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnClassOrderDetails = new System.Windows.Forms.Button();
            this.cbbChooseSup = new System.Windows.Forms.ComboBox();
            this.lblChooseSup = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEditStu
            // 
            this.btnEditStu.Location = new System.Drawing.Point(466, 81);
            this.btnEditStu.Name = "btnEditStu";
            this.btnEditStu.Size = new System.Drawing.Size(168, 40);
            this.btnEditStu.TabIndex = 0;
            this.btnEditStu.Text = "編輯期別/學員資料";
            this.btnEditStu.UseVisualStyleBackColor = true;
            this.btnEditStu.Click += new System.EventHandler(this.btnEditStu_Click);
            // 
            // btnEditSup
            // 
            this.btnEditSup.Location = new System.Drawing.Point(466, 145);
            this.btnEditSup.Name = "btnEditSup";
            this.btnEditSup.Size = new System.Drawing.Size(168, 40);
            this.btnEditSup.TabIndex = 0;
            this.btnEditSup.Text = "編輯廠商資料";
            this.btnEditSup.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(147, 472);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(168, 40);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "確認訂購";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(466, 419);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(168, 40);
            this.button4.TabIndex = 0;
            this.button4.Text = "個人訂購明細";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnClassOrderDetails
            // 
            this.btnClassOrderDetails.Location = new System.Drawing.Point(466, 359);
            this.btnClassOrderDetails.Name = "btnClassOrderDetails";
            this.btnClassOrderDetails.Size = new System.Drawing.Size(168, 40);
            this.btnClassOrderDetails.TabIndex = 0;
            this.btnClassOrderDetails.Text = "訂購明細";
            this.btnClassOrderDetails.UseVisualStyleBackColor = true;
            // 
            // cbbChooseSup
            // 
            this.cbbChooseSup.FormattingEnabled = true;
            this.cbbChooseSup.Location = new System.Drawing.Point(28, 33);
            this.cbbChooseSup.Name = "cbbChooseSup";
            this.cbbChooseSup.Size = new System.Drawing.Size(121, 28);
            this.cbbChooseSup.TabIndex = 1;
            this.cbbChooseSup.SelectedIndexChanged += new System.EventHandler(this.cbbChooseSup_SelectedIndexChanged);
            // 
            // lblChooseSup
            // 
            this.lblChooseSup.AutoSize = true;
            this.lblChooseSup.Location = new System.Drawing.Point(28, 12);
            this.lblChooseSup.Name = "lblChooseSup";
            this.lblChooseSup.Size = new System.Drawing.Size(105, 20);
            this.lblChooseSup.TabIndex = 2;
            this.lblChooseSup.Text = "選擇今日廠商";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(27, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 370);
            this.panel1.TabIndex = 3;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(466, 518);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(168, 40);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "登出";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 567);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(657, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(29, 17);
            this.toolStripStatusLabel1.Text = "111";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(175, 33);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(101, 28);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "確認";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OliveDrab;
            this.ClientSize = new System.Drawing.Size(657, 589);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblChooseSup);
            this.Controls.Add(this.cbbChooseSup);
            this.Controls.Add(this.btnClassOrderDetails);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnEditSup);
            this.Controls.Add(this.btnEditStu);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "訂便當系統";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_main_FormClosed);
            this.Load += new System.EventHandler(this.Form_main_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEditStu;
        private System.Windows.Forms.Button btnEditSup;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnClassOrderDetails;
        private System.Windows.Forms.ComboBox cbbChooseSup;
        private System.Windows.Forms.Label lblChooseSup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnConfirm;
    }
}