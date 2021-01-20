using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models;

namespace Testing
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();

        public Product GetProduct(int id);

        public void UpdateProduct(Product product);

        public void InsertProduct(Product productToInsert);

        public IEnumerable<GroceryItems> GetNames();

        public IEnumerable<GroceryItems> AssignGroceryName();

        public void DeleteProduct(Product product);

    }
}
