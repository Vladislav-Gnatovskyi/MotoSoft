using eBay.Service.Core.Soap;
using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoSoft.Data.Repository.eBay
{
    class LotAnalyticsSheetEBayRepository : ISheetRepository<LotAnalyticSheet>
    {
        public IList<LotAnalyticSheet> GetSheet()
        {
            IList<LotAnalyticSheet> list = new List<LotAnalyticSheet>();
            ItemType[] items = ServiceProvider.Instance.eBayService.GetSellerList();

            foreach (var item in items)
            {
                list.Add(new LotAnalyticSheet
                {
                    
                });
            }
            return list;
        }
    }
}
