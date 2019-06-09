using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoSoft.Frameworks.Components.Table
{
    public interface IDataSource
    {
        event EventHandler SourceChanged;

        Task<int> GetPagesCount(int pageSize);
        IList<Column> Columns { get; set; }
        IList<ContextMenuField> ContextMenu { get; set; }
        string Search { get; set; }
        Task<IList> GetItemsForPage(int page, int pageSize);
    }
}
