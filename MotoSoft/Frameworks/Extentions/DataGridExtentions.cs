using MotoSoft.Frameworks.Components.Table;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;

namespace MotoSoft.Assets.Extentions
{
    public static class DataGridExtentions
    {
        public static void GenerateColumns(this DataGrid dataGrid, IList<Column> columns)
        {
            dataGrid.Columns.Clear();
            int index = 0;
            foreach (var column in columns)
            {
                dataGrid.Columns.Add(new DataGridTextColumn
                {
                    Header = column.Title,
                    Binding = new Binding(string.Format("[{0}]", index++)),
                });
            }
        }
    }
}
