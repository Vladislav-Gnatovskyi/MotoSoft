using DevExpress.Mvvm;
using MotoSoft.Pages.LotSheets;
using MotoSoft.Frameworks.Command;
using System.Windows.Input;
using MotoSoft.Frameworks;

namespace MotoSoft.Pages.Lot
{
    class LotViewModel:ViewModelBase
    {
        public LotSheetsModel Product { get; set; }
        public LotViewModel() { Product = new LotSheetsModel(); }


        public ICommand AddProduct
        {
            get => new RelayCommand(x => 
            {
                ServiceProvider.Instance.LotSheetRepository.AddNewItem(Product);
            });
        }
    }
}
