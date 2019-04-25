using DevExpress.Mvvm;
using MotoSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoSoft.Components.Table
{
    class TableViewModel:ViewModelBase
    {
        public DataSource<Product> Source { get; set; }
        public TableViewModel()
        {
            Source = new DataSource<Product>();
            Source.SetItems(ProductList.Instance.Products);
        }
    }
}
