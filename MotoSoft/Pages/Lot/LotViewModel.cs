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
        public LotViewModel() { Product = new LotSheetsModel(); }

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
                if (!ServiceProvider.Instance.LotSheetRepository.AddNewItem(Product))
                {
                    MessageBox.Show("Product already exists or your not corrected fill fields!");
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
