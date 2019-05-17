﻿using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoSoft.Data.Interfaces
{
    public interface IEBayApiService
    {
        UserType GetUser { get; }
        ApiContext GetApiContext { get; }
        IEnumerable<ItemType> GetSellerList(ListingStatusCodeType status);
        Task<IEnumerable<ItemType>> GetSellerListAsync(ListingStatusCodeType status);
        Task<OrderTypeCollection> GetOrdersCallAsync(TimeFilter timeFilter, TradingRoleCodeType tradingRole, OrderStatusCodeType orderStatus);
        OrderTypeCollection GetOrdersCall(TimeFilter timeFilter, TradingRoleCodeType tradingRole, OrderStatusCodeType orderStatus);
        string AddItem(string title, string description, string catecoryID, double price, string UUID, string location = "US", int DispathTimeMax = 7);
    }
}
