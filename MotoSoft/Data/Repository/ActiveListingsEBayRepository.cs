using eBay.Service.Core.Soap;
using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MotoSoft.Data.Repository
{
    class ActiveListingsEBayRepository : ISheetRepository<ActiveListings>
    {
        public IList<ActiveListings> GetSheet()
        {
            IList<ActiveListings> list = new List<ActiveListings>();
            OrderTypeCollection orders = new EbayApiService().GetOrdersCall(new TimeFilter(new DateTime(2019, 1, 1), DateTime.Now), TradingRoleCodeType.Buyer, OrderStatusCodeType.All);
            for (int i = 0; i < orders.Count; i++)
            {
                list.Add(new ActiveListings
                {
                    CUSTOM_LABEL = orders[i].Any.ItemAt(0).LocalName,
                    ITEM_ID = orders[i].OrderID,
                    LISTING_TYPE = orders[i].LogisticsPlanType.ToList().FirstOrDefault().ToString(),
                    PRICE = orders[i].Total.Value,
                    QTY = orders[i].AdjustmentAmount.Value,
                    START_TIME = orders[i].PaidTime.ToLongDateString(),
                    TITLE = orders[i].Any.ItemAt(0).Name,
                    URL = orders[i].Any.ItemAt(0).BaseURI,
                });
            }
            return list;
        }

        public void Save(IList<ActiveListings> sheet)
        {
            throw new NotImplementedException();
        }
    }
}
