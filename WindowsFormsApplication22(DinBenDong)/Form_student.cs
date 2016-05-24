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
        string sqlCon = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
    @"AttachDbFilename=C:\Users\rugia\Desktop\Lunch.mdf;" +
    @"Integrated Security=True;" +
    @"MultipleActiveResultSets=True;" +
    @"User Instance=False;";
        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
        List<studentItem> studentItems = new List<studentItem>();

        DataSet DsLunch = new DataSet();
        SqlDataAdapter DaStudent;
        SqlDataAdapter DaClass;
        SqlCommandBuilder scb;

        int classID = 0;
        List<int> tempStuId = new List<int>();
        List<String> tempStuName = new List<string>();

        public Form_student(SqlConnectionStringBuilder scsb)
        {
            InitializeComponent();
            this.scsb = scsb;            
        }

        private void Form_student_Load(object sender, EventArgs e)
        {
            //sqlCon = scsb.ToString();
            SqlConnection con = new SqlConnection(sqlCon);
            DaStudent = new SqlDataAdapter("select * from student", con);
            DaClass = new SqlDataAdapter("select * from class", con);
            scb = new SqlCommandBuilder(DaStudent);
            //con = new SqlConnection(scsb.ToString());

            //Load class names
            DaClass.Fill(DsLunch, "class");
            DaStudent.Fill(DsLunch, "student");
            foreach (DataRow row in DsLunch.Tables["class"].Rows)
            {
                cbbClass.Items.Add(row["name"]);
            }
            cbbClass.SelectedIndex = 0;
            /*
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
            */

            //build label and textfield
            //buildColumns();
            
        }
        
        //switching classes
        private void cbbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            studentItems.Clear();
            tempStuId = new List<int>();
            tempStuName = new List<string>();

            //SqlConnection con = new SqlConnection(sqlCon);
            try
            {                
                classID = (int)DsLunch.Tables["class"].Select("name = '" + cbbClass.SelectedItem.ToString() + "'").First()["class_id"];
                //Console.WriteLine("class id = " + classID);
                foreach (DataRow row in DsLunch.Tables["student"].Select("class_id = '" + classID + "'"))
                {
                    tempStuId.Add((int)row["number"]);
                    tempStuName.Add((string)row["name"]);
                    //Console.WriteLine((int)row["number"] + " " + (string)row["name"]);
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            /*
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from student s join class c on s.class_id = c.class_id where c.name = @name", con);
            cmd.Parameters.AddWithValue("@name", cbbClass.SelectedItem.ToString());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    tempStuId.Add((int)reader["number"]);
                    tempStuName.Add((string)reader["name"]);
                    //studentItems[(int)reader["number"]-1].name.Text = (string)reader["name"];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            reader.Close();
            con.Close();
            */
            int max = 0;
            if (tempStuId.Count > 0)
            {
                max = tempStuId.Max();
            }
            buildColumns((max/10+1)*10);
            if (tempStuId.Count > 0)
            {
                for (int i = 0; i < tempStuId.Count; i++)
                {
                    studentItems[tempStuId[i] - 1].name.Text = tempStuName[i];
                }
            }

            Button btnAdd = new Button();
            btnAdd.Location = new Point(21 + (max / 10 + 1) * 260, 15);
            btnAdd.Text = "更多";
            btnAdd.Size = new Size(110, 25);
            btnAdd.BackColor = default(Color);
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            panel1.Controls.Add(btnAdd);            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<int> tempId = new List<int>();
            List<string> tempName = new List<string>();

            foreach (studentItem student in studentItems)
            {
                if (student.name.Text != "")
                {
                    tempId.Add(Convert.ToInt32(student.id.Text));
                    tempName.Add(student.name.Text);
                }                
            }

            panel1.Controls.RemoveAt(panel1.Controls.Count - 1);//remove add button
            int panelControlsCount = panel1.Controls.Count / 2;//how many buttons
            panel1.Controls.Clear();
            studentItems.Clear();

            Button btnAdd = new Button();
            btnAdd.Location = new Point(21 + ((panelControlsCount / 10) + 1) * 260, 15);
            btnAdd.Size = new Size(110, 25);
            btnAdd.Name = "btnAdd";
            btnAdd.Text = "更多";
            btnAdd.BackColor = default(Color);
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            panel1.Controls.Add(btnAdd);

            buildColumns(panelControlsCount + 10);
            for (int i = 0; i < tempId.Count; i++)
            {
                studentItems[tempId[i] - 1].name.Text = tempName[i];
            }
            panel1.ScrollControlIntoView(btnAdd);//pan to add button
        }
        private void buildColumns(int numRow)
        {
            int yCounter = 0;
            for (int i = 0; i < numRow; i++)
            {
                int x = 21 + i / 10 * 260;
                if (yCounter > 9)
                {
                    yCounter = 0;
                }

                Label lbl = new Label();
                lbl.Text = (i + 1).ToString();
                lbl.Font = new Font("微軟正黑體", 10);
                lbl.Size = new Size(32, 20);
                lbl.Location = new Point(x, 15 + yCounter * 40);

                TextBox tb = new TextBox();
                tb.Font = new Font("微軟正黑體", 10);
                tb.Location = new Point(x + 34, 15 + yCounter * 40);
                tb.Size = new Size(200, 25);

                panel1.Controls.Add(lbl);
                panel1.Controls.Add(tb);
                studentItems.Add(new studentItem(lbl, tb));
                yCounter++;
            }
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

        //Save/Update student names
        private void btnSave_Click(object sender, EventArgs e)
        {
            //DsLunch.Tables["student"].Rows.Clear();
            //DaStudent.Fill(DsLunch, "student");
            SqlConnection con = new SqlConnection(sqlCon);
            con.Open();
            int i = 0;
            foreach (studentItem student in studentItems)
            {
                try
                {
                    bool ifModified = false;
                    foreach (int o in tempStuId)
                    {
                        if (student.id.Text == o.ToString())
                        {
                            Console.WriteLine(student.id.Text + " should be modified");
                            ifModified = true;
                            break;
                        }
                    }
                    if (ifModified) //if this item should be modified
                    {
                        if (student.name.Text != "") //update
                        {
                            Console.WriteLine("updating "+student.name.Text);
                            SqlCommand cmd = new SqlCommand("update student set name = @name where number = @number and class_id = @class_id", con);
                            cmd.Parameters.AddWithValue("@name", student.name.Text);
                            cmd.Parameters.AddWithValue("@number", Convert.ToInt32(student.id.Text));
                            cmd.Parameters.AddWithValue("@class_id", classID);
                            SqlDataReader reader = cmd.ExecuteReader();
                            reader.Close();
                        }
                        else //delete
                        {
                            Console.WriteLine("deleting" + student.id.Text);
                            SqlCommand cmd = new SqlCommand("delete from student where number = @number and class_id = @class_id", con);
                            cmd.Parameters.AddWithValue("@number", Convert.ToInt32(student.id.Text));
                            cmd.Parameters.AddWithValue("@class_id", classID);
                            SqlDataReader reader = cmd.ExecuteReader();
                            reader.Close();

                        }
                    }
                    else // should be inserted
                    {
                        if (student.name.Text != "")
                        {
                            Console.WriteLine("inserting " + student.name.Text);
                            SqlCommand cmd = new SqlCommand("insert into student values(@name, @number, @class_id)", con);
                            cmd.Parameters.AddWithValue("@name", student.name.Text);
                            cmd.Parameters.AddWithValue("@number", Convert.ToInt32(student.id.Text));
                            cmd.Parameters.AddWithValue("@class_id", classID);
                            SqlDataReader reader = cmd.ExecuteReader();
                            reader.Close();
                        }
                    }
                    
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                
                i++;
            }
            con.Close();
            DsLunch = new DataSet();
            DaStudent.Fill(DsLunch, "student");
            DaClass.Fill(DsLunch, "class");

            MessageBox.Show(this, "已儲存變更", "儲存");
        }

        //Add new class
        private void btnAddClass_Click(object sender, EventArgs e)
        {
            string promptValue = Prompt.ShowDialog("請輸入新班級的名稱:", "建立新班級");
            if (promptValue != "")
            {
                try {
                    SqlConnection con = new SqlConnection(sqlCon);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into class(name) values(@name)", con);
                    cmd.Parameters.AddWithValue("@name", promptValue);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    con.Close();

                    DsLunch.Tables["class"].Clear();
                    DaClass.Fill(DsLunch, "class");
                    cbbClass.Items.Clear();
                    foreach (DataRow row in DsLunch.Tables["class"].Rows)
                    {
                        cbbClass.Items.Add(row["name"]);
                    }
                    cbbClass.SelectedIndex = cbbClass.Items.Count-1;
                }catch(Exception ex)
                {
                    MessageBox.Show(this,"班級名稱不可重複", "錯誤");
                }
            }           
        }

        //Delete class
        private void btnDeleteClass_Click(object sender, EventArgs e)
        {
            string className = cbbClass.SelectedItem.ToString();
            DialogResult dr = MessageBox.Show("是否要刪除班級: " + className + "?", "確認刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(sqlCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from class where name = @name", con);
                cmd.Parameters.AddWithValue("@name", className);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                con.Close();

                DsLunch.Tables["class"].Clear();
                DaClass.Fill(DsLunch, "class");
                cbbClass.Items.Clear();
                foreach (DataRow row in DsLunch.Tables["class"].Rows)
                {
                    cbbClass.Items.Add(row["name"]);
                }
                cbbClass.SelectedIndex = 0;

                MessageBox.Show("已刪除班級: " + className, "成功");
            }            
        }
    }
}
