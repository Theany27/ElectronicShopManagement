using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ElectronicShopManagement
{
    public static class SalesRepository
    {
        // ទិន្នន័យលក់ទាំងអស់រក្សាទុកក្នុង memory
        public static BindingList<ProductForSellModel> Sales { get; } = new BindingList<ProductForSellModel>();

        // ព្រឹត្តិការណ៍ប្រើសម្រាប់ notify UI
        public static event Action DataChanged;

        public static void AddSale(ProductForSellModel item)
        {
            Sales.Add(item);
            DataChanged?.Invoke();
        }

        public static void AddSaleRange(IEnumerable<ProductForSellModel> items)
        {
            foreach (var it in items)
                Sales.Add(it);
            DataChanged?.Invoke();
        }

        public static IEnumerable<ProductForSellModel> GetByDateRange(DateTime from, DateTime to)
        {
            return Sales.Where(s =>
                DateTime.TryParse(s.date, out var d) &&
                d.Date >= from.Date && d.Date <= to.Date);
        }
    }
}
