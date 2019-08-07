using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp
{
    public interface IDiscount
    {
        float GetDiscount(Dictionary<Product, int> addedProducts);
        
    }
}
