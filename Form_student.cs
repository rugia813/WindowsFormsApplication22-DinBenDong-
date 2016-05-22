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
    public partial class Form_student : Form
    {
        SqlConnection con;
        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
        List<studentItem> studentItems = new List<studentItem>();

        public Form_student(SqlConnectionStringBuilder scsb)
        {
            InitializeComponent();
            this.scsb = scsb;
        }

        private void Form_student_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(scsb.ToString());

            //Load class names
            con.Open();
            SqlCommand cmd = new SqlCommand("select name from class", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cbbClass.Items.Add(reader["name"]);
                cbbClass.SelectedIndex = 0;
            }
            reader.Close();
            con.Close();

            //build label and textfield
            int counter = 0;
            for (int i = 0; i < 34; i++)
            {

                
                
                int x = 21;
                //int y = (i%10)*40;
                if (counter > 9)
                {
                    counter = 0;
                }

                //if (i > 8) x = 280;
                
                int o = i;
                while (o>10)
                {
                    o -= 10;
                    x += 260;
                }
                


                Label lbl = new Label();
                lbl.Text = (i+1).ToString();
                lbl.Font = new Font("微軟正黑體", 10);
                lbl.Size = new Size(25, 20);
                lbl.Location = new Point(x, 15 + counter * 40);

                TextBox tb = new TextBox();
                tb.Font = new Font("微軟正黑體", 10);
                tb.Location = new Point(x+34, 15 + counter * 40);
                tb.Size = new Size(200, 25);

                panel1.Controls.Add(lbl);
                panel1.Controls.Add(tb);
                studentItems.Add(new studentItem(lbl, tb));
                counter++;
            }
            
        }

        //switching classes
        private void cbbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(scsb.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from student s join class c on s.class_id = c.class_id where c.name = @name", con);
            cmd.Parameters.AddWithValue("@name", cbbClass.SelectedItem.ToString());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    //studentItems[(int)reader["number"]-1].name.Text = (string)reader["name"];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            reader.Close();
            con.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }
        class studentItem
        {
            public TextBox name { get; set; }
            public Label id { get; set; }
            public studentItem(Label id, TextBox name)
            {
                this.id = id;
                this.name = name;
            }
        }
    }
}
