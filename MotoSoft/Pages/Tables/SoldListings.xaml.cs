using MotoSoft.ViewModels.Table;
using System.Windows.Controls;


namespace MotoSoft.Pages.Tables
{
    /// <summary>
    /// Interaction logic for SoldLotSheets.xaml
    /// </summary>
    public partial class SoldListings : Page
    {
        public SoldListings()
        {
            InitializeComponent();
            LotSheetContext.DataContext = new SoldListingsViewModel();
        }
    }
}
