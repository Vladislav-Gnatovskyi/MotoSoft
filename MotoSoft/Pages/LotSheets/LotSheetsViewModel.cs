using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DevExpress.Mvvm;
using MotoSoft.Frameworks;
using MotoSoft.Frameworks.Command;
using MotoSoft.Frameworks.Components.Table;

namespace MotoSoft.Pages.LotSheets
{
    class LotSheetsViewModel : ViewModelBase
    {
        public TableViewModel TableViewModel { get; }
        public Frame MenuEdit { get; set; }

        public LotSheetsViewModel(Frame frame)
        {
            LotSheetsRouter.Instance.InitRouter(this);
            var dataSource = new LotSheetDataSource();
            dataSource.ContextMenu.Add(new ContextMenuField { Title = "Active Listings", Action = GoToActiveListing });
            dataSource.ContextMenu.Add(new ContextMenuField { Title = "Sold Listings", Action = GoToSoldListing });
            MenuEdit = frame;
            TableViewModel = new TableViewModel(dataSource);
        }

        public ICommand GoToActiveListing
        {
            get => new RelayCommand(x => 
            {
                LotSheetsModel item = (LotSheetsModel)TableViewModel.SelectedItem;
                Router.Instance.GoToActiveListings($"{item.Lot}");
            });
        }
        public ICommand GoToSoldListing
        {
            get => new RelayCommand(x =>
            {
                LotSheetsModel item = (LotSheetsModel)TableViewModel.SelectedItem;
                Router.Instance.GoToSoldListings($"{item.Lot}");
            });
        }

        public string Search
        {
            get
            {
                return TableViewModel.Search;
            }
            set
            {
                TableViewModel.Search = value;
            }
        }


        public async Task Load()
        {
            await TableViewModel.Load();
        }

        public ICommand AddClick
        {
            get => new RelayCommand(x => { LotSheetsRouter.Instance.OpenMenuAdd(); });
        }
        public ICommand EditClick
        {
            get => new RelayCommand(x => 
            {
                LotSheetsRouter.Instance.OpenMenuEdit();
            });
        }

        public ICommand RemoveClick
        {
            get => new RelayCommand(x => 
            {
                LotSheetsModel item = (LotSheetsModel)TableViewModel.SelectedItem;
                if (ServiceProvider.Instance.LotSheetRepository.Remove(item) != null)
                {
                    MessageBox.Show("Your succesfulle delete product, you need press button 'Refresh'");
                }
                else
                {
                    MessageBox.Show("Error product isn't exists!");
                }
            });
        }
    }
}
