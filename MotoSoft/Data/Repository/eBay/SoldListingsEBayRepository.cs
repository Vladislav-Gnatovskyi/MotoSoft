using eBay.Service.Core.Soap;
using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.Interfaces;
using System.Collections.Generic;

namespace MotoSoft.Data.Repository.eBay
{
    class SoldListingsEBayRepository : ISheetRepository<SoldListings>
    {
        public IList<SoldListings> GetSheet()
        {
            IList<SoldListings> list = new List<SoldListings>();
            ItemType[] items = ServiceProvider.Instance.eBayService.GetSellerList();

            foreach (var item in items)
            {
                list.Add(new SoldListings
                {
                    ITEM_ID = item.ItemID,
                    COST = item.ItemCompatibilityCount,
                    CUSTOM_LABEL = item.SubTitle,
                    ITEM_TITLE = item.Title,
                    DATE = item.ScheduleTime,
                    SALES_RECORD_NUMBER = item.BestOfferDetails.BestOfferCount,
                    SHIPPING_COST = item.ShippingDetails.DefaultShippingCost.Value,
                });
            }
            return list;
        }
    }
}
