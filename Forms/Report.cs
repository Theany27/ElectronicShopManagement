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
            dvgShowData.DataSource=getReport;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            // បើមានលក់ថ្មី → refresh
            SalesRepository.DataChanged += RefreshData;

            // បើអ្នកប្តូរថ្ងៃ From / To → refresh

            // load ដំបូង
            RefreshData();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnreload_Click(object sender, EventArgs e)
        {
            RefreshData();

        }

        private void btndate_Click(object sender, EventArgs e)
        {
            var from = dtFrom.Value.Date;
            var to = dtTo.Value.Date;

            // ទាញទិន្នន័យតាមថ្ងៃពី Repository
            var list = SalesRepository.GetByDateRange(from, to).ToList();

            if (list.Count == 0)
            {
                // បើគ្មានទិន្នន័យ Clear grid
                dvgShowData.DataSource = null;
                dvgShowData.Rows.Clear();

                MessageBox.Show(
                    $"No sales data found between {from:dd/MM/yyyy} and {to:dd/MM/yyyy}",
                    "No Data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            // បើមានទិន្នន័យ បង្ហាញវា
            dvgShowData.DataSource = null;
            dvgShowData.DataSource = list;

            // Optional: គណនាសរុប
            int totalQty = list.Sum(p => p.SellQty);
            decimal totalAmount = list.Sum(p => p.totalAmount);

            MessageBox.Show(
                $"✅ Filtered {list.Count} records\n" +
                $"Total Quantity: {totalQty}\n" +
                $"Total Amount: {totalAmount:0.00} $",
                "Filter Result",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var from = dtFrom.Value.Date;
            var to = dtTo.Value.Date;

            var filtered = SalesRepository.GetByDateRange(from, to).ToList();

            if (filtered.Count == 0)
            {
                MessageBox.Show("No sales data found in this date range.",
                                "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string cashier = filtered.First().Cashier;
            ReportPDF frm = new ReportPDF(filtered, from, to, cashier);
            frm.ShowDialog();
        }
        private void RefreshData()
        {
            var from = dtFrom.Value.Date;
            var to = dtTo.Value.Date;

            // ទាញទិន្នន័យតាមថ្ងៃពី Repository
            var list = SalesRepository.GetByDateRange(from, to).ToList();

            // បើគ្មានទិន្នន័យក្នុង range
            if (list == null || list.Count == 0)
            {
                // ✅ Clear DataGridView
                dvgShowData.DataSource = null;
                dvgShowData.Rows.Clear();

                // ✅ បង្ហាញសារ
                MessageBox.Show(
                    $"No sales data found between {from:dd/MM/yyyy} and {to:dd/MM/yyyy}",
                    "No Data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            // ✅ បើមានទិន្នន័យ បង្ហាញវា
            dvgShowData.DataSource = null;
            dvgShowData.DataSource = list;

            // Optional: គណនាសរុប
            int totalQty = list.Sum(p => p.SellQty);
            decimal totalAmount = list.Sum(p => p.totalAmount);

            Console.WriteLine($"Total Qty: {totalQty}, Total Amount: {totalAmount}");
        }
    }
}
