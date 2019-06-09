using System.Windows.Controls;

namespace MotoSoft.Pages.ActiveListings
{
    /// <summary>
    /// Interaction logic for ActiveLotSheets.xaml
    /// </summary>
    public partial class ActiveListingsView : Page
    {
        ActiveListingsViewModel activeListingsViewModel;
        public string Search { get => activeListingsViewModel.TableViewModel.Search; set => activeListingsViewModel.TableViewModel.Search = value; }
        public ActiveListingsView()
        {
            InitializeComponent();
            activeListingsViewModel = new ActiveListingsViewModel();
            DataContext = new ActiveListingsViewModel();
            ListingTable.DataContext = activeListingsViewModel.TableViewModel;
        }

        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await activeListingsViewModel.Load();
        }
    }
}
