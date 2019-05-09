using MotoSoft.Data.Models;

namespace MotoSoft.Data.DataSources
{
    class ActiveListingsDataSource:SheetDataSourceBase<ActiveListings>
    {
        public ActiveListingsDataSource()
        {
            sheetRepository = ServiceProvider.Instance.ActiveListingsRepository;
            lotSheets = sheetRepository.GetSheet();
        }
    }
}
