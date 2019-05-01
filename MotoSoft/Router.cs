using MotoSoft.Data;
using MotoSoft.Data.eBay;
using MotoSoft.ViewModels;
using System.Windows.Controls;

namespace MotoSoft
{
    public class Router
    {
        private static Router instance;
        public static Router Instance => instance ?? (instance = new Router());

        private MainViewModel mainViewModel;

        private readonly Page Home;
        private readonly Page Inventory;
        private readonly Page ListParts;
        private readonly Page Orders;
        private readonly Page Analytics;
        private readonly Page Garage;
        private readonly Page Settings;
        private readonly Page LotSheets;
        private readonly Page ActiveListings;
        private readonly Page SoldListings;
        public EBayAuthorize ebayApi { get; }

        private Router()
        {
            ebayApi = new EBayAuthorize();
            if (ebayApi.Code == null) App.Current.Shutdown();
            new EbayApiService().GetStore();
            Home = new Pages.Home();
            Inventory = new Pages.Inventory();
            ListParts = new Pages.ListParts();
            Orders = new Pages.Orders();
            Analytics = new Pages.Analytics();
            Garage = new Pages.Garage();
            Settings = new Pages.Settings();
            LotSheets = new Pages.Tables.LotSheets();
            ActiveListings = new Pages.Tables.ActiveListings();
            SoldListings = new Pages.Tables.SoldListings();
        }

        public void InitRouter(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            mainViewModel.CurrentPage = Home;
        }

        public void GoToHome()
        {
            mainViewModel.CurrentPage = Home;
        }

        public void GoToInventory()
        {
            mainViewModel.CurrentPage = Inventory;
        }

        public void GoToListParts()
        {
            mainViewModel.CurrentPage = ListParts;
        }

        public void GoToOrders()
        {
            mainViewModel.CurrentPage = Orders;
        }

        public void GoToAnalytics()
        {
            mainViewModel.CurrentPage = Analytics;
        }

        public void GoToGarage()
        {
            mainViewModel.CurrentPage = Garage;
        }

        public void GoToSettings()
        {
            mainViewModel.CurrentPage = Settings;
        }

        public void GoToLotSheets()
        {
            mainViewModel.CurrentPage = LotSheets;
        }
        public void GoToActiveListings()
        {
            mainViewModel.CurrentPage = ActiveListings;
        }
        public void GoToSoldListings()
        {
            mainViewModel.CurrentPage = SoldListings;
        }

        public void GoToProduct(Data.Models.Product product)
        {
            mainViewModel.CurrentPage = new Pages.Product(product);
        }
    }
}
