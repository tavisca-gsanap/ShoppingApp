using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp
{
    public class Cart
    {
        private Dictionary<IProduct, int> _addedProducts = new Dictionary<IProduct, int>();
        private OfferManager _offerManager;

        public Cart(OfferManager offerManager)
        {
            _offerManager = offerManager;
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
                total += (product.Price * (1 - _offerManager.GetDiscount(product) / 100)) * _addedProducts[product];
            }
            return total;
        }
        public void AddToCart(IProduct product,int quantity)
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
    }
}
