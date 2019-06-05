using MotoSoft.Pages.LotSheets;
using System.Windows.Controls;


namespace MotoSoft.Pages.Lot
{
    /// <summary>
    /// Interaction logic for LotView.xaml
    /// </summary>
    public partial class LotView : Page
    {
        public LotView(LotSheetsModel item = null, LotSheetsModel oldItem = null)
        {
            InitializeComponent();
            DataContext = new LotViewModel(item, oldItem);
        }
    }
}
