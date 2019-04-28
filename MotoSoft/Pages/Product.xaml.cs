using MotoSoft.ViewModels;
using System.Windows.Controls;

namespace MotoSoft.Pages
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Product : Page
    {
        public Product(Models.Product product)
        {
            InitializeComponent();
            DataContext = new ProductViewModel(product);
        }
    }
}
