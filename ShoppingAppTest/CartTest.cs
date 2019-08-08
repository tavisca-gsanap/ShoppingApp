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
            DiscountConfig discountConfig = new DiscountConfig();
            Product product = new Product("Surface",35000,Category.Laptop);
            Cart cart = new Cart(discountConfig);
            cart.AddProduct(product, 2);
            Assert.Equal(70000, cart.GetTotal());
        }

        [Fact]
        public void Add_Product_To_Cart_Same_Product_Twice()
        {
            DiscountConfig discountConfig = new DiscountConfig();
            Product product = new Product("Surface", 35000, Category.Laptop);
            Cart cart = new Cart(discountConfig);
            cart.AddProduct(product, 2);
            cart.AddProduct(product, 1);
            Assert.Equal(105000, cart.GetTotal());
        }

        [Fact]
        public void Add_Product_To_Cart_With_Invalid_Quantity()
        {
            DiscountConfig discountConfig = new DiscountConfig();
            Product product = new Product("Surface", 35000, Category.Laptop);
            Cart cart = new Cart(discountConfig);
            Assert.Throws<NotValidQuantityException>(() => cart.AddProduct(product, -2));
        }

        [Fact]
        public void Remove_Product_Which_Is_Not_Present()
        {
            DiscountConfig discountConfig = new DiscountConfig();
            Product product = new Product("Surface", 35000, Category.Laptop);
            Cart cart = new Cart(discountConfig);
            Assert.Throws<ProductNotFoundException>(() => cart.RemoveProduct(product, 1));
        }

        [Fact]
        public void Remove_Product_From_Cart_With_Invalid_Quantity()
        {
            DiscountConfig discountConfig = new DiscountConfig();
            Product product = new Product("Surface", 35000, Category.Laptop);
            Cart cart = new Cart(discountConfig);
            cart.AddProduct(product, 3);
            Assert.Throws<NotValidQuantityException>(() => cart.RemoveProduct(product, -2));
        }

        [Fact]
        public void Add_Product_To_Cart_With_Discount()
        {
            DiscountConfig discountConfig = new DiscountConfig();
            Product product = new Product("Surface", 35000, Category.Laptop);
            discountConfig.SetDiscount(Category.Laptop, 50);
            Cart cart = new Cart(discountConfig);
            cart.AddProduct(product, 2);
            Assert.Equal(35000, cart.GetDiscountedTotal());
        }


    }
}
