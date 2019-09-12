using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WifiRegistration
{
    public partial class WifiRegistration : Form
    {
        public WifiRegistration()
        {
            InitializeComponent();
        }
        string logoPath;
        Image myImage;
        private void expiredDevicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expired frm = new Expired();
            frm.MdiParent = this;
            frm.Show();
        }

        private void addUnitOwnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUnit frm = new AddUnit();
            frm.MdiParent = this;
            frm.Show();
        }

        private void addDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDevice frm = new AddDevice();
            frm.MdiParent = this;
            frm.Show();

        }

        private void viewALLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewALL frm = new ViewALL();
            frm.MdiParent = this;
            frm.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void WifiRegistration_Load(object sender, EventArgs e)
        {
            /*using (StreamReader sr = new StreamReader("LogoString.txt"))
            {
                logoPath = sr.ReadLine();
                if(myImage == null)
                {
                    MessageBox.Show("Please Provide a logo path in the LogoString.txt file");
                }
                myImage = new Bitmap(logoPath);
               // this.BackgroundImage = myimage;
            }*/
        }

        private void wifiRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AddComplexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddComplex c = new AddComplex();
            c.Show();
        }

        private void AddAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAddress a = new AddAddress();
            a.Show();
        }
    }
}
