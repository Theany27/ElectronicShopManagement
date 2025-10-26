using System;
using System.Linq;
using System.Windows.Forms;

namespace ElectronicShopManagement.Forms
{
    public partial class Report : Form
    {

        public Report()
        {
            InitializeComponent();
        }
        private void btnreload_Click(object sender, EventArgs e)
        {
            var list = SalesRepository.report.ToList();

            if (list.Count == 0)
            {
                MessageBox.Show("⚠️ No sales data available!",
                                "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dvgShowData.DataSource = null;
            dvgShowData.DataSource = list;
            dvgShowData.Columns["totalAmount"].Visible = false;
            dvgShowData.Columns["ID"].Visible = false;


            int totalQty = list.Sum(p => p.SellQty);
            decimal totalAmount = list.Sum(p => p.Prices * p.SellQty);
            labeltotalamounreport.Text = $"{Convert.ToString(totalAmount)}$";



            MessageBox.Show($"✅ Found {list.Count} sale records\n" +
                            $"Total Quantity: {totalQty}\n" +
                            $"Total Amount: {totalAmount:0.00} $",
                            "All Sales Data",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

        }

        private void btndate_Click(object sender, EventArgs e)
        {
            var from = dtFrom.Value.Date;
            var to = dtTo.Value.Date;

            var list = SalesRepository.GetByDateRange(from, to).ToList();

            //if (list.Count == 0)
            //{
            //    dvgShowData.DataSource = null;
            //    dvgShowData.Rows.Clear();

            //    MessageBox.Show(
            //        $"No sales data found between {from:dd/MM/yyyy} and {to:dd/MM/yyyy}",
            //        "No Data",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Information
            //    );
            //    return;
            //}

            dvgShowData.DataSource = null;
            dvgShowData.DataSource = list;
            dvgShowData.Columns["totalAmount"].Visible = false;
            dvgShowData.Columns["ID"].Visible = false;


            int totalQty = list.Sum(p => p.SellQty);
            decimal totalAmount = list.Sum(p => p.Prices * p.SellQty);


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

        private void Report_Load_1(object sender, EventArgs e)
        {
            // បើមានលក់ថ្មី → refresh
            SalesRepository.DataChanged += RefreshData;

            // បើអ្នកប្តូរថ្ងៃ From / To → refresh

            // load ដំបូង
            RefreshData();
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

            // Optional: គណនាសរុប
            int totalQty = list.Sum(p => p.SellQty);
            decimal totalAmount = list.Sum(p => p.Prices * p.SellQty);
            labeltotalamounreport.Text = $"{Convert.ToString(totalAmount)}$";
            // ✅ បើមានទិន្នន័យ បង្ហាញវា
            dvgShowData.DataSource = null;
            dvgShowData.DataSource = list;
            dvgShowData.Columns["totalAmount"].Visible = false;
            dvgShowData.Columns["ID"].Visible = false;

           


            //Console.WriteLine($"Total Qty: {totalQty}, Total Amount: {totalAmount}");
        }
    }
}
