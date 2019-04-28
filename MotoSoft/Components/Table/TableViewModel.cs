using DevExpress.Mvvm;
using MotoSoft.Assets.Command;
using MotoSoft.Models;
using MotoSoft.Models.DataSources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MotoSoft.Components.Table
{
    class TableViewModel:ViewModelBase
    {
        private int _pageID = 0;
        private string _pageIDFromLabel;
        public IDataSource Source { get; set; }
        public IList Items { get; set; }
        private int PageID
        {
            get => _pageID;
            set
            {
                if (value >= 0 && value < Source.GetPageCount())
                    _pageID = value;
                Items = Source.GetItems(_pageID);
            }
        }

        public int PageIDFromTextBox
        {
            get => PageID+1;
            set => PageID = value-1;
        }

        public string PageIDFromLabel
        {
            get => $"Page {PageID + 1}/{Source.GetPageCount()}";
            set => _pageIDFromLabel = value;
        }
        public TableViewModel()
        {
            Source = new ProductDataSource();
            Items = Source.GetItems(_pageID);
        }


        #region Command
        public ICommand NextPage
        {
            get
            {
                return new RelayCommand(x =>
                {
                    Items = Source.GetItems(++PageID) ?? Source.GetItems(Source.GetPageCount()-1);
                });
            }
        }
        public ICommand BackPage
        {
            get
            {
                return new RelayCommand(x =>
                {
                    Items = Source.GetItems(--PageID) ?? Source.GetItems(PageID = 0);
                });
            }
        }
        #endregion Command
    }
}
