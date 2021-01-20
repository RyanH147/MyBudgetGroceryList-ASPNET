using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class Product
    {
        public int GroceryItemID { get; set; }
        public string Name { get; set; }
        public double PricePerUnit { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public IEnumerable<GroceryItems> GroceryNames { get; set; }
    }
}
