using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.Mvvm;
using MotoSoft.Frameworks.Command;
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

        public ICommand AddClick
        {
            get => new RelayCommand(x => { Router.Instance.GoToLotCreate(); });
        }
    }
}
