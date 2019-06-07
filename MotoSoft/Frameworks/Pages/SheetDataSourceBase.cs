using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MotoSoft.Frameworks.Components.Table;

namespace MotoSoft.Frameworks.Pages
{
    public abstract class SheetDataSourceBase<T> : IDataSource
    {
        private int pageCount = 15;

        private ISheetRepository<T> sheetRepository;

        public string Search { get; set; } = "";

        protected ISheetRepository<T> SheetRepository
        {
            get
            {
                return sheetRepository;
            }
            set
            {
                if(sheetRepository != null)
                {
                    sheetRepository.DataChanged -= SheetRepository_DataChanged;
                }
                sheetRepository = value;
                sheetRepository.DataChanged += SheetRepository_DataChanged;
            }
        }

        private void SheetRepository_DataChanged(object sender, EventArgs e)
        {
            SourceChanged?.Invoke(sender, e);
            //clean cache
            _allItems = null;
        }

        public event EventHandler SourceChanged;

        private IList<T> _allItems { get; set; }
        public IList<Column> Columns { get; set; }

        protected SheetDataSourceBase()
        {
            Columns = new List<Column>();
        }

        private async Task<IList<T>> GetAllItems()
        {
            if (_allItems == null)
            {
                _allItems = await sheetRepository.GetSheetAsync();
            }
            return _allItems;
        }

        public async Task<IList> GetItemsForPage(int page, int pageSize)
        {
            var items = await GetAllItems();
            if (items != null)
            {
                pageCount = pageSize;
                var itemsReturn = items.Skip(page * pageCount).Take(pageCount).ToList();
                if (Search == "") return itemsReturn;
                else return Contains(itemsReturn, Search).ToList();
            }
            return new List<T>();
        }

        protected virtual IList<T> Contains(IEnumerable<T> listFinder, string Search)
        {
            return listFinder.ToList();
        }

        public async Task<int> GetPagesCount(int pageSize)
        {
            var items = await GetAllItems();
            if (items != null)
            {
                int totalPages = items.Count / pageSize;
                if (items.Count % pageSize > 0)
                {
                    totalPages += 1;
                }
                return totalPages;
            }
            return 1;
        }
    }
}
