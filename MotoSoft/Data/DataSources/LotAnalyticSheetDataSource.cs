using MotoSoft.Components.Table;
using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MotoSoft.Data.DataSources
{
    public class LotAnalyticSheetDataSource:SheetDataSource<LotAnalyticSheet>
    {
        public LotAnalyticSheetDataSource()
        {
            sheetRepository = ServiceProvider.Instance.LotAnalyticSheetRepository;
            lotSheets = sheetRepository.GetSheet();
            Columns.Add(new Column { Title = "Item ID" });
        }
    }
}
