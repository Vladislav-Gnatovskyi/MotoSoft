namespace MotoSoft.Pages.LotSheets
{
    class LotSheetsRouter
    {
        private static LotSheetsRouter instance;
        public static LotSheetsRouter Instance => instance ?? (instance = new LotSheetsRouter());
        private LotSheetsViewModel lotSheetsViewModel;
        public void InitRouter(LotSheetsViewModel lotSheetsViewModel)
        {
            this.lotSheetsViewModel = lotSheetsViewModel;
        }
        
        public void OpenMenu()
        {
            lotSheetsViewModel.MenuEdit.Width = 300;
        }
         public void CloseMenu()
        {
            lotSheetsViewModel.MenuEdit.Width = 0;
        }
    }
}
