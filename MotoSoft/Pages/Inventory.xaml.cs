using MotoSoft.ViewModels;
using System.Windows.Controls;

namespace MotoSoft.Pages
{
    /// <summary>
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class Inventory : Page
    {
        public Inventory()
        {
            InitializeComponent();
            DataContext = new InventoryViewModel();
        }
    }
}
