using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
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
            AddContectMenu();
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

        void AddContectMenu()
        {
            var context = (DataContext as TableViewModel);
            if (context != null)
            {
                if (dataGrid.ContextMenu == null) dataGrid.ContextMenu = new ContextMenu();
                dataGrid.ContextMenu.Items.Clear();
                var contextMenuFields = context.ContextMenu;
                if (context.ContextMenu != null && context.ContextMenu.Count != 0)
                {
                    foreach (var contextField in contextMenuFields)
                    {
                        dataGrid.ContextMenu.Items.Add(new MenuItem
                        {
                            Header = contextField.Title,
                            Command = contextField.Action
                        });
                    }
                }
            }
        }

        private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridCell cell = sender as DataGridCell;
            if(cell != null)
            {
                cell.Column.Width = (cell.Content as TextBlock).ActualWidth;
            }
        }
    }
}
