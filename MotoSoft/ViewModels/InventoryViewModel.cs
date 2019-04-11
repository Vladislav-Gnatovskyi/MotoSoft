using DevExpress.Mvvm;
using MotoSoft.Assets.Command;
using MotoSoft.Models;
using MotoSoft.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                if (_pageCount >= 0) _pageCount = value;
            }
        }

        public string PageNumber { get => _pageNumber = $"Page {PageCount}/{Items.Count+1}"; set => _pageNumber = value; }
        private ETypePage Type { get; set; }

        public List<Product> Items { get; set; }


        private static InventoryViewModel _instance;
        public static InventoryViewModel Instance => _instance ?? (_instance = new InventoryViewModel());

        private InventoryViewModel()
        {
            Items = new List<Product>();
            Items.Add(new Product { Brand = "Test", Description = "All Test", MPN = "Test", Name = "FirstItem", Price = 100, Quantity = 1 });
        }

        public ICommand ProductItem
        {
            get
            {
                return new RelayCommand(x => {
                    ProductViewModel.Instance.ItemProduct = Items[0];
                    MainViewModel.Instance.CurrentPage = new Pages.Product();
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
                return new RelayCommand(x => PageCount++);
            }
        }

        public ICommand BackPage
        {
            get
            {
                return new RelayCommand(x => PageCount--);
            }
        }

    }
}
