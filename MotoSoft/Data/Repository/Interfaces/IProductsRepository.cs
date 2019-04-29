using MotoSoft.Data.Models;
using System.Collections.Generic;

namespace MotoSoft.Data.Repository.Interfaces
{
    public interface IProductsRepository
    {
        List<Product> GetProducts();
        void Save(List<Product> products);
    }
}