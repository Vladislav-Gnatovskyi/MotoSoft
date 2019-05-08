using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;

namespace MotoSoft.Data.Interfaces
{
    public interface IEBayApiService
    {
        UserType GetUser { get; }
        ApiContext GetApiContext { get; }
        ItemType[] GetSellerList();
        OrderTypeCollection GetOrdersCall(TimeFilter timeFilter, TradingRoleCodeType tradingRole, OrderStatusCodeType orderStatus);
    }
}
