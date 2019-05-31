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
                return items.Skip(page * pageCount).Take(pageCount).ToList();
            }
            return new List<T>();
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
