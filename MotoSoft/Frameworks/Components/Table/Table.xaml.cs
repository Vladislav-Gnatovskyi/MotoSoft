using System.Windows.Controls;
using System.Windows.Data;
using MahApps.Metro.Controls;

namespace MotoSoft.Frameworks.Components.Table
{
    /// <summary>
    /// Interaction logic for Table.xaml
    /// </summary>
    public partial class Table : UserControl
    {
        public Table()
        {
            InitializeComponent();
            DataContextChanged += Table_DataContextChanged;
        }

        private void Table_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            AddColumns();
        }

        void AddColumns()
        {
            var context = (DataContext as TableViewModel);
            if (context != null)
            {
                dataGrid.Columns.Clear();
                var columns = context.Columns;
                foreach (var column in columns)
                {
                    dataGrid.Columns.Add(new DataGridTextColumn
                    {
                        Binding = new Binding(column.Field),
                        Header = column.Title
                    });
                }
            }
        }
    }
}
