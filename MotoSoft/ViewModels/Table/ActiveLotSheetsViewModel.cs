using MotoSoft.Components.Table;
using MotoSoft.Data.DataSources;

namespace MotoSoft.ViewModels.Table
{
    class ActiveLotSheetsViewModel:TableViewModel
    {
        private const int itemsOnPage = 40;
        public ActiveLotSheetsViewModel()
        {
            Source = new ActiveLotSheetDataSource();
            PageItemsContol = new PageItemsViewModel(Source, itemsOnPage);
        }
    }
}
