using eBay.Service.Core.Soap;
using MotoSoft.Frameworks;
using MotoSoft.Frameworks.Pages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoSoft.Pages.ActiveListings
{
    class ActiveListingsEbayRepository : ISheetRepository<ActiveListingsModel>
    {
        public ActiveListingsEbayRepository()
        {
        }

        public event EventHandler DataChanged;

        public async Task<IList<ActiveListingsModel>> GetSheetAsync()
        {
            IList<ActiveListingsModel> list = new List<ActiveListingsModel>();
            IEnumerable<ItemType> items = await ServiceProvider.Instance.EbayService.GetSellerListAsync(ListingStatusCodeType.Active);
            foreach (ItemType item in items)
            {
                list.Add(new ActiveListingsModel
                {
                    ItemId = item.ItemID,
                    ListingType = item.ListingType.ToString(),
                    Price = item.StartPrice.Value,
                    StartTime = item.ScheduleTime.ToString(),
                    Title = item.Title,
                    Url = item.Storefront?.StoreURL,
                    CustomLabel = item.SubTitle,
                    Quantity = item.Quantity - item.SellingStatus.QuantitySold
                });
            }
            return list;
        }

        public bool Remove(ActiveListingsModel item)
        {
            throw new NotImplementedException();
        }

        public void Save(IList sheet)
        {
            throw new NotImplementedException();
        }

        public bool AddNewItem(ActiveListingsModel item)
        {
            throw new NotImplementedException();
        }

        public bool EditItem(ActiveListingsModel NewItem, string OldItem)
        {
            throw new NotImplementedException();
        }
    }
}
