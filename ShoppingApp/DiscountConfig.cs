using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp
{
    public class DiscountConfig
    {
        private Dictionary<Category, float> _categoryDiscounts = new Dictionary<Category, float>();
        private const float _DEFAULT_COUNT = 0;

        public void SetDiscount(Category category, float dicount)
        {
            if (_categoryDiscounts.ContainsKey(category))
            {
                _categoryDiscounts[category] = dicount;
            }
            else
            {
                _categoryDiscounts.Add(category, dicount);
            }
        }
        public float GetDiscount(Category category)
        {
            if (_categoryDiscounts.ContainsKey(category))
            {
                return _categoryDiscounts[category];
            }
            else
            {
                return _DEFAULT_COUNT;
            }
        }
    }
}
