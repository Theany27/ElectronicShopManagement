namespace ElectronicShopManagement.Forms
{
    partial class Products_Stock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toplabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtproid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboboxcategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtproname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtproprice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtproqty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tblproductstock = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tblproductstock)).BeginInit();
            this.SuspendLayout();
            // 
            // toplabel
            // 
            this.toplabel.AutoSize = true;
            this.toplabel.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toplabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toplabel.Location = new System.Drawing.Point(302, 82);
            this.toplabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.toplabel.Name = "toplabel";
            this.toplabel.Size = new System.Drawing.Size(201, 31);
            this.toplabel.TabIndex = 8;
            this.toplabel.Text = "Search Products";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(508, 78);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(349, 26);
            this.textBox1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(990, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 31);
            this.label1.TabIndex = 10;
            this.label1.Text = "Filter by Category";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1214, 77);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(192, 28);
            this.comboBox1.TabIndex = 11;
            // 
            // txtproid
            // 
            this.txtproid.Location = new System.Drawing.Point(508, 289);
            this.txtproid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtproid.Name = "txtproid";
            this.txtproid.Size = new System.Drawing.Size(192, 26);
            this.txtproid.TabIndex = 13;
            this.txtproid.TextChanged += new System.EventHandler(this.txtproid_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(303, 291);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 31);
            this.label2.TabIndex = 12;
            this.label2.Text = "Product Id";
            // 
            // comboboxcategory
            // 
            this.comboboxcategory.FormattingEnabled = true;
            this.comboboxcategory.Items.AddRange(new object[] {
            "s",
            "fs",
            "sfs",
            "s"});
            this.comboboxcategory.Location = new System.Drawing.Point(508, 200);
            this.comboboxcategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboboxcategory.Name = "comboboxcategory";
            this.comboboxcategory.Size = new System.Drawing.Size(192, 28);
            this.comboboxcategory.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(303, 203);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 31);
            this.label3.TabIndex = 14;
            this.label3.Text = "Category";
            // 
            // txtproname
            // 
            this.txtproname.Location = new System.Drawing.Point(508, 374);
            this.txtproname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtproname.Name = "txtproname";
            this.txtproname.Size = new System.Drawing.Size(192, 26);
            this.txtproname.TabIndex = 17;
            this.txtproname.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(303, 375);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 31);
            this.label4.TabIndex = 16;
            this.label4.Text = "Product Name";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtproprice
            // 
            this.txtproprice.Location = new System.Drawing.Point(1054, 200);
            this.txtproprice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtproprice.Name = "txtproprice";
            this.txtproprice.Size = new System.Drawing.Size(192, 26);
            this.txtproprice.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(849, 202);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 31);
            this.label5.TabIndex = 18;
            this.label5.Text = "Product Price";
            // 
            // txtproqty
            // 
            this.txtproqty.Location = new System.Drawing.Point(1054, 292);
            this.txtproqty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtproqty.Name = "txtproqty";
            this.txtproqty.Size = new System.Drawing.Size(192, 26);
            this.txtproqty.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(849, 294);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(215, 31);
            this.label6.TabIndex = 20;
            this.label6.Text = "Product Quantity";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(855, 357);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 48);
            this.button1.TabIndex = 22;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1054, 357);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 48);
            this.button2.TabIndex = 23;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1248, 357);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(159, 48);
            this.button3.TabIndex = 24;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // tblproductstock
            // 
            this.tblproductstock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tblproductstock.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tblproductstock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblproductstock.Location = new System.Drawing.Point(18, 442);
            this.tblproductstock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tblproductstock.Name = "tblproductstock";
            this.tblproductstock.RowHeadersWidth = 62;
            this.tblproductstock.Size = new System.Drawing.Size(1690, 623);
            this.tblproductstock.TabIndex = 25;
            // 
            // Products_Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1810, 1050);
            this.Controls.Add(this.tblproductstock);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtproqty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtproprice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtproname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboboxcategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtproid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.toplabel);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Products_Stock";
            this.Text = "Products Stock";
            this.Load += new System.EventHandler(this.Products_Stock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblproductstock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label toplabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtproid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboboxcategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtproname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtproprice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtproqty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView tblproductstock;
    }
}