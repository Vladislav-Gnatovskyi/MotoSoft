using System.Threading.Tasks;
using DevExpress.Mvvm;
using MotoSoft.Frameworks.Components.Table;

namespace MotoSoft.Pages.LotSheets
{
    class LotSheetsViewModel: ViewModelBase
    {
        public TableViewModel TableViewModel { get; }
        public LotSheetsViewModel()
        {
            TableViewModel = new TableViewModel(new LotSheetDataSource());
        }

        public async Task Load()
        {
            await TableViewModel.Load();
        }
    }
}
