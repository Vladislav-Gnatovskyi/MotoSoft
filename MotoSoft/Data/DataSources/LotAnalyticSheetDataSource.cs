using MotoSoft.Data.Models;

namespace MotoSoft.Data.DataSources
{
    public class LotAnalyticSheetDataSource: SheetDataSourceBase<LotAnalyticSheet>
    {
        public LotAnalyticSheetDataSource()
        {
            sheetRepository = ServiceProvider.Instance.LotAnalyticSheetRepository;
            GetLotSheetsAsync();
        }
    }
}
