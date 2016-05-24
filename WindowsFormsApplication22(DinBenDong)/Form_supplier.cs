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
    public partial class Form_supplier : Form
    {
        string sqlCon = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
    @"AttachDbFilename=C:\Users\rugia\Desktop\Lunch.mdf;" +
    @"Integrated Security=True;" +
    @"MultipleActiveResultSets=True;" +
    @"User Instance=False;";
        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
        List<supplierItem> supplierItems = new List<supplierItem>();

        DataSet DsSupplier = new DataSet();
        SqlDataAdapter DaSupplier;
        SqlDataAdapter DasupItem;

        int SupplierID = 0;
        List<String> tempItemPrice = new List<String>();
        List<String> tempItemName = new List<string>();

        public Form_supplier(SqlConnectionStringBuilder scsb)
        {
            InitializeComponent();
            this.scsb = scsb;
        }

        private void Form_supplier_Load(object sender, EventArgs e)
        {
            //sqlCon = scsb.ToString();
            SqlConnection con = new SqlConnection(sqlCon);
            DasupItem = new SqlDataAdapter("select * from supplier_items", con);
            DaSupplier = new SqlDataAdapter("select * from supplier", con);
            //con = new SqlConnection(scsb.ToString());

            //Load class names
            DaSupplier.Fill(DsSupplier, "supplier");
            DasupItem.Fill(DsSupplier, "supplier_items");
            foreach (DataRow row in DsSupplier.Tables["supplier"].Rows)
            {
                cbbSuppliers.Items.Add(row["name"]);
            }
            cbbSuppliers.SelectedIndex = 0;
        }

        //save items
        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlCon);
            con.Open();
            int i = 0;

            SqlCommand cmd = new SqlCommand("update supplier set tel = @tel where sup_id = @sup_id", con);
            cmd.Parameters.AddWithValue("@tel", tbTel.Text);
            cmd.Parameters.AddWithValue("@sup_id", SupplierID);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();

            foreach (supplierItem item in supplierItems)
            {
                try
                {
                    bool ifModified = false;
                    //Console.WriteLine(tempItemName[i]);   
                    /*                 
                    foreach (string o in tempItemName)
                    {
                        if (item.name.Text == o.ToString())
                        {
                            Console.WriteLine(item.name.Text + " should be modified");
                            ifModified = true;
                            break;
                        }
                    }
                    */
                    if (i < tempItemName.Count())
                    {
                        Console.WriteLine(tempItemName[i] + " should be modified");
                        ifModified = true;
                    }
                    if (ifModified) //if this item should be modified
                    {
                        if (item.name.Text != "") //update
                        {
                            Console.WriteLine("updating " + item.name.Text);
                            cmd = new SqlCommand("update supplier_items set item_name = @name, price = @price where sup_id = @sup_id AND item_name = @OldName", con);
                            cmd.Parameters.AddWithValue("@name", item.name.Text);
                            cmd.Parameters.AddWithValue("@OldName", tempItemName[i]);
                            cmd.Parameters.AddWithValue("@sup_id", SupplierID);
                            cmd.Parameters.AddWithValue("@price", item.price.Text);
                            reader = cmd.ExecuteReader();
                            reader.Close();
                        }
                        else //delete
                        {
                            Console.WriteLine("deleting" + item.name.Text);
                            cmd = new SqlCommand("delete from supplier_items where sup_id = @sup_id AND item_name = @name", con);
                            cmd.Parameters.AddWithValue("@sup_id", SupplierID);
                            cmd.Parameters.AddWithValue("@name", tempItemName[i]);
                            reader = cmd.ExecuteReader();
                            reader.Close();

                        }
                    }
                    else // should be inserted
                    {
                        if (item.name.Text != "")
                        {
                            Console.WriteLine("inserting " + item.name.Text);
                            cmd = new SqlCommand("insert into supplier_items values(@sup_id, @name, @price)", con);
                            cmd.Parameters.AddWithValue("@name", item.name.Text);
                            cmd.Parameters.AddWithValue("@sup_id", SupplierID);
                            cmd.Parameters.AddWithValue("@price", item.price.Text);
                            reader = cmd.ExecuteReader();
                            reader.Close();
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                i++;
            }

            con.Close();
            DsSupplier = new DataSet();
            DaSupplier.Fill(DsSupplier, "supplier");
            DasupItem.Fill(DsSupplier, "supplier_items");

            MessageBox.Show(this, "已儲存變更", "儲存");
        }

        private void cbbSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            supplierItems.Clear();
            tbTel.Text = "";
            tempItemPrice = new List<String>();
            tempItemName = new List<string>();

            //check if supplier name contains ' , if so, make it '' to avoid crashing in sql
            string s = cbbSuppliers.SelectedItem.ToString();
            string r = "";
            string supName = s;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i]==0x0027)// 0x0027 = '
                {
                    for (int o = 0; o < s.Length; o++)
                    {
                        r+= s[o];
                        if (o==i)
                        {
                            r += "'";
                        }
                    }
                    supName = r;
                }
            }
            try
            {
                SupplierID = (int)DsSupplier.Tables["supplier"].Select("name = '" + supName + "'").First()["sup_id"];
                foreach (DataRow row in DsSupplier.Tables["supplier_items"].Select("sup_id = '" + SupplierID + "'"))
                {
                    tempItemPrice.Add(row["price"].ToString());
                    tempItemName.Add((string)row["item_name"]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            int max = 0;
            if (tempItemPrice.Count > 0)
            {
                max = tempItemPrice.Count();
            }
            buildColumns((max / 5 + 1) * 5);
            if (tempItemPrice.Count > 0) //fill in data to form
            {
                for (int i = 0; i < tempItemPrice.Count; i++)
                {
                    supplierItems[i].name.Text = tempItemName[i];
                    supplierItems[i].price.Text = tempItemPrice[i];
                }
            }
            try
            {
                tbTel.Text = (string)DsSupplier.Tables["supplier"].Select("sup_id =" + SupplierID).First()["tel"];
            }
            catch (Exception)
            {
                Console.WriteLine("Tel is empty");
            }          

            Button btnAdd = new Button();
            btnAdd.Location = new Point(24, 14 + panel1.Controls.Count/2 * 40);
            btnAdd.Text = "更多";
            btnAdd.Size = new Size(110, 25);
            btnAdd.BackColor = default(Color);
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            panel1.Controls.Add(btnAdd);
        }
        private void buildColumns(int numRow)
        {
            for (int i = 0; i < numRow; i++)
            {
                int x = 24;

                TextBox name = new TextBox();
                name.Font = new Font("微軟正黑體", 10);
                name.Size = new Size(227, 29);
                name.Location = new Point(x, 14 + i * 40);

                TextBox price = new TextBox();
                price.Font = new Font("微軟正黑體", 10);
                price.Location = new Point(x + 251, 14 + i * 40);
                price.Size = new Size(54, 29);

                panel1.Controls.Add(name);
                panel1.Controls.Add(price);
                supplierItems.Add(new supplierItem(name, price));
            }
        }
        class supplierItem
        {
            public TextBox name { get; set; }
            public TextBox price { get; set; }
            public supplierItem(TextBox name, TextBox price)
            {
                this.price = price;
                this.name = name;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<string> tempPrice = new List<string>();
            List<string> tempName = new List<string>();

            foreach (supplierItem item in supplierItems)
            {
                if (item.name.Text != "")
                {
                    tempPrice.Add(item.price.Text);
                    tempName.Add(item.name.Text);
                }
            }

            panel1.Controls.RemoveAt(panel1.Controls.Count - 1);//remove add button
            int panelControlsCount = panel1.Controls.Count / 2;//how many buttons
            panel1.Controls.Clear();
            supplierItems.Clear();

            buildColumns(panelControlsCount + 3);
            for (int i = 0; i < tempPrice.Count; i++)
            {
                supplierItems[i].name.Text = tempItemName[i];
                supplierItems[i].price.Text = tempItemPrice[i];
            }
            Button btnAdd = new Button();
            btnAdd.Location = new Point(24, 14 + panel1.Controls.Count / 2 * 40);
            btnAdd.Text = "更多";
            btnAdd.Size = new Size(110, 25);
            btnAdd.BackColor = default(Color);
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            panel1.Controls.Add(btnAdd);

            panel1.ScrollControlIntoView(btnAdd);//pan to add button
        }

        //Add Snew supplier
        private void btnAddSup_Click(object sender, EventArgs e)
        {
            string promptValue = Prompt.ShowDialog("請輸入廠商的名稱:", "建立新廠商");
            if (promptValue != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection(sqlCon);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into supplier(name) values(@name)", con);
                    cmd.Parameters.AddWithValue("@name", promptValue);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    con.Close();

                    DsSupplier.Tables["supplier"].Clear();
                    DaSupplier.Fill(DsSupplier, "supplier");
                    cbbSuppliers.Items.Clear();
                    foreach (DataRow row in DsSupplier.Tables["supplier"].Rows)
                    {
                        cbbSuppliers.Items.Add(row["name"]);
                    }
                    cbbSuppliers.SelectedIndex = cbbSuppliers.Items.Count - 1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "廠商名稱不可重複", "錯誤");
                }
            }
        }


        //delete supplier
        private void btnDeleteSup_Click(object sender, EventArgs e)
        {
            string className = cbbSuppliers.SelectedItem.ToString();
            DialogResult dr = MessageBox.Show("是否要刪除廠商: " + className + "?", "確認刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(sqlCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from supplier where name = @name", con);
                cmd.Parameters.AddWithValue("@name", className);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                con.Close();

                DsSupplier.Tables["supplier"].Clear();
                DaSupplier.Fill(DsSupplier, "supplier");
                cbbSuppliers.Items.Clear();
                foreach (DataRow row in DsSupplier.Tables["supplier"].Rows)
                {
                    cbbSuppliers.Items.Add(row["name"]);
                }
                cbbSuppliers.SelectedIndex = 0;

                MessageBox.Show("已刪除廠商: " + className, "成功");
            }
        }
    }
}
