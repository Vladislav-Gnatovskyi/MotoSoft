using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.Call;
using System;
using System.Linq;
using eBay.ApiClient.Auth.OAuth2.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using MotoSoft.Frameworks.Authorize;

namespace MotoSoft.Frameworks.Ebay
{
    public class EbayApiService : IEbayApiService
    {
        private string[] Scopes = { "https://api.ebay.com/wsapi", "https://api.sandbox.ebay.com/wsapi" };
        private const string version = "571";
        public ApiContext GetApiContext
        {
            get
            {
                ApiContext context = new ApiContext();
                if (EBayAuthorize.Instance.Environment.Equals(OAuthEnvironment.SANDBOX))
                {
                    context.ApiCredential.ApiAccount.Developer = Properties.Settings.Default.SDEV_ID;
                    context.ApiCredential.ApiAccount.Application = Properties.Settings.Default.SAPP_ID;
                    context.ApiCredential.ApiAccount.Certificate = Properties.Settings.Default.SCER_ID;
                    context.SoapApiServerUrl = Scopes[1];
                }
                else
                {
                    context.ApiCredential.ApiAccount.Developer = Properties.Settings.Default.DEV_ID;
                    context.ApiCredential.ApiAccount.Application = Properties.Settings.Default.APP_ID;
                    context.ApiCredential.ApiAccount.Certificate = Properties.Settings.Default.CER_ID;
                    context.SoapApiServerUrl = Scopes[0];
                }
                context.ApiCredential.eBayToken = context.ApiCredential.oAuthToken = ServiceProvider.Instance.CurrentContext.Settings.Token.AccessToken.Token;
                context.Version = version;
                context.Site = SiteCodeType.US;
                context.Timeout = 30000;
                return context;
            }
        }

        public bool GetTokenStatusCall()
        {
            try
            {
                new GetUserCall(GetApiContext).GetUser();
                return true;
            }
            catch
            {
                return EBayAuthorize.Instance.GetAccesToken();
            }
        }

        public UserType GetUser
        {
            get
            {
                if (EBayAuthorize.Instance.IsAuthorized && GetTokenStatusCall())
                {
                    GetUserCall call = new GetUserCall(GetApiContext);
                    return call.GetUser();
                }
                return new UserType();
            }
        }

        public IEnumerable<ItemType> GetSellerList(ListingStatusCodeType status)
        {
            if (EBayAuthorize.Instance.IsAuthorized && GetTokenStatusCall())
            {
                GetSellerListCall oGetSellerListCall = new GetSellerListCall(GetApiContext);
                oGetSellerListCall.Version = GetApiContext.Version;
                oGetSellerListCall.Site = GetApiContext.Site;
                oGetSellerListCall.EnableCompression = true;
                oGetSellerListCall.GranularityLevel = GranularityLevelCodeType.Fine;
                PaginationType oPagination = new PaginationType();
                oPagination.EntriesPerPage = 200;
                oPagination.EntriesPerPageSpecified = true;
                oPagination.PageNumber = 1;
                oPagination.PageNumberSpecified = true;
                oGetSellerListCall.Pagination = oPagination;
                oGetSellerListCall.EndTimeFilter = new TimeFilter(DateTime.Now.AddMonths(-2), DateTime.Now.AddMonths(1));
                oGetSellerListCall.Sort = 2;
                switch (status)
                {
                    case ListingStatusCodeType.Active:
                        return oGetSellerListCall.GetSellerList().ToArray().ToList().Where(x => x.SellingStatus.ListingStatus.Equals(status));
                    case ListingStatusCodeType.Completed:
                    case ListingStatusCodeType.Ended:
                        return oGetSellerListCall.GetSellerList().ToArray().ToList().Where(x => x.SellingStatus.QuantitySold != 0);
                }
                
            }
            return new ItemTypeCollection().ToArray();
        }

        public async Task<IEnumerable<ItemType>> GetSellerListAsync(ListingStatusCodeType status)
        {
            return await Task.Run(() => GetSellerList(status));
        }

        public async Task<OrderTypeCollection> GetOrdersCallAsync()
        {
            OrderTypeCollection x = await Task.Run(() => GetOrdersCall());
            return x;
        }

        public OrderTypeCollection GetOrdersCall()
        {

            if (EBayAuthorize.Instance.IsAuthorized && GetTokenStatusCall())
            {
                GetOrdersCall call = new GetOrdersCall(GetApiContext);
                call.EnableCompression = true;
                call.DetailLevelList = new DetailLevelCodeTypeCollection();
                call.DetailLevelList.Add(DetailLevelCodeType.ReturnAll);
                return call.GetOrders(new TimeFilter(DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(2)), TradingRoleCodeType.Seller, OrderStatusCodeType.All);
            }
            return new OrderTypeCollection();
        }

        public ItemType GetItem(string ItemID)
        {
            if (EBayAuthorize.Instance.IsAuthorized && GetTokenStatusCall())
            {
                GetItemCall call = new GetItemCall(GetApiContext);
                return call.GetItem(ItemID);
            }
            return new ItemType();
        }
    }
}
