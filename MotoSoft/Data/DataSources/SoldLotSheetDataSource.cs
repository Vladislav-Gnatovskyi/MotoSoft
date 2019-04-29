using MotoSoft.Data.Models;

namespace MotoSoft.Data.DataSources
{
    public class SoldLotSheetDataSource:SheetDataSource<SoldLotSheet>
    {       
        public SoldLotSheetDataSource()
        {
            sheetRepository = ServiceProvider.Instance.SoldLotSheetRepository;
            lotSheets = sheetRepository.GetSheet();
        }
    }
}
