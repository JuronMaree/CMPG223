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
    public partial class Excel : Form
    {
        public Excel()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlDataAdapter adap;
        SqlCommand cmd;
        DataSet ds;
        StreamReader sr;
        string connectionString;
        private void button3_Click(object sender, EventArgs e)
        {
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
        }

        private void Excel_Load(object sender, EventArgs e)
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

                string sql = "SELECT a.UnitNumber,a.OwnerName,a.OwnerCell,a.Memo,b.Mac,b.Expire,b.DeviceType FROM Unit a, ValidMac b WHERE a.UnitNumber = b.UnitNum and b.Expire <='" + DateTime.Now.ToString("MM/dd/yyyy") + "'";
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
    }
}
