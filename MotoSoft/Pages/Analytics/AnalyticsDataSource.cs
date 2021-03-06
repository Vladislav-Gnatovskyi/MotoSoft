﻿using MotoSoft.Frameworks;
using MotoSoft.Frameworks.Pages;

namespace MotoSoft.Pages.Analytics
{
    public class AnalyticsDataSource: SheetDataSourceBase<AnalyticsModel>
    {
        public AnalyticsDataSource()
        {
            SheetRepository = ServiceProvider.Instance.AnalyticsRepository;
        }
    }
}
