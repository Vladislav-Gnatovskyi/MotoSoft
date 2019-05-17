using eBay.Service.Core.Soap;
using MotoSoft.Components.Table;
using MotoSoft.Data.Repository.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MotoSoft.Data.DataSources
{
    public abstract class SheetDataSourceBase<T>: IDataSource
    {
        private int pageCount = 15;

        protected ISheetRepository<T> sheetRepository;
        protected IList<T> lotSheets { get; set; }
        public IList<Column> Columns { get; set; }

        protected SheetDataSourceBase ()
        {
            Columns = new List<Column>();
        }

        protected virtual async void GetLotSheetsAsync()
        {
            lotSheets = await sheetRepository.GetSheetAsync();
        }

        public IList GetItems(int page = 0, int pageCountItems = 15)
        {
            if (lotSheets != null)
            {
                pageCount = pageCountItems;
                return lotSheets.Skip(page * pageCount).Take(pageCount).ToList();
            }
            else return new List<T>();
        }
        public int GetPageCount()
        {
            if (lotSheets != null)
            {
                int totalPages = lotSheets.Count / pageCount;
                if (lotSheets.Count % pageCount > 0)
                {
                    totalPages += 1;
                }
                return totalPages;
            }
            return 1;
        }
    }
}
