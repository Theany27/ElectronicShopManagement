using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicShopManagement
{
    public static class ProductData
    {
        public static List<ProductsModel> GetProducts()
        {
            // FIRST check if Products_Stock has shared data
            try
            {
                // Check if the SharedProducts list exists and has data
                if (Forms.Products_Stock.SharedProducts != null &&
                    Forms.Products_Stock.SharedProducts.Count > 0)
                {
                    return Forms.Products_Stock.SharedProducts.ToList();
                }
            }
            catch
            {
                // If Products_Stock hasn't been loaded yet, continue to original data
            }

            //  Fallback to original data if no shared data exists
            return new List<ProductsModel>
            {
                new ProductsModel { ProductID = "PB001", ProductName = "Anker PowerCore 10000", Category = "Power Bank", Price = 29.99m, StockQuantity = 50 },
                new ProductsModel { ProductID = "PB002", ProductName = "Xiaomi Mi Power Bank 20000", Category = "Power Bank", Price = 25.50m, StockQuantity = 40 },
                new ProductsModel { ProductID = "PB003", ProductName = "RAVPower 10000mAh", Category = "Power Bank", Price = 27.99m, StockQuantity = 35 },
                new ProductsModel { ProductID = "PB004", ProductName = "Baseus 20000mAh", Category = "Power Bank", Price = 23.99m, StockQuantity = 60 },
                new ProductsModel { ProductID = "PB005", ProductName = "AUKEY 10000mAh", Category = "Power Bank", Price = 21.99m, StockQuantity = 25 },

                new ProductsModel { ProductID = "CH001", ProductName = "Samsung Fast Charger", Category = "Charger", Price = 15.00m, StockQuantity = 100 },
                new ProductsModel { ProductID = "CH002", ProductName = "Anker 20W Charger", Category = "Charger", Price = 18.50m, StockQuantity = 80 },
                new ProductsModel { ProductID = "CH003", ProductName = "Xiaomi 33W Charger", Category = "Charger", Price = 16.99m, StockQuantity = 75 },
                new ProductsModel { ProductID = "CH004", ProductName = "Baseus Quick Charger", Category = "Charger", Price = 17.49m, StockQuantity = 60 },
                new ProductsModel { ProductID = "CH005", ProductName = "Apple 20W Charger", Category = "Charger", Price = 19.99m, StockQuantity = 50 },

                new ProductsModel { ProductID = "CB001", ProductName = "Anker USB-C Cable", Category = "Cable", Price = 9.99m, StockQuantity = 200 },
                new ProductsModel { ProductID = "CB002", ProductName = "Baseus Lightning Cable", Category = "Cable", Price = 8.50m, StockQuantity = 180 },
                new ProductsModel { ProductID = "CB003", ProductName = "UGREEN USB-C Cable", Category = "Cable", Price = 7.99m, StockQuantity = 160 },
                new ProductsModel { ProductID = "CB004", ProductName = "Samsung Type-C Cable", Category = "Cable", Price = 6.99m, StockQuantity = 150 },
                new ProductsModel { ProductID = "CB005", ProductName = "Apple Lightning Cable", Category = "Cable", Price = 14.99m, StockQuantity = 140 },

                new ProductsModel { ProductID = "HS001", ProductName = "Sony WH-1000XM4", Category = "Headset", Price = 299.99m, StockQuantity = 20 },
                new ProductsModel { ProductID = "HS002", ProductName = "Bose QuietComfort 35 II", Category = "Headset", Price = 279.99m, StockQuantity = 15 },
                new ProductsModel { ProductID = "HS003", ProductName = "JBL Tune 500BT", Category = "Headset", Price = 49.99m, StockQuantity = 50 },
                new ProductsModel { ProductID = "HS004", ProductName = "Anker Soundcore Life Q20", Category = "Headset", Price = 59.99m, StockQuantity = 35 },
                new ProductsModel { ProductID = "HS005", ProductName = "Apple AirPods Pro", Category = "Headset", Price = 249.99m, StockQuantity = 25 },

                new ProductsModel { ProductID = "SP001", ProductName = "JBL Flip 5", Category = "Speaker", Price = 99.99m, StockQuantity = 40 },
                new ProductsModel { ProductID = "SP002", ProductName = "Anker Soundcore 2", Category = "Speaker", Price = 49.99m, StockQuantity = 60 },
                new ProductsModel { ProductID = "SP003", ProductName = "Sony SRS-XB23", Category = "Speaker", Price = 129.99m, StockQuantity = 30 },
                new ProductsModel { ProductID = "SP004", ProductName = "Bose SoundLink Micro", Category = "Speaker", Price = 119.99m, StockQuantity = 20 },
                new ProductsModel { ProductID = "SP005", ProductName = "Marshall Emberton", Category = "Speaker", Price = 149.99m, StockQuantity = 25 },

                new ProductsModel { ProductID = "MC001", ProductName = "Logitech MX Master 3", Category = "Mouse", Price = 99.99m, StockQuantity = 45 },
                new ProductsModel { ProductID = "MC002", ProductName = "Razer DeathAdder V2", Category = "Mouse", Price = 69.99m, StockQuantity = 50 },
                new ProductsModel { ProductID = "MC003", ProductName = "SteelSeries Rival 600", Category = "Mouse", Price = 79.99m, StockQuantity = 35 },
                new ProductsModel { ProductID = "MC004", ProductName = "Microsoft Surface Mouse", Category = "Mouse", Price = 59.99m, StockQuantity = 40 },
                new ProductsModel { ProductID = "MC005", ProductName = "Apple Magic Mouse 2", Category = "Mouse", Price = 79.99m, StockQuantity = 30 }
            };
        }
        public static List<ProductForSellModel> GetProductsSold()
        {
            return new List<ProductForSellModel>
    {
        new ProductForSellModel { Categories="Power Bank", ID="PB001", Name="Anker PowerCore 10000", SellQty=10, Prices=29.99m, totalAmount=10*29.99m, date="10/01/2025", Cashier="Mr.PheakTra" },
        new ProductForSellModel { Categories="Power Bank", ID="PB002", Name="Xiaomi 20000mAh", SellQty=8, Prices=25.50m, totalAmount=8*25.50m, date="10/02/2025", Cashier="Mr.PheakTra" },
        new ProductForSellModel { Categories="Power Bank", ID="PB003", Name="RAVPower 10000", SellQty=5, Prices=27.99m, totalAmount=5*27.99m, date="10/03/2025", Cashier="Mr.PheakTra" },
        new ProductForSellModel { Categories="Power Bank", ID="PB004", Name="Baseus 20000mAh", SellQty=12, Prices=23.99m, totalAmount=12*23.99m, date="10/04/2025", Cashier="Mr.Dara" },
        new ProductForSellModel { Categories="Power Bank", ID="PB005", Name="AUKEY 10000mAh", SellQty=9, Prices=21.99m, totalAmount=9*21.99m, date="10/05/2025", Cashier="Mr.Dara" },

        new ProductForSellModel { Categories="Charger", ID="CH001", Name="Samsung Fast Charger", SellQty=5, Prices=15.00m, totalAmount=5*15.00m, date="10/06/2025", Cashier="Mr.PheakTra" },
        new ProductForSellModel { Categories="Charger", ID="CH002", Name="Anker 20W Charger", SellQty=7, Prices=18.50m, totalAmount=7*18.50m, date="10/07/2025", Cashier="Mr.PheakTra" },
        new ProductForSellModel { Categories="Charger", ID="CH003", Name="Xiaomi 33W Charger", SellQty=4, Prices=16.99m, totalAmount=4*16.99m, date="10/08/2025", Cashier="Mr.PheakTra" },
        new ProductForSellModel { Categories="Charger", ID="CH004", Name="Baseus Quick Charger", SellQty=6, Prices=17.49m, totalAmount=6*17.49m, date="10/09/2025", Cashier="Mr.Dara" },
        new ProductForSellModel { Categories="Charger", ID="CH005", Name="Apple 20W Charger", SellQty=3, Prices=19.99m, totalAmount=3*19.99m, date="10/10/2025", Cashier="Mr.Dara" },

        new ProductForSellModel { Categories="Cable", ID="CB001", Name="Anker USB-C Cable", SellQty=15, Prices=9.99m, totalAmount=15*9.99m, date="10/11/2025", Cashier="Mr.PheakTra" },
        new ProductForSellModel { Categories="Cable", ID="CB002", Name="Baseus Lightning Cable", SellQty=10, Prices=8.50m, totalAmount=10*8.50m, date="10/12/2025", Cashier="Mr.PheakTra" },
        new ProductForSellModel { Categories="Cable", ID="CB003", Name="UGREEN USB-C Cable", SellQty=8, Prices=7.99m, totalAmount=8*7.99m, date="10/13/2025", Cashier="Mr.Dara" },
        new ProductForSellModel { Categories="Cable", ID="CB004", Name="Samsung Type-C Cable", SellQty=9, Prices=6.99m, totalAmount=9*6.99m, date="10/14/2025", Cashier="Mr.Dara" },
        new ProductForSellModel { Categories="Cable", ID="CB005", Name="Apple Lightning Cable", SellQty=11, Prices=14.99m, totalAmount=11*14.99m, date="10/15/2025", Cashier="Mr.Dara" },

        new ProductForSellModel { Categories="Headset", ID="HS001", Name="Sony WH-1000XM4", SellQty=2, Prices=299.99m, totalAmount=2*299.99m, date="10/16/2025", Cashier="Mr.PheakTra" },
        new ProductForSellModel { Categories="Headset", ID="HS002", Name="Bose QC 35 II", SellQty=3, Prices=279.99m, totalAmount=3*279.99m, date="10/17/2025", Cashier="Mr.PheakTra" },
        new ProductForSellModel { Categories="Headset", ID="HS003", Name="JBL Tune 500BT", SellQty=4, Prices=49.99m, totalAmount=4*49.99m, date="10/18/2025", Cashier="Mr.Dara" },
        new ProductForSellModel { Categories="Headset", ID="HS004", Name="Anker Soundcore Q20", SellQty=5, Prices=59.99m, totalAmount=5*59.99m, date="10/19/2025", Cashier="Mr.Dara" },
        new ProductForSellModel { Categories="Headset", ID="HS005", Name="Apple AirPods Pro", SellQty=2, Prices=249.99m, totalAmount=2*249.99m, date="10/20/2025", Cashier="Mr.Dara" },
    };
        }

    }
}