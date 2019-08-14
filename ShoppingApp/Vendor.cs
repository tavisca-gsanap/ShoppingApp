using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp
{
    public class Vendor
    {
        public void SetCategoryDiscount(Category category, float discount)
        {
            CategoryWiseDiscount categoryWiseDiscount = (CategoryWiseDiscount)DiscountFactory.GetDiscountType("category wise");
            categoryWiseDiscount.SetDiscount(category,discount);
        }
        public float GetCategoryDiscount(Category category)
        {
            CategoryWiseDiscount categoryWiseDiscount = (CategoryWiseDiscount)DiscountFactory.GetDiscountType("category wise");
            return categoryWiseDiscount.GetDiscount(category);
        }

        public void SetConfigurableDiscount(float discount)
        {
            ConfigurableDiscount configurableDiscount = (ConfigurableDiscount)DiscountFactory.GetDiscountType("configurable");
            configurableDiscount.SetDiscount(discount);
        }
        public float GetConfigurableDiscount()
        {
            ConfigurableDiscount configurableDiscount = (ConfigurableDiscount)DiscountFactory.GetDiscountType("configurable");
            return configurableDiscount.GetDiscount();
        }
    }
}
