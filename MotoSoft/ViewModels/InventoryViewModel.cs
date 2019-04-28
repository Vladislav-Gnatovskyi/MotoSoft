using DevExpress.Mvvm;
using MotoSoft.Assets.Command;
using MotoSoft.Components.Table;
using MotoSoft.Models;
using MotoSoft.Models.DataSources;
using MotoSoft.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace MotoSoft.ViewModels
{
    public class InventoryViewModel: ViewModelBase
    {
        public IDataSource Source { get; set; }
        public PageItemsViewModel PageItemsContol { get; set; }
        public IList Items { get; set; }
        private ETypePage Type { get; set; }
        
        public InventoryViewModel()
        {
            Source = new ProductDataSource();
            PageItemsContol = new PageItemsViewModel(Source);
            Items = Source.GetItems(PageItemsContol.PageID);
        }

        public ICommand ProductItem
        {
            get
            {
                return new RelayCommand(x =>
                {
                    int id = Int32.Parse(x.ToString());
                    Product product = (Product)Items[id];
                    if (product != null)
                    {
                        Router.Instance.GoToProduct(product);
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
                return new RelayCommand(x =>
                {
                        Items = PageItemsContol.NextPage();
                });
            }
        }

        public ICommand BackPage
        {
            get
            {
                return new RelayCommand(x =>
                {
                        Items = PageItemsContol.BackPage();
                });
            }
        }
    }
}
