using MotoSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoSoft.ViewModels
{
    class ProductViewModel
    {
        public Product ItemProduct { get; set; }
        private static ProductViewModel _instance;
        public static ProductViewModel Instance => _instance ?? (_instance = new ProductViewModel());
    }
}
