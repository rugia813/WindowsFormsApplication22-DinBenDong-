namespace WindowsFormsApplication22_DinBenDong_
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.ckb_onDuty = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbClass = new System.Windows.Forms.ComboBox();
            this.cbbName = new System.Windows.Forms.ComboBox();
            this.btnReceptionLogin = new System.Windows.Forms.Button();
            this.btnX = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnStuLogin = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pbReceptionLogin = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnStuLogin.SuspendLayout();
            this.pbReceptionLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Image = global::WindowsFormsApplication22_DinBenDong_.Properties.Resources.logo;
            this.label1.Location = new System.Drawing.Point(67, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(523, 148);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "姓名:";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(66, 199);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(179, 38);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登入";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // ckb_onDuty
            // 
            this.ckb_onDuty.AutoSize = true;
            this.ckb_onDuty.BackColor = System.Drawing.Color.GhostWhite;
            this.ckb_onDuty.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ckb_onDuty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ckb_onDuty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ckb_onDuty.Location = new System.Drawing.Point(94, 159);
            this.ckb_onDuty.Name = "ckb_onDuty";
            this.ckb_onDuty.Size = new System.Drawing.Size(73, 24);
            this.ckb_onDuty.TabIndex = 4;
            this.ckb_onDuty.Text = "值日生";
            this.ckb_onDuty.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "期別:";
            // 
            // cbbClass
            // 
            this.cbbClass.BackColor = System.Drawing.Color.LightGray;
            this.cbbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbClass.FormattingEnabled = true;
            this.cbbClass.Location = new System.Drawing.Point(113, 60);
            this.cbbClass.Name = "cbbClass";
            this.cbbClass.Size = new System.Drawing.Size(121, 28);
            this.cbbClass.TabIndex = 5;
            this.cbbClass.SelectedIndexChanged += new System.EventHandler(this.cbbClass_SelectedIndexChanged);
            // 
            // cbbName
            // 
            this.cbbName.BackColor = System.Drawing.Color.LightGray;
            this.cbbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbName.FormattingEnabled = true;
            this.cbbName.Location = new System.Drawing.Point(113, 110);
            this.cbbName.Name = "cbbName";
            this.cbbName.Size = new System.Drawing.Size(121, 28);
            this.cbbName.TabIndex = 5;
            // 
            // btnReceptionLogin
            // 
            this.btnReceptionLogin.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnReceptionLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReceptionLogin.Location = new System.Drawing.Point(51, 153);
            this.btnReceptionLogin.Name = "btnReceptionLogin";
            this.btnReceptionLogin.Size = new System.Drawing.Size(179, 40);
            this.btnReceptionLogin.TabIndex = 6;
            this.btnReceptionLogin.Text = "登入";
            this.btnReceptionLogin.UseVisualStyleBackColor = false;
            this.btnReceptionLogin.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnX.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnX.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.Font = new System.Drawing.Font("微軟正黑體", 16F);
            this.btnX.Location = new System.Drawing.Point(627, -8);
            this.btnX.Margin = new System.Windows.Forms.Padding(0);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(38, 35);
            this.btnX.TabIndex = 7;
            this.btnX.Text = "×";
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblTitle.Location = new System.Drawing.Point(10, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(246, 20);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "登入  ||  DinBenDong 訂便當系統";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnStuLogin
            // 
            this.pnStuLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnStuLogin.Controls.Add(this.cbbName);
            this.pnStuLogin.Controls.Add(this.label5);
            this.pnStuLogin.Controls.Add(this.cbbClass);
            this.pnStuLogin.Controls.Add(this.ckb_onDuty);
            this.pnStuLogin.Controls.Add(this.btnLogin);
            this.pnStuLogin.Controls.Add(this.label3);
            this.pnStuLogin.Controls.Add(this.label2);
            this.pnStuLogin.Location = new System.Drawing.Point(344, 232);
            this.pnStuLogin.Name = "pnStuLogin";
            this.pnStuLogin.Size = new System.Drawing.Size(308, 303);
            this.pnStuLogin.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 20F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(90, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 35);
            this.label5.TabIndex = 8;
            this.label5.Text = "學員登入";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbReceptionLogin
            // 
            this.pbReceptionLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbReceptionLogin.Controls.Add(this.btnReceptionLogin);
            this.pbReceptionLogin.Controls.Add(this.label4);
            this.pbReceptionLogin.Location = new System.Drawing.Point(14, 232);
            this.pbReceptionLogin.Name = "pbReceptionLogin";
            this.pbReceptionLogin.Size = new System.Drawing.Size(304, 302);
            this.pbReceptionLogin.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 20F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(79, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 35);
            this.label4.TabIndex = 8;
            this.label4.Text = "櫃台登入";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.BackgroundImage = global::WindowsFormsApplication22_DinBenDong_.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(664, 611);
            this.Controls.Add(this.pbReceptionLogin);
            this.Controls.Add(this.pnStuLogin);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnX);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "訂便當系統";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnStuLogin.ResumeLayout(false);
            this.pnStuLogin.PerformLayout();
            this.pbReceptionLogin.ResumeLayout(false);
            this.pbReceptionLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox ckb_onDuty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbClass;
        private System.Windows.Forms.ComboBox cbbName;
        private System.Windows.Forms.Button btnReceptionLogin;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnStuLogin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pbReceptionLogin;
        private System.Windows.Forms.Label label4;
    }
}

