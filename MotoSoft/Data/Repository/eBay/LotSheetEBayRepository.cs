using MotoSoft.Data.Models;
using eBay.Service.Core.Soap;
using System.Collections.Generic;
using MotoSoft.Data.Repository.Interfaces;
using System.Threading.Tasks;

namespace MotoSoft.Data.Repository.eBay
{
    class LotSheetEBayRepository : ISheetRepository<LotSheet>
    {
        public IList<LotSheet> GetSheet()
        {
            IList<LotSheet> list = new List<LotSheet>();
            IEnumerable<ItemType> items = ServiceProvider.Instance.eBayService.GetSellerList(ListingStatusCodeType.Completed);

            foreach (ItemType item in items)
            {
                list.Add(new LotSheet
                {
                    TITLE = item.Title,
                    STATUS = item.SellingStatus.ListingStatus.ToString(),
                    COST = item.ReservePrice.Value,
                    DATE = item.ScheduleTime,
                    LOT = item.ItemID,
                    NOTES = item.eBayNotes,
                    PARTS_SOLD = item.ItemCompatibilityCount,
                    TYPE = item.ListingType.ToString(),
                });
            }                
            return list;
        }

        public async Task<IList<LotSheet>> GetSheetAsync()
        {
            IList<LotSheet> list = new List<LotSheet>();
            IEnumerable<ItemType> items = await ServiceProvider.Instance.eBayService.GetSellerListAsync(ListingStatusCodeType.Completed);
            foreach (ItemType item in items)
            {
                list.Add(new LotSheet
                {
                    TITLE = item.Title,
                    STATUS = item.SellingStatus.ListingStatus.ToString(),
                    COST = item.ReservePrice.Value,
                    DATE = item.ScheduleTime,
                    LOT = item.ItemID,
                    NOTES = item.eBayNotes,
                    PARTS_SOLD = item.ItemCompatibilityCount,
                    TYPE = item.ListingType.ToString(),
                });
            }
            return list;
        }
    }
}
