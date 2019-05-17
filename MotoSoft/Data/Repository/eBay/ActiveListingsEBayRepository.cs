using eBay.Service.Core.Soap;
using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoSoft.Data.Repository.eBay
{
    class ActiveListingsEBayRepository : ISheetRepository<ActiveListings>
    {
        public IList<ActiveListings> GetSheet()
        {
            IList<ActiveListings> list = new List<ActiveListings>();
            IEnumerable<ItemType> items = ServiceProvider.Instance.eBayService.GetSellerList(ListingStatusCodeType.Active);
            foreach (ItemType x in items)
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
            }
            return list;
        }

        public async Task<IList<ActiveListings>> GetSheetAsync()
        {
            IList<ActiveListings> list = new List<ActiveListings>();
            IEnumerable<ItemType> items = await ServiceProvider.Instance.eBayService.GetSellerListAsync(ListingStatusCodeType.Active);
            foreach (ItemType x in items)
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
            }
            return list;
        }
    }
}
