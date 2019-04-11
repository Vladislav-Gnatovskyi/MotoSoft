using DevExpress.Mvvm;
using MotoSoft.Assets.Command;
using MotoSoft.Models;
using MotoSoft.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MotoSoft.ViewModels
{
    class InventoryViewModel:ViewModelBase
    {
        private string _pageNumber;
        private int _pageCount;

        private int PageCount
        {
            get => _pageCount <= 0 ? 1 : _pageCount;
            set
            {
                if (_pageCount >= 0 && value < ProductList.Instance.CountPage) _pageCount = value;
            }
        }

        public string PageNumber { get => _pageNumber = $"Page {PageCount}/{ProductList.Instance.CountPage}"; set => _pageNumber = value; }
        private ETypePage Type { get; set; }

        public List<Product> Items { get; set; }


        private static InventoryViewModel _instance;
        public static InventoryViewModel Instance => _instance ?? (_instance = new InventoryViewModel());

        private InventoryViewModel()
        {
            Items = ProductList.Instance.ProductsPage();
        }

        public ICommand ProductItem
        {
            get
            {
                return new RelayCommand(x => {
                    int id = Int32.Parse(x.ToString());
                    Product product = ProductList.Instance.ProductPage(PageCount, id);
                    if (product != null)
                    {
                        ProductViewModel.Instance.ItemProduct = product;
                        MainViewModel.Instance.CurrentPage = new Pages.Product();
                    }
                    else
                    {
                        MessageBox.Show("Product is not exist!");
                    }
                });
            }
        }

        public ICommand Apparel_Click
        {
            get
            {
                return new RelayCommand(x => Type = ETypePage.Apparel);
            }
        }

        public ICommand SeeAll_Click
        {
            get
            {
                return new RelayCommand(x => Type = ETypePage.SeeAll);
            }
        }

        public ICommand Tires_Click
        {
            get
            {
                return new RelayCommand(x => Type = ETypePage.Tires);
            }
        }

        public ICommand NextPage
        {
            get
            {
                return new RelayCommand(x => ++PageCount);
            }
        }

        public ICommand BackPage
        {
            get
            {
                return new RelayCommand(x => --PageCount);
            }
        }

    }
}
