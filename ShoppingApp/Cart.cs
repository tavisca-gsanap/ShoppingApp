using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp
{
    public class Cart
    {
        private Dictionary<Product, int> _addedProducts = new Dictionary<Product, int>();
        private DiscountConfig _discountConfig;

        public Cart(DiscountConfig discountConfig)
        {
            _discountConfig = discountConfig;
        }

        public double GetTotal()
        {
            double total = 0;
            foreach(var product in _addedProducts.Keys)
            {
                total += product.Price * _addedProducts[product];
            }
            return total;
        }
        public double GetDiscountedTotal()
        {
            double total = 0;
            foreach (var product in _addedProducts.Keys)
            {
                total += (product.Price * (1 - _discountConfig.GetDiscount(product.Category) / 100)) * _addedProducts[product];
            }
            return total;
        }
        public void AddProduct(Product product,int quantity)
        {
            if (_addedProducts.ContainsKey(product))
            {
                _addedProducts[product] += quantity;
            }
            else
            {
                _addedProducts.Add(product, quantity);
            }
        }
        public void RemoveProduct(Product product, int quantity)
        {
            if (_addedProducts.ContainsKey(product))
            {
                _addedProducts[product] = (_addedProducts[product] - quantity) < 0 ? 0 : (_addedProducts[product] - quantity);
            }
            else
            {
                _addedProducts.Remove(product);
            }
        }
    }
}
