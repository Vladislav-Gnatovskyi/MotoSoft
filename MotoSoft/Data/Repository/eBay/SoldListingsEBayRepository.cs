using eBay.Service.Core.Soap;
using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoSoft.Data.Repository.eBay
{
    class SoldListingsEBayRepository : ISheetRepository<SoldListings>
    {
        public IList<SoldListings> GetSheet()
        {
            IList<SoldListings> list = new List<SoldListings>();
            IEnumerable<ItemType> items = ServiceProvider.Instance.eBayService.GetSellerList(ListingStatusCodeType.Ended);

            foreach (ItemType item in items)
            {
                list.Add(new SoldListings
                {
                    ITEM_ID = item.ItemID,
                    COST = item.ItemCompatibilityCount,
                    CUSTOM_LABEL = item.SubTitle,
                    ITEM_TITLE = item.Title,
                    DATE = item.ScheduleTime,
                });
            }
            return list;
        }

        public async Task<IList<SoldListings>> GetSheetAsync()
        {
            IList<SoldListings> list = new List<SoldListings>();
            IEnumerable<ItemType> items = await ServiceProvider.Instance.eBayService.GetSellerListAsync(ListingStatusCodeType.Completed);
            foreach (ItemType item in items)
            {
                list.Add(new SoldListings
                {
                    ITEM_ID = item.ItemID,
                    COST = item.ItemCompatibilityCount,
                    CUSTOM_LABEL = item.SubTitle,
                    ITEM_TITLE = item.Title,
                    DATE = item.ScheduleTime,
                });
            }
            return list;
        }
    }
}
