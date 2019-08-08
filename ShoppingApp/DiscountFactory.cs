using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp
{
    public static class DiscountFactory
    {
        public static IDiscount GetDiscountType(string discountType)
        {
            switch (discountType.ToLower())
            {
                case "fixed":
                    return new FixedDiscount();
                case "configurable":
                    return ConfigurableDiscount.GetInstance;
                case "category wise":
                    return CategoryWiseDiscount.GetInstance;
                default:
                    throw new InvalidDiscountTypeException("Invalid Discount Type");
            }
        }
    }
}
