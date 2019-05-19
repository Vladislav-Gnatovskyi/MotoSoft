using eBay.Service.Core.Soap;
using System.Collections.Generic;
using System.Threading.Tasks;
using MotoSoft.Frameworks.Pages;
using MotoSoft.Frameworks;

namespace MotoSoft.Pages.LotSheets
{
    class LotSheetEBayRepository : ISheetRepository<LotSheetsModel>
    {
        public IList<LotSheetsModel> GetSheet()
        {
            IList<LotSheetsModel> list = new List<LotSheetsModel>();
            IEnumerable<ItemType> items = ServiceProvider.Instance.EbayService.GetSellerList(ListingStatusCodeType.Completed);

            foreach (ItemType item in items)
            {
                list.Add(new LotSheetsModel
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

        public async Task<IList<LotSheetsModel>> GetSheetAsync()
        {
            IList<LotSheetsModel> list = new List<LotSheetsModel>();
            IEnumerable<ItemType> items = await ServiceProvider.Instance.EbayService.GetSellerListAsync(ListingStatusCodeType.Completed);
            foreach (ItemType item in items)
            {
                list.Add(new LotSheetsModel
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
