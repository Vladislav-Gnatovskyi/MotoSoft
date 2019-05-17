using MotoSoft.Data.Models;

namespace MotoSoft.Data.DataSources
{
    public class ActiveListingsDataSource:SheetDataSourceBase<ActiveListings>
    {
        public ActiveListingsDataSource()
        {
            sheetRepository = ServiceProvider.Instance.ActiveListingsRepository;
            GetLotSheetsAsync();
        }
    }
}
