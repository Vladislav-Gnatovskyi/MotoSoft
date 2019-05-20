using DevExpress.Mvvm;
using MotoSoft.Frameworks.Components.Table;
using System.Threading.Tasks;

namespace MotoSoft.Pages.ActiveListings
{
    class ActiveListingsViewModel : ViewModelBase
    {
        public TableViewModel TableViewModel { get; }
        public ActiveListingsViewModel()
        {
            TableViewModel = new TableViewModel(new ActiveListingsDataSource());
        }
        public async Task Load()
        {
            await TableViewModel.Load();
        }
    }
}
