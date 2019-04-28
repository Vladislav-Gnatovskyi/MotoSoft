using MotoSoft.ViewModels;

namespace MotoSoft.Models
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
