using System;

namespace MotoSoft.Pages.Analytics
{
    public class AnalyticsModel
    {
        public int LotID { get; set; }
        public int Type { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string Notes { get; set; }
        public int TitleStatus { get; set; }
        public string BillOfSale { get; set; }
        public int PartsActive { get; set; }
        public int PartsSold { get; set; }
        public int LotCost { get; set; }
        public double eBayFees { get; set; }
        public double PayPalFees { get; set; }
        public double SnippingFees { get; set; }
        public double TotalCost { get; set; }
        public double TotalSales { get; set; }
        public double NetProfit { get; set; }
        public string ActiveUnSold { get; set; }
    }
}
