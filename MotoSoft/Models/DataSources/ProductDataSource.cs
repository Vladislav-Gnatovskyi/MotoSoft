using MotoSoft.Components.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoSoft.Models.DataSources
{
    class ProductDataSource : DataSource<Product>
    {
        public ProductDataSource()
        {
            Items = ProductList.Instance.ProductPage();
        }
    }
}
