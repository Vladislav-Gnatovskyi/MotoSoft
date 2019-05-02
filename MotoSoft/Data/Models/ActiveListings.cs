using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoSoft.Data.Models
{
    public class ActiveListings
    {
        public string ITEM_ID { get; set; }
        public string CUSTOM_LABEL { get; set; }
        public double QTY { get; set; }
        public double PRICE { get; set; }
        public string START_TIME { get; set; }
        public string LISTING_TYPE { get; set; }
        public string TITLE { get; set; }
        public string URL { get; set; }
    }
}
