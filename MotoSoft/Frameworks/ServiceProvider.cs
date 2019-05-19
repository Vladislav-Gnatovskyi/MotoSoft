using MotoSoft.Frameworks.Components.Table;
using MotoSoft.Frameworks.Ebay;
using MotoSoft.Frameworks.Pages;
using MotoSoft.Pages.ActiveListings;
using MotoSoft.Pages.Analytics;
using MotoSoft.Pages.LotSheets;
using MotoSoft.Pages.Settings;
using MotoSoft.Pages.SoldListings;

namespace MotoSoft.Frameworks
{
    public class ServiceProvider
    {
        private static ServiceProvider instance;

        public static ServiceProvider Instance => instance ?? (instance = new ServiceProvider());
        private ServiceProvider(){}

        public ISettingsRepository SettingsRepository
        {
            get
            {
                return new SettingJsonRepository();
            }
        }

        public ISheetRepository<LotSheetsModel> LotSheetRepository
        {
            get
            {
                return new LotSheetJsonRepository();
            }
        }

        public ISheetRepository<ActiveListingsModel> ActiveListingsRepository
        {
            get
            {
                return new ActiveListingsEbayRepository();
            }
        }

        public ISheetRepository<SoldListingsModel> SoldListingsEBayRepository
        {
            get
            {
                return new SoldListingsEBayRepository();
            }
        }

        public ISheetRepository<AnalyticsModel> AnalyticsRepository
        {
            get
            {
                return new AnalyticsRepository();
            }
        }

        public IEbayApiService EbayService
        {
            get
            {
                return new EbayApiService();
            }
        }

        public IDataSource GetActiveListingsDataSource
        {
            get
            {
                return new ActiveListingsDataSource();
            }
        }

        public IDataSource SoldListingsDataSource
        {
            get
            {
                return new SoldListingsDataSource();
            }
        }

        public Context CurrentContext
        {
            get
            {
                return new Context()
                {
                    Settings = SettingsRepository.Load()
                };
            }
        }
    }
}
