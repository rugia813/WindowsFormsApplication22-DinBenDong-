using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication22_DinBenDong_
{
    public partial class Form_order_detail : Form
    {
        String sqlCon = @"Data Source = (LocalDB)\MSSQLLocalDB;" +
    @"AttachDbFilename=C:\Users\rugia\Desktop\Lunch.mdf;" +
    @"Integrated Security=True;" +
    @"MultipleActiveResultSets=True;" +
    @"User Instance=False;";
        int class_id = 1; // 0 = reception
        HashSet<int> orders = new HashSet<int>();
        
        public Form_order_detail(String sqlCon, int class_id)
        {
            InitializeComponent();
            this.sqlCon = sqlCon;
            this.class_id = class_id;

            this.BackColor = ColorScheme.main;
            tabControl1.TabPages[0].BackColor = ColorScheme.secondary;
            tabControl1.TabPages[1].BackColor = ColorScheme.background;
            flowLayoutPanel1.BackColor = ColorScheme.background;
            treeView1.BackColor = ColorScheme.secondary;
            btnSubmit.BackColor = ColorScheme.main;
            btnX.BackColor = ColorScheme.main;
            btnX.FlatAppearance.BorderColor = ColorScheme.main;
            lblTitle.BackColor = ColorScheme.main;
        }

        private void Form_order_detail_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlCon);
            con.Open();
            SqlDataReader reader = null;
            if (class_id == 0) //Reception
            {
                #region reception
                tabControl1.TabPages.RemoveAt(1);
                timer1.Start();

                #endregion
            }
            else //Class
            {
                #region class
                tabControl1.TabPages.RemoveAt(0);
                try
                {
                    //Supplier & Class Label
                    String conText = "select todaySupplier, name from class where class_id = @class_id";
                    SqlCommand cmd = new SqlCommand(conText, con);
                    cmd.Parameters.AddWithValue("@class_id", class_id);
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblSupplier.Text += (string)reader["todaySupplier"];
                        lblClass.Text += (string)reader["name"];
                        tabControl1.TabPages[0].Text = (string)reader["name"];
                    }

                    //Get All the Type of Items Ordered and Create Root Node
                    conText = "select i.item_name, sum(i.price) as price from orders o join order_detail od on o.order_id = od.order_id " +
                                         "join supplier_items i on i.item_id = od.item_id where o.stu_id in (select stu_id from student where class_id = @class_id) " +
                                         "group by i.item_name";
                    cmd = new SqlCommand(conText, con);
                    cmd.Parameters.AddWithValue("@class_id", class_id);
                    reader = cmd.ExecuteReader();
                    int priceTotal = 0;
                    List<String> itemTypes = new List<string>();
                    while (reader.Read())
                    {
                        treeView1.Nodes.Add((string)reader["item_name"]); // + "-------------------($" + reader["price"] + ") ");
                        itemTypes.Add((string)reader["item_name"]);
                        priceTotal += (int)reader["price"];
                    }
                    lblTotal.Text += "$ " + priceTotal;

                    //Get Names and Prices of Each Type and Create Sub Nodes
                    foreach (TreeNode n in treeView1.Nodes)
                    {
                        conText = "select s.name, i.item_name, i.price from student s join class c on s.class_id = c.class_id " +
                                         "join orders o on o.stu_id = s.stu_id join order_detail od on o.order_id = od.order_id " +
                                         "join supplier_items i on i.item_id = od.item_id " +
                                         "where c.class_id = @class_id and i.item_name = @item_name";
                        cmd = new SqlCommand(conText, con);
                        cmd.Parameters.AddWithValue("@class_id", class_id);
                        cmd.Parameters.AddWithValue("@item_name", n.Text);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            n.Nodes.Add((string)reader["name"] + "(" + (string)reader["item_name"] + ")  $" + reader["price"]);
                        }
                        treeView1.ExpandAll();

                        //Hide sumbit button if already submitted
                        conText = "select submit from class where class_id = @class_id";
                        cmd = new SqlCommand(conText, con);
                        cmd.Parameters.AddWithValue("@class_id", class_id);
                        if (cmd.ExecuteScalar() != DBNull.Value)//if submitted
                        {
                            btnSubmit.Enabled = false;
                            btnSubmit.Text = "已送出";
                        }
                    }
                    
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }finally
                {
                    reader.Close();
                    con.Close();
                }
                #endregion
            }            
        }

        //make treeView item red and crossedout
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent!=null)
            {
                if (e.Node.Checked)
                {
                    e.Node.NodeFont = new Font("微軟正黑體", 16, FontStyle.Regular);
                    e.Node.ForeColor = Color.Black;
                    e.Node.Checked = false;
                }
                else
                {
                    e.Node.NodeFont = new Font("微軟正黑體", 16, FontStyle.Strikeout);
                    e.Node.ForeColor = Color.Red;
                    e.Node.Checked = true;
                }
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlCon);
            con.Open();
            SqlDataReader reader = null;
            try
            {                
                String conText = "select class_id, name, submit from class";
                SqlCommand cmd = new SqlCommand(conText, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["submit"] != DBNull.Value)//if submit != null
                    {
                        if (orders.Add((int)reader["class_id"]))
                        {
                            lblNoOrder.Visible = false;
                            Button orderItem = new Button();
                            orderItem.Name = reader["class_id"].ToString();
                            orderItem.Size = new Size(flowLayoutPanel1.Width/3-10, 150);
                            orderItem.TextAlign = ContentAlignment.MiddleCenter;
                            orderItem.Text = (string)reader["name"];
                            orderItem.BackColor = ColorScheme.main;
                            orderItem.Click += OrderItem_Click;
                            orderItem.FlatStyle = FlatStyle.Flat;
                            flowLayoutPanel1.Controls.Add(orderItem);
                            notifyIcon1.Icon = this.Icon;
                            notifyIcon1.ShowBalloonTip(7000, "新訂單", (string)reader["name"] + "訂單已收到!", ToolTipIcon.Info);
                            FlashWindow(this.Handle, true);
                        }
                   
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                reader.Close();
                con.Close();
            }
        }
        //blink taskbar button
        [DllImport("user32.dll")]
        static extern bool FlashWindow(IntPtr hwnd, bool bInvert);
            
        private void OrderItem_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            TabPage page = new TabPage(btn.Text);
            page.BackColor = ColorScheme.secondary;

            TreeView tree = new TreeView();
            tree.BackColor = ColorScheme.background;
            tree.Font = new System.Drawing.Font("微軟正黑體", 16F);
            tree.HotTracking = true;
            tree.ItemHeight = 26;
            tree.Location = new System.Drawing.Point(125, 63);
            tree.Size = new System.Drawing.Size(606, 575);

            page.Controls.Add(tree);
            tabControl1.TabPages.Add(page);

            Button btnDestroy = new Button();
            btnDestroy.Location = new System.Drawing.Point(523, 653);
            btnDestroy.Name += btn.Name;
            btnDestroy.Size = new System.Drawing.Size(207, 39);
            btnDestroy.Text = "訂單完成";
            btnDestroy.UseVisualStyleBackColor = true;
            btnDestroy.BackColor = ColorScheme.main;
            btnDestroy.Click += BtnDestroy_Click;
            btnDestroy.FlatStyle = FlatStyle.Flat;
            page.Controls.Add(btnDestroy);

            #region treeView data
            SqlConnection con = new SqlConnection(sqlCon);
            con.Open();
            SqlDataReader reader = null;
            try
            {
                //Supplier & Class Label
                String conText = "select c.todaySupplier, c.name, s.tel from class c join supplier s on c.todaysupplier = s.name where c.class_id = @class_id";
                SqlCommand cmd = new SqlCommand(conText, con);
                cmd.Parameters.AddWithValue("@class_id", btn.Name);
                reader = cmd.ExecuteReader();
                Label lblT = new Label();
                if (reader.Read())
                {
                    Label lblSup = new Label();
                    lblSup.Text = "廠商: " + (string)reader["todaySupplier"];
                    lblSup.Location = new System.Drawing.Point(418, 0);
                    lblSup.Size = new System.Drawing.Size(313, 35);
                    lblSup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                    Label lblTel = new Label();
                    if (reader["tel"] != DBNull.Value)
                    lblTel.Text = "電話: " + (string)reader["tel"];
                    lblTel.Location = new System.Drawing.Point(418, 30);
                    lblTel.Size = new System.Drawing.Size(313, 39);
                    lblTel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                    Label lblC = new Label();
                    lblC.Text = "班級: " + (string)reader["name"];
                    lblC.Location = new System.Drawing.Point(121, 30);
                    lblC.Size = new System.Drawing.Size(291, 39);
                    lblC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                                        
                    lblT.Font = new System.Drawing.Font("微軟正黑體", 16F);
                    lblT.Location = new System.Drawing.Point(121, 654);
                    lblT.Size = new System.Drawing.Size(313, 39);
                    lblT.Text = "總額: ";
                    lblT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                    page.Controls.Add(lblSup);
                    page.Controls.Add(lblC);
                    page.Controls.Add(lblT);
                    page.Controls.Add(lblTel);
                }

                //Get All the Type of Items Ordered and Create Root Node
                conText = "select i.item_name, sum(od.qty) as qty, sum(i.price) as price from orders o join order_detail od on o.order_id = od.order_id " +
                                     "join supplier_items i on i.item_id = od.item_id where o.stu_id in (select stu_id from student where class_id = @class_id) " +
                                     "group by i.item_name";
                cmd = new SqlCommand(conText, con);
                cmd.Parameters.AddWithValue("@class_id", btn.Name);
                reader = cmd.ExecuteReader();
                int priceTotal = 0;
                List<String> itemTypes = new List<string>();
                while (reader.Read())
                {
                    tree.Nodes.Add((string)reader["item_name"] + " x " + reader["qty"] + "-------------------($" + reader["price"] + ") ");
                    itemTypes.Add((string)reader["item_name"]);
                    priceTotal += (int)reader["price"];
                }
                lblT.Text += "$ " + priceTotal;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                reader.Close();
                con.Close();
            }
            #endregion




            flowLayoutPanel1.Controls.Remove(btn);
        }

        //Destroy order
        private void BtnDestroy_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DialogResult dr = RmsgBox.Show("確認訂單是否已下訂完成?\n按下\"確定\"此訂單將被刪除！", "警告", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);

                SqlConnection con = new SqlConnection(sqlCon);
                con.Open();
                SqlDataReader reader = null;
                try
                {
                    //delete order details
                    string strSQL = "delete from order_detail where order_id in (select order_id from orders where stu_id in (select stu_id from student where class_id = @class_id))";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@class_id", btn.Name);
                    cmd.ExecuteNonQuery();

                    //delete orders
                    strSQL = "delete from orders where stu_id in (select stu_id from student where class_id = @class_id)";
                    cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@class_id", btn.Name);
                    cmd.ExecuteNonQuery();

                    //Nullify todaySupplier & submit
                    strSQL = "update class set todaySupplier = null, submit = null where class_id = @class_id";
                    cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@class_id", btn.Name);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    if(reader!=null)
                    reader.Close();
                    con.Close();
                }
            }          
        }

        //Student submit order
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlCon);
            con.Open();
            SqlDataReader reader = null;

            try
            {
                //submit
                String conText = "update class set submit = 1 where class_id = @class_id";
                SqlCommand cmd = new SqlCommand(conText, con);
                cmd.Parameters.AddWithValue("@class_id", class_id);
                reader = cmd.ExecuteReader();

                btnSubmit.Enabled = false;
                btnSubmit.Text = "已送出";       
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                reader.Close();
                con.Close();
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void Form_order_detail_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon1.Dispose();
        }
    }
}
