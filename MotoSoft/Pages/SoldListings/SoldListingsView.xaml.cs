using System.Windows.Controls;

namespace MotoSoft.Pages.SoldListings
{
    /// <summary>
    /// Interaction logic for SoldListingsView.xaml
    /// </summary>
    public partial class SoldListingsView : Page
    {
        SoldListingsViewModel soldListingsViewModel;
        public SoldListingsView()
        {
            InitializeComponent();
            soldListingsViewModel = new SoldListingsViewModel();
            DataContext = new SoldListingsViewModel();
            ListingTable.DataContext = soldListingsViewModel.TableViewModel;
        }

        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await soldListingsViewModel.Load();
        }
    }
}
