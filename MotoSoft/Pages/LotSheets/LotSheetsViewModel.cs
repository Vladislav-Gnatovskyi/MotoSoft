using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using DevExpress.Mvvm;
using MotoSoft.Frameworks.Command;
using MotoSoft.Frameworks.Components.Table;
using MotoSoft.Pages.Lot;

namespace MotoSoft.Pages.LotSheets
{
    class LotSheetsViewModel: ViewModelBase
    {
        public TableViewModel TableViewModel { get; }
        public Frame MenuEdit { get; set; }
        public LotSheetsViewModel(Frame frame)
        {
            LotSheetsRouter.Instance.InitRouter(this);
            MenuEdit = frame;
            MenuEdit.Content = new LotView();
            TableViewModel = new TableViewModel(new LotSheetDataSource());
        }

        public async Task Load()
        {
            await TableViewModel.Load();
        }

        public ICommand AddClick
        {
            get => new RelayCommand(x => { LotSheetsRouter.Instance.OpenMenu(); });
        }

        public ICommand EditClick
        {
            get => new RelayCommand(x => { LotSheetsRouter.Instance.OpenMenu(); });
        }

        public ICommand RemoveClick
        {
            get => new RelayCommand(x => {  });
        }
    }
}
