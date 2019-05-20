using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoSoft.Frameworks.Ebay
{
    class FakeEbayService : IEbayApiService
    {
        public UserType GetUser => throw new NotImplementedException();

        public ApiContext GetApiContext => throw new NotImplementedException();

        public bool CheckToken => throw new NotImplementedException();

        public string AddItem(string title, string description, string catecoryID, double price, string UUID, string location = "US", int DispathTimeMax = 7)
        {
            throw new NotImplementedException();
        }

        public OrderTypeCollection GetOrdersCall(TimeFilter timeFilter, TradingRoleCodeType tradingRole, OrderStatusCodeType orderStatus)
        {
            throw new NotImplementedException();
        }

        public Task<OrderTypeCollection> GetOrdersCallAsync(TimeFilter timeFilter, TradingRoleCodeType tradingRole, OrderStatusCodeType orderStatus)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemType> GetSellerList(ListingStatusCodeType status)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemType>> GetSellerListAsync(ListingStatusCodeType status)
        {
            throw new NotImplementedException();
        }
    }
}
