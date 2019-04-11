using DevExpress.Mvvm;
using MotoSoft.Assets.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
