using System.Linq;
using MotoSoft.Data.Models;

namespace MotoSoft.Data.DataSources
{
    public class SoldListingsDataSource: SheetDataSourceBase<SoldListings>
    {       
        public SoldListingsDataSource()
        {
            sheetRepository = ServiceProvider.Instance.SoldLotSheetRepository;
            GetLotSheetsAsync();
        }

        protected override async void GetLotSheetsAsync()
        {
            lotSheets = await sheetRepository.GetSheetAsync();
        }
    }
}
