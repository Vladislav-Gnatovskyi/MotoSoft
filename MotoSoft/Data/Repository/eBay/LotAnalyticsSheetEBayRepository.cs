using eBay.Service.Core.Soap;
using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoSoft.Data.Repository.eBay
{
    class LotAnalyticsSheetEBayRepository : ISheetRepository<LotAnalyticSheet>
    {
        public IList<LotAnalyticSheet> GetSheet()
        {
            IList<LotAnalyticSheet> list = new List<LotAnalyticSheet>();
            IEnumerable<ItemType> items = ServiceProvider.Instance.eBayService.GetSellerList(ListingStatusCodeType.Active);

            foreach (var item in items)
            {
                list.Add(new LotAnalyticSheet
                {
                    
                });
            }
            return list;
        }

        public Task<IList<LotAnalyticSheet>> GetSheetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
