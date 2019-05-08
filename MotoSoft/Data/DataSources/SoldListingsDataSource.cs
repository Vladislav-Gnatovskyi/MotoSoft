using MotoSoft.Components.Table;
using MotoSoft.Data.Models;

namespace MotoSoft.Data.DataSources
{
    public class SoldListingsDataSource: SheetDataSourceBase<SoldListings>
    {       
        public SoldListingsDataSource()
        {
            sheetRepository = ServiceProvider.Instance.SoldLotSheetRepository;
            lotSheets = sheetRepository.GetSheet();
        }
    }
}
