using eBay.Service.Core.Soap;
using MotoSoft.Data.eBay;
using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MotoSoft.Data.Repository.eBay
{
    class ActiveListingsEBayRepository : ISheetRepository<ActiveListings>
    {
        public IList<ActiveListings> GetSheet()
        {
            IList<ActiveListings> list = new List<ActiveListings>();
            List<ItemType> orders = new EbayApiService().GetSellerList().ToList();
            orders.ForEach(x =>
            {
                list.Add(new ActiveListings
                {
                    ITEM_ID = x.ItemID,
                    LISTING_TYPE = x.ListingType.ToString(),
                    PRICE = x.StartPrice.Value,
                    START_TIME = x.ScheduleTime.ToString(),
                    TITLE = x.Title,
                    URL = x.VINLink,
                    CUSTOM_LABEL = x.SubTitle,
                    QTY = 0
                });
            });
            return list;
        }
    }
}
