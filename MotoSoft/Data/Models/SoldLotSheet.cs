using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoSoft.Data.Models
{
    public class SoldLotSheet
    {
        public int ITEM_ID { get; set; }
        public DateTime DATE { get; set; }
        public int SALES_RECORD_NUMBER { get; set; }
        public string ITEM_TITLE { get; set; }
        public string CUSTOM_LABEL { get; set; }
        public string PRODUCT_NAME { get; set; }
        public int QTY { get; set; }
        public double SALE_PRICE { get; set; }
        public int SHIPPING_CHARGED { get; set; }
        public double GROSS_SALES { get; set; }
        public double COST_OF_ITEM { get; set; }
        public double SHIPPING_COST { get; set; }
        public double eBAY_FEES { get; set; }
        public double PAYPAL_FEES { get; set; }
        public double COST { get; set; }
        public double GAIN { get; set; }
        public double SALES_TAX { get; set; }
        public double ITEM_eBAY_FEES { get; set; }

    }
}
