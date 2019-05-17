using System.Windows.Controls;


namespace MotoSoft.Components.Table
{
    /// <summary>
    /// Interaction logic for Table.xaml
    /// </summary>
    public partial class Table : UserControl
    {
        public Table()
        {
            InitializeComponent();
            DataContext = new TableViewModel();
        }
    }
}
