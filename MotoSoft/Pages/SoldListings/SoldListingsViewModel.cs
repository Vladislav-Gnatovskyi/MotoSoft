using DevExpress.Mvvm;
using MotoSoft.Frameworks.Components.Table;
using System.Threading.Tasks;

namespace MotoSoft.Pages.SoldListings
{
    class SoldListingsViewModel: ViewModelBase
    {
        public TableViewModel TableViewModel { get; }
        public SoldListingsViewModel()
        {
            TableViewModel = new TableViewModel(new SoldListingsDataSource());
        }
        public async Task Load()
        {
            await TableViewModel.Load();
        }
    }
}
