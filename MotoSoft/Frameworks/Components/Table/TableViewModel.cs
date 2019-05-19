using DevExpress.Mvvm;
using MotoSoft.Frameworks.Command;
using MotoSoft.ViewModels;
using System.Collections;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MotoSoft.Frameworks.Components.Table
{
    class TableViewModel:ViewModelBase
    {
        private int _pageNumber = 0;
        private int _pageSize = 15;
        private int _pagesCount = 0;
        public IDataSource Source { get; set; }
        public IList Items { get; set; }

        public TableViewModel(IDataSource source)
        {
            Source = source;
        }

        public async Task LoadItems()
        {
            Items = await Source.GetItemsForPage(_pageNumber, _pageSize);
        }

        public async Task Load()
        {
            _pagesCount = await Source.GetPagesCount(_pageSize);
            await LoadItems();
        }

        public int PageID
        {
            get => _pageNumber;
            set
            {
                if (value >= 0 && value < _pagesCount)
                {
                    _pageNumber = value;
                    Task.Run(LoadItems);
                }
            }
        }

        public int PageIDFromTextBox
        {
            get => _pageNumber + 1;
            set => _pageNumber = value - 1;
        }

        public string PageIDFromLabel
        {
            get
            {
                return $"Page {_pageNumber + 1}/{_pagesCount}";
            }
        }

        private void LoadNextPage()
        {
            if (_pageNumber < _pagesCount - 1)
            {
                _pageNumber += 1;
                Task.Run(LoadItems);
            }
        }

        private void LoadBackPage()
        {
            if (_pageNumber > 0)
            {
                _pageNumber -= 1;
                Task.Run(LoadItems);
            }
        }

        #region Command
        public ICommand NextPage
        {
            get
            {
                return new RelayCommand(x =>
                {
                    LoadNextPage();
                });
            }
        }
        public ICommand BackPage
        {
            get
            {
                return new RelayCommand(x =>
                {
                    LoadBackPage();
                });
            }
        }

        public ICommand Refresh
        {
            get => new RelayCommand(x => { Task.Run(LoadItems); });
        }
        #endregion Command
    }
}
