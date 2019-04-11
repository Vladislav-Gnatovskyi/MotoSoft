using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MotoSoft.ViewModels
{
    class ListPartsViewModel : ViewModelBase
    {
        public Page CurrentPage { get; set; } = new Pages.ListPartPage.Years();
    }
}
