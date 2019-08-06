using ShoppingApp;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppingAppTest
{
    public class CartTest
    {
        [Fact]
        public void Add_Product_To_Cart_With_No_Discount()
        {
            OfferManager offerManager = new OfferManager();
            IProduct product = new Surface();
            Cart cart = new Cart(offerManager);
            cart.AddToCart(product, 2);
            Assert.Equal(70000, cart.GetTotal());
        }
        [Fact]
        public void Add_Product_To_Cart_Same_Product_Twice()
        {
            OfferManager offerManager = new OfferManager();
            IProduct product = new Surface();
            Cart cart = new Cart(offerManager);
            cart.AddToCart(product, 2);
            cart.AddToCart(product, 1);
            Assert.Equal(105000, cart.GetTotal());
        }
        [Fact]
        public void Add_Product_To_Cart_With_Discount()
        {
            OfferManager offerManager = new OfferManager();
            IProduct product = new Surface();
            offerManager.AddDiscount(product, 50);
            Cart cart = new Cart(offerManager);
            cart.AddToCart(product, 2);
            Assert.Equal(35000, cart.GetDiscountedTotal());
        }

    }
}
