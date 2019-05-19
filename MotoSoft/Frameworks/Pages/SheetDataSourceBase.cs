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

        protected ISheetRepository<T> sheetRepository;
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
