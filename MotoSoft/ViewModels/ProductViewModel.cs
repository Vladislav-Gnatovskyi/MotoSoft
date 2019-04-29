using DevExpress.Mvvm;
using MotoSoft.Data.Models;
using System.Windows.Controls;

namespace MotoSoft.ViewModels
{
    class ProductViewModel : ViewModelBase
    {
        public Product ItemProduct { get; set; }
        public Page ImageControl { get; set; }

        public ProductViewModel(Product product)
        {
            ItemProduct = product;
            ImageControl = new Pages.Image();
        }
    }
}
