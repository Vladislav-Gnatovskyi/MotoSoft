using eBay.Service.Core.Soap;
using MotoSoft.Frameworks;
using MotoSoft.Frameworks.Pages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoSoft.Pages.Analytics
{
    class AnalyticsRepository : ISheetRepository<AnalyticsModel>
    {
        public bool AddNewItem(AnalyticsModel item)
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
    }
}
