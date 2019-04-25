using MotoSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoSoft.Components.Table
{
    class DataSource<T> : IDataSource<T>
    {
        public List<T> Items { get; set; }
        public DataSource()
        {
            Items = new List<T>();
        }

        public int GetPageCount()
        {
            return ProductList.Instance.CountPage;
        }

        public List<T> GetItems(int page = 1)
        {
            return Items;
        }

        public void SetItems(List<T> list)
        {
            Items = list;
        }
    }
}
