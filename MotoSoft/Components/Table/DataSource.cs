using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoSoft.Components.Table
{
    abstract class DataSource<T> : IDataSource
    {
        public IList<List<T>> Items { get; set; }

        public IList GetItems(int page = 0)
        {
            if(page >= 0 && page < Items.Count)
                return Items[page];
            return null;
        }

        public int GetPageCount()
        {
            return Items.Count();
        }
    }
}
