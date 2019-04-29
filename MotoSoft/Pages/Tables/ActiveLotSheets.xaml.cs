using MotoSoft.ViewModels.Table;
using System.Windows.Controls;

namespace MotoSoft.Pages.Tables
{
    /// <summary>
    /// Interaction logic for ActiveLotSheets.xaml
    /// </summary>
    public partial class ActiveLotSheets : Page
    {
        public ActiveLotSheets()
        {
            InitializeComponent();
            LotSheetContext.DataContext = new ActiveLotSheetsViewModel();
        }
    }
}
