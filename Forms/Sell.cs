using kh.gov.nbc.bakong_khqr.model;
using kh.gov.nbc.bakong_khqr;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net.Http;


namespace ElectronicShopManagement.Forms
{
    public partial class Sell : Form
    {
        public static List<ProductForSellModel> products = new List<ProductForSellModel>();
        public static List<ProductForSellModel> LastInvoice = new List<ProductForSellModel>();
        public static event Action<List<ProductForSellModel>> InvoiceCreated;
        public static List<RecentSell> RecentProducts = new List<RecentSell>();


        public Sell()
        {
            InitializeComponent();

            //tblshowproductsell.Refresh();
            //tblshowproductsell.DataSource = products;
            //tblshowproductsell.Columns["totalAmount"].Visible = false;
            //tblshowproductsell.Columns["ID"].Visible = false;
            //tblshowproductsell.Columns["date"].Visible = false;


            var selectedCategory = Products_Stock.SharedProducts;
            

            var categories = selectedCategory.Select(p => p.Category).Distinct().ToList();
            comboboxsell.DataSource = categories;
            comboboxsell.SelectedIndexChanged += comboboxsell_SelectedIndexChanged;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var minusPro = Products_Stock.SharedProducts.FirstOrDefault(p => p.ProductName == comboboxsellproname.Text);

            if (combocashier.SelectedItem == null)
            { 
                MessageBox.Show("Please select Cashier name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (minusPro.StockQuantity < Convert.ToInt32(txtsellqty.Text))
            {
                MessageBox.Show("Not enough stock available!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ProductForSellModel productsModel = new ProductForSellModel()
            {

                Categories = comboboxsell.SelectedItem.ToString(),
                ID = comboboxsellproname.SelectedValue.ToString(),
                Cashier=combocashier.SelectedItem.ToString(),
                Name = comboboxsellproname.Text,
                Prices = Convert.ToDecimal(txtsellprice.Text),
                SellQty = Convert.ToInt32(txtsellqty.Text),
                date = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"),

            };
            
            products.Add(productsModel);
            
            minusPro.StockQuantity -= Convert.ToInt32(txtsellqty.Text);
            productsModel.Amount = productsModel.Prices * productsModel.SellQty;
            productsModel.totalAmount = products.Sum(p => p.Prices * p.SellQty);
            txtamount.Text = productsModel.totalAmount.ToString("0.00");

            txtsellqty.Text = "1";



            tblshowproductsell.DataSource = null;
            tblshowproductsell.DataSource = products;
            //tblshowproductsell.Refresh();
            tblshowproductsell.Columns["totalAmount"].Visible = false;
            tblshowproductsell.Columns["ID"].Visible = false;
            tblshowproductsell.Columns["date"].Visible = false;
            //tblshowproductsell.Columns["Cashier"].Visible = false;

        }

        private  async Task CheckPaymentAsync(string md5)
        {
            var client = new HttpClient();
            var url = "https://api-bakong.nbc.gov.kh/v1/check_transaction_by_md5";
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJkYXRhIjp7ImlkIjoiZTI4NzY2YjAxMDA4NGI2ZiJ9LCJpYXQiOjE3NTg3ODg2MjUsImV4cCI6MTc2NjU2NDYyNX0.rfqbEiwVn-VzpxTecK7lHea20c-Bv48T2kkuC0N0Mjc";
            var startTime = DateTime.Now;
            var timeout = TimeSpan.FromMinutes(1);


            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            while (DateTime.Now - startTime < timeout)
            {
                var json = $"{{ \"md5\": \"{md5}\" }}";
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();
                //Console.WriteLine($"[{DateTime.Now}] Response: {result}");

                if (result.Contains("Success"))
                {
                    var dialogResult = MessageBox.Show(
                        "Payment Successful!",
                        "Bakong KHQR",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        
                    );
                    
                    if (dialogResult == DialogResult.OK)
                     {
                        Invoice invoice = new Invoice();
                        invoice.Show();

                        foreach (Form f in Application.OpenForms)
                        {
                        if (f is BakongKhqr)
                        {
                            f.Close();
                            break;
                        }
                    }
                        var data = products;
                        var recentData = data.Select(p => new RecentSell
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
                        RecentProducts.AddRange(recentData);
                        products.Clear();

                        tblshowproductsell.DataSource = null;
                        tblshowproductsell.DataSource = products; // rebind
                        tblshowproductsell.Columns["totalAmount"].Visible = false;
                        tblshowproductsell.Columns["ID"].Visible = false;
                        tblshowproductsell.Columns["date"].Visible = false;
                        tblshowproductsell.Columns["Cashier"].Visible = false;
                        txtamount.Text = "0.00";
                    }
                    break;
                }

                await Task.Delay(5000); // wait 5 seconds
            }
        }
        private async void btnpayment_Click(object sender, EventArgs e)
        {
            decimal totalAmount = products.Sum(p => p.Prices * p.SellQty);



            DateTime now = DateTime.UtcNow;
            long millisecondsSinceEpoch = (long)(now - new DateTime(1970, 1, 1)).TotalMilliseconds;

            long expirationTimestamp = millisecondsSinceEpoch + 3600000;
            var response = BakongKHQR.GenerateIndividual(
                new IndividualInfo
                {
                    BakongAccountID = "khoeurn_rotheany1@aclb",
                    MerchantName = "Rotheany Khoeurn",
                    Currency = KHQRCurrency.KHR,
                    Amount = Convert.ToInt32(totalAmount),
                    MerchantCity = "PHNOM PENH",
                    BillNumber = "#12345",
                    MobileNumber = "855969884476",
                    StoreLabel = "Electronic Shop",
                    TerminalLabel = "Cashier_1",
                    ExpirationTimestamp = expirationTimestamp
                }
            );

            

            string qrText = response.Data.QR;
            string md5 = response.Data.MD5;
            //generate qr code
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(10);

            //pop up qr code
            BakongKhqr bakong = new BakongKhqr(qrCodeImage, totalAmount);
            bakong.Show();

            //call fuction Check payment
            await CheckPaymentAsync(md5);
            

            //it loops all form if BakongKhqr close
            foreach (Form f in Application.OpenForms)
            {
                if (f is BakongKhqr)
                {
                    MessageBox.Show("Payment not completed within 1 minutes.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    f.Close();
                    break;
                }
            }
        }

        private void comboboxsellproname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboboxsellproname.SelectedItem != null)
            {
                var selectedProduct = comboboxsellproname.SelectedItem as ProductsModel;

                if (selectedProduct != null)
                {
                    txtsellprice.Text = selectedProduct.Price.ToString("0.00");
                }
            }
        }

        private void comboboxsell_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedName = comboboxsell.SelectedItem.ToString();
            var products = Products_Stock.SharedProducts
                                      .Where(p => p.Category == selectedName)
                                      .ToList();


            comboboxsellproname.DisplayMember = "ProductName"; // Show Name
            comboboxsellproname.ValueMember = "ProductID";     // Store ID
            comboboxsellproname.DataSource = products;
            comboboxsellproname.SelectedIndexChanged += comboboxsellproname_SelectedIndexChanged;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var minusPro = Products_Stock.SharedProducts.FirstOrDefault(p => p.ProductName == comboboxsellproname.Text);
            minusPro.StockQuantity += products.Sum(p => p.SellQty);
            MessageBox.Show("Are you sure to cancel this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tblshowproductsell.CurrentRow != null)
            {
                var selectedProduct = tblshowproductsell.CurrentRow.DataBoundItem as ProductForSellModel;
                if (selectedProduct != null)
                {
                    products.Remove(selectedProduct);

                    tblshowproductsell.DataSource = null;     // reset
                    tblshowproductsell.DataSource = products;
                    tblshowproductsell.Columns["totalAmount"].Visible = false;
                    tblshowproductsell.Columns["ID"].Visible = false;
                    tblshowproductsell.Columns["date"].Visible = false;
                    tblshowproductsell.Columns["Cashier"].Visible = false;

                }
            }
            else
            {
                MessageBox.Show("Please select a valid row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (products.Count == 0)
                txtamount.Text = "0.00";
            else
                txtamount.Text = products.Sum(p => p.Amount).ToString("0.00");
        }

        private void Sell_Load(object sender, EventArgs e)
        {
        }

        private void txtamount_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tblshowproductsell.DataSource=null;
            tblshowproductsell.DataSource=products;
        }
    }
}

