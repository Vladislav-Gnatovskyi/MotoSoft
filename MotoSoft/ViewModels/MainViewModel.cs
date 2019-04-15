using DevExpress.Mvvm;
using MotoSoft.Assets.Command;
using System.Windows.Controls;
using System.Windows.Input;

namespace MotoSoft.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private readonly Page Home;
        private readonly Page Inventory;
        private readonly Page ListParts;
        private readonly Page Orders;
        private readonly Page Analytics;
        private readonly Page Garage;
        private readonly Page Settings;

        private static MainViewModel _instance;
        public static MainViewModel Instance => _instance ?? (_instance = new MainViewModel());

        public Page CurrentPage { get; set; }
        public string User { get => $"{SettingViewModel.Instance.SettingModel.FirstName} {SettingViewModel.Instance.SettingModel.SecondName}"; }

        private MainViewModel()
        {
            Home = new Pages.Home();
            Inventory = new Pages.Inventory();
            ListParts = new Pages.ListParts();
            Orders = new Pages.Orders();
            Analytics = new Pages.Analytics();
            Garage = new Pages.Garage();
            Settings = new Pages.Settings();
            CurrentPage = Home;
        }

        #region OnClick

        public ICommand BMenuHome_Click
        {
            get
            {
                return new RelayCommand(x => CurrentPage = Home);
            }
        }
        public ICommand BMenuInventory_Click
        {
            get
            {
                return new RelayCommand(x => CurrentPage = Inventory);
            }
        }
        public ICommand BMenuListParts_Click
        {
            get
            {
                return new RelayCommand(x => CurrentPage = ListParts);
            }
        }
        public ICommand BMenuOrders_Click
        {
            get
            {
                return new RelayCommand(x => CurrentPage = Orders);
            }
        }
        public ICommand BMenuAnalytics_Click
        {
            get
            {
                return new RelayCommand(x => CurrentPage = Analytics);
            }
        }
        public ICommand BMenuGarage_Click
        {
            get
            {
                return new RelayCommand(x => CurrentPage = Garage);
            }
        }
        public ICommand BMenuSettings_Click
        {
            get
            {
                return new RelayCommand(x => CurrentPage = Settings);
            }
        }

        public ICommand BExit_Click
        {
            get
            {
                return new RelayCommand(x => App.Current.Shutdown());
            }
        }
        #endregion OnClick

    }
}
