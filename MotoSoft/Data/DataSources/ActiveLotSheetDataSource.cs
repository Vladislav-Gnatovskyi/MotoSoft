using MotoSoft.Components.Table;
using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MotoSoft.Data.DataSources
{
    class ActiveLotSheetDataSource:SheetDataSource<ActiveLotSheet>
    {
        public ActiveLotSheetDataSource()
        {
            sheetRepository = ServiceProvider.Instance.ActiveLotSheetRepository;
            lotSheets = sheetRepository.GetSheet();
        }
    }
}
