using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoSoft.Frameworks.Ebay
{
    public interface IEbayApiService
    {
        UserType GetUser { get; }
        ApiContext GetApiContext { get; }
        IEnumerable<ItemType> GetSellerList(ListingStatusCodeType status);
        Task<IEnumerable<ItemType>> GetSellerListAsync(ListingStatusCodeType status);
        Task<OrderTypeCollection> GetOrdersCallAsync();
        OrderTypeCollection GetOrdersCall();
    }
}
