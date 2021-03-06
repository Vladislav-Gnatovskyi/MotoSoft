﻿using MotoSoft.ViewModels;
using System.Windows.Controls;
using MotoSoft.Pages.ActiveListings;
using MotoSoft.Pages.SoldListings;
using MotoSoft.Pages.LotSheets;
using MotoSoft.Pages.Analytics;
using MotoSoft.Pages.Settings;
using MotoSoft.Frameworks.Authorize;
using MotoSoft.Pages.Authorize;
using MotoSoft.Pages.Lot;
using MotoSoft.Frameworks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection;

namespace MotoSoft
{
    public class Router
    {
        private static Router instance;
        public static Router Instance => instance ?? (instance = new Router());

        private MainViewModel mainViewModel;

        private LotSheetsView _lotSheets;
        private AnalyticsView _analytics;
        private ActiveListingsView _activeListings;
        private SoldListingsView _soldListings;
        private LotView _lotCreate;
        private SettingsView _settings;
        private Authorize _brouser;

        private Authorize Brouser(string url = null)
        {
            if (_brouser == null && url == null)
                _brouser = new Authorize("https://www.ebay.com/");
            else if (url != null) new Authorize(url);
                return _brouser;
        }

        private LotSheetsView LotSheets
        {
            get
            {
                if (_lotSheets == null)
                {
                    _lotSheets = new LotSheetsView();
                }
                return _lotSheets;
            }
        }

        private AnalyticsView Analytics
        {
            get
            {
                if (_analytics == null)
                {
                    _analytics = new AnalyticsView();
                }
                return _analytics;
            }
        }

        private LotView LotCreate
        {
            get
            {
                if(_lotCreate == null)
                {
                    _lotCreate = new LotView(null);
                }
                return _lotCreate;
            }
        }

        private ActiveListingsView ActiveListings
        {
            get
            {
                if(_activeListings == null)
                {
                    _activeListings = new ActiveListingsView();
                }
                return _activeListings;
            }
        }
        private SoldListingsView SoldListings
        {
            get
            {
                if(_soldListings == null)
                {
                    _soldListings = new SoldListingsView();
                }
                return _soldListings;
            }
        }
        private SettingsView Settings
        {
            get
            {
                if(_settings == null)
                {
                    _settings = new SettingsView();
                }
                return _settings;
            }
        }
        public void GotToDefault()
        {
            GoToLotSheets();
        }

        public void InitRouter(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            ServiceProvider.Instance.EbayService.GetTokenStatusCall();
            GotToDefault();
        }
       
        public void GoToBrouser(string url = null)
        {
            SetPage(Brouser(url));
        }

        public void GoToAnalytics()
        {
            SetPage(Analytics);
        }      

        public void GoToSettings()
        {
            SetPage(Settings);
        }

        public void GoToLotSheets()
        {
            SetPage(LotSheets);
        }
        public void GoToActiveListings(string search = "")
        {
            ActiveListings.Search = search;
            SetPage(ActiveListings);
        }
        public void GoToSoldListings(string search = "")
        {
            SoldListings.Search = search;
            SetPage(SoldListings);
        }

        public void GoToLotCreate()
        {
            SetPage(LotCreate);
        }

        public void GoToAuthorize()
        {
            mainViewModel.CurrentPage = new Authorize();
        }

        private void SetPage(Page page)
        {
            if (EBayAuthorize.Instance.IsAuthorized)
            {
                mainViewModel.CurrentPage = page;                
            }
            else
            {
                GoToAuthorize();
            }
        }
    }
}
