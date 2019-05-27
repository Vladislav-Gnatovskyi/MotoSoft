using MotoSoft.Frameworks;
using MotoSoft.Frameworks.Components.Table;
using MotoSoft.Frameworks.Pages;
using System.Collections.Generic;

namespace MotoSoft.Pages.LotSheets
{
    public class LotSheetDataSource: SheetDataSourceBase<LotSheetsModel>
    {       
        public LotSheetDataSource()
        {
            sheetRepository = ServiceProvider.Instance.LotSheetRepository;
            Columns = new List<Column>()
            {
                new Column
                {
                    Title = "Lot",
                    Field = "Lot",
                    Type = EColumnType.Text,
                },
                new Column
                {
                    Title = "Type",
                    Field = "Type",
                    Type = EColumnType.Text,
                },
                new Column
                {
                    Title = "Date",
                    Field = "Date",
                    Type = EColumnType.Text,
                },
                new Column
                {
                    Title = "Model",
                    Field = "Model",
                    Type = EColumnType.Text,
                },
                new Column
                {
                    Title = "Make",
                    Field = "Make",
                    Type = EColumnType.Text,
                },
                new Column
                {
                    Title = "Year",
                    Field = "Year",
                    Type = EColumnType.Number,
                },
                new Column
                {
                    Title = "Mileage",
                    Field = "Mileage",
                    Type = EColumnType.Number,
                },
                new Column
                {
                    Title = "Notes",
                    Field = "Notes",
                    Type = EColumnType.Text,
                },
                new Column
                {
                    Title = "Title",
                    Field = "Title",
                    Type = EColumnType.Text,
                },
                new Column
                {
                    Title = "Bos",
                    Field = "Bos",
                    Type = EColumnType.Text,
                },
                new Column
                {
                    Title = "Cost",
                    Field = "Cost",
                    Type = EColumnType.Text,
                },
                new Column
                {
                    Title = "Profit",
                    Field = "Profit",
                    Type = EColumnType.Link,
                },
                new Column
                {
                    Title = "Parts Active",
                    Field = "PartsActive",
                    Type = EColumnType.Link,
                },
                new Column
                {
                    Title = "Parts Sold",
                    Field = "PartsSold",
                    Type = EColumnType.Number,
                },
                new Column
                {
                    Title = "Status",
                    Field = "Status",
                    Type = EColumnType.Link,
                },
                new Column
                {
                    Title = "eBay Fees",
                    Field = "eBayFees",
                    Type = EColumnType.Number,
                },
                new Column
                {
                    Title = "PayPal Fees",
                    Field = "PayPalFees",
                    Type = EColumnType.Number,
                },
                new Column
                {
                    Title = "Shipping Fees",
                    Field = "ShippingFees",
                    Type = EColumnType.Number,
                },
                new Column
                {
                    Title = "Total Cost",
                    Field = "TotalCost",
                    Type = EColumnType.Number,
                },
                new Column
                {
                    Title = "Total Sales",
                    Field = "TotalSales",
                    Type = EColumnType.Number,
                },
                new Column
                {
                    Title = "Net Profit",
                    Field = "NetProfit",
                    Type = EColumnType.Number,
                },
                new Column
                {
                    Title = "Active UnSold",
                    Field = "ActiveUnSold",
                    Type = EColumnType.Number,
                },
            };
        }
    }
}
