using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoSoft.Data.Models
{
    public class ActiveLotSheet
    {
        public int ITEM_ID { get; set; }
        public string CUSTOM_LABEL { get; set; }
        public int QTY { get; set; }
        public decimal PRICE { get; set; }
        public DateTime START_TIME { get; set; }
        public string LISTING_TYPE { get; set; }
        public string TITLE { get; set; }
        public string URL { get; set; }
    }
}
