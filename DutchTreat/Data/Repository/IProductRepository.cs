using System.Collections.Generic;
using DutchTreat.Data.Entities;

namespace DutchTreat.Data
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
    }
}