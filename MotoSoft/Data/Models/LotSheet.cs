using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoSoft.Data.Models
{
    public class LotSheet
    {
        public int LOT { get; set; }
        public string TYPE { get; set; }
        public DateTime DATE { get; set; }
        public string MAKE { get; set; }
        public string MODEL { get; set; }
        public int YEAR { get; set; }
        public int MILEAGE { get; set; }
        public string NOTES { get; set; }
        public string TITLE { get; set; }
        public string BOS { get; set; }
        public int COST { get; set; }
        public string PROFIT { get; set; }
        public string PARTS_ACTIVE { get; set; }
        public int PARTS_SOLD { get; set; }
        public string STATUS { get; set; }
    }
}
