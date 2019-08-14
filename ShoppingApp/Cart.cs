using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShoppingApp
{
    public class Cart
    {
        private Dictionary<Product, int> _addedProducts = new Dictionary<Product, int>();
        private IDiscount _discount;

        public Cart(string discountType)
        {
            try
            {
                _discount = DiscountFactory.GetDiscountType(discountType);
            }
            catch(InvalidDiscountTypeException) { }
        }

        public double GetTotal()
        {
            return _addedProducts.Keys.Select<Product, double>(x => x.Price * _addedProducts[x]).Sum();
        }
        public double GetDiscountedTotal()
        {
            return _discount.GetDiscountedTotal(_addedProducts); ;
        }
        public void AddProduct(Product product,int quantity)
        {
            if (quantity > 0)
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
            else
            {
                throw new NotValidQuantityException("You have entered Invalid quantity");
            }
        }
        public void RemoveProduct(Product product, int quantity)
        {
            if (_addedProducts.ContainsKey(product))
            {
                if (quantity > 0 && quantity <= _addedProducts[product])
                {
                    if((_addedProducts[product] - quantity) < 0)
                        _addedProducts.Remove(product);
                    else
                        _addedProducts[product] = _addedProducts[product] - quantity;
                }
                else
                {
                    throw new NotValidQuantityException("You have entered Invalid quantity");
                }
            }
            else
            {
                throw new ProductNotFoundException("Product Specified Not Found in Cart");
            }
        }
    }
}
