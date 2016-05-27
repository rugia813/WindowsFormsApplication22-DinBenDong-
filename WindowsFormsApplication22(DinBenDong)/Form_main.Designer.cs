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
            this.btnClassOrderDetail = new System.Windows.Forms.Button();
            this.cbbChooseSup = new System.Windows.Forms.ComboBox();
            this.lblChooseSup = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblTodaySup = new System.Windows.Forms.Label();
            this.pnSetting = new System.Windows.Forms.Panel();
            this.btnSetting = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.pnSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEditStu
            // 
            this.btnEditStu.Location = new System.Drawing.Point(7, 27);
            this.btnEditStu.Name = "btnEditStu";
            this.btnEditStu.Size = new System.Drawing.Size(168, 40);
            this.btnEditStu.TabIndex = 0;
            this.btnEditStu.Text = "編輯期別/學員資料";
            this.btnEditStu.UseVisualStyleBackColor = true;
            this.btnEditStu.Click += new System.EventHandler(this.btnEditStu_Click);
            // 
            // btnEditSup
            // 
            this.btnEditSup.Location = new System.Drawing.Point(7, 91);
            this.btnEditSup.Name = "btnEditSup";
            this.btnEditSup.Size = new System.Drawing.Size(168, 40);
            this.btnEditSup.TabIndex = 0;
            this.btnEditSup.Text = "編輯廠商/菜單資料";
            this.btnEditSup.UseVisualStyleBackColor = true;
            this.btnEditSup.Click += new System.EventHandler(this.btnEditSup_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(147, 518);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(168, 40);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "確認訂購";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClassOrderDetail
            // 
            this.btnClassOrderDetail.Location = new System.Drawing.Point(466, 419);
            this.btnClassOrderDetail.Name = "btnClassOrderDetail";
            this.btnClassOrderDetail.Size = new System.Drawing.Size(168, 40);
            this.btnClassOrderDetail.TabIndex = 0;
            this.btnClassOrderDetail.Text = "全班訂購明細";
            this.btnClassOrderDetail.UseVisualStyleBackColor = true;
            this.btnClassOrderDetail.Click += new System.EventHandler(this.btnClassOrderDetail_Click);
            // 
            // cbbChooseSup
            // 
            this.cbbChooseSup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbChooseSup.FormattingEnabled = true;
            this.cbbChooseSup.Location = new System.Drawing.Point(28, 33);
            this.cbbChooseSup.Name = "cbbChooseSup";
            this.cbbChooseSup.Size = new System.Drawing.Size(194, 28);
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
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(27, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 377);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(325, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "數量";
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
            this.btnConfirm.Location = new System.Drawing.Point(242, 32);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(101, 28);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "確認";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblTodaySup
            // 
            this.lblTodaySup.Location = new System.Drawing.Point(39, 68);
            this.lblTodaySup.Name = "lblTodaySup";
            this.lblTodaySup.Size = new System.Drawing.Size(344, 27);
            this.lblTodaySup.TabIndex = 0;
            this.lblTodaySup.Text = "今天的供應商: ";
            this.lblTodaySup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTodaySup.Visible = false;
            // 
            // pnSetting
            // 
            this.pnSetting.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnSetting.Controls.Add(this.btnEditSup);
            this.pnSetting.Controls.Add(this.btnEditStu);
            this.pnSetting.Location = new System.Drawing.Point(459, 54);
            this.pnSetting.Name = "pnSetting";
            this.pnSetting.Size = new System.Drawing.Size(183, 165);
            this.pnSetting.TabIndex = 6;
            this.pnSetting.Visible = false;
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(563, 22);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(79, 33);
            this.btnSetting.TabIndex = 7;
            this.btnSetting.Text = "設置";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "品名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "價格";
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OliveDrab;
            this.ClientSize = new System.Drawing.Size(657, 589);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.pnSetting);
            this.Controls.Add(this.lblTodaySup);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblChooseSup);
            this.Controls.Add(this.cbbChooseSup);
            this.Controls.Add(this.btnClassOrderDetail);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnSubmit);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "訂便當系統";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_main_FormClosed);
            this.Load += new System.EventHandler(this.Form_main_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnSetting.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEditStu;
        private System.Windows.Forms.Button btnEditSup;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClassOrderDetail;
        private System.Windows.Forms.ComboBox cbbChooseSup;
        private System.Windows.Forms.Label lblChooseSup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblTodaySup;
        private System.Windows.Forms.Panel pnSetting;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}