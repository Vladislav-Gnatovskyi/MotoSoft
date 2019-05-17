using MotoSoft.Assets.Command;
using MotoSoft.Components.Table;
using MotoSoft.Data;
using MotoSoft.Data.DataSources;
using System.Windows.Input;

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
