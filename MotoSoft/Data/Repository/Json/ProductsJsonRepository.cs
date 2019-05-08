using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MotoSoft.Data.Repository.Json
{
    public class ProductsJsonRepository: IProductsRepository
    {
        private const string productsFilename = "products.json";
        public List<Product> GetProducts()
        {
            if (File.Exists(productsFilename))
            {
                string json = File.ReadAllText(productsFilename);
                List<Product> obj = JsonConvert.DeserializeObject<List<Product>>(json);
                return obj;
            }
            return new List<Product>();
        }

        public void Save(List<Product> products)
        {
            string json = JsonConvert.SerializeObject(products);
            File.WriteAllText(productsFilename, json);
        }
    }
}
