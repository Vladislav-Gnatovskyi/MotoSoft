using DevExpress.Mvvm;
using MotoSoft.Models;
using System.Windows.Controls;

namespace MotoSoft.ViewModels
{
    class ProductViewModel : ViewModelBase
    {
        public Product ItemProduct { get; set; }
        private static ProductViewModel _instance;
        public static ProductViewModel Instance => _instance ?? (_instance = new ProductViewModel());
        public Page ImageControl { get; set; }

        private ProductViewModel()
        {
            ImageControl = new Pages.Image();
        }
    }
}
