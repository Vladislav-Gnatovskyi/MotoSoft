using MotoSoft.Components.Table;
using MotoSoft.Data.DataSources;

namespace MotoSoft.ViewModels.Table
{
    class SoldLotSheetsViewModel:TableViewModel
    {
        private const int itemsOnPage = 40;
        public SoldLotSheetsViewModel()
        {
            Source = new SoldLotSheetDataSource();
            PageItemsContol = new PageItemsViewModel(Source, itemsOnPage);
        }
    }
}
