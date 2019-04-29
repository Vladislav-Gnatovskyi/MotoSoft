using MotoSoft.Components.Table;
using MotoSoft.Data.DataSources;

namespace MotoSoft.ViewModels.Table
{
    class LotSheetsViewModel:TableViewModel
    {
        private const int itemsOnPage = 40;
        public LotSheetsViewModel()
        {
            Source = new LotSheetDataSource();
            PageItemsContol = new PageItemsViewModel(Source, itemsOnPage);
        }
    }
}
