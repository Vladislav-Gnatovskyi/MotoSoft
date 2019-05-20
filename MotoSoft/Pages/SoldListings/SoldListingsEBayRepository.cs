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
            IEnumerable<ItemType> items = await ServiceProvider.Instance.EbayService.GetSellerListAsync(ListingStatusCodeType.Active);
            foreach (ItemType item in items)
            {
                list.Add(new SoldListingsModel
                {
                    ItemID = item.ItemID,
                    QTY = item.Quantity,
                    SalePrice = item.StartPrice.Value,
                    CustomLabel = item.SubTitle,
                    Title = item.Title,
                    Date = item.ScheduleTime,
                    CostOfItem = item.StartPrice.Value,
                    //ProductName = item.ProductListingDetails
                });
            }
            return list;
        }
    }
}
