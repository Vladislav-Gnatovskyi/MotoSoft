﻿using MotoSoft.Components.Table;
using MotoSoft.Data.Models;

namespace MotoSoft.Data.DataSources
{
    public class SoldListingsDataSource:SheetDataSource<SoldListings>
    {       
        public SoldListingsDataSource()
        {
            sheetRepository = ServiceProvider.Instance.SoldLotSheetRepository;
            lotSheets = sheetRepository.GetSheet();
            Columns.Add(new Column { Title = "Item ID" });
        }
    }
}
