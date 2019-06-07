using MotoSoft.Frameworks;
using MotoSoft.Frameworks.Components.Table;
using MotoSoft.Frameworks.Pages;
using System.Collections.Generic;
using System.Linq;

namespace MotoSoft.Pages.ActiveListings
{
    public class ActiveListingsDataSource: SheetDataSourceBase<ActiveListingsModel>
    {
        public ActiveListingsDataSource()
        {
            SheetRepository = ServiceProvider.Instance.ActiveListingsRepository;
            Columns = new List<Column>()
            {
                new Column()
                {
                    Title = "Item ID",
                    Field = "ItemId",
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
                    Title = "Title",
                    Field = "Title",
                    Type = EColumnType.Text
                },
                new Column()
                {
                    Title = "QTY",
                    Field = "Quantity",
                    Type = EColumnType.Text
                },
                new Column()
                {
                    Title = "Price",
                    Field = "Price",
                    Type = EColumnType.Number
                },
                new Column()
                {
                    Title = "Start time",
                    Field = "StartTime",
                    Type = EColumnType.Text
                },
                new Column()
                {
                    Title = "Listing type",
                    Field = "ListingType",
                    Type = EColumnType.Text
                },
                new Column()
                {
                    Title = "Url",
                    Field = "Url",
                    Type = EColumnType.Link
                }
            };
        }

        protected override IList<ActiveListingsModel> Contains(IEnumerable<ActiveListingsModel> listFinder, string search)
        {
            if (search != null || search != "")
            {
                return listFinder.ToList().Where(itemContains => itemContains.CustomLabel.ToUpper().Contains(search.ToUpper())
                || itemContains.Title.ToUpper().Contains(search.ToUpper())
                || itemContains.Quantity.ToString().Contains(search)
                || itemContains.ListingType.ToUpper().Contains(search.ToUpper())
                || itemContains.Price.ToString().Contains(search)
                || itemContains.Url.ToUpper().Contains(search.ToUpper())
                || itemContains.ItemId.ToString().Contains(search)).ToList();
            }
            return listFinder.ToList();
        }
    }
}
