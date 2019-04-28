using System.Collections.Generic;

namespace MotoSoft.Models
{
    public interface IProductsRepository
    {
        List<Product> GetProducts();
        void Save(List<Product> products);
    }
}