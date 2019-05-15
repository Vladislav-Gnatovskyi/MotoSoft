using MotoSoft.ViewModels.Table;
using System.Windows.Controls;

namespace MotoSoft.Pages.Tables
{
    /// <summary>
    /// Interaction logic for LotSheets.xaml
    /// </summary>
    public partial class LotSheets : Page
    {
        public LotSheets()
        {
            InitializeComponent();
            LotSheetContext.DataContext = new LotSheetsViewModel();
            DataContext = new LotSheetsViewModel();
        }
    }
}
