using MotoSoft.Components.Table;
using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace MotoSoft.Data.DataSources
{
    public class ProductDataSource : IDataSource
    {
        private int pageCount = 15;

        private IProductsRepository productsRepository;
        private List<Product> products { get; set; }

        public IList GetItems(int page = 0, int pageCountItems = 15)
        {
            pageCount = pageCountItems;
            return products.Skip(page * pageCount).Take(pageCount).ToList();
        }
        public int GetPageCount()
        {
            int totalPages = products.Count / pageCount;
            if (products.Count % pageCount > 0)
            {
                totalPages += 1;
            } 
            return totalPages;
        }

        public ProductDataSource()
        {
            productsRepository = ServiceProvider.Instance.ProductsRepository;
            products = productsRepository.GetProducts();
        }
    }
}
