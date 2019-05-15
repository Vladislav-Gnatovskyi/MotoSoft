
    using System;
    using eBay.Service.Call;
    using eBay.Service.Core.Sdk;
    using eBay.Service.Util;
    using eBay.Service.Core.Soap;
    namespace SDK3Examples
    {

    public class SampleAdd
    {
        public string AddItem(string UUID)
        {
            AddItemCall addItem = new AddItemCall(new ApiContext());
            ItemType item = new ItemType();
            item.Currency = CurrencyCodeType.USD;
            item.Country = CountryCodeType.US;
            item.PaymentMethods = new BuyerPaymentMethodCodeTypeCollection();
            item.PaymentMethods.AddRange(new BuyerPaymentMethodCodeType[] { BuyerPaymentMethodCodeType.PayPal });
            item.PayPalEmailAddress = "test@test.com";
            item.Title = "";
            item.Quantity = 1;
            item.PostalCode = "";
            item.ListingDuration = "Days_7";
            item.PrimaryCategory = new CategoryType();
            item.PrimaryCategory.CategoryID = "1463";
            item.StartPrice = new AmountType();
            item.StartPrice.currencyID = CurrencyCodeType.USD;
            item.StartPrice.Value = 20;
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

            FeeTypeCollection fees = addItem.AddItem(item);
            return item.ItemID;
        }

    }
}
