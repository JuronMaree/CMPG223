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
    public partial class AddAddress : Form
    {
        public AddAddress()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlDataAdapter adap;
        SqlCommand cmd;
        SqlCommand cmd2;
        SqlDataAdapter adap2;
        DataSet ds;
        StreamReader sr;
        string connectionString;
        int indexRow;

        public void loadALL()
        {
            try
            {

                string sql = "SELECT * FROM Address";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                indexRow = e.RowIndex;
                DataGridViewRow row = dataGridView1.Rows[indexRow];

                textBox3.Text = row.Cells[0].Value.ToString().ToUpper();
                textBox1.Text = row.Cells[1].Value.ToString().ToUpper();
                textBox2.Text = row.Cells[2].Value.ToString().ToUpper();

            }
            catch
            {
                MessageBox.Show("error");
            }
        }

        private void AddAddress_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            using (sr = new StreamReader("ConnectionString.txt"))
            {
                connectionString = sr.ReadLine();
            }
            loadALL();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("All fields must be filled in!!!", "Empty Field!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
            else
            {
                try
                {
                    conn = new SqlConnection(connectionString);
                    
                    string sql = "INSERT INTO [Address] ([CityName],[PostalCode]) VALUES (@CityName,@PostalCode)";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("CityName", textBox1.Text.ToUpper());
                    cmd.Parameters.AddWithValue("PostalCode", textBox2.Text.ToUpper());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Address [ " + textBox1.Text.ToUpper() + " ] were added successfully to the database.");
                    //this.Close();
                    loadALL();
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

       

        private void Button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("All fields require!!!", "ATTENTION!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
            else
            {
                DataGridViewRow updateRow = dataGridView1.Rows[indexRow];
                //DateTime enteredDate = DateTime.Parse(textBox3.Text);
                updateRow.Cells[0].Value = textBox3.Text.ToUpper();
                updateRow.Cells[1].Value = textBox1.Text.ToUpper();
                updateRow.Cells[2].Value = textBox2.Text.ToUpper();

                try
                {
                    conn = new SqlConnection(connectionString);
                    cmd = new SqlCommand("Update Address SET CityName=@CityName, PostalCode=@PostalCode", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("CityName", textBox1.Text.ToUpper());
                    cmd.Parameters.AddWithValue("PostalCode", textBox2.Text.ToUpper());


                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Address Updated Successfully");
                    conn.Close();
                    //this.Close();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete Address [ " + textBox1.Text + " ] from the database?", "WARNING!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    conn = new SqlConnection(connectionString);
                    conn.Open();
                    string kk = "  Delete from Address where CityName = '" + textBox1.Text + "';Delete from Address where CityName = '" + textBox1.Text + "'";
                   
                    cmd = new SqlCommand(kk, conn);
                    
                    adap = new SqlDataAdapter();
                    adap.DeleteCommand = cmd;
                    adap.DeleteCommand.ExecuteNonQuery();

                   

                    conn.Close();
                    
                    loadALL();


                }

                catch (SqlException error)
                {
                    MessageBox.Show(error.Message);
                }
                loadALL();
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Show();
            }
        }
    }
}
