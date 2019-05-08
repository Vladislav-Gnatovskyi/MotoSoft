using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.Call;
using MotoSoft.Data.Interfaces;
using System;
using System.Windows;

namespace MotoSoft.Data.eBay
{
    public class EbayApiService:IEBayApiService
    {
        private string[] Scopes = { "https://api.ebay.com/wsapi", "https://api.ebay.com/oauth/api_scope"};
        private const string version = "571";
        public ApiContext GetApiContext
        {
            get
            {
                ApiContext context = new ApiContext();
                context.ApiCredential.ApiAccount.Developer = Properties.Settings.Default.DEV_ID;
                context.ApiCredential.ApiAccount.Application = Properties.Settings.Default.APP_ID;
                context.ApiCredential.ApiAccount.Certificate = Properties.Settings.Default.CER_ID;
                EBayAuthorize ebayApi = new EBayAuthorize();
                context.ApiCredential.eBayToken = context.ApiCredential.oAuthToken = ServiceProvider.Instance.CurrentContext.Settings.Token;
                context.SoapApiServerUrl = Scopes[0];
                context.Version = version;
                context.Site = SiteCodeType.US;
                context.Timeout = 30000;
                return context;
            }
        }
        public UserType GetUser
        {
            get
            {
                GetUserCall call = new GetUserCall(GetApiContext);
                return call.GetUser();
            }
        }
        public ItemType[] GetSellerList()
        {
            GetSellerListCall call = new GetSellerListCall(GetApiContext);
            call.DetailLevelList = new DetailLevelCodeTypeCollection();
            call.DetailLevelList.Add(DetailLevelCodeType.ReturnAll);
            ItemTypeCollection collection = call.GetSellerList(GetUser.UserID, new UserIDArrayType(), new DateTime(2019, 4, 30), DateTime.Now, 0, new DateTime(2019,4, 30), DateTime.Now, new PaginationType { EntriesPerPage = 25, PageNumber=1 }, GranularityLevelCodeType.Fine, new StringCollection(), true, true, 162031, true);
            return collection.ToArray();
        }

        public OrderTypeCollection GetOrdersCall(TimeFilter timeFilter, TradingRoleCodeType tradingRole, OrderStatusCodeType orderStatus)
        {
            GetOrdersCall call = new GetOrdersCall(GetApiContext);
            call.EnableCompression = true;
            call.DetailLevelList = new DetailLevelCodeTypeCollection();
            call.DetailLevelList.Add(DetailLevelCodeType.ReturnAll);        
            return call.GetOrders(timeFilter, tradingRole, orderStatus);
        }               
    }
}
