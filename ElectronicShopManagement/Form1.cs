using ElectronicShopManagement.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicShopManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            //if (txtusername.Text == "kodot" && txtpassword.Text == "123")
            //{
                FormDashboard forms = new FormDashboard();
                forms.Show();
                this.Hide();
            //}
            //else
            //{
                //MessageBox.Show("Wrong Username or Password");
                //txtpassword.Text = "";
            //    txtusername.Text = "";
            //}
        }

        private void labelclear_Click(object sender, EventArgs e)
        {
            txtpassword.Text = "";
            txtusername.Text = "";
        }
    }
}
