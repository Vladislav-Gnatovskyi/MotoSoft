using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using MotoSoft.ViewModels;

namespace MotoSoft
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            bool existed;
            // получаем GIUD приложения
            string guid = Marshal.GetTypeLibGuidForAssembly(Assembly.GetExecutingAssembly()).ToString();
            Mutex mutexObj = new Mutex(true, guid, out existed);
            if (existed)
            {
                InitializeComponent();
                DataContext = new MainViewModel();
            }
            else App.Current.Shutdown();
        }
    }
}
