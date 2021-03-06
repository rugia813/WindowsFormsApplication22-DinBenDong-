﻿using System;
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
        int student_id;
        int class_id;
        bool ifOnDuty = false;

        List<Button> btnDishes = new List<Button>();
        ArrayList supplierItems = new ArrayList();

        SqlConnectionStringBuilder scsb;

        string todaySup;

        public Form_main(Form1 f, string loginName, int stu_id, string className, int class_id, bool ifod)
        {
            InitializeComponent();
            //load login info into variables
            form1 = f;
            user_name = loginName;
            class_name = className;
            student_id = stu_id;
            this.class_id = class_id;
            ifOnDuty = ifod;
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            //status bar text
            toolStripStatusLabel1.Text = string.Format("使用者:{0}({2}), 班級: {1}({3})", user_name, class_name, student_id, class_id);

            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "CR3-08";
            scsb.InitialCatalog = "Lunch";
            scsb.IntegratedSecurity = true;

            //See if today's supplier chosen yet
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select todaySupplier from class where class_id = @class_id";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@class_id", class_id);
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine(1);
            try
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        Console.WriteLine(2);
                        var t = reader["todaySupplier"];
                        Console.WriteLine(t);
                        if (t.GetType() == "string".GetType())
                        {
                            todaySup = (string)t;
                            Console.WriteLine(todaySup + " today sup");
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
                if (reader != null)
                {
                    reader.Close();
                }
                if (con != null)
                {
                    con.Close();
                }
            }

            Console.WriteLine(3);

            //if today sup is chosen
            if (todaySup != null)
            {
                cbbChooseSup.Enabled = false;
                btnConfirm.Text = "更改廠商";
                try
                {
                    Console.WriteLine("yes sup " + todaySup);
                    //get name and price of each items of this supplier, and make button(name) and Label(price) on panel1
                    con.Open();
                    strSQL = "select i.item_name, i.price from supplier s join supplier_items i on s.sup_id = i.sup_id where s.name = 'Mcdonald''s'";
                    cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@sup_name", todaySup);
                    reader = cmd.ExecuteReader();
                    while (reader.HasRows)
                    {
                        int i = 0;
                        buildSupplierItems(reader, i);
                        reader.NextResult();
                    }
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
            else //if today sup is not chosen
            {
                Console.WriteLine("no sup");
                Label lbl = new Label();
                lbl.Location = new Point(panel1.Size.Width / 2 - 50, panel1.Height / 2 - 50);
                lbl.Size = new Size(200, 200);
                lbl.Text = "還未選擇今日廠商";
                panel1.Controls.Add(lbl);
            }


            //if is on duty load supplier names into combobox, if not, hide combobox.
            if (ifOnDuty)
            {
                con.Open();
                strSQL = "select name from supplier";
                cmd = new SqlCommand(strSQL, con);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbbChooseSup.Items.Add(reader["name"]);
                }

                cbbChooseSup.SelectedIndex = 0;
                reader.Close();
            }
            else
            {
                cbbChooseSup.Visible = false;
                btnClassOrderDetails.Visible = false;
                lblChooseSup.Visible = false;
                btnConfirm.Visible = false;
            }
            con.Close();
        }

        //Switching Supllier selection
        private void cbbChooseSup_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); //clear existing controls
            btnDishes.Clear();
            supplierItems.Clear();

            //get name and price of each items of this supplier, and make button(name) and Label(price) on panel1
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select item_name, price from supplier_items where sup_id = @sup_id";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@sup_id", cbbChooseSup.SelectedIndex + 1);
            SqlDataReader reader = cmd.ExecuteReader();
            var items = new[] { new { Name = "", Price = 0 } };
            while (reader.HasRows)
            {
                int i = 0;
                buildSupplierItems(reader, i);

                reader.NextResult();
            }
            reader.Close();
            con.Close();
        }

        //Confirm order
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string output = "";
            foreach (supplier_item supItem in supplierItems)
            {
                if (Convert.ToInt32(supItem.tb.Text) != 0)
                {
                    output += supItem.btn.Text + " " + supItem.tb.Text + "\n";
                }
            }
            MessageBox.Show(output);
        }

        //button confirm supplier
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            try
            {
                if (todaySup == null)
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
                }
                else
                {
                    todaySup = null;
                    btnConfirm.Text = "選擇";
                    cbbChooseSup.Enabled = true;
                }
            }
            finally
            {
                if (con != null)
                {

                }
            }
        }

        //button edit students
        private void btnEditStu_Click(object sender, EventArgs e)
        {
            Form_student formStu = new Form_student(scsb);
            formStu.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //log out, kill this form and show form1
            form1.Show();
            this.Hide();
        }

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
            public TextBox tb { get; set; }
            public supplier_item(Button btn, Label lbl, TextBox tb)
            {
                this.btn = btn;
                this.lbl = lbl;
                this.tb = tb;
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
                btn.BackColor = default(Color);
                btn.UseVisualStyleBackColor = true;
                panel1.Controls.Add(btn);

                Label lbl = new Label();
                lbl.AutoSize = false;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Text = reader.GetInt32(1).ToString();
                lbl.Location = new Point(210, 24 + i);
                lbl.Size = new Size(47, 29);
                panel1.Controls.Add(lbl);

                TextBox tb = new TextBox();
                tb.Location = new Point(300, 24 + i);
                tb.Size = new Size(46, 29);
                tb.ReadOnly = true;
                tb.Text = "0";
                panel1.Controls.Add(tb);
                i += 35;

                supplierItems.Add(new supplier_item(btn, lbl, tb));
            }
        }

        
    }
}
