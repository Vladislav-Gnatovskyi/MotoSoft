using MotoSoft.Data;
using MotoSoft.Data.Models;
using MotoSoft.Data.Repository;
using MotoSoft.Data.Repository.Interfaces;
using MotoSoft.ViewModels;

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
                return new LotSheetJsonRepository();
            }
        }

        public ISheetRepository<ActiveListings> ActiveLotSheetRepository
        {
            get
            {
                return new ActiveListingsJsonRepository();
            }
        }

        public ISheetRepository<SoldListings> SoldLotSheetRepository
        {
            get
            {
                return new SoldListingsRepository();
            }
        }

        public ISheetRepository<LotAnalyticSheet> LotAnalyticSheetRepository
        {
            get
            {
                return new LotAnalyticSheetJsonRepository();
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
