using DevExpress.Mvvm;
using MotoSoft.Assets.Command;
using System.Windows.Input;

namespace MotoSoft.ViewModels
{
    class HomeViewModel : ViewModelBase
    {
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
    }
}
