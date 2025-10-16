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
using DevExpress.XtraLayout.Filtering.Templates;

namespace ElectronicShopManagement.Forms
{
    public partial class Sell : Form
    {
        public static List<ProductForSellModel> products = new List<ProductForSellModel>();
        

        public Sell()
        {
            InitializeComponent();
            var selectedCategory = ProductData.GetProducts();

            var categories = selectedCategory.Select(p => p.Category).Distinct().ToList();
            comboboxsell.DataSource = categories;
            comboboxsell.SelectedIndexChanged += comboboxsell_SelectedIndexChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (combocashier.SelectedItem == null)
            {
                MessageBox.Show("Please select Cashier name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            

            productsModel.Amount = productsModel.Prices * productsModel.SellQty;
            productsModel.totalAmount = products.Sum(p => p.Prices * p.SellQty);
            txtamount.Text = productsModel.totalAmount.ToString("0.00");

            txtsellqty.Text = "1";

           

            tblshowproductsell.DataSource = null;
            tblshowproductsell.DataSource = products;
            tblshowproductsell.Columns["totalAmount"].Visible = false;
            tblshowproductsell.Columns["ID"].Visible = false;
            tblshowproductsell.Columns["date"].Visible = false;
            tblshowproductsell.Columns["Cashier"].Visible = false;

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
                        //products.Clear();
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

            //Invoice invoice = new Invoice();
            //invoice.Show();
            //products.Clear();

            //generate qr code
            string qrText = response.Data.QR;
            string md5 = response.Data.MD5;

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(10);

            //pop up qr code
            BakongKhqr bakong = new BakongKhqr(qrCodeImage, totalAmount);
            bakong.Show();

            //call fuction Check payment
            await CheckPaymentAsync(md5);
            


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
            var products = ProductData.GetProducts()
                                      .Where(p => p.Category == selectedName)
                                      .ToList();


            comboboxsellproname.DisplayMember = "ProductName"; // Show Name
            comboboxsellproname.ValueMember = "ProductID";     // Store ID
            comboboxsellproname.DataSource = products;
            comboboxsellproname.SelectedIndexChanged += comboboxsellproname_SelectedIndexChanged;
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
    }
}

