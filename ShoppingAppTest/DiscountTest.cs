using System;
using Xunit;
using ShoppingApp;

namespace ShoppingAppTest
{
    public class DiscountTest
    {
        [Fact]
        public void Add_Discount_To_Category()
        {
            DiscountConfig discountConfig = new DiscountConfig();
            discountConfig.SetDiscount(Category.Laptop,12);
            Assert.Equal(12, discountConfig.GetDiscount(Category.Laptop));
        }

        [Fact]
        public void Set_Invalid_Discount_Of_Category()
        {
            DiscountConfig discountConfig = new DiscountConfig();
            Assert.Throws<NotValidDiscountException>(() => discountConfig.SetDiscount(Category.Laptop, -12));
        }

        [Fact]
        public void Change_Discount_Of_Category()
        {
            DiscountConfig discountConfig = new DiscountConfig();
            discountConfig.SetDiscount(Category.Laptop, 12);
            discountConfig.SetDiscount(Category.Laptop, 15);
            Assert.Equal(15, discountConfig.GetDiscount(Category.Laptop));
        }
    }
}
