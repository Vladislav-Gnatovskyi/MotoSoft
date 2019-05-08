using MotoSoft.Components.Table;
using MotoSoft.Data.Models;

namespace MotoSoft.Data.DataSources
{
    public class LotSheetDataSource: SheetDataSourceBase<LotSheet>
    {       
        public LotSheetDataSource()
        {
            sheetRepository = ServiceProvider.Instance.LotSheetRepository;
            lotSheets = sheetRepository.GetSheet();
        }
    }
}
