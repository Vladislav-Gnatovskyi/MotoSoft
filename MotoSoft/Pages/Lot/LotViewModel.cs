using DevExpress.Mvvm;
using MotoSoft.Pages.LotSheets;
using MotoSoft.Frameworks.Command;
using System.Windows.Input;
using MotoSoft.Frameworks;
using System.Windows.Forms;
using System.Collections.Generic;
using MotoSoft.Pages.LotSheets.Vehicle.Models;
using System.Linq;
using MotoSoft.Pages.LotSheets.Vehicle;
using System.Windows.Media.Imaging;

namespace MotoSoft.Pages.Lot
{
    class LotViewModel:ViewModelBase
    {
        public LotSheetsModel Product { get; set; }
        private LotSheetsModel OldProduct { get; set; }
        public ETypeVehicle Type { get => Product.Type; set => Product.Type = value; }
        public string Make { get => Product.Make; set => Product.Make = value; }
        public string Title { get => Product.Title; set => Product.Title = value; }
        public string Bos { get => Product.Bos; set => Product.Bos= value; }

        public BitmapImage GetTitleImage { get => Product.GetImage(Title); }
        public BitmapImage GetBillOfSaleImage { get => Product.GetImage(Bos); }

        public ICollection<Make> Makes { get => ServiceProvider.Instance.MakeRepository.GetMakes().Where(make => make.Type.Equals(Type)).ToList(); }
        public ICollection<Model> Models { get => ServiceProvider.Instance.MakeRepository.GetModels(Make, Type); }
        public LotViewModel(LotSheetsModel item = null, LotSheetsModel oldItem = null) { Product = item ?? new LotSheetsModel(); OldProduct = oldItem ?? null; }

        public ICommand GetTitle
        {
            get => new RelayCommand(x => 
            {
                Title = new OpenFileDialogImage().ShowDialog();
            });
        }

        public ICommand GetBillOfSale
        {
            get => new RelayCommand(x =>
            {
                Bos = new OpenFileDialogImage().ShowDialog();
            });
        }

        public ICommand SaveProduct
        {
            get => new RelayCommand(x =>
            {
                if (OldProduct == null && ServiceProvider.Instance.LotSheetRepository.AddItem(Product))
                {
                    MessageBox.Show("Your successfully add new Product");
                }
                else if (OldProduct != null && ServiceProvider.Instance.LotSheetRepository.EditItem(Product, OldProduct))
                {
                    MessageBox.Show("Your successfully eding product!");
                }
                else
                {
                    MessageBox.Show("Error #102 - Wrong data!");
                    return;
                }
                    LotSheetsRouter.Instance.CloseMenu();

            if (Makes.Where(makeExists => makeExists.Name.Equals(Make)).FirstOrDefault() == null)
                    ServiceProvider.Instance.MakeRepository.AddMake(new Make(Make, Type));
            if(Models.Where(modelExists => modelExists.Name.Equals(Product.Model)).FirstOrDefault() == null)
                    ServiceProvider.Instance.MakeRepository.AddModel(new Make(Make, Type), Product.Model);
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
