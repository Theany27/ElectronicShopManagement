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
    public partial class Report : Form
    {
            List<ProductForSellModel> products = new List<ProductForSellModel>();

        public Report()
        {
            InitializeComponent();
            ProductForSellModel getReport = new ProductForSellModel();
            tblshowreport.DataSource=getReport;
        }

        private void Report_Load(object sender, EventArgs e)
        {

        }
    }
}
