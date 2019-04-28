using DevExpress.Mvvm;
using MotoSoft.Components.Table;
using System.Collections;

namespace MotoSoft.ViewModels
{
    public class PageItemsViewModel : ViewModelBase, IPageItem
    {
        private int _pageID = 0;
        private int _countItems = 15;
        public IDataSource Source { get; set; }
        public IList Items { get; set; }
        public PageItemsViewModel(IDataSource source, int countItems = 15)
        {
            Source = source;
            _countItems = countItems;
            Items = Source.GetItems(PageID, _countItems);
        }
        
        public int PageID
        {
            get => _pageID;
            set
            {
                if (value >= 0 && value < Source.GetPageCount())
                    _pageID = value;
                Items = Source.GetItems(_pageID, _countItems);
            }
        }

        public int PageIDFromTextBox
        {
            get => PageID + 1;
            set => PageID = value - 1;
        }

        public string PageIDFromLabel
        {
            get => $"Page {PageID + 1}/{Source.GetPageCount()}";
        }

        public IList NextPage()
        {
            return Items = PageID + 1 < Source.GetPageCount() ? Source.GetItems(++PageID, _countItems) : Source.GetItems(Source.GetPageCount() - 1, _countItems);
        }

        public IList BackPage()
        {
            return Items = Source.GetItems(--PageID, _countItems) ?? Source.GetItems(PageID = 0, _countItems);
        }        
    }
}
