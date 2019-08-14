using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShoppingApp
{
    public interface IDiscount
    {
        double GetDiscountedTotal(Dictionary<Product, int> addedProducts);
    }

    public class FixedDiscount : IDiscount
    {
        private const float _discount = 10;
        public double GetDiscountedTotal(Dictionary<Product, int> addedProducts)
        {
            double total = addedProducts.Keys.Select<Product, double>(x => x.Price * addedProducts[x]).Sum();
            return total * (1 - _discount / 100);
        }
    }

    public class ConfigurableDiscount : IDiscount
    {
        /*Below I have used singleton design pattern to make sure user 
            will get same object for which discounts has been set already*/
        private static ConfigurableDiscount _instance = null;
        public static ConfigurableDiscount GetInstance
        {
            get
            {
                if (_instance == null)
                    _instance = new ConfigurableDiscount();
                return _instance;
            }
        }
        private ConfigurableDiscount() { }

        private float _discount = 10;

        public void SetDiscount(float discount)
        {
            if (discount >= 0 && discount <= 100)
                _discount = discount;
            else
                throw new NotValidDiscountException();
        }

        public float GetDiscount()
        {
            return _discount;
        }

        public double GetDiscountedTotal(Dictionary<Product, int> addedProducts)
        {
            double total = addedProducts.Keys.Select<Product, double>(x => x.Price * addedProducts[x]).Sum();
            return total * (1 - _discount / 100);
        }
    }

    public sealed class CategoryWiseDiscount :IDiscount
    {
        /*Below I have used singleton design pattern to make sure user 
            will get same object for which discounts has been set already*/
        private static CategoryWiseDiscount _instance = null;
        public static CategoryWiseDiscount GetInstance
        {
            get
            {
                if (_instance == null)
                    _instance = new CategoryWiseDiscount();
                return _instance;
            }
        }
        private CategoryWiseDiscount() { }


        private Dictionary<Category, float> _categoryDiscounts = new Dictionary<Category, float>();
        private const float _DEFAULT_COUNT = 0;

        public void SetDiscount(Category category, float discount)
        {
            if (discount >= 0 && discount <= 100)
            {
                if (_categoryDiscounts.ContainsKey(category))
                {
                    _categoryDiscounts[category] = discount;
                }
                else
                {
                    _categoryDiscounts.Add(category, discount);
                }
            }
            else
            {
                throw new NotValidDiscountException("Not a Valid Discount Percentage");
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

        public double GetDiscountedTotal(Dictionary<Product, int> addedProducts)
        {
            double total = 0;
            foreach (var product in addedProducts.Keys)
            {
                total += (product.Price * (1 - GetDiscount(product.Category) / 100)) * addedProducts[product];
            }
            return total;
        }
    }
}
