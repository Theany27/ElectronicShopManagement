using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicShopManagement.Forms
{
    public partial class BakongKhqr : Form
    {
        public BakongKhqr(Image qrCodeImage,decimal totalAmount)
        {
            InitializeComponent();
            pictureBox1.Image = qrCodeImage;
            labeltotalamountpay.Text = totalAmount.ToString("0.00");
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BakongKhqr_Load(object sender, EventArgs e)
        {

        }
    }
}
