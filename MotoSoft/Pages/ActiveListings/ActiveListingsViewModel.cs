using DevExpress.Mvvm;
using MotoSoft.Frameworks.Command;
using MotoSoft.Frameworks.Components.Table;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MotoSoft.Pages.ActiveListings
{
    class ActiveListingsViewModel : ViewModelBase
    {
        public TableViewModel TableViewModel { get; }
        public ActiveListingsViewModel()
        {
            ActiveListingsDataSource dataSource = new ActiveListingsDataSource();
            dataSource.ContextMenu.Add(new ContextMenuField { Title = "Show Brouser", Action = GoToBrouser });
            TableViewModel = new TableViewModel(dataSource);
            
        }
        public async Task Load()
        {
            await TableViewModel.Load();
        }

        public ICommand GoToBrouser
        {
            get
            {
                return new RelayCommand(x => 
                {
                    if (TableViewModel.SelectedItem != null)
                    {
                        ActiveListingsModel item = (ActiveListingsModel)TableViewModel.SelectedItem;
                        Router.Instance.GoToBrouser(item.Url);
                    }
                });
                
            }
        }
    }
}
