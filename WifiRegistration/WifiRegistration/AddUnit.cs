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
    public partial class AddUnit : Form
    {
        public AddUnit()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlConnection conn1 = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=C:\\Users\\gerri\\Documents\\NWU\\CMPG223\\WifiRegistration\\WifiRegistration\\WifiRegistrationFinal.mdf;Integrated Security = True ");
        SqlDataAdapter adap;
        SqlCommand cmd;
        SqlCommand cmd2;
        SqlDataAdapter adap2;
        DataSet ds;
        StreamReader sr;
        string connectionString;
        int indexRow;
        // string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Francois\source\repos\WifiRegistration\WifiRegistration\WifiRegistrationFinal.mdf;Integrated Security=True";
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("All fields must be filled in!!!", "Empty Field!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
            else
            {
                try
                {
                    conn = new SqlConnection(connectionString);

                    string sql = "INSERT INTO [Unit] ( [UnitNumber],[OwnerName],[OwnerCell],[Memo],[ComplexId]) VALUES (@UnitNumber, @OwnerName,@OwnerCell,@Memo,@ComplexId)";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("UnitNumber", textBox1.Text.ToUpper());
                    cmd.Parameters.AddWithValue("OwnerName", textBox2.Text.ToUpper());
                    cmd.Parameters.AddWithValue("OwnerCell", textBox3.Text.ToUpper());
                    cmd.Parameters.AddWithValue("Memo", textBox4.Text.ToUpper());
                    cmd.Parameters.AddWithValue("ComplexId", comboBox1.Text.ToUpper());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Unit [ "+textBox1.Text.ToUpper()+" ] were added successfully to the database.");
                    //this.Close();
                    loadALL();
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void AddUnit_Load(object sender, EventArgs e)
        {
            DataTable dt;
            
            conn1.Open();
            adap = new SqlDataAdapter("SELECT ComplexName FROM Complex", conn1);
            dt = new DataTable();
            adap.Fill(dt);
            comboBox1.ValueMember = "ComplexName";
            comboBox1.DataSource = dt;
            conn1.Close();

            groupBox1.Visible = false;
            using (sr = new StreamReader("ConnectionString.txt"))
            {
                connectionString = sr.ReadLine();
            }
            loadALL();
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

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        public void loadALL()
        {
            try
            {

                string sql = "SELECT * FROM Unit";
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

                textBox5.Text = row.Cells[0].Value.ToString().ToUpper();
                textBox1.Text = row.Cells[1].Value.ToString().ToUpper();
                textBox2.Text = row.Cells[2].Value.ToString().ToUpper();
                textBox3.Text = row.Cells[3].Value.ToString().ToUpper();
                textBox4.Text = row.Cells[4].Value.ToString().ToUpper();
                comboBox1.Text = row.Cells[5].Value.ToString().ToUpper();

            }
            catch
            {
                MessageBox.Show("error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" )
            {
                MessageBox.Show("All fields require!!!", "ATTENTION!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
            else
            {
                DataGridViewRow updateRow = dataGridView1.Rows[indexRow];
                //DateTime enteredDate = DateTime.Parse(textBox3.Text);
                updateRow.Cells[0].Value = Convert.ToInt32(textBox5.Text.ToUpper());
                updateRow.Cells[1].Value = textBox1.Text.ToUpper();
                updateRow.Cells[2].Value = textBox2.Text.ToUpper();
                updateRow.Cells[3].Value = textBox3.Text.ToUpper();
                updateRow.Cells[4].Value = textBox3.Text.ToUpper();
                try
                {
                    conn = new SqlConnection(connectionString);
                    cmd = new SqlCommand("Update Unit SET UnitNumber=@UnitNumber, OwnerName=@OwnerName, OwnerCell=@OwnerCell, Memo=@Memo where Id=@id", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("UnitNumber", textBox1.Text.ToUpper());
                    cmd.Parameters.AddWithValue("OwnerName", textBox2.Text.ToUpper());
                    cmd.Parameters.AddWithValue("OwnerCell", textBox3.Text.ToUpper());
                    cmd.Parameters.AddWithValue("Memo", textBox4.Text.ToUpper());
                    cmd.Parameters.AddWithValue("Id", Convert.ToInt32(textBox5.Text.ToUpper()));
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Unit Updated Successfully");
                    conn.Close();
                    //this.Close();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete Unit [ " + textBox1.Text + " ] from the database?", "WARNING!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    conn = new SqlConnection(connectionString);
                    conn.Open();
                    string kk = "  Delete from ValidMac where UnitNum = '" + textBox1.Text + "';Delete from Unit where UnitNumber = '" + textBox1.Text + "'";
                    //string s = "DELETE FROM Unit WHERE UnitNumber=@UnitNumber";
                    //string x = "DELETE FROM ValidMac WHERE Unit=@UnitNumber";
                   
                    
                    cmd = new SqlCommand(kk, conn);
                   // 

                   // cmd.Parameters.AddWithValue("UnitNumber", textBox1.Text);
                   //
                    adap = new SqlDataAdapter();
                    adap.DeleteCommand = cmd;
                    adap.DeleteCommand.ExecuteNonQuery();

                    //
                   
                    conn.Close();
                    /*conn.Open();
                    cmd2 = new SqlCommand(x, conn);
                    cmd2.Parameters.AddWithValue("UnitNumber", textBox1.Text);
                    adap2 = new SqlDataAdapter();
                    adap2.DeleteCommand = cmd;
                    adap2.DeleteCommand.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Device deleted successfully");*/
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

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
