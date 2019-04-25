using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoSoft.Components.Table
{
    interface IDataSource <T>
    {
        int GetPageCount();
        List<T> GetItems(int page = 1);
    }
}
