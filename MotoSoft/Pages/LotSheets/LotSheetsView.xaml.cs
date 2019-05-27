using System.Windows.Controls;

namespace MotoSoft.Pages.LotSheets
{
    /// <summary>
    /// Interaction logic for LotSheets.xaml
    /// </summary>
    public partial class LotSheetsView : Page
    {
        LotSheetsViewModel lotSheetsViewModel;
        public LotSheetsView()
        {
            InitializeComponent();
            DataContext = lotSheetsViewModel = new LotSheetsViewModel();
            LotSheetsTable.DataContext = lotSheetsViewModel.TableViewModel;
        }

        private void Page_Initialized(object sender, System.EventArgs e)
        {
        }

        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await lotSheetsViewModel.Load();
        }
    }
}
