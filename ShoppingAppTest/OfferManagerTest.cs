using System;
using Xunit;
using ShoppingApp;

namespace ShoppingAppTest
{
    public class OfferManagerTest
    {
        [Fact]
        public void Add_Discount_To_Product()
        {
            OfferManager offerManager = new OfferManager();
            IProduct product = new Surface();
            offerManager.AddDiscount(product,12);
            Assert.Equal(12, offerManager.GetDiscount(product));
        }
        [Fact]
        public void Change_Discount_Of_Product()
        {
            OfferManager offerManager = new OfferManager();
            IProduct product = new Surface();
            offerManager.AddDiscount(product, 12);
            offerManager.AddDiscount(product, 15);
            Assert.Equal(15, offerManager.GetDiscount(product));
        }
    }
}
