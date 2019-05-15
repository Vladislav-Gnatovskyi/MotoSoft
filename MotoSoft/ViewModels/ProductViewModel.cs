using DevExpress.Mvvm;
using MotoSoft.Assets.Command;
using MotoSoft.Data;
using MotoSoft.Data.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MotoSoft.ViewModels
{
    class ProductViewModel : ViewModelBase
    {
        public Product ItemProduct { get; set; }
        public Page ImageControl { get; set; }

        public ProductViewModel(Product product)
        {
            if (product != null)
                ItemProduct = product;
            else
                ItemProduct = new Product();
            ImageControl = new Pages.Image();
        }

        public ICommand Add_Click
        {
            get
            {
                return new RelayCommand(x => 
                {
                    MessageBox.Show(ServiceProvider.Instance.eBayService.AddItem(ItemProduct.Name, ItemProduct.Description, ItemProduct.CategoryID, ItemProduct.Price, "1234567898abcbcaabca0987654321aa"));
                });
            }
        }
    }
}
