using DevExpress.Mvvm;
using MotoSoft.Pages.LotSheets;
using MotoSoft.Frameworks.Command;
using System.Windows.Input;
using MotoSoft.Frameworks;
using System.Windows.Forms;

namespace MotoSoft.Pages.Lot
{
    class LotViewModel:ViewModelBase
    {
        public LotSheetsModel Product { get; set; }
        private string _OldProduct;
        public LotViewModel(LotSheetsModel item = null, string oldProduct = null) { Product = item ?? new LotSheetsModel(); _OldProduct = oldProduct; }

        public ICommand GetTitle
        {
            get => new RelayCommand(x => 
            {
                Product.Title = new OpenFileDialogImage().ShowDialog();
                MessageBox.Show($"{Product.Title}");
            });
        }

        public ICommand GetBillOfSale
        {
            get => new RelayCommand(x =>
            {
                Product.Bos = new OpenFileDialogImage().ShowDialog();
                MessageBox.Show($"{Product.Bos}");
            });
        }

        public ICommand SaveProduct
        {
            get => new RelayCommand(x =>
            {
                if (_OldProduct == null && ServiceProvider.Instance.LotSheetRepository.AddNewItem(Product))
                {
                    MessageBox.Show("Your successfully add new Product");
                }
                else if(_OldProduct != null && ServiceProvider.Instance.LotSheetRepository.EditItem(Product, _OldProduct))
                {
                    MessageBox.Show("Your successfully edit product");
                }
                else
                {
                    MessageBox.Show("Error save product");
                    return;
                }
                LotSheetsRouter.Instance.CloseMenu();
            });
        }

        public ICommand Cancel
        {
            get => new RelayCommand(x =>
            {
                LotSheetsRouter.Instance.CloseMenu();
            });
        }
    }
}
