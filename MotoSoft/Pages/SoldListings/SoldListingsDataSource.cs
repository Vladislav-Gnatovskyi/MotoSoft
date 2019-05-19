using MotoSoft.Frameworks;
using MotoSoft.Frameworks.Pages;
using System.Linq;
namespace MotoSoft.Pages.SoldListings
{
    public class SoldListingsDataSource: SheetDataSourceBase<SoldListingsModel>
    {       
        public SoldListingsDataSource()
        {
            sheetRepository = ServiceProvider.Instance.SoldListingsEBayRepository;
        }
    }
}
