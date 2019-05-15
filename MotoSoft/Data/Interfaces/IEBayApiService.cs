using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;

namespace MotoSoft.Data.Interfaces
{
    public interface IEBayApiService
    {
        UserType GetUser { get; }
        ApiContext GetApiContext { get; }
        ItemTypeCollection GetSellerList();
        OrderTypeCollection GetOrdersCall(TimeFilter timeFilter, TradingRoleCodeType tradingRole, OrderStatusCodeType orderStatus);
        string AddItem(string title, string description, string catecoryID, double price, string UUID, string location = "US", int DispathTimeMax = 7);
    }
}
