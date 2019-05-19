using System.Windows.Controls;

namespace MotoSoft.Pages.Settings
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class SettingsView : Page
    {
        public SettingsView()
        {
            InitializeComponent();
            DataContext = new SettingViewModel();
        }
    }
}
