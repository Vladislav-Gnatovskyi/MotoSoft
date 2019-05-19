using eBay.Service.Core.Soap;
using MotoSoft.Frameworks;
using MotoSoft.Frameworks.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoSoft.Pages.SoldListings
{
    class SoldListingsEBayRepository : ISheetRepository<SoldListingsModel>
    {
        public async Task<IList<SoldListingsModel>> GetSheetAsync()
        {
            IList<SoldListingsModel> list = new List<SoldListingsModel>();
            IEnumerable<ItemType> items = await ServiceProvider.Instance.EbayService.GetSellerListAsync(ListingStatusCodeType.Completed);
            foreach (ItemType item in items)
            {
                list.Add(new SoldListingsModel
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
