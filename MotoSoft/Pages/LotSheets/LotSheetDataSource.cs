using MotoSoft.Frameworks;
using MotoSoft.Frameworks.Pages;

namespace MotoSoft.Pages.LotSheets
{
    public class LotSheetDataSource: SheetDataSourceBase<LotSheetsModel>
    {       
        public LotSheetDataSource()
        {
            sheetRepository = ServiceProvider.Instance.LotSheetRepository;
        }
    }
}
