using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models;
using Dapper;

namespace Testing
{
    public class ProductRepo : IProductRepository
    {
        private readonly IDbConnection _conn;

        public ProductRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM grocery_items;");
        }

        public Product GetProduct(int id)
        {
            return (Product)_conn.QuerySingle<Product>("SELECT * FROM grocery_items WHERE GroceryItemID = @id", new { id = id });
        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE grocery_items SET Name = @name, PricePerUnit = @price, Quantity = @quantity WHERE GroceryItemID = @id",
                new { name = product.Name, price = product.PricePerUnit, quantity = product.Quantity, id = product.GroceryItemID });
        }

        public void InsertProduct(Product productToInsert)
        {
            _conn.Execute("INSERT INTO grocery_items (Name, PricePerUnit, Quantity) VALUES (@Name, @Price, @Quantity);",
                new { name = productToInsert.Name, price = productToInsert.PricePerUnit, quantity = productToInsert.Quantity });
        }

        public IEnumerable<GroceryItems> GetNames()
        {
            return _conn.Query<GroceryItems>("SELECT Name FROM grocery_items;");
        }

        public IEnumerable<GroceryItems> AssignGroceryName()
        {
            var groceryList = GetNames();
            var productName = new Product();
            return productName.GroceryNames = groceryList;
        }

        public void DeleteProduct(Product product)
        {
            _conn.Execute("DELETE FROM grocery_items WHERE GroceryItemID = @id;", new { id = product.GroceryItemID });
        }
    }
}
