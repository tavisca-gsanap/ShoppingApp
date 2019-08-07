using System;
using Xunit;
using ShoppingApp;

namespace ShoppingAppTest
{
    public class OfferManagerTest
    {
        [Fact]
        public void Add_Discount_To_Category()
        {
            DiscountConfig offerManager = new DiscountConfig();
            offerManager.SetDiscount(Category.Laptop,12);
            Assert.Equal(12, offerManager.GetDiscount(Category.Laptop));
        }
        [Fact]
        public void Change_Discount_Of_Category()
        {
            DiscountConfig offerManager = new DiscountConfig();
            offerManager.SetDiscount(Category.Laptop, 12);
            offerManager.SetDiscount(Category.Laptop, 15);
            Assert.Equal(15, offerManager.GetDiscount(Category.Laptop));
        }
    }
}
