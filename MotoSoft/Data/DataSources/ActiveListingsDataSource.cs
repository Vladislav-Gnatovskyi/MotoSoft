using MotoSoft.Components.Table;
using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MotoSoft.Data.DataSources
{
    class ActiveListingsDataSource:SheetDataSourceBase<ActiveListings>
    {
        public ActiveListingsDataSource()
        {
            sheetRepository = ServiceProvider.Instance.ActiveListingsRepository;
            lotSheets = sheetRepository.GetSheet();
        }
    }
}
