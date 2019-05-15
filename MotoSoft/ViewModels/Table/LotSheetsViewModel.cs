using DevExpress.Mvvm;
using MotoSoft.Assets.Command;
using MotoSoft.Components.Table;
using MotoSoft.Data.DataSources;
using System.Windows;
using System.Windows.Input;

namespace MotoSoft.ViewModels.Table
{
    class LotSheetsViewModel:TableViewModel
    {
        private const int itemsOnPage = 40;
        public LotSheetsViewModel()
        {
            Source = new LotSheetDataSource();
            PageItemsContol = new PageItemsViewModel(Source, itemsOnPage);
        }

        public ICommand AddClick
        {
            get
            {
                return new RelayCommand(x => {
                    MessageBox.Show("Test");
                Router.Instance.GoToProduct(new Data.Models.Product()); });
            }
        }
    }
}
