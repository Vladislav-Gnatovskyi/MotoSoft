using MotoSoft.Pages.Lot;

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

        public void OpenMenuEdit()
        {
            LotSheetsModel item = (LotSheetsModel)lotSheetsViewModel.TableViewModel.SelectedItem;
            lotSheetsViewModel.MenuEdit.Content = new LotView(item);
            lotSheetsViewModel.MenuEdit.Width = 300;
        }

        public void OpenMenuAdd()
        {            
            lotSheetsViewModel.MenuEdit.Content = new LotView(null);
            lotSheetsViewModel.MenuEdit.Width = 300;
        }

        public void CloseMenu()
        {
            lotSheetsViewModel.MenuEdit.Width = 0;
        }
    }
}
