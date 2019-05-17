using MotoSoft.Data.eBay;
using MotoSoft.Data.Enums;
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

        private Router()
        {
            Home = new Pages.Home();
            Inventory = new Pages.Inventory();
            ListParts = new Pages.ListParts();
            Orders = new Pages.Orders();
            Analytics = new Pages.Analytics();
            Garage = new Pages.Garage();
            Settings = new Pages.Settings();
        }

        public void InitRouter(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            if (EBayAuthorize.IsAuthorize.Equals(EbayAuthorizeState.Authorized))
                mainViewModel.CurrentPage = Home;
            else GoToAuthorize();
        }

        public void GoToHome()
        {
            if (EBayAuthorize.IsAuthorize.Equals(EbayAuthorizeState.Authorized))
                mainViewModel.CurrentPage = Home;
            else GoToAuthorize();
        }

        public void GoToInventory()
        {
            if (EBayAuthorize.IsAuthorize.Equals(EbayAuthorizeState.Authorized))
                mainViewModel.CurrentPage = Inventory;
            else GoToAuthorize();
        }

        public void GoToListParts()
        {
            if (EBayAuthorize.IsAuthorize.Equals(EbayAuthorizeState.Authorized))
                mainViewModel.CurrentPage = ListParts;
            else GoToAuthorize();
        }

        public void GoToOrders()
        {
            if (EBayAuthorize.IsAuthorize.Equals(EbayAuthorizeState.Authorized))
                mainViewModel.CurrentPage = Orders;
            else GoToAuthorize();
        }

        public void GoToAnalytics()
        {
            if (EBayAuthorize.IsAuthorize.Equals(EbayAuthorizeState.Authorized))
                mainViewModel.CurrentPage = Analytics;
            else GoToAuthorize();
        }

        public void GoToGarage()
        {
            if (EBayAuthorize.IsAuthorize.Equals(EbayAuthorizeState.Authorized))
                mainViewModel.CurrentPage = Garage;
            else GoToAuthorize();
        }

        public void GoToSettings()
        {
            if (EBayAuthorize.IsAuthorize.Equals(EbayAuthorizeState.Authorized))
                mainViewModel.CurrentPage = Settings;
            else GoToAuthorize();
        }

        public void GoToLotSheets()
        {
            if (EBayAuthorize.IsAuthorize.Equals(EbayAuthorizeState.Authorized))
                mainViewModel.CurrentPage = new Pages.Tables.LotSheets();
            else GoToAuthorize();
        }
        public void GoToActiveListings()
        {
            if (EBayAuthorize.IsAuthorize.Equals(EbayAuthorizeState.Authorized))
                mainViewModel.CurrentPage = new Pages.Tables.ActiveListings();
            else GoToAuthorize();
        }
        public void GoToSoldListings()
        {
            if (EBayAuthorize.IsAuthorize.Equals(EbayAuthorizeState.Authorized))
                mainViewModel.CurrentPage = new Pages.Tables.SoldListings();
            else GoToAuthorize();
        }

        public void GoToProduct(Data.Models.Product product = null)
        {
            if (EBayAuthorize.IsAuthorize.Equals(EbayAuthorizeState.Authorized))
                mainViewModel.CurrentPage = new Pages.Product(product);
            else GoToAuthorize();
        }

        public void GoToAuthorize()
        {
            mainViewModel.CurrentPage = new Pages.Authorize();
        }
    }
}
