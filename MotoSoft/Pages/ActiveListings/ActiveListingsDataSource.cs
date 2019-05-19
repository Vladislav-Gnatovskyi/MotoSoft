using MotoSoft.Frameworks;
using MotoSoft.Frameworks.Pages;

namespace MotoSoft.Pages.ActiveListings
{
    public class ActiveListingsDataSource: SheetDataSourceBase<ActiveListingsModel>
    {
        public ActiveListingsDataSource()
        {
            sheetRepository = ServiceProvider.Instance.ActiveListingsRepository;
        }
    }
}
