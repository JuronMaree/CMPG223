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
using System.IO;

namespace WifiRegistration
{
    public partial class ViewALL : Form
    {
        public ViewALL()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlDataAdapter adap;
        SqlCommand cmd;
        DataSet ds;
        StreamReader sr;
        string connectionString;
       // string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Francois\source\repos\WifiRegistration\WifiRegistration\WifiRegistrationFinal.mdf;Integrated Security=True";
        

        private void ViewALL_Load(object sender, EventArgs e)
        {
            using (sr = new StreamReader("ConnectionString.txt"))
            {
                connectionString = sr.ReadLine();
            }
                loadALL();
        }
        public void loadALL()
        {
            try
            {

                string sql = "SELECT a.UnitNumber,a.OwnerName,a.OwnerCell,a.Memo,b.Mac,b.Expire,b.DeviceType,c.ComplexName,d.CityName,d.PostalCode FROM Unit a, ValidMac b, Complex c, Address d WHERE a.UnitNumber = b.UnitNum  "; 
                conn = new SqlConnection(connectionString);
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                adap = new SqlDataAdapter();
                adap.SelectCommand = cmd;
                adap.SelectCommand.ExecuteNonQuery();
                ds = new DataSet();
                adap.Fill(ds, "stable");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "stable";
                conn.Close();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                adap = new SqlDataAdapter("select * FROM ValidMac WHERE UnitNum LIKE '" + textBox1.Text + "%' OR Mac LIKE '" + textBox1.Text + "%' OR Expire LIKE '" + textBox1.Text + "%' OR DeviceType LIKE '" + textBox1.Text + "%'", conn);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
