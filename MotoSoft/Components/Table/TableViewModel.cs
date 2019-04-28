using DevExpress.Mvvm;
using MotoSoft.Models;
using MotoSoft.Models.DataSources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoSoft.Components.Table
{
    class TableViewModel:ViewModelBase
    {
        public IDataSource Source { get; set; }
        public IList Items { get; set; }
        public TableViewModel()
        {
            Source = new ProductDataSource();
            Items = Source.GetItems();
        }
    }
}
