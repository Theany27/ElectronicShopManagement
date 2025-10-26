namespace ElectronicShopManagement.Forms
{
    partial class Report
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
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dvgShowData = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnreload = new System.Windows.Forms.Button();
            this.btndate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgShowData)).BeginInit();
            this.SuspendLayout();
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(128, 71);
            this.dtFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(265, 22);
            this.dtFrom.TabIndex = 0;
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(524, 71);
            this.dtTo.Margin = new System.Windows.Forms.Padding(4);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(265, 22);
            this.dtTo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(36, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 26);
            this.label3.TabIndex = 23;
            this.label3.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(467, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 26);
            this.label1.TabIndex = 24;
            this.label1.Text = "To";
            // 
            // dvgShowData
            // 
            this.dvgShowData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgShowData.Location = new System.Drawing.Point(16, 167);
            this.dvgShowData.Margin = new System.Windows.Forms.Padding(4);
            this.dvgShowData.Name = "dvgShowData";
            this.dvgShowData.RowHeadersWidth = 51;
            this.dvgShowData.Size = new System.Drawing.Size(1396, 357);
            this.dvgShowData.TabIndex = 25;
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(1124, 545);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(173, 36);
            this.btnExport.TabIndex = 32;
            this.btnExport.Text = "Export to PDF";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnreload
            // 
            this.btnreload.Location = new System.Drawing.Point(871, 66);
            this.btnreload.Margin = new System.Windows.Forms.Padding(4);
            this.btnreload.Name = "btnreload";
            this.btnreload.Size = new System.Drawing.Size(100, 28);
            this.btnreload.TabIndex = 33;
            this.btnreload.Text = "Reload";
            this.btnreload.UseVisualStyleBackColor = true;
            this.btnreload.Click += new System.EventHandler(this.btnreload_Click);
            // 
            // btndate
            // 
            this.btndate.Location = new System.Drawing.Point(1068, 66);
            this.btndate.Margin = new System.Windows.Forms.Padding(4);
            this.btndate.Name = "btndate";
            this.btndate.Size = new System.Drawing.Size(100, 28);
            this.btndate.TabIndex = 34;
            this.btndate.Text = "Filter Date";
            this.btndate.UseVisualStyleBackColor = true;
            this.btndate.Click += new System.EventHandler(this.btndate_Click);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1625, 786);
            this.Controls.Add(this.btndate);
            this.Controls.Add(this.btnreload);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dvgShowData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.dtFrom);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Report";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dvgShowData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dvgShowData;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnreload;
        private System.Windows.Forms.Button btndate;
    }
}