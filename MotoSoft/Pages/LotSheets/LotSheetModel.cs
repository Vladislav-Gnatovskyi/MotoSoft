using MotoSoft.Pages.LotSheets.Vehicle;
using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace MotoSoft.Pages.LotSheets
{
    public class LotSheetsModel
    {
        private int _lot = 10000;
        #region UserAddingField
        public int Lot
        {
            get => _lot;
            set
            {
                _lot = value >= 10000 ? value : 10000 + value;
            }
        }
        public LotSheetsModel()
        {
            DatePublic = DateTime.Now;
        }

        public ETypeVehicle Type { get; set; }
        public DateTime DatePublic { get; set; }
        public string Date { get => $"{DatePublic.Day}-{DatePublic.Month}-{DatePublic.Year}"; }
        public string Make { get; set; } = "";
        public string Model { get; set; } = "";
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string Notes { get; set; } = "";
        public string Title { get; set; }
        public string Bos { get; set; }
        public double Cost { get; set; }

        public BitmapImage GetImage(string path)
        {
            BitmapImage image = new BitmapImage();
            if (Title != null && File.Exists(path))
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = stream;
                    image.EndInit();
                }
            }
            return image;
        }
        #endregion UserAddingField

        public double eBayFees { get; set; }
        public double PayPalFees { get; set; }
        public double ShippingFees { get; set; }
        public double TotalCost { get => Cost + eBayFees + PayPalFees + ShippingFees;  }
        public double TotalSales { get; set; }
        public double NetProfit { get => TotalSales - TotalCost; }
        public double ActiveUnSold { get; set; }
        public string Profit { get; set; }
        public int PartsActive { get; set; }
        public int PartsSold { get; set; }
        public string Status { get; set; } = "";
    }
}
