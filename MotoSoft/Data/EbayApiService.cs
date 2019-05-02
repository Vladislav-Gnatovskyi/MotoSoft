using eBay.Service.Util;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.Call;
using eBay.ApiClient.Auth.OAuth2.Model;
using System.Windows;
using System;
using System.Threading;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace MotoSoft.Data
{
    public class EbayApiService
    {
        private ApiContext GetApiContext()
        {
            ApiContext context = new ApiContext();
            context.ApiCredential.ApiAccount.Developer = Properties.Settings.Default.DEV_ID;
            context.ApiCredential.ApiAccount.Application = Properties.Settings.Default.APP_ID;
            context.ApiCredential.ApiAccount.Certificate = Properties.Settings.Default.CER_ID;
            context.ApiCredential.eBayToken = Properties.Settings.Default.eBayToken;
            context.ApiCredential.oAuthToken = eBay.EBayAuthorize.Token;
            context.SoapApiServerUrl = "https://api.ebay.com/wsapi";
            context.Version = "571";
            return context;
        }

        public OrderTypeCollection GetOrdersCall(TimeFilter timeFilter, TradingRoleCodeType tradingRole,  OrderStatusCodeType orderStatus)
        {
            GetOrdersCall call = new GetOrdersCall(GetApiContext());
            call.EnableCompression = true;
            call.DetailLevelList = new DetailLevelCodeTypeCollection(new DetailLevelCodeType[] { DetailLevelCodeType.ReturnAll });
            call.Timeout = 20000;
            MessageBox.Show(call.GetOrders(timeFilter, tradingRole, orderStatus).Count.ToString());
            return call.GetOrders(timeFilter, tradingRole, orderStatus);
        }
    }
}
