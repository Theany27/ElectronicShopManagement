using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ElectronicShopManagement.Forms
{
    public partial class Products_Stock : Form
    {
        // Static list for sharing data with other forms
        public static List<ProductsModel> SharedProducts = new List<ProductsModel>();

        private List<ProductsModel> filteredProducts;

        public Products_Stock()
        {
            InitializeComponent();
            // Manually wire up all events
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            // Remove existing events first to avoid duplicates
            textBox1.TextChanged -= textBox1_TextChanged;
            comboBox1.SelectedIndexChanged -= comboBox1_SelectedIndexChanged;
            button1.Click -= button1_Click;
            button2.Click -= button2_Click;
            button3.Click -= button3_Click;
            tblproductstock.SelectionChanged -= tblproductstock_SelectionChanged;

            // Add events
            textBox1.TextChanged += textBox1_TextChanged;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            tblproductstock.SelectionChanged += tblproductstock_SelectionChanged;
        }

        private void Products_Stock_Load(object sender, EventArgs e)
        {
            InitializeForm();
            tblproductstock.DataSource = filteredProducts;
            ClearFormForAdd(); // Start with clean form for adding
        }

        private void InitializeForm()
        {
            // Initialize the shared list if it's empty
            if (SharedProducts.Count == 0)
            {
                SharedProducts = ProductData.GetProducts().ToList();
            }

            filteredProducts = new List<ProductsModel>();
            LoadProducts();
            SetupComboBoxes();
        }

        private void LoadProducts()
        {
            filteredProducts = SharedProducts.ToList();
        }

        private void SetupComboBoxes()
        {
            var categories = SharedProducts.Select(p => p.Category).Distinct().ToList();

            comboBox1.Items.Clear();
            comboBox1.Items.Add("All Categories");
            comboBox1.Items.AddRange(categories.ToArray());
            comboBox1.SelectedIndex = 0;

            comboboxcategory.Items.Clear();
            comboboxcategory.Items.AddRange(categories.ToArray());
            if (comboboxcategory.Items.Count > 0)
                comboboxcategory.SelectedIndex = 0;
        }

        //========== EVENT HANDLERS ==========

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddProduct();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateProduct();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteProduct();
        }

        private void tblproductstock_SelectionChanged(object sender, EventArgs e)
        {
            LoadSelectedProductData();
        }

        // Other event handlers that exist in designer
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtproid_TextChanged(object sender, EventArgs e) { }

        // ========== CORE FUNCTIONALITY ==========

        private void AddProduct()
        {
            try
            {
                if (ValidateInputs())
                {
                    string newId = txtproid.Text.Trim();

                    // Check if Product ID already exists
                    if (SharedProducts.Any(p => p.ProductID.Equals(newId, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("Product ID already exists! Please use a different ID.", "Error");
                        txtproid.Focus();
                        return;
                    }

                    var newProduct = new ProductsModel
                    {
                        ProductID = newId,
                        Category = comboboxcategory.SelectedItem?.ToString(),
                        ProductName = txtproname.Text.Trim(),
                        Price = decimal.Parse(txtproprice.Text),
                        StockQuantity = int.Parse(txtproqty.Text)
                    };

                    // Add to shared list
                    SharedProducts.Add(newProduct);

                    // Update filteredProducts to include the new product
                    filteredProducts = SharedProducts.ToList();

                    RefreshDataGridView();
                    ClearFormForAdd();
                    UpdateCategoryComboBoxes();

                    MessageBox.Show("Product added successfully! Now available in the sales system.", "Success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product: {ex.Message}", "Error");
            }
        }

        private void UpdateProduct()
        {
            try
            {
                if (tblproductstock.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a product to update.", "Information");
                    return;
                }

                if (ValidateInputs())
                {
                    var selectedRow = tblproductstock.SelectedRows[0];
                    string oldId = selectedRow.Cells["ProductID"].Value.ToString();
                    string newId = txtproid.Text.Trim();

                    // If ID changed, check if new ID exists
                    if (oldId != newId && SharedProducts.Any(p => p.ProductID.Equals(newId, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("Product ID already exists! Please use a different ID.", "Error");
                        txtproid.Focus();
                        return;
                    }

                    // Find and update the product in shared data
                    var productToUpdate = SharedProducts.FirstOrDefault(p => p.ProductID == oldId);
                    if (productToUpdate != null)
                    {
                        productToUpdate.ProductID = newId;
                        productToUpdate.Category = comboboxcategory.SelectedItem?.ToString();
                        productToUpdate.ProductName = txtproname.Text.Trim();
                        productToUpdate.Price = decimal.Parse(txtproprice.Text);
                        productToUpdate.StockQuantity = int.Parse(txtproqty.Text);
                    }

                    // Refresh filteredProducts to show updated data
                    filteredProducts = SharedProducts.ToList();

                    RefreshDataGridView();
                    ClearFormForAdd();

                    MessageBox.Show("Product updated successfully! Changes applied to sales system.", "Success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product: {ex.Message}", "Error");
            }
        }

        private void DeleteProduct()
        {
            try
            {
                if (tblproductstock.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a product to delete.", "Information");
                    return;
                }

                var selectedRow = tblproductstock.SelectedRows[0];
                string productId = selectedRow.Cells["ProductID"].Value.ToString();
                string productName = selectedRow.Cells["ProductName"].Value.ToString();

                var result = MessageBox.Show(
                    $"Are you sure you want to delete '{productName}'?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Remove from both lists
                    SharedProducts.RemoveAll(p => p.ProductID == productId);

                    // Update filteredProducts to remove the deleted product
                    filteredProducts = SharedProducts.ToList();

                    RefreshDataGridView();
                    ClearFormForAdd();
                    UpdateCategoryComboBoxes();

                    MessageBox.Show("Product deleted successfully! Removed from sales system.", "Success");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}", "Error");
            }
        }

        private void LoadSelectedProductData()
        {
            try
            {
                if (tblproductstock.SelectedRows.Count > 0)
                {
                    var selectedRow = tblproductstock.SelectedRows[0];

                    // Check if the row has data (not a header or empty row)
                    if (selectedRow.Cells["ProductID"].Value != null)
                    {
                        // Load data from selected row into textboxes
                        txtproid.Text = selectedRow.Cells["ProductID"].Value?.ToString() ?? "";
                        txtproname.Text = selectedRow.Cells["ProductName"].Value?.ToString() ?? "";
                        txtproprice.Text = selectedRow.Cells["Price"].Value?.ToString() ?? "";
                        txtproqty.Text = selectedRow.Cells["StockQuantity"].Value?.ToString() ?? "";

                        // Set the category in combobox
                        string category = selectedRow.Cells["Category"].Value?.ToString() ?? "";
                        if (!string.IsNullOrEmpty(category) && comboboxcategory.Items.Contains(category))
                        {
                            comboboxcategory.SelectedItem = category;
                        }
                        else if (comboboxcategory.Items.Count > 0)
                        {
                            comboboxcategory.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product data: {ex.Message}", "Error");
            }
        }

        private void FilterProducts()
        {
            try
            {
                string searchText = textBox1.Text.ToLower();
                string selectedCategory = comboBox1.SelectedItem?.ToString();

                filteredProducts = SharedProducts.Where(p =>
                    (string.IsNullOrEmpty(searchText) ||
                     p.ProductName.ToLower().Contains(searchText) ||
                     p.ProductID.ToLower().Contains(searchText)) &&
                    (selectedCategory == "All Categories" || p.Category == selectedCategory)
                ).ToList();

                RefreshDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering products: {ex.Message}", "Error");
            }
        }

        private void RefreshDataGridView()
        {
            tblproductstock.DataSource = null;
            tblproductstock.DataSource = filteredProducts;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtproid.Text))
            {
                MessageBox.Show("Please enter Product ID.", "Validation Error");
                txtproid.Focus();
                return false;
            }

            if (comboboxcategory.SelectedItem == null)
            {
                MessageBox.Show("Please select a category.", "Validation Error");
                comboboxcategory.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtproname.Text))
            {
                MessageBox.Show("Please enter Product Name.", "Validation Error");
                txtproname.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtproprice.Text))
            {
                MessageBox.Show("Please enter Product Price.", "Validation Error");
                txtproprice.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtproqty.Text))
            {
                MessageBox.Show("Please enter Product Quantity.", "Validation Error");
                txtproqty.Focus();
                return false;
            }

            if (!decimal.TryParse(txtproprice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price (greater than 0).", "Validation Error");
                txtproprice.Focus();
                txtproprice.SelectAll();
                return false;
            }

            if (!int.TryParse(txtproqty.Text, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Please enter a valid quantity (0 or greater).", "Validation Error");
                txtproqty.Focus();
                txtproqty.SelectAll();
                return false;
            }

            return true;
        }

        private void ClearFormForAdd()
        {
            txtproid.Clear();
            txtproname.Clear();
            txtproprice.Clear();
            txtproqty.Clear();

            if (comboboxcategory.Items.Count > 0)
                comboboxcategory.SelectedIndex = 0;

            tblproductstock.ClearSelection();
            txtproid.Focus(); // Set focus to Product ID for new entry
        }

        private void UpdateCategoryComboBoxes()
        {
            try
            {
                var categories = SharedProducts.Select(p => p.Category).Distinct().ToList();

                comboBox1.Items.Clear();
                comboBox1.Items.Add("All Categories");
                comboBox1.Items.AddRange(categories.ToArray());
                comboBox1.SelectedIndex = 0;

                comboboxcategory.Items.Clear();
                comboboxcategory.Items.AddRange(categories.ToArray());
                if (comboboxcategory.Items.Count > 0)
                    comboboxcategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating categories: {ex.Message}", "Error");
            }
        }
    }
}