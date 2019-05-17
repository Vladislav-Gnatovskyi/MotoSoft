using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.Call;
using MotoSoft.Data.Interfaces;
using System;
using MotoSoft.Data.Enums;
using eBay.ApiClient.Auth.OAuth2.Model;
using System.Threading.Tasks;

namespace MotoSoft.Data.eBay
{
    public class EbayApiService:IEBayApiService
    {
        private string[] Scopes = { "https://api.ebay.com/wsapi", "https://api.sandbox.ebay.com/wsapi" };
        private const string version = "571";
        public ApiContext GetApiContext
        {
            get
            {
                ApiContext context = new ApiContext();
                if (EBayAuthorize.Environment.Equals(OAuthEnvironment.SANDBOX))
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
                context.ApiCredential.eBayToken = context.ApiCredential.oAuthToken = ServiceProvider.Instance.CurrentContext.Settings.Token;
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
                if (EBayAuthorize.IsAuthorize.Equals(EbayAuthorizeState.Authorized))
                {
                    GetUserCall call = new GetUserCall(GetApiContext);
                    return call.GetUser();
                }
                return new UserType();
            }
        }
        public ItemTypeCollection GetSellerList()
        {
            if (EBayAuthorize.IsAuthorize.Equals(EbayAuthorizeState.Authorized))
            {
                //GetSellerListCall call = new GetSellerListCall(GetApiContext);
                //call.DetailLevelList.Add(DetailLevelCodeType.ReturnAll);
                //call.Pagination = new PaginationType();
                //call.Pagination.PageNumber = 1;
                //call.Pagination.EntriesPerPage = 10;
                //call.UserID = GetUser.UserID;
                //call.GranularityLevel = GranularityLevelCodeType.Fine;
                //call.StartTimeFilter = new TimeFilter(DateTime.Now.AddDays(-2), DateTime.Now.AddDays(2));
                //call.EndTimeFilter = new TimeFilter(DateTime.Now.AddHours(-5), DateTime.Now.AddHours(1));
                //return call.GetSellerList();


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
                oGetSellerListCall.EndTimeFilter = new TimeFilter(DateTime.Now, DateTime.Now.AddMonths(3));
                oGetSellerListCall.Sort = 2;
                return oGetSellerListCall.GetSellerList();
            }
            return new ItemTypeCollection();
        }
        public async Task<ItemTypeCollection> GetSellerListAsync()
        {
            return await Task.Run(() => GetSellerList());
        }

        public async Task<OrderTypeCollection> GetOrdersCallAsync(TimeFilter timeFilter, TradingRoleCodeType tradingRole, OrderStatusCodeType orderStatus)
        {
            OrderTypeCollection x = await Task.Factory.StartNew(() => GetOrdersCall(timeFilter, tradingRole, orderStatus));
            return x;
        }

        public OrderTypeCollection GetOrdersCall(TimeFilter timeFilter, TradingRoleCodeType tradingRole, OrderStatusCodeType orderStatus)
        {
            if (EBayAuthorize.IsAuthorize.Equals(EbayAuthorizeState.Authorized))
            {
                GetOrdersCall call = new GetOrdersCall(GetApiContext);
                call.EnableCompression = true;
                call.DetailLevelList = new DetailLevelCodeTypeCollection();
                call.DetailLevelList.Add(DetailLevelCodeType.ReturnAll);
                return call.GetOrders(timeFilter, tradingRole, orderStatus);
            }
            return new OrderTypeCollection();
        }

        
        public string AddItem(string title, string description, string catecoryID, double price, string UUID, string location = "US", int DispathTimeMax = 10)
        {
            if (EBayAuthorize.IsAuthorize.Equals(EbayAuthorizeState.Authorized))
            {
                AddItemCall call = new AddItemCall(GetApiContext);
                ItemType item = new ItemType();
                item.Currency = CurrencyCodeType.USD;
                item.Country = CountryCodeType.US;
                item.PaymentMethods = new BuyerPaymentMethodCodeTypeCollection();
                item.PaymentMethods.AddRange(new BuyerPaymentMethodCodeType[] { BuyerPaymentMethodCodeType.PayPal });
                item.PayPalEmailAddress = "test@test.com";
                item.Title = title;
                item.Quantity = 1;
                item.PostalCode = ServiceProvider.Instance.CurrentContext.Settings.PostalCode;
                item.Description = description;
                item.ListingDuration = "Days_7";
                item.PrimaryCategory = new CategoryType();
                item.PrimaryCategory.CategoryID = catecoryID;
                item.StartPrice = new AmountType();
                item.StartPrice.currencyID = CurrencyCodeType.USD;
                item.DispatchTimeMax = 7;
                item.StartPrice.Value = price;
                item.UUID = UUID;

                item.ShippingDetails = new ShippingDetailsType();
                item.ShippingDetails.ShippingServiceOptions = new ShippingServiceOptionsTypeCollection();
                ShippingServiceOptionsType[] opt = new ShippingServiceOptionsType[2];
                opt[0] = new ShippingServiceOptionsType();
                opt[0].ShippingServiceCost = new AmountType();
                opt[0].ShippingServiceCost.currencyID = CurrencyCodeType.USD;
                opt[0].ShippingServiceCost.Value = 5;
                // ShippingService is now a string
                //Make a call to GeteBayDetails to find out the valid Shipping Service values
                opt[0].ShippingService = "USPSPriority";
                opt[0].ShippingServicePriority = 1;
                item.ShippingDetails.ShippingServiceOptions.Add(opt[0]);
               
                opt[1] = new ShippingServiceOptionsType();
                opt[1].ShippingServiceCost = new AmountType();
                opt[1].ShippingServiceCost.currencyID = CurrencyCodeType.USD;
                opt[1].ShippingServiceCost.Value = 10;
                opt[1].ShippingService = "USPSExpressMail";
                opt[1].ShippingServicePriority = 2;
                item.ShippingDetails.ShippingServiceOptions.Add(opt[1]);
                item.ShipToLocations = new StringCollection();
                item.ShipToLocations.Add("US");
                item.Location = location;

                FeeTypeCollection fees = call.AddItem(item);
                return item.ItemID;
            }
            return null;
        }
        

        public ItemType GetItem(string ItemID)
        {
            if (EBayAuthorize.IsAuthorize.Equals(EbayAuthorizeState.Authorized))
            {                
                GetItemCall call = new GetItemCall(GetApiContext);
                return call.GetItem(ItemID);
            }
            return new ItemType();
        }
    }
}
