using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication22_DinBenDong_
{
    public partial class Form_main : Form
    {
        //Variables used to store infos get from form1 login
        Form1 form1;
        string user_name = "";
        string class_name = "";
        int student_number;
        int student_id;
        int class_id;
        bool ifOnDuty = false;

        Label lblTotal = new Label();

        List<Button> btnDishes = new List<Button>();
        ArrayList supplierItems = new ArrayList();

        SqlConnectionStringBuilder scsb;
        String sqlCon = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
    @"AttachDbFilename=C:\Users\rugia\Desktop\Lunch.mdf;" +
    @"Integrated Security=True;" +
    @"MultipleActiveResultSets=True;" +
    @"User Instance=False;";

        string todaySup;

        bool ifOrdered;

        bool settingOn = false;

        public Form_main(Form1 f, int stu_id, string loginName, int stu_num, string className, int class_id, bool ifod)
        {
            InitializeComponent();
            //load login info into variables
            form1 = f;
            user_name = loginName;
            class_name = className;
            student_number = stu_num;
            student_id = stu_id;
            this.class_id = class_id;
            ifOnDuty = ifod;
            lblTitle.BackColor = ColorScheme.main;
            btnX.BackColor = ColorScheme.main;
            btnX.FlatAppearance.BorderColor = ColorScheme.main;
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            //Total Price Label
            lblTotal.Name = "lblTotal";
            lblTotal.Location = new Point(242, 510);
            lblTotal.AutoSize = false;
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            lblTotal.Size = new Size(210, 29);
            lblTotal.BackColor = Color.Wheat;
            lblTotal.Visible = false;
            this.Controls.Add(lblTotal);

            //status bar text
            toolStripStatusLabel1.Text = string.Format("使用者:{0} 座號:{2}, 班級: {1}({3})", user_name, class_name, student_number, class_id);

            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "CR3-08";
            scsb.InitialCatalog = "Lunch";
            scsb.IntegratedSecurity = true;    

            //sqlCon = scsb.ToString(); //should comment this out when not in III

            #region//See if today's supplier chosen yet
            SqlConnection con = new SqlConnection(sqlCon);
            con.Open();
            string strSQL = "select todaySupplier from class where class_id = @class_id";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@class_id", class_id);
            SqlDataReader reader = cmd.ExecuteReader();
            
            try
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        var t = reader["todaySupplier"];
                        if (t.GetType() == "string".GetType())
                        {
                            todaySup = (string)t;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                reader.Close();
                con.Close();
            }
            #endregion

            #region//see if this user has already got an order
            try
            {
                con = new SqlConnection(sqlCon);
                con.Open();
                strSQL = "select count(*) from orders where stu_id = @stu_id";
                cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@stu_id", student_id);
                ifOrdered = (int)cmd.ExecuteScalar() != 0 ? true : false;
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                con.Close();
            }

            //if today sup is chosen
            if (todaySup != null)
            {
                cbbChooseSup.Enabled = false;
                btnConfirm.Text = "更改廠商";
                if (!ifOrdered) //not yet ordered
                {
                    showItems();
                }
                else //ordered
                {
                    showOrderDetails();
                }                
            }
            else //if today sup is not chosen
            {
                btnSubmit.Enabled = false;
                Console.WriteLine("no sup");
                Label lbl = new Label();
                lbl.Location = new Point(panel1.Size.Width / 2 - 50, panel1.Height / 2 - 50);
                lbl.Size = new Size(200, 200);
                lbl.Text = "還未選擇今日廠商";
                panel1.Controls.Add(lbl);
            }
            #endregion

            #region//if is on duty load supplier names into combobox, if not, hide combobox.
            try
            {
                //get todaySup name
                string todaySup = "";
                con.Open();
                strSQL = "select todaySupplier from class where class_id = @class";
                cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@class", class_id);
                var result = cmd.ExecuteScalar().ToString();
                if (result != null) todaySup = (string)result;

                if (ifOnDuty)// Is On Duty, load sup name into CBB
                {                    
                    strSQL = "select name from supplier";
                    cmd = new SqlCommand(strSQL, con);
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cbbChooseSup.Items.Add(reader["name"]);
                    }

                    cbbChooseSup.SelectedItem = todaySup;
                    reader.Close();
                    con.Close();
                }
                else
                {
                    btnClassOrderDetail.Visible = false;         
                    lblTodaySup.Visible = true;
                    lblTodaySup.Text += todaySup;
                    cbbChooseSup.Visible = false;
                    lblChooseSup.Visible = false;
                    btnConfirm.Visible = false;
                    con.Close();
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                con.Close();
            }
            #endregion
        }

        //Switching Supllier selection
        private void cbbChooseSup_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); //clear existing controls
            btnDishes.Clear();
            supplierItems.Clear();

            if (!ifOrdered)
            {
                //get name and price of each items of this supplier, and make button(name) and Label(price) on panel1
                SqlConnection con = new SqlConnection(sqlCon);
                con.Open();
                string strSQL = "select item_name, price, item_id from supplier_items where sup_id = @sup_id";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@sup_id", cbbChooseSup.SelectedIndex + 1);
                SqlDataReader reader = cmd.ExecuteReader();
                //var items = new[] { new { Name = "", Price = 0 } };
                while (reader.HasRows)
                {
                    int i = 0;
                    buildSupplierItems(reader, i);

                    reader.NextResult();
                }
                reader.Close();
                con.Close();
            }
            else
            {
                showOrderDetails();
            }            
        }

        //Confirm Button
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!ifOrdered) //not yet ordered, use to submit order
            {
                //Check if ordered anything
                foreach (supplier_item i in supplierItems)
                {
                    if(i.tb.Value != 0)
                    {
                        break;
                    }
                    if (i == supplierItems[supplierItems.Count-1])
                    {
                        RmsgBox.Show("並未選取任何物品", "錯誤");
                        return;
                    }
                }
                

                int orderID;

                //Check if TodaySup changed
                SqlConnection con = new SqlConnection(sqlCon);
                con.Open();
                string strSQL = "select todaySupplier from class where class_id = @class_id";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@class_id", class_id);
                String todaySupNew = (string)cmd.ExecuteScalar();
                if (todaySupNew != todaySup) //today sup is different from the data in database
                {
                    RmsgBox.Show("值日生已更換今日供應商，請重新下訂","錯誤");
                    todaySup = todaySupNew;
                    lblTodaySup.Text = "今天的供應商: " + todaySupNew;
                    panel1.Controls.Clear();
                    supplierItems.Clear();
                    lblTotal.Visible = false;
                    ifOrdered = false;
                    showItems();
                    return;
                }

                string output = "您的訂單為:\n\n";
                foreach (supplier_item supItem in supplierItems)
                {
                    if (Convert.ToInt32(supItem.tb.Text) != 0)
                    {
                        output += supItem.btn.Text + " x " + supItem.tb.Text + "\n\n";
                    }
                }
                RmsgBox.Show(output, "下訂成功");

                

                //create order master
                strSQL = "insert into orders values(@stu_id)";
                cmd = new SqlCommand(strSQL, con);
                cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@stu_id", student_id);
                cmd.ExecuteNonQuery();

                //get order id
                strSQL = "select order_id from orders where stu_id = @stu_id";
                cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@stu_id", student_id);
                orderID = (int)cmd.ExecuteScalar();

                //insert order items
                foreach (supplier_item supItem in supplierItems)
                {
                    if (Convert.ToInt32(supItem.tb.Text) != 0)
                    {
                        strSQL = "insert into order_detail values(@order_id, @qty, @item_id)";
                        cmd = new SqlCommand(strSQL, con);
                        cmd.Parameters.AddWithValue("@order_id", orderID);
                        cmd.Parameters.AddWithValue("@qty", supItem.tb.Value);
                        cmd.Parameters.AddWithValue("@item_id", supItem.item_id);
                        cmd.ExecuteNonQuery();
                    }
                }
                con.Close();

                //show detail page
                panel1.Controls.Clear();
                showOrderDetails();
                ifOrdered = true;
            }
            else //Already ordered, use to cancel order
            {
                panel1.Controls.Clear();
                supplierItems.Clear();
                lblTotal.Visible = false;
                ifOrdered = false;
                showItems();

                //Delete orders
                SqlConnection con = new SqlConnection(sqlCon);
                con.Open();
                //delete order details
                string strSQL = "delete from order_detail where order_id in (select order_id from orders where stu_id = @stu_id)";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@stu_id", student_id);
                cmd.ExecuteNonQuery();

                //delete orders
                strSQL = "delete from orders where stu_id = @stu_id";
                cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@stu_id", student_id);
                cmd.ExecuteNonQuery();                
            }            
        }

        //button confirm supplier
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlCon);
            try
            {
                if (todaySup == null)//Choose Sup
                {                    
                    try
                    {
                        con.Open();
                        string strSQL = "update class set todaySupplier = @sup_name where class_id = @class_id";
                        SqlCommand cmd = new SqlCommand(strSQL, con);
                        cmd.Parameters.AddWithValue("@sup_name", cbbChooseSup.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@class_id", class_id);
                        cmd.ExecuteNonQuery();

                        todaySup = cbbChooseSup.SelectedItem.ToString();
                        Console.WriteLine(cbbChooseSup.SelectedItem);
                        btnConfirm.Text = "更改廠商";
                        cbbChooseSup.Enabled = false;
                        btnSubmit.Enabled = true;
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex);
                        RmsgBox.Show("請選擇供應商", "錯誤");
                    }
                }
                else//Change Sup
                {
                    //DialogResult dr = MessageBox.Show("是否更改供應商? 已下定訂單將被刪除", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    DialogResult dr = RmsgBox.Show("是否更改供應商? 已下定訂單將被刪除", "警告", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        ifOrdered = false;
                        todaySup = null;
                        btnConfirm.Text = "選擇";
                        cbbChooseSup.Enabled = true;
                        cbbChooseSup.SelectedIndex = 0;
                        //get name and price of each items of this supplier, and make button(name) and Label(price) on panel1
                        panel1.Controls.Clear(); //clear existing controls
                        btnDishes.Clear();
                        supplierItems.Clear();
                        btnSubmit.Text = "確認訂購";
                        btnSubmit.Enabled = false;
                        lblTotal.Visible = false;
                        con = new SqlConnection(sqlCon);
                        con.Open();
                        string strSQL = "select item_name, price, item_id from supplier_items where sup_id = @sup_id";
                        SqlCommand cmd = new SqlCommand(strSQL, con);
                        cmd.Parameters.AddWithValue("@sup_id", cbbChooseSup.SelectedIndex + 1);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.HasRows)
                        {
                            int i = 0;
                            buildSupplierItems(reader, i);

                            reader.NextResult();
                        }
                        reader.Close();
                        con.Close();

                        con.Open();
                        //delete order details
                        strSQL = "delete from order_detail where order_id in (select order_id from orders where stu_id in (select stu_id from student where class_id = @class_id))";
                        cmd = new SqlCommand(strSQL, con);
                        cmd.Parameters.AddWithValue("@class_id", class_id);
                        cmd.ExecuteNonQuery();

                        //delete orders
                        strSQL = "delete from orders where stu_id in (select stu_id from student where class_id = @class_id)";
                        cmd = new SqlCommand(strSQL, con);
                        cmd.Parameters.AddWithValue("@class_id", class_id);
                        cmd.ExecuteNonQuery();
                    }                    
                }
            }
            finally
            {
                con.Close();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //log out, kill this form and show form1
            form1.Show();
            this.Hide();
        }

        #region methods, button_clicks
        private void item_name_right_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Button btn = (Button)sender;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (me.X > btn.Location.X && me.X < btn.Location.X + btn.Size.Width)
                {
                    if (panel1.Controls[btn.TabIndex + 2].Text != "" && panel1.Controls[btn.TabIndex + 2].Text != "0")
                    {
                        panel1.Controls[btn.TabIndex + 2].Text = (Int16.Parse(panel1.Controls[btn.TabIndex + 2].Text) - 1).ToString();
                    }
                }

            }
            if (me.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (me.X > btn.Location.X && me.X < btn.Location.X + btn.Size.Width)
                {
                    if (panel1.Controls[btn.TabIndex + 2].Text == "")
                    {
                        panel1.Controls[btn.TabIndex + 2].Text = "1";
                    }
                    else
                    {
                        panel1.Controls[btn.TabIndex + 2].Text = (Int16.Parse(panel1.Controls[btn.TabIndex + 2].Text) + 1).ToString();
                    }
                }
            }
        }

        private void Form_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            form1.Close(); //make sure form1 also close when this one do
        }

        class supplier_item
        {
            public Button btn { get; set; }
            public Label lbl { get; set; }
            public NumericUpDown tb { get; set; }
            public int item_id { get; set; }
            public supplier_item(Button btn, Label lbl, NumericUpDown tb, int item_id)
            {
                this.btn = btn;
                this.lbl = lbl;
                this.tb = tb;
                this.item_id = item_id;
            }
        }
        private void buildSupplierItems(SqlDataReader rd, int counter)
        {
            SqlDataReader reader = rd;
            int i = counter;
            while (reader.Read())
            {
                Button btn = new Button();
                btn.Text = reader.GetString(0);
                btn.Location = new Point(17, 24 + i);
                btn.Size = new Size(160, 30);
                btn.MouseUp += item_name_right_Click;
                btnDishes.Add(btn);
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = ColorScheme.main;
                toolTip1.SetToolTip(btn, "點擊滑鼠左鍵 + 1、滑鼠右鍵 - 1");
                panel1.Controls.Add(btn);

                Label lbl = new Label();
                lbl.AutoSize = false;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Text = reader.GetInt32(1).ToString();
                lbl.Location = new Point(210, 24 + i);
                lbl.Size = new Size(47, 29);
                panel1.Controls.Add(lbl);

                NumericUpDown tb = new NumericUpDown();
                tb.Increment = 1;
                tb.Location = new Point(300, 24 + i);
                tb.Size = new Size(46, 29);
                tb.Text = "0";
                panel1.Controls.Add(tb);
                i += 35;

                supplierItems.Add(new supplier_item(btn, lbl, tb, (int)reader["item_id"]));
            }
        }

        //open supplier edit page
        private void btnEditSup_Click(object sender, EventArgs e)
        {
            Form_supplier formSup = new Form_supplier(sqlCon);
            formSup.ShowDialog();
        }

        //button edit students
        private void btnEditStu_Click(object sender, EventArgs e)
        {
            Form_student formStu = new Form_student(sqlCon);
            formStu.ShowDialog();
        }

        //Setting button
        private void btnSetting_Click(object sender, EventArgs e)
        {
            if (!settingOn)//if btn off
            {
                pnSetting.Visible = true;
                settingOn = true;
            }
            else
            {
                pnSetting.Visible = false;
                settingOn = false;
            }
        }
        
        private void showOrderDetails()
        {
            btnSubmit.Text = "取消訂單";
            //Show personal order details
            SqlConnection con = new SqlConnection(sqlCon);            
            try
            {       
                con.Open();
                string strSQL = "select i.item_name, i.price, od.qty from order_detail od join orders o on od.order_id = o.order_id " +
                    "join student s on o.stu_id = s.stu_id join supplier_items i on od.item_id = i.item_id where s.stu_id = @stu_id";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@stu_id", student_id);
                SqlDataReader reader = cmd.ExecuteReader();

                int i = 0;
                int totalPrice = 0;
                while (reader.HasRows) //Print Order Details on Panel1
                {
                    while (reader.Read())
                    {
                        Label lblItem = new Label();
                        lblItem.Text = (string)reader["item_name"];
                        lblItem.Location = new Point(17, 24 + i);
                        lblItem.AutoSize = false;
                        lblItem.TextAlign = ContentAlignment.MiddleCenter;
                        lblItem.Size = new Size(200, 29);
                        panel1.Controls.Add(lblItem);

                        Label lblPrice = new Label();
                        lblPrice.Text = reader["price"].ToString();
                        totalPrice += (int)reader["price"];
                        lblPrice.Location = new Point(210, 24 + i);
                        lblPrice.AutoSize = false;
                        lblPrice.TextAlign = ContentAlignment.MiddleCenter;
                        lblPrice.Size = new Size(47, 29);
                        panel1.Controls.Add(lblPrice);

                        Label lblQty = new Label();
                        lblQty.Text = reader["qty"].ToString();
                        lblQty.Location = new Point(300, 24 + i);
                        lblQty.AutoSize = false;
                        lblQty.TextAlign = ContentAlignment.MiddleCenter;
                        lblQty.Size = new Size(47, 29);
                        panel1.Controls.Add(lblQty);

                        i += 35;
                    }
                    reader.NextResult();
                }
                //Total Price Label
                lblTotal.Text = "總價:         " + totalPrice.ToString();
                lblTotal.Visible = true;

                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }            
        }

        private void showItems()
        {
            btnSubmit.Text = "確認訂購";
            try
            {
                SqlConnection con = new SqlConnection(sqlCon);
                //get name and price of each items of this supplier, and make button(name) and Label(price) on panel1
                con.Open();
                String strSQL = "select i.item_name, i.price, i.item_id from supplier s join supplier_items i on s.sup_id = i.sup_id where s.name = @sup_name";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@sup_name", todaySup);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.HasRows)
                {
                    int i = 0;
                    buildSupplierItems(reader, i);
                    reader.NextResult();
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        #endregion

        //Class Order Detail Item
        private void btnClassOrderDetail_Click(object sender, EventArgs e)
        {
            Form_order_detail form = new Form_order_detail(sqlCon, class_id);
            form.ShowDialog(this);
        }
        protected override void WndProc(ref Message m)  //make the form draggable
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
