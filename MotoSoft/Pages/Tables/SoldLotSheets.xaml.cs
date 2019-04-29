using MotoSoft.ViewModels.Table;
using System.Windows.Controls;


namespace MotoSoft.Pages.Tables
{
    /// <summary>
    /// Interaction logic for SoldLotSheets.xaml
    /// </summary>
    public partial class SoldLotSheets : Page
    {
        public SoldLotSheets()
        {
            InitializeComponent();
            LotSheetContext.DataContext = new SoldLotSheetsViewModel();
        }
    }
}
