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
    public partial class Home : Form
    {

        public Home()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            var data = Sell.products;
            var recentData = data.Select(p => new ProductForSellModel
            {
                Name = p.Name,
                Prices = p.Prices,
                SellQty = p.SellQty,
                totalAmount = p.totalAmount,
                Cashier = p.Cashier,
                date = p.date,
                Amount = p.Amount,
                Categories = p.Categories
            }).ToList();


            tblrecentsell.DataSource = null;
            tblrecentsell.DataSource = recentData;
            tblrecentsell.Refresh();
        }
    }
}
