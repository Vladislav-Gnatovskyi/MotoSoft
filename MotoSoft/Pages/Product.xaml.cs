using MotoSoft.ViewModels;
using System.Windows.Controls;

namespace MotoSoft.Pages
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class Product : Page
    {
        public Product()
        {
            InitializeComponent();
            DataContext = new ProductViewModel();
        }
    }
}
