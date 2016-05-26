using System;
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
    public partial class Form_order_detail : Form
    {
        String sqlCon = @"Data Source = (LocalDB)\MSSQLLocalDB;" +
    @"AttachDbFilename=C:\Users\rugia\Desktop\Lunch.mdf;" +
    @"Integrated Security=True;" +
    @"MultipleActiveResultSets=True;" +
    @"User Instance=False;";
        int class_id = 1;

        public Form_order_detail(String sqlCon, int class_id)
        {
            InitializeComponent();
            this.sqlCon = sqlCon;
            this.class_id = class_id;
        }

        private void Form_order_detail_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlCon);
            con.Open();
            SqlDataReader reader = null;
            if (class_id == 0) //Reception
            {

            }
            else //Class
            {
                tabControl1.TabPages.RemoveAt(0);
                try
                {
                    /* String conText = "select * from student s join class c on s.class_id = c.class_id " +
                                         "join orders o on o.stu_id = s.stu_id join order_detail od on o.order_id = od.order_id " +
                                         "join supplier_items i on i.item_id = od.item_id";*/

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

            }           

        }

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
    }
}
