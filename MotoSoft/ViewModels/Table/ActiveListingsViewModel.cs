using MotoSoft.Components.Table;
using MotoSoft.Data.DataSources;

namespace MotoSoft.ViewModels.Table
{
    class ActiveListingsViewModel : TableViewModel
    {
        private const int itemsOnPage = 40;
        public ActiveListingsViewModel()
        {
            Source = new ActiveListingsDataSource();
            PageItemsContol = new PageItemsViewModel(Source, itemsOnPage);
        }        
    }
}
