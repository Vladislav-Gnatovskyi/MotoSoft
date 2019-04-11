using DevExpress.Mvvm;
using System.Windows.Input;

namespace MotoSoft.ViewModels
{
    class HomeViewModel : ViewModelBase
    {
        public ICommand BMenuInventory_Click
        {
            get
            {                
                return MainViewModel.Instance.BMenuInventory_Click;
            }
        }
        public ICommand BMenuListParts_Click
        {
            get
            {
                return MainViewModel.Instance.BMenuListParts_Click;
            }
        }
        public ICommand BMenuGarage_Click
        {
            get
            {
                return MainViewModel.Instance.BMenuGarage_Click;
            }
        }
        public ICommand BMenuOrders_Click
        {
            get
            {
                return MainViewModel.Instance.BMenuOrders_Click;
            }
        }
        public ICommand BMenuAnalytics_Click
        {
            get
            {
                return MainViewModel.Instance.BMenuAnalytics_Click;
            }
        }
        public ICommand BMenuSettings_Click
        {
            get
            {
                return MainViewModel.Instance.BMenuSettings_Click;
            }
        }
    }
}
