using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ElectronicShopManagement.Forms
{
    public partial class Home : Form
    {
        // Low stock threshold (<= 20 is "low")
        private const int LOW_STOCK_LIMIT = 20;
        public static List<RecentSell> RecentProducts = new List<RecentSell>();

        public Home()
        {
            InitializeComponent();

            Products_Stock.InventoryChanged -= OnInventoryChanged;
            Products_Stock.InventoryChanged += OnInventoryChanged;

            Sell.InvoiceCreated -= OnInvoiceCreated;
            Sell.InvoiceCreated += OnInvoiceCreated;

            panel3.Cursor = Cursors.Hand;
            label4.Cursor = Cursors.Hand;
            label5.Cursor = Cursors.Hand;
            panel3.Click += (s, e) => ShowLowStockList();
            label4.Click += (s, e) => ShowLowStockList();
            label5.Click += (s, e) => ShowLowStockList();


            this.Shown += (s, e) =>
            {
                RefreshProductsStockCount();
                RefreshLowStockCount();

                // โหลดประวัติที่มีอยู่ + อัปเดตเลขครั้งแรก
                BindInvoiceToHome(Sell.LastInvoice ?? new List<ProductForSellModel>());
                RefreshSellHistoriesCount();
                //if (Sell.LastInvoice != null && Sell.LastInvoice.Count > 0)
                //    BindInvoiceToHome(Sell.LastInvoice);
            };


            this.FormClosed += (s, e) =>
            {
                Products_Stock.InventoryChanged -= OnInventoryChanged;
                Sell.InvoiceCreated -= OnInvoiceCreated;
            };
        }

        private void OnInventoryChanged()
        {
            RefreshProductsStockCount();
            RefreshLowStockCount();
        }

        private List<ProductsModel> CurrentProducts()
        {
            return (Products_Stock.SharedProducts != null && Products_Stock.SharedProducts.Count > 0)
                ? Products_Stock.SharedProducts
                : (Products_Stock.SharedProducts = ProductData.GetProducts()?.ToList()
                    ?? new List<ProductsModel>());
        }

        private void RefreshProductsStockCount()
        {
            var src = CurrentProducts();
            int totalProducts = src.Count;
            label2.Text = totalProducts.ToString();
        }

        private void RefreshLowStockCount()
        {
            var src = CurrentProducts();
            int lowCount = src.Count(p => p.StockQuantity <= LOW_STOCK_LIMIT);
            label4.Text = lowCount.ToString();
        }

        private void ShowLowStockList()
        {
            var items = CurrentProducts()
                .Where(p => p.StockQuantity <= LOW_STOCK_LIMIT)
                .Select(p => new
                {
                    p.ProductID,
                    p.ProductName,
                    p.Category,
                    p.Price,
                    p.StockQuantity
                })
                .ToList();

            if (items.Count == 0)
            {
                MessageBox.Show($"No items at or below {LOW_STOCK_LIMIT}.", "Low Stock");
                return;
            }

            var dlg = new Form
            {
                Text = $"Low Stock (≤ {LOW_STOCK_LIMIT})",
                StartPosition = FormStartPosition.CenterParent,
                Size = new Size(800, 400),
                MinimizeBox = false,
                MaximizeBox = false
            };

            var grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoGenerateColumns = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                DataSource = items
            };

            dlg.Controls.Add(grid);
            dlg.ShowDialog(this);
        }

        // ======= Sell Histories: อัปเดตเลขในการ์ด panel1 =======
        private void RefreshSellHistoriesCount()
        {
            // นับจำนวน "รายการประวัติการขาย"
            int count = Sell.RecentProducts.Count;

            // หา label ที่เป็นตัวเลขภายใน panel1 (การ์ด Sell Histries)
            Label lbl = panel1.Controls.OfType<Label>()
                .FirstOrDefault(l => int.TryParse(l.Text.Trim(), out _));

            // ถ้าออกแบบมาไม่ใช่ตัวเลขตั้งต้น ให้ fallback เป็น label ที่ฟอนต์ใหญ่สุดใน panel1
            if (lbl == null)
            {
                lbl = panel1.Controls.OfType<Label>()
                    .OrderByDescending(l => l.Font.Size)
                    .FirstOrDefault();
            }

            if (lbl != null) lbl.Text = count.ToString();
        }

        private void OnInvoiceCreated(List<ProductForSellModel> items)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() =>
                {
                    BindInvoiceToHome(items);
                    RefreshSellHistoriesCount();
                }));
            }
            else
            {
                BindInvoiceToHome(items);
                RefreshSellHistoriesCount();
            }
        }


        private void BindInvoiceToHome(List<ProductForSellModel> items)
        {
            tblrecentsell.AutoGenerateColumns = true;
            tblrecentsell.DataSource = null;
            tblrecentsell.DataSource = Sell.RecentProducts; // สำคัญ
           // tblrecentsell.DataSource = items;
            tblrecentsell.Refresh();
            tblrecentsell.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tblrecentsell.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            foreach (DataGridViewColumn col in tblrecentsell.Columns)
            {
                col.FillWeight = 1;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        }



        private void label1_Click(object sender, EventArgs e) { }

        private void Home_Load(object sender, EventArgs e)
        {
            tblrecentsell.DataSource = null;
            tblrecentsell.DataSource =Sell.RecentProducts;
            tblrecentsell.Refresh();

            RefreshProductsStockCount();
            RefreshLowStockCount();

            if (Sell.LastInvoice != null && Sell.LastInvoice.Count > 0)
                BindInvoiceToHome(Sell.LastInvoice);

            if (tblrecentsell.Columns.Contains("ID"))
                tblrecentsell.Columns["ID"].Visible = false;

        }

        private void tblrecentsell_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
