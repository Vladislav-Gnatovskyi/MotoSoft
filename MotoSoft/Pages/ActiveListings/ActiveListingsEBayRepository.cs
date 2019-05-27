using eBay.Service.Core.Soap;
using MotoSoft.Frameworks;
using MotoSoft.Frameworks.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoSoft.Pages.ActiveListings
{
    class ActiveListingsEbayRepository : ISheetRepository<ActiveListingsModel>
    {
        public bool AddNewItem(ActiveListingsModel item)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<ActiveListingsModel>> GetSheetAsync()
        {
            IList<ActiveListingsModel> list = new List<ActiveListingsModel>();
            IEnumerable<ItemType> items = await ServiceProvider.Instance.EbayService.GetSellerListAsync(ListingStatusCodeType.Active);
            foreach (ItemType x in items)
            {
                list.Add(new ActiveListingsModel
                {
                    ItemId = x.ItemID,
                    ListingType = x.ListingType.ToString(),
                    Price = x.StartPrice.Value,
                    StartTime = x.ScheduleTime.ToString(),
                    Title = x.Title,
                    Url = x.VINLink,
                    CustomLabel = x.SubTitle,
                    Quantity = x.Quantity
                });
            }
            return list;
        }
    }
}
