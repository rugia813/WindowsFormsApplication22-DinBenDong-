namespace WindowsFormsApplication22_DinBenDong_
{
    partial class Form_order_detail
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_order_detail));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblNoOrder = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnX = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lbClass = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.treeHisDetail = new System.Windows.Forms.TreeView();
            this.lblGrandtotal = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.treeView1.CheckBoxes = true;
            this.treeView1.Font = new System.Drawing.Font("微軟正黑體", 16F);
            this.treeView1.HotTracking = true;
            this.treeView1.ItemHeight = 26;
            this.treeView1.Location = new System.Drawing.Point(125, 63);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(606, 575);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(856, 742);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.YellowGreen;
            this.tabPage1.Controls.Add(this.lblNoOrder);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(848, 709);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Reception";
            // 
            // lblNoOrder
            // 
            this.lblNoOrder.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lblNoOrder.Font = new System.Drawing.Font("微軟正黑體", 16F);
            this.lblNoOrder.Location = new System.Drawing.Point(353, 338);
            this.lblNoOrder.Name = "lblNoOrder";
            this.lblNoOrder.Size = new System.Drawing.Size(186, 35);
            this.lblNoOrder.TabIndex = 1;
            this.lblNoOrder.Text = "目前尚無訂單";
            this.lblNoOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 16F);
            this.label1.Location = new System.Drawing.Point(132, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "今日訂單:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(136, 106);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(577, 592);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.YellowGreen;
            this.tabPage2.Controls.Add(this.btnSubmit);
            this.tabPage2.Controls.Add(this.lblGrandtotal);
            this.tabPage2.Controls.Add(this.lblTotal);
            this.tabPage2.Controls.Add(this.lblSupplier);
            this.tabPage2.Controls.Add(this.lblClass);
            this.tabPage2.Controls.Add(this.treeView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(848, 709);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Class";
            // 
            // btnSubmit
            // 
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Location = new System.Drawing.Point(523, 653);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(207, 39);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "訂單確認";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("微軟正黑體", 16F);
            this.lblTotal.Location = new System.Drawing.Point(121, 654);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(163, 39);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "總額: ";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSupplier
            // 
            this.lblSupplier.Location = new System.Drawing.Point(418, 21);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(313, 39);
            this.lblSupplier.TabIndex = 1;
            this.lblSupplier.Text = "廠商: ";
            this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblClass
            // 
            this.lblClass.Location = new System.Drawing.Point(121, 21);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(291, 39);
            this.lblClass.TabIndex = 1;
            this.lblClass.Text = "班級: ";
            this.lblClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.Color.Green;
            this.btnX.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnX.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.Font = new System.Drawing.Font("微軟正黑體", 16F);
            this.btnX.Location = new System.Drawing.Point(824, -4);
            this.btnX.Margin = new System.Windows.Forms.Padding(0);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(38, 35);
            this.btnX.TabIndex = 8;
            this.btnX.Text = "×";
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(2, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(278, 20);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "訂單確認  ||  DinBenDong 訂便當系統";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "hgfhf";
            this.notifyIcon1.BalloonTipTitle = "hfgh";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "新訂單";
            this.notifyIcon1.Visible = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.LightGray;
            this.tabPage3.Controls.Add(this.treeHisDetail);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.lbClass);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(848, 709);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "歷史紀錄";
            // 
            // lbClass
            // 
            this.lbClass.FormattingEnabled = true;
            this.lbClass.ItemHeight = 20;
            this.lbClass.Location = new System.Drawing.Point(37, 61);
            this.lbClass.Name = "lbClass";
            this.lbClass.Size = new System.Drawing.Size(206, 564);
            this.lbClass.TabIndex = 0;
            this.lbClass.SelectedIndexChanged += new System.EventHandler(this.lbClass_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "班級";
            // 
            // treeHisDetail
            // 
            this.treeHisDetail.Location = new System.Drawing.Point(265, 61);
            this.treeHisDetail.Name = "treeHisDetail";
            this.treeHisDetail.Size = new System.Drawing.Size(552, 563);
            this.treeHisDetail.TabIndex = 2;
            // 
            // lblGrandtotal
            // 
            this.lblGrandtotal.Font = new System.Drawing.Font("微軟正黑體", 16F);
            this.lblGrandtotal.Location = new System.Drawing.Point(290, 654);
            this.lblGrandtotal.Name = "lblGrandtotal";
            this.lblGrandtotal.Size = new System.Drawing.Size(163, 39);
            this.lblGrandtotal.TabIndex = 1;
            this.lblGrandtotal.Text = "總量: ";
            this.lblGrandtotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form_order_detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(862, 788);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnX);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form_order_detail";
            this.Text = "訂單檢視";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_order_detail_FormClosed);
            this.Load += new System.EventHandler(this.Form_order_detail_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblNoOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TreeView treeHisDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbClass;
        private System.Windows.Forms.Label lblGrandtotal;
    }
}