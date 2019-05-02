using MotoSoft.Components.Table;
using MotoSoft.Data.Models;

namespace MotoSoft.Data.DataSources
{
    public class LotSheetDataSource:SheetDataSource<LotSheet>
    {       
        public LotSheetDataSource()
        {
            sheetRepository = ServiceProvider.Instance.LotSheetRepository;
            lotSheets = sheetRepository.GetSheet();
        }
    }
}
