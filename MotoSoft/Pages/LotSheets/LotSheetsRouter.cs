using MotoSoft.Frameworks;
using MotoSoft.Pages.Lot;
using System.Linq;

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
            if (item != null)
            {
                LotSheetsModel oldItem = ServiceProvider.Instance.LotSheetRepository.GetSheet().Where(itemExist => itemExist.Lot.Equals(item.Lot)).FirstOrDefault();
                if (oldItem != null)
                {
                    lotSheetsViewModel.MenuEdit.Content = new LotView(item, oldItem);
                    lotSheetsViewModel.MenuEdit.Width = 300;
                }
            }
        }

        public void OpenMenuAdd()
        {            
            lotSheetsViewModel.MenuEdit.Content = new LotView();
            lotSheetsViewModel.MenuEdit.Width = 300;
        }

        public void CloseMenu()
        {
            lotSheetsViewModel.MenuEdit.Width = 0;
        }
    }
}
