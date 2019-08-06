using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp
{
    public class OfferManager
    {
        private Dictionary<IProduct, float> Discounts = new Dictionary<IProduct, float>();
        public void AddDiscount(IProduct product, float dicount)
        {
            if (Discounts.ContainsKey(product))
            {
                Discounts[product] = dicount;
            }
            else
            {
                Discounts.Add(product, dicount);
            }
        }
        public float GetDiscount(IProduct product)
        {
            if (Discounts.ContainsKey(product))
            {
                return Discounts[product];
            }
            else
            {
                return 0;
            }
        }
    }
}
