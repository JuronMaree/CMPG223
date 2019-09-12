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
    public partial class Expired : Form
    {
        public Expired()
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
        int indexRow;
        private void Expired_Load(object sender, EventArgs e)
        {
            using (sr = new StreamReader("ConnectionString.txt"))
            {
                connectionString = sr.ReadLine();
            }
            loadExpiredAddresses();
        }

        public void loadExpiredAddresses()
        {
            try
            {

                string sql = "Select * from ValidMac V where V.Expire <='" + DateTime.Now.ToString("MM/dd/yyyy") + "'";
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

                textBox1.Text = row.Cells[1].Value.ToString().ToUpper();
                textBox2.Text = row.Cells[2].Value.ToString().ToUpper();
                textBox3.Text = row.Cells[3].Value.ToString().ToUpper();
                textBox4.Text = row.Cells[4].Value.ToString().ToUpper();
                textBox6.Text = row.Cells[0].Value.ToString().ToUpper();
            }
            catch
            {
                MessageBox.Show("error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("All fields require!!!", "ATTENTION!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
            else
            {
                DataGridViewRow updateRow = dataGridView1.Rows[indexRow];
                //DateTime enteredDate = DateTime.Parse(textBox3.Text);
                //updateRow.Cells[0].Value = textBox5
                updateRow.Cells[1].Value = textBox1.Text.ToUpper();
                updateRow.Cells[2].Value = textBox2.Text.ToUpper();
                updateRow.Cells[3].Value = Convert.ToDateTime(textBox3.Text.ToUpper());
                updateRow.Cells[4].Value = textBox4.Text.ToUpper();
                try
                {
                    conn = new SqlConnection(connectionString);
                    cmd = new SqlCommand("Update ValidMac SET Mac=@Mac, Expire=@Expire, DeviceType=@DeviceType where UnitNum=@UnitNum", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("UnitNum", textBox1.Text.ToUpper());
                    cmd.Parameters.AddWithValue("Mac", textBox2.Text.ToUpper());
                    cmd.Parameters.AddWithValue("Expire", Convert.ToDateTime(textBox3.Text.ToUpper()));
                    cmd.Parameters.AddWithValue("DeviceType", textBox4.Text.ToUpper());
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record Updated Successfully");
                    conn.Close();
                    //this.Close();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete Mac [ " + textBox2.Text + " ] from the database?", "WARNING!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    conn = new SqlConnection(connectionString);
                    conn.Open();
                    cmd = new SqlCommand("Delete From ValidMac Where Id = '" + textBox6.Text + "'", conn);
                    adap = new SqlDataAdapter();
                    adap.DeleteCommand = cmd;
                    adap.DeleteCommand.ExecuteNonQuery();
                    MessageBox.Show("Device deleted successfully");
                    conn.Close();
                }

                catch (SqlException error)
                {
                    MessageBox.Show(error.Message);
                }
                loadExpiredAddresses();
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Show();
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.CharacterCasing = CharacterCasing.Upper;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                adap = new SqlDataAdapter("select * FROM ValidMac WHERE UnitNum LIKE '" + textBox5.Text + "%' OR Mac LIKE '" + textBox5.Text + "%' OR Expire LIKE '" + textBox5.Text + "%' OR DeviceType LIKE '" + textBox5.Text + "%'", conn);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Print p = new Print();
            p.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.CharacterCasing = CharacterCasing.Upper;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.CharacterCasing = CharacterCasing.Upper;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.CharacterCasing = CharacterCasing.Upper;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.CharacterCasing = CharacterCasing.Upper;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           // using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV files (*.csv)|*.csv", ValidateNames = true })
            //{
               // if (sfd.ShowDialog() == DialogResult.OK)
                //{
                    // Don't save if no data is returned
                    if (dataGridView1.Rows.Count == 0)
                    {
                        return;
                    }
                    StringBuilder sb = new StringBuilder();
                    // Column headers
                    string columnsHeader = "";
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        columnsHeader += dataGridView1.Columns[i].Name + ",";
                    }
                    sb.Append(columnsHeader + Environment.NewLine);
                    // Go through each cell in the datagridview
                    foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
                    {
                        // Make sure it's not an empty row.
                        if (!dgvRow.IsNewRow)
                        {
                            for (int c = 0; c < dgvRow.Cells.Count; c++)
                            {
                                // Append the cells data followed by a comma to delimit.

                                sb.Append(dgvRow.Cells[c].Value + ",");
                            }
                            // Add a new line in the text file.
                            sb.Append(Environment.NewLine);
                        }
                    }
                    // Load up the save file dialog with the default option as saving as a .csv file.
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "CSV files (*.csv)|*.csv";
                    if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        // If they've selected a save location...
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false))
                        {
                            // Write the stringbuilder text to the the file.
                            sw.WriteLine(sb.ToString());
                        }
                    }
                    // Confirm to the user it has been completed.
                    MessageBox.Show("CSV file saved.");
                //}
            //}
        }
        private void ExtractDataToCSV(DataGridView dgv)
        {

            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Excel frm = new Excel();
            frm.Show();
        }
    }
}
    

