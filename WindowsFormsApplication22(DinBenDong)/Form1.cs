using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication22_DinBenDong_
{
    public partial class Form1 : Form
    {
        bool skipLogin = false;  //Skip login

        String sqlCon = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
    @"AttachDbFilename=C:\Users\rugia\Desktop\Lunch.mdf;" +
    @"Integrated Security=True;" +
    @"MultipleActiveResultSets=True;" +
    @"User Instance=False;";

        string loginName;
        int studentNumber;
        string class_name;
        string class_id;

        SqlConnectionStringBuilder scsb;
        List<class_item> classItems = new List<class_item> {};
        List<student_item> studentItems = new List<student_item> { };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (skipLogin)
            {
                loginName = "Jay Li";
                class_name = "AppDev 98";

                Form_main form = new Form_main(this, 1, loginName, 1,class_name, 1, true);
                form.ShowDialog();
            }
            
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "CR3-08";
            scsb.InitialCatalog = "Lunch";
            scsb.IntegratedSecurity = true;

            //sqlCon = scsb.ToString(); // comment this out when not in III

            SqlConnection con = new SqlConnection(sqlCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from class", con);
            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    classItems.Add(new class_item((int)reader["class_id"], (string)reader["name"]));
                    cbbClass.Items.Add(classItems.Last<class_item>().name);
                }
                reader.Close();
                con.Close();                
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
            //cbbClass.DataSource = classItems;
            //cbbClass.DisplayMember = "name";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (cbbClass.SelectedIndex<0 || cbbName.SelectedIndex<0)
            {
                MessageBox.Show("Choose a name"); return;
            }
            loginName = studentItems[cbbName.SelectedIndex].name;
            studentNumber = studentItems[cbbName.SelectedIndex].number;
            class_name = classItems[cbbClass.SelectedIndex].name;
            int id = studentItems[cbbName.SelectedIndex].id;
            int class_id = classItems[cbbClass.SelectedIndex].id;
            Boolean ifOnDuty = false;
            if (ckb_onDuty.Checked) ifOnDuty = true;

            MessageBox.Show(string.Format("ID: {3}, 姓名: {0}, 座號: {1}, 班級: {2}", loginName, studentNumber, class_name, id), "登入成功", MessageBoxButtons.OK, MessageBoxIcon.None);
            Form_main form = new Form_main(this, id, loginName, studentNumber, class_name, class_id, ifOnDuty);

            //hide form1 and show form_main
            form.Show();
            this.Hide();
        }

        //Change class selection
        private void cbbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(sqlCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from student where class_id = @id order by number", con);
            cmd.Parameters.AddWithValue("@id", classItems[cbbClass.SelectedIndex].id);
            SqlDataReader reader = cmd.ExecuteReader();

            cbbName.Items.Clear();
            studentItems.Clear();

            try
            {
                while (reader.Read())
                {
                    cbbName.Items.Add((string)reader["name"] + " (" + reader["number"] + ")");
                    studentItems.Add(new student_item((int)reader["stu_id"], (string)reader["name"], (int)reader["number"]));
                }
                cbbName.Text = "";
                cbbName.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                Console.WriteLine("class has no student");
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
        }

        class class_item
        {
        public int id;
        public string name;
        public class_item(int id, string name)
            {
                this.id = id;
                this.name = name;
            }
        }
        class student_item
        {
            public int id;
            public string name;
            public int number;
            public student_item(int id, string name, int number)
            {
                this.id = id;
                this.name = name;
                this.number = number;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_order_detail form = new Form_order_detail(sqlCon, 0);
            form.ShowDialog(this);
        }
    }
}
