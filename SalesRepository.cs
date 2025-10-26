using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ElectronicShopManagement
{
    public class SalesRepository:ProductForSellModel
    {
        public static List<SalesRepository> report=new List<SalesRepository>();
        static SalesRepository()
        {
            report.Add(new SalesRepository
            {
                Categories = "Power Bank",
                ID = "P001",
                Name = "RAVPower 10000mAh",
                SellQty = 2,
                Prices = 1.50m,
                Amount = 3.00m,
                totalAmount = 3.00m,
                date = DateTime.UtcNow.AddDays(-1).ToString("yyyy/MM/dd"),
                Cashier = "Theany"
            });

            report.Add(new SalesRepository
            {
                Categories = "Power Bank",
                ID = "P002",
                Name = "Xiaomi Mi Power Bank 20000",
                SellQty = 3,
                Prices = 0.80m,
                Amount = 2.40m,
                totalAmount = 5.40m,
                date = DateTime.UtcNow.AddDays(-1).ToString("yyyy/MM/dd"),
                Cashier = "Theany"
            });

            report.Add(new SalesRepository
            {
                Categories = "Power Bank",
                ID = "P003",
                Name = "Anker PowerCore 10000",
                SellQty = 1,
                Prices = 1.40m,
                Amount = 1.40m,
                totalAmount = 6.80m,
                date = DateTime.UtcNow.AddDays(-2).ToString("yyyy/MM/dd"),
                Cashier = "Theany"
            });

            report.Add(new SalesRepository
            {
                Categories = "Charger",
                ID = "P004",
                Name = "Samsung Fast Charger",
                SellQty = 4,
                Prices = 0.75m,
                Amount = 3.00m,
                totalAmount = 9.80m,
                date = DateTime.UtcNow.AddDays(-3).ToString("yyyy/MM/dd"),
                Cashier = "Theany"
            });

            report.Add(new SalesRepository
            {
                Categories = "Charger",
                ID = "P005",
                Name = "Anker 20W Charger",
                SellQty = 2,
                Prices = 2.00m,
                Amount = 4.00m,
                totalAmount = 13.80m,
                date = DateTime.UtcNow.AddDays(-4).ToString("yyyy/MM/dd"),
                Cashier = "Theany"
            });
        }


        // ទិន្នន័យលក់ទាំងអស់រក្សាទុកក្នុង memory
        //// ព្រឹត្តិការណ៍ប្រើសម្រាប់ notify UI
        public static event Action DataChanged;

        public static void AddSale(SalesRepository item)
        {
            report.Add(item);
            DataChanged?.Invoke();
        }

        //public static void AddSaleRange(IEnumerable<ProductForSellModel> items)
        //{
        //    //foreach (var it in items)
        //        report.Add(SalesRepository);
        //    DataChanged?.Invoke();

        //}

        public static IEnumerable<ProductForSellModel> GetByDateRange(DateTime from, DateTime to)
        {
            return report.Where(s =>
                DateTime.TryParse(s.date, out var d) &&
                d.Date >= from.Date && d.Date <= to.Date);
        }
    }
}
