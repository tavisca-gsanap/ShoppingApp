using System;
using Xunit;
using ShoppingApp;

namespace ShoppingAppTest
{
    public class DiscountTest
    {
        [Fact]
        public void Set_Configurable_Discount()
        {
            Vendor vendor = new Vendor();
            vendor.SetConfigurableDiscount(12);
            Assert.Equal(12, vendor.GetConfigurableDiscount());
        }

        [Fact]
        public void Set_Discount_To_Category()
        {
            Vendor vendor = new Vendor();
            vendor.SetCategoryDiscount(Category.Laptop,12);
            Assert.Equal(12, vendor.GetCategoryDiscount(Category.Laptop));
        }

        [Fact]
        public void Set_Invalid_Discount_Of_Category()
        {
            Vendor vendor = new Vendor();
            Assert.Throws<NotValidDiscountException>(() => vendor.SetCategoryDiscount(Category.Laptop, -12));
        }

        [Fact]
        public void Change_Discount_Of_Category()
        {
            Vendor vendor = new Vendor();
            vendor.SetCategoryDiscount(Category.Laptop, 12);
            vendor.SetCategoryDiscount(Category.Laptop, 15);
            Assert.Equal(15, vendor.GetCategoryDiscount(Category.Laptop));
        }
    }
}
