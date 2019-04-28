using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoSoft.Components.Table
{
    public interface IPageItem
    {
        int PageID { get; set; }
        int PageIDFromTextBox { get; set; }
        string PageIDFromLabel { get; }
        IDataSource Source { get; set; }
        IList Items { get; }
        IList NextPage();
        IList BackPage();
    }
}
