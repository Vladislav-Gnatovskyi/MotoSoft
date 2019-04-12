using System;
using System.Collections.Generic;

namespace MotoSoft.Models
{
    class ProductList
    {
        private List<List<Product>> _products;
        private static ProductList _instance;
        public static ProductList Instance => _instance ?? (_instance = new ProductList());
        public int CountPage { get => _products.Count; }

        public List<Product> Products { get; set; }


        private ProductList()
        {
            _products = new List<List<Product>>();
            Products = new List<Product>();
            Products = ProductsJsonRepository.Load();
        }


        public List<List<Product>> ProductPage()
        {
            if (!Products.Count.Equals(0))
            {
                _products = new List<List<Product>>();
                int count = 0, page = 0;
                Products.ForEach(x =>
                {
                    if (count.Equals(14))
                    {
                        _products.Add(new List<Product>());
                        count = 0;
                        page++;
                    }
                    else if (_products.Count.Equals(0))
                    {
                        _products.Add(new List<Product>());
                    }
                    _products[page].Add(x);
                    count++;
                });
                return _products;
            }
            return null;
        }

        public List<Product> ProductsPage(int page = 1)
        {
            ProductPage();
            return (_products.Count > 0 && _products.Count > page-1) ? _products[page-1] : null;
        }

        public Product ProductPage(int page, int ID)
        {
            List<Product> items = ProductsPage(page);
            try
            {
                return (items.Count > 0 && items.Count > ID - 1) ? items[ID] : null;
            }
            catch (ArgumentOutOfRangeException EX)
            {
                return null;
            }
        }
    }
}
