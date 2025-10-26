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
    public partial class FormDashboard : Form
    {
        private Form activeForm = null;


        private Button activeButton = null;

        
        private void OpenchildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelshowitem1.Controls.Clear();
            this.panelshowitem1.Controls.Add(childForm);
            this.panelshowitem1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            toplabel.Text = childForm.Text;
        }
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void panelshowitem1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenchildForm(new Forms.Home());
            // If this button is already active, turn it off (back to default)
            if (activeButton == button1)
            {
                button1.BackColor = SystemColors.Control;
                button1.ForeColor = Color.Black;
                activeButton = null;
                return;
            }

            // Reset previously active button (if any)
            if (activeButton != null)
            {
                activeButton.BackColor = SystemColors.Control;
                activeButton.ForeColor = Color.Black;
            }

            // Set the clicked one as active
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.White;
            activeButton = button1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenchildForm(new Forms.Products_Stock());
            // If this button is already active, turn it off (back to default)
            if (activeButton == button2)
            {
                button2.BackColor = SystemColors.Control;
                button2.ForeColor = Color.Black;
                activeButton = null;
                return;
            }

            // Reset previously active button (if any)
            if (activeButton != null)
            {
                activeButton.BackColor = SystemColors.Control;
                activeButton.ForeColor = Color.Black;
            }

            // Set the clicked one as active
            button2.BackColor = Color.Black;
            button2.ForeColor = Color.White;
            activeButton = button2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenchildForm(new Forms.Sell());

            // If this button is already active, turn it off (back to default)
            if (activeButton == button3)
            {
                button3.BackColor = SystemColors.Control;
                button3.ForeColor = Color.Black;
                activeButton = null;
                return;
            }

            // Reset previously active button (if any)
            if (activeButton != null)
            {
                activeButton.BackColor = SystemColors.Control;
                activeButton.ForeColor = Color.Black;
            }

            // Set the clicked one as active
            button3.BackColor = Color.Black;
            button3.ForeColor = Color.White;
            activeButton = button3; 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenchildForm(new Forms.Report());
            // If this button is already active, turn it off (back to default)
            if (activeButton == button4)
            {
                button4.BackColor = SystemColors.Control;
                button4.ForeColor = Color.Black;
                activeButton = null;
                return;
            }

            // Reset previously active button (if any)
            if (activeButton != null)
            {
                activeButton.BackColor = SystemColors.Control;
                activeButton.ForeColor = Color.Black;
            }

            // Set the clicked one as active
            button4.BackColor = Color.Black;
            button4.ForeColor = Color.White;
            activeButton = button4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            OpenchildForm(new Forms.Home());
            // If this button is already active, turn it off (back to default)
            if (activeButton == button1)
            {
                button1.BackColor = SystemColors.Control;
                button1.ForeColor = Color.Black;
                activeButton = null;
                return;
            }

            // Reset previously active button (if any)
            if (activeButton != null)
            {
                activeButton.BackColor = SystemColors.Control;
                activeButton.ForeColor = Color.Black;
            }

            // Set the clicked one as active
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.White;
            activeButton = button1;

        }
    }
}
