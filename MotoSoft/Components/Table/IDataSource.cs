using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoSoft.Components.Table
{
    interface IDataSource
    {
        int GetPageCount();
        IList GetItems(int page = 1);
    }
}
