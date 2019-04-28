using DevExpress.Mvvm;
using MotoSoft.Models;
using System.Windows.Controls;

namespace MotoSoft.ViewModels
{
    class ProductViewModel : ViewModelBase
    {
        public Product ItemProduct { get; set; }
        public Page ImageControl { get; set; }

        public ProductViewModel()
        {
            ImageControl = new Pages.Image();
        }
    }
}
