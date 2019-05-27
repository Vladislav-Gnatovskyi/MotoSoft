using System;

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
                _lot = value > 10000 ? value : 10000 + value;
            }
        }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string Notes { get; set; }
        public string Title { get; set; }
        public string Bos { get; set; }
        public double Cost { get; set; }
        #endregion UserAddingField

        public double eBayFees { get; set; }
        public double PayPalFees { get; set; }
        public double ShippingFees { get; set; }
        public double TotalCost { get; set; }
        public double TotalSales { get; set; }
        public double NetProfit { get => TotalSales - TotalCost; }
        public double ActiveUnSold { get; set; }
        public string Profit { get; set; }
        public int PartsActive { get; set; }
        public int PartsSold { get; set; }
        public string Status { get; set; }
    }
}
