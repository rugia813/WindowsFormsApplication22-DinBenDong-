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
        bool skipLogin = true;  //Skip login

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

                Form_main form = new Form_main(this, loginName, 1,class_name, 1, true);
                form.ShowDialog();
            }

            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "CR3-08";
            scsb.InitialCatalog = "Lunch";
            scsb.IntegratedSecurity = true;

            SqlConnection con = new SqlConnection(scsb.ToString());
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
            studentNumber = studentItems[cbbName.SelectedIndex].id;
            class_name = classItems[cbbClass.SelectedIndex].name;
            int class_id = classItems[cbbClass.SelectedIndex].id;
            Boolean ifOnDuty = false;
            if (ckb_onDuty.Checked) ifOnDuty = true;

            MessageBox.Show(string.Format("姓名:{0}, 座號: {1}, 班級: {2}", loginName, studentNumber, class_name), "登入成功", MessageBoxButtons.OK, MessageBoxIcon.None);
            Form_main form = new Form_main(this, loginName, studentNumber, class_name, class_id, ifOnDuty);

            //hide form1 and show form_main
            form.Show();
            this.Hide();
        }

        //Change class selection
        private void cbbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from student where class_id = @id", con);
            cmd.Parameters.AddWithValue("@id", classItems[cbbClass.SelectedIndex].id);
            SqlDataReader reader = cmd.ExecuteReader();

            cbbName.Items.Clear();

            try
            {
                while (reader.Read())
                {
                    cbbName.Items.Add(reader["name"]);
                    studentItems.Add(new student_item((int)reader["stu_id"], (string)reader["name"]));
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
            cbbName.SelectedIndex = 0;
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
            public student_item(int id, string name)
            {
                this.id = id;
                this.name = name;
            }
        }

    }
}
