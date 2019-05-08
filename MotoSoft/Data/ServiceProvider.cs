using MotoSoft.Data.eBay;
using MotoSoft.Data.Interfaces;
using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.eBay;
using MotoSoft.Data.Repository.Interfaces;
using MotoSoft.Data.Repository.Json;

namespace MotoSoft.Data
{
    public class ServiceProvider
    {
        private static ServiceProvider instance;
        public static ServiceProvider Instance => instance ?? (instance = new ServiceProvider());
        private ServiceProvider() { }

        public ISettingsRepository SettingsRepository
        {
            get
            {
                return new SettingJsonRepository();
            }
        }

        public IProductsRepository ProductsRepository
        {
            get
            {
                return new ProductsJsonRepository();
            }
        }

        public ISheetRepository<LotSheet> LotSheetRepository
        {
            get
            {
                return new LotSheetEBayRepository();
            }
        }

        public ISheetRepository<ActiveListings> ActiveListingsRepository
        {
            get
            {
                return new ActiveListingsEBayRepository();
            }
        }

        public ISheetRepository<SoldListings> SoldLotSheetRepository
        {
            get
            {
                return new SoldListingsEBayRepository();
            }
        }

        public ISheetRepository<LotAnalyticSheet> LotAnalyticSheetRepository
        {
            get
            {
                return new LotAnalyticsSheetEBayRepository();
            }
        }

        public IEBayApiService eBayService
        {
            get
            {
                return new FakeEBayService();
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
