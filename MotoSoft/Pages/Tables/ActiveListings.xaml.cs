using MotoSoft.ViewModels.Table;
using System.Windows.Controls;

namespace MotoSoft.Pages.Tables
{
    /// <summary>
    /// Interaction logic for ActiveLotSheets.xaml
    /// </summary>
    public partial class ActiveListings : Page
    {
        public ActiveListings()
        {
            InitializeComponent();
            LotSheetContext.DataContext = new ActiveListingsViewModel();
        }
    }
}
