using System.Windows.Controls;


namespace MotoSoft.Pages.Lot
{
    /// <summary>
    /// Interaction logic for LotView.xaml
    /// </summary>
    public partial class LotView : Page
    {
        public LotView()
        {
            InitializeComponent();
            DataContext = new LotViewModel();
        }
    }
}
