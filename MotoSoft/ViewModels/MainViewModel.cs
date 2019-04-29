using DevExpress.Mvvm;
using MotoSoft.Assets.Command;
using MotoSoft.Data;
using MotoSoft.Models;
using System.Windows.Controls;
using System.Windows.Input;

namespace MotoSoft.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Context currentContext { get; }
        public Page CurrentPage { get; set; }
        public string User { get => $"{currentContext.Settings.FirstName} {currentContext.Settings.SecondName}"; }

        public MainViewModel()
        {
            Router.Instance.InitRouter(this);
            currentContext = ServiceProvider.Instance.CurrentContext;
        }

        #region OnClick

        public ICommand BMenuHome_Click
        {
            get
            {
                return new RelayCommand(x => Router.Instance.GoToHome());
            }
        }
        public ICommand BMenuInventory_Click
        {
            get
            {
                return new RelayCommand(x => Router.Instance.GoToInventory());
            }
        }
        public ICommand BMenuListParts_Click
        {
            get
            {
                return new RelayCommand(x => Router.Instance.GoToListParts());
            }
        }
        public ICommand BMenuOrders_Click
        {
            get
            {
                return new RelayCommand(x => Router.Instance.GoToOrders());
            }
        }
        public ICommand BMenuAnalytics_Click
        {
            get
            {
                return new RelayCommand(x => Router.Instance.GoToAnalytics());
            }
        }
        public ICommand BMenuGarage_Click
        {
            get
            {
                return new RelayCommand(x => Router.Instance.GoToGarage());
            }
        }
        public ICommand BMenuSettings_Click
        {
            get
            {
                return new RelayCommand(x => Router.Instance.GoToSettings());
            }
        }

        public ICommand BMenuLotSheets_Click
        {
            get
            {
                return new RelayCommand(x => Router.Instance.GoToLotSheets());
            }
        }
        public ICommand BMenuActiveListings_Click
        {
            get
            {
                return new RelayCommand(x => Router.Instance.GoToActiveListings());
            }
        }
        public ICommand BMenuSoldListings_Click
        {
            get
            {
                return new RelayCommand(x => Router.Instance.GoToSoldListings());
            }
        }

        public ICommand BExit_Click
        {
            get
            {
                return new RelayCommand(x => App.Current.Shutdown());
            }
        }

        public object CurrentContext { get; private set; }
        #endregion OnClick

    }
}
