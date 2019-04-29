using MotoSoft.Components.Table;
using MotoSoft.Data.DataSources;

namespace MotoSoft.ViewModels.Table
{
    class SoldListingsViewModel:TableViewModel
    {
        private const int itemsOnPage = 40;
        public SoldListingsViewModel()
        {
            Source = new SoldListingsDataSource();
            PageItemsContol = new PageItemsViewModel(Source, itemsOnPage);
        }
    }
}
