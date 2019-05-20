using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoSoft.Pages.SoldListings
{
    public class SoldListingsModel
    {
        public string ItemID { get; set; }
        public DateTime Date { get; set; }
        public int SalesRecordNumber { get; set; }
        public string Title { get; set; }
        public string CustomLabel { get; set; }
        public string ProductName { get; set; }
        public int QTY { get; set; }
        public double SalePrice { get; set; }
        public int ShippingChanged { get; set; }
        public double GrossSales { get; set; }
        public double CostOfItem { get; set; }
        public double ShippingCost { get; set; }
        public double eBayFees { get; set; }
        public double PAYPALFees { get; set; }
        public double COST { get; set; }
        public double GAIN { get; set; }
        public double SalesTax { get; set; }
        public double ItemeBayFees { get; set; }

    }
}
