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
using System.Drawing.Printing;
using Microsoft.Office.Interop.Excel;

namespace WifiRegistration
{
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
        }
        public SqlConnection conn;
        public SqlCommand cmd;
        public SqlDataAdapter adap;
        public DataSet ds;
        string connectionString;
        StreamReader sr;
        SqlDataReader reader;
        PrintDocument document;
        //string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Francois\source\repos\WifiRegistration\WifiRegistration\WifiRegistrationFinal.mdf;Integrated Security=True";




        private void Print_Load(object sender, EventArgs e)
        {
            using (sr = new StreamReader("ConnectionString.txt"))
            {
                connectionString = sr.ReadLine();
                try
                {
                    conn = new SqlConnection(connectionString);
                    conn.Open();
                    listBox1.Items.Clear();
                    string sql = "SELECT a.UnitNumber,a.OwnerName,a.OwnerCell,b.Mac,b.Expire,b.DeviceType FROM Unit a, ValidMac b WHERE a.UnitNumber = b.UnitNum AND b.Expire <='" + DateTime.Now.ToString("MM/dd/yyyy") + "'";


                    cmd = new SqlCommand(sql, conn);
                    reader = cmd.ExecuteReader();
                    string a = "UNIT NO:" + "   " + " OWNER: " + "\t\t\t" + "CELL:" + "\t\t" + "MAC:" + "\t\t\t" + "EXP DATE:" + "\t" + "DEVICE:";
                    listBox1.Items.Add(a);
                    listBox1.Items.Add("_________________________________________________________________________________________________________________");

                    while (reader.Read())
                    {
                        DateTime dt = Convert.ToDateTime(reader.GetValue(4).ToString());
                        
                        string unit = Convert.ToString(reader.GetValue(0));
                        string owner= Convert.ToString(reader.GetValue(1));
                        string cell = Convert.ToString(reader.GetValue(2));
                        string mac = Convert.ToString(reader.GetValue(3));
                        string ExpD = Convert.ToString(reader.GetValue(4));
                        string device = Convert.ToString(reader.GetValue(5));

                        string subUnit = unit.PadRight(10, '_');
                        string subOnwer = owner.PadRight(25,'_');
                        string subCell = cell.PadRight(15, '_');
                        string subExpD = ExpD.PadRight(11, '_');
                        string subDevice = device.PadRight(50, '_');
                        string subMac = mac.PadRight(18, '_');



                        string s = subUnit.ToUpper() +" \t" + subOnwer.ToUpper() + "\t" + subCell.ToUpper() +" \t" + subMac.ToUpper() +"\t" + String.Format("{0:MM/dd/yyyy}",dt) + "\t" + subDevice.ToUpper();

                        listBox1.Items.Add(s);

                    }
                    conn.Close();
                }
                catch (SqlException err)
                {
                    MessageBox.Show(err.Message);
                }
            }

        }

        public void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            int leading = 5;
            int leftMargin = 130;
            int topMargin = 10;

            // a few simple formatting options..
            StringFormat FmtRight = new StringFormat() { Alignment = StringAlignment.Center };
            StringFormat FmtLeft = new StringFormat() { Alignment = StringAlignment.Center };
            StringFormat FmtCenter = new StringFormat() { Alignment = StringAlignment.Center };

            StringFormat fmt = FmtRight;

            using (System.Drawing.Font font = new System.Drawing.Font("Arial Narrow", 12f))
            {
                SizeF sz = e.Graphics.MeasureString("_|", Font);
                float h = sz.Height + leading;

                for (int i = 0; i < listBox1.Items.Count; i++)
                    e.Graphics.DrawString(listBox1.Items[i].ToString().ToUpper() + " \t\t", font, Brushes.Black,
                                          leftMargin, topMargin + h * i, fmt);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            document = new PrintDocument();
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Document = document;
            ppd.Document.DocumentName = "TESTING";
            document.PrintPage += document_PrintPage;
            ppd.ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            
        }



        

    }
    
}
