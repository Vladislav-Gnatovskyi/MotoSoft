using MotoSoft.ViewModels;
using System.Windows.Controls;

namespace MotoSoft.Pages.Authorize
{
    /// <summary>
    /// Interaction logic for Authorize.xaml
    /// </summary>
    public partial class Authorize : Page
    {
        public Authorize()
        {
            InitializeComponent();
            DataContext = new AuthorizeViewModel();
        }
    }
}
