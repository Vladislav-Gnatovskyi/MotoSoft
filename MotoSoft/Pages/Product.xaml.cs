using MotoSoft.ViewModels;
using System.Windows.Controls;

namespace MotoSoft.Pages
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Product : Page
    {
        public Product(Data.Models.Product product)
        {
            InitializeComponent();
            DataContext = new ProductViewModel(product);
        }
    }
}
