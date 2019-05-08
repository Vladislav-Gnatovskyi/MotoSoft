using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using MotoSoft.Data.Interfaces;
using MotoSoft.Data.Repository.Json;
using System;

namespace MotoSoft.Data.eBay
{
    class FakeEBayService : IEBayApiService
    {
        public UserType GetUser => throw new NotImplementedException();

        public ApiContext GetApiContext => throw new NotImplementedException();

        public OrderTypeCollection GetOrdersCall(TimeFilter timeFilter, TradingRoleCodeType tradingRole, OrderStatusCodeType orderStatus)
        {
            throw new NotImplementedException();
        }

        public ItemType[] GetSellerList()
        {
            return new FakeEBaySellerListJsonRepository().Load();
        }
    }
}
