using MotoSoft.Frameworks.Pages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoSoft.Pages.Analytics
{
    class AnalyticsRepository : ISheetRepository<AnalyticsModel>
    {
        public event EventHandler DataChanged;

        public bool AddNewItem(AnalyticsModel item)
        {
            throw new NotImplementedException();
        }

        public bool EditItem(AnalyticsModel NewItem, string OldItem)
        {
            throw new NotImplementedException();
        }

        public IList<AnalyticsModel> GetSheet()
        {
            IList<AnalyticsModel> list = new List<AnalyticsModel>()
            {
                new AnalyticsModel()
            };
            return list;
        }

        public Task<IList<AnalyticsModel>> GetSheetAsync()
        {
            return Task.Run(GetSheet);
        }

        public bool Remove(AnalyticsModel item)
        {
            throw new NotImplementedException();
        }

        public void Save(IList sheet)
        {
            throw new NotImplementedException();
        }
    }
}
