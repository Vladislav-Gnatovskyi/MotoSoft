using eBay.Service.Core.Soap;
using MotoSoft.Frameworks;
using MotoSoft.Frameworks.Pages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoSoft.Pages.SoldListings
{
    class SoldListingsEBayRepository : ISheetRepository<SoldListingsModel>
    {
        public event EventHandler DataChanged;

        public bool AddNewItem(SoldListingsModel item)
        {
            throw new NotImplementedException();
        }

        public bool EditItem(SoldListingsModel NewItem, string OldItem)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<SoldListingsModel>> GetSheetAsync()
        {
            IList<SoldListingsModel> list = new List<SoldListingsModel>();
            IEnumerable<ItemType> items = await ServiceProvider.Instance.EbayService.GetSellerListAsync(ListingStatusCodeType.Completed);
            foreach (ItemType item in items)
            {
                list.Add(new SoldListingsModel
                {
                    ItemID = item.ItemID,
                    QTY = item.SellingStatus.QuantitySold,
                    SalePrice = item.SellingStatus.CurrentPrice.Value,
                    CustomLabel = item.SubTitle,
                    Title = item.Title,
                    Date = item.ScheduleTime.Date,
                    CostOfItem = item.StartPrice.Value,
                    COST = item.SellingStatus.QuantitySold * item.StartPrice.Value,
                    eBayFees = item.SellingStatus.FinalValueFee != null ? item.SellingStatus.FinalValueFee.Value : 0.0,
                    PAYPALFees = item.ShippingDetails != null 
                    ? item.ShippingDetails.SalesTax != null 
                    ? item.ShippingDetails.SalesTax.SalesTaxAmount != null 
                    ? item.ShippingDetails.SalesTax.SalesTaxAmount.Value : 0.0 : 0.0 : 0.0,
                    ProductName = item.ProductListingDetails?.DetailsURL
                }); ;
            }
            return list;
        }

        public bool Remove(SoldListingsModel item)
        {
            throw new NotImplementedException();
        }

        public void Save(IList sheet)
        {
            throw new NotImplementedException();
        }
    }
}
