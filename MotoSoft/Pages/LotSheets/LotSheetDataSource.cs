using MotoSoft.Frameworks;
using MotoSoft.Frameworks.Components.Table;
using MotoSoft.Frameworks.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MotoSoft.Pages.LotSheets
{
    public class LotSheetDataSource: SheetDataSourceBase<LotSheetsModel>
    {       
        public LotSheetDataSource()
        {
            SheetRepository = ServiceProvider.Instance.LotSheetRepository;          
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
                //new Column
                //{
                //    Title = "Title",
                //    Field = "Title",
                //    Type = EColumnType.Text,
                //},
                //new Column
                //{
                //    Title = "Bos",
                //    Field = "Bos",
                //    Type = EColumnType.Text,
                //},
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

        protected override IList<LotSheetsModel> Contains(IEnumerable<LotSheetsModel> listFinder, string search)
        {
            if (search != null || search != "")
            {
                return listFinder.ToList().Where(itemContains => itemContains.Lot.ToString().Contains(search)
                || itemContains.Year.ToString().Contains(search)
                || itemContains.Type.ToString().ToUpper().Contains(search.ToUpper())
                || itemContains.Make.ToUpper().Contains(search.ToUpper())
                || itemContains.Model.ToUpper().Contains(search.ToUpper())
                || itemContains.Notes.ToUpper().Contains(search.ToUpper())
                || itemContains.Date.Contains(search)
                || itemContains.Mileage.ToString().Contains(search)
                || itemContains.Cost.ToString().Contains(search)
                || itemContains.Status.ToUpper().Contains(search.ToUpper())).ToList();
            }
            return listFinder.ToList();
        }
    }
}
