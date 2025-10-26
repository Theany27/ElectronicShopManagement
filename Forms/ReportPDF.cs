using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ElectronicShopManagement.Forms
{
    public partial class ReportPDF : Form
    {
        private List<ProductForSellModel> reportList;
        private DateTime fromDate;
        private DateTime toDate;
        private string cashierName;

        public ReportPDF(List<ProductForSellModel> filteredProducts, DateTime from, DateTime to, string cashier)
        {
            InitializeComponent();
            reportList = filteredProducts;
            fromDate = from;
            toDate = to;
            cashierName = cashier;
        }

        private void ReportPDF_Load(object sender, EventArgs e)
        {
            // ✅ បើចង់យកពី shared repository តែម្ដង
            if (reportList == null || reportList.Count == 0)
                reportList = SalesRepository.GetByDateRange(fromDate, toDate).ToList();

            ReportDataSource rds = new ReportDataSource("ReportProduct", reportList);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            ReportParameter[] parameters =
            {
                new ReportParameter("FromDate" , fromDate.ToString("dd/MM/yyyy")),
                new ReportParameter("ToDate" , toDate.ToString("dd/MM/yyyy")),
                new ReportParameter("Cashier" , cashierName),
                new ReportParameter("PrintDate",DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))
            };

            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.RefreshReport();
        }
    }
}
