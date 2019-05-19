using eBay.Service.Core.Soap;
using MotoSoft.Frameworks;
using MotoSoft.Frameworks.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoSoft.Pages.ActiveListings
{
    class ActiveListingsEBayRepository : ISheetRepository<ActiveListingsModel>
    {
        public async Task<IList<ActiveListingsModel>> GetSheetAsync()
        {
            IList<ActiveListingsModel> list = new List<ActiveListingsModel>();
            IEnumerable<ItemType> items = await ServiceProvider.Instance.EbayService.GetSellerListAsync(ListingStatusCodeType.Active);
            foreach (ItemType x in items)
            {
                list.Add(new ActiveListingsModel
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
