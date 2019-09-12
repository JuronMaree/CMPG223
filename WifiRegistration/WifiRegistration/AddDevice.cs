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
    public partial class AddDevice : Form
    {
        public AddDevice()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlDataAdapter adap;
        SqlCommand cmd;
        DataSet ds;
        StreamReader sr;
        string connectionString;
        //string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Francois\source\repos\WifiRegistration\WifiRegistration\WifiRegistrationFinal.mdf;Integrated Security=True";


        private void AddDevice_Load(object sender, EventArgs e)
        {
            using (sr = new StreamReader("ConnectionString.txt"))
            {
                connectionString = sr.ReadLine();
                groupBox1.Visible = false;
                conn = new SqlConnection(connectionString);
                conn.Open();
                string query = "select * from Unit";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandText = query;


                SqlDataReader drd = cmd.ExecuteReader();
                while (drd.Read())
                {

                    comboBox1.Items.Add(drd["UnitNumber"].ToString().ToUpper());

                }
                conn.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("All fields must be filled in!!!", "Empty Field!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                
            }
            else
            {
                try
                {
                    conn = new SqlConnection(connectionString);

                    string sql = "INSERT INTO [ValidMac] ( [UnitNum],[Mac],[Expire],[DeviceType]) VALUES (@UnitNum, @Mac,@Expire,@DeviceType)";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("UnitNum", comboBox1.Text.ToUpper());
                    cmd.Parameters.AddWithValue("Mac", textBox1.Text.ToUpper());
                    cmd.Parameters.AddWithValue("Expire", textBox2.Text.ToUpper());
                    cmd.Parameters.AddWithValue("DeviceType", textBox3.Text.ToUpper());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Mac [ "+textBox1.Text.ToUpper()+" ] were added successfully to the database.");
                    this.Close();
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.Message);
                }
            }






        }

        private void button1_Click(object sender, EventArgs e)
        {
          
                try
                {
                    conn = new SqlConnection(connectionString);
                    conn.Open();
                    string sql = "Select * from ValidMac where UnitNum like '" + comboBox1.Text + "'";
                    cmd = new SqlCommand(sql, conn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    /* while (dr.Read())
                     {
                         textBox1.Text = (dr["Mac"].ToString());
                         textBox2.Text = (dr["Expire"].ToString());
                         textBox3.Text = (dr["DeviceType"].ToString());

                     }*/

                    conn.Close();
                    groupBox1.Visible = true;
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.Message);
                }
            
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.CharacterCasing = CharacterCasing.Upper;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.CharacterCasing = CharacterCasing.Upper;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.CharacterCasing = CharacterCasing.Upper;
        }
    }
}
