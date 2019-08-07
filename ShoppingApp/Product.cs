using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp
{
    public class Product
    {
        public Product(string name, double price,Category category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
        public string Name { get; }
        public double Price { get; }
        public Category Category {get;}
    }
}
