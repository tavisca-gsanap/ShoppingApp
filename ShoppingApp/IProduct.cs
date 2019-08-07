﻿using System;
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
        string Name { get; }
        double Price { get; }
        Category Category {get;}
    }
}
