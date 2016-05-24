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
        //List<studentItem> studentItems = new List<studentItem>();

        DataSet DsSupplier = new DataSet();
        SqlDataAdapter DaSupplier;
        SqlDataAdapter DasupItem;

        int classID = 0;
        List<int> tempStuId = new List<int>();
        List<String> tempStuName = new List<string>();

        public Form_supplier(SqlConnectionStringBuilder scsb)
        {
            InitializeComponent();
            this.scsb = scsb;
        }

        private void Form_supplier_Load(object sender, EventArgs e)
        {
            sqlCon = scsb.ToString();
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
            
        }
    }
}
