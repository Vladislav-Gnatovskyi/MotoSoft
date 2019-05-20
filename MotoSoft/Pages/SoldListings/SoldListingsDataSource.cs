﻿using MotoSoft.Frameworks;
using MotoSoft.Frameworks.Components.Table;
using MotoSoft.Frameworks.Pages;
using System.Collections.Generic;

namespace MotoSoft.Pages.SoldListings
{
    public class SoldListingsDataSource : SheetDataSourceBase<SoldListingsModel>
    {
        public SoldListingsDataSource()
        {
            sheetRepository = ServiceProvider.Instance.SoldListingsRepository;
            Columns = new List<Column>()
            {
                new Column()
                {
                    Title = "Item ID",
                    Field = "ItemID",
                    Type = EColumnType.Text
                },
                new Column()
                {
                    Title = "Date",
                    Field = "Date",
                    Type = EColumnType.Text
                },
                new Column()
                {
                    Title = "Sales Record Number",
                    Field = "SalesRecordNumber",
                    Type = EColumnType.Number
                },
                new Column()
                {
                    Title = "Title",
                    Field = "Title",
                    Type = EColumnType.Text
                },
                new Column()
                {
                    Title = "Label",
                    Field = "CustomLabel",
                    Type = EColumnType.Text
                },
                new Column()
                {
                    Title = "Product Name",
                    Field = "ProductName",
                    Type = EColumnType.Text
                },
                new Column()
                {
                    Title = "QTY",
                    Field = "QTY",
                    Type = EColumnType.Number
                },
                new Column()
                {
                    Title = "Sale Price",
                    Field = "SalePrice",
                    Type = EColumnType.Number
                },
                new Column()
                {
                    Title = "Shipping Changed",
                    Field = "ShippingChanged",
                    Type = EColumnType.Number
                },
                new Column()
                {
                    Title = "Gross Sales",
                    Field = "GrossSales",
                    Type = EColumnType.Number
                },
                new Column()
                {
                    Title = "Cost Of Item",
                    Field = "CostOfItem",
                    Type = EColumnType.Number
                },
                new Column()
                {
                    Title = "Shipping Cost",
                    Field = "ShippingCost",
                    Type = EColumnType.Number
                },
                new Column()
                {
                    Title = "eBay Fees",
                    Field = "eBayFees",
                    Type = EColumnType.Number
                },
                new Column()
                {
                    Title = "PAYPAL Fees",
                    Field = "PAYPALFees",
                    Type = EColumnType.Number
                },
                new Column()
                {
                    Title = "COST",
                    Field = "COST",
                    Type = EColumnType.Number
                },
                new Column()
                {
                    Title = "GAIN",
                    Field = "GAIN",
                    Type = EColumnType.Number
                },
                new Column()
                {
                    Title = "Sales Tax",
                    Field = "SalesTax",
                    Type = EColumnType.Number
                },
                new Column()
                {
                    Title = "Item eBay Fees",
                    Field = "ItemeBayFees",
                    Type = EColumnType.Number
                },

            };
        }
    }
}
