using ShoppingApp;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppingAppTest
{
    public class CartTest
    {
        [Theory]
        [InlineData("fixed")]
        [InlineData("configurable")]
        [InlineData("category wise")]
        
        public void Add_Product_To_Cart_With_No_Discount(string discountType)
        {
            Product product = new Product("Surface",35000,Category.Laptop);
            Cart cart = new Cart(discountType);
            cart.AddProduct(product, 2);
            Assert.Equal(70000, cart.GetTotal());
        }

        [Fact]
        public void Add_Product_To_Cart_Same_Product_Twice()
        {
            Product product = new Product("Surface", 35000, Category.Laptop);
            Cart cart = new Cart("category wise");
            cart.AddProduct(product, 2);
            cart.AddProduct(product, 1);
            Assert.Equal(105000, cart.GetTotal());
        }

        [Fact]
        public void Add_Product_To_Cart_With_Invalid_Quantity()
        {
            Product product = new Product("Surface", 35000, Category.Laptop);
            Cart cart = new Cart("category wise");
            Assert.Throws<NotValidQuantityException>(() => cart.AddProduct(product, -2));
        }

        [Fact]
        public void Remove_Product_Which_Is_Not_Present()
        {
            Product product = new Product("Surface", 35000, Category.Laptop);
            Cart cart = new Cart("category wise");
            Assert.Throws<ProductNotFoundException>(() => cart.RemoveProduct(product, 1));
        }

        [Fact]
        public void Remove_Product_From_Cart_With_Invalid_Quantity()
        {
            Product product = new Product("Surface", 35000, Category.Laptop);
            Cart cart = new Cart("category wise");
            cart.AddProduct(product, 3);
            Assert.Throws<NotValidQuantityException>(() => cart.RemoveProduct(product, -2));
        }

        [Fact]
        public void Add_Product_To_Cart_With_Categorical_Discount()
        {
            Vendor vendor = new Vendor();
            Product product = new Product("Surface", 35000, Category.Laptop);
            vendor.SetCategoryDiscount(Category.Laptop, 50);
            Cart cart = new Cart("category wise");
            cart.AddProduct(product, 2);
            Assert.Equal(35000, cart.GetDiscountedTotal());
        }
        [Fact]
        public void Add_Product_To_Cart_With_Configurable_Discount()
        {
            Vendor vendor = new Vendor();
            Product product = new Product("Surface", 35000, Category.Laptop);
            vendor.SetConfigurableDiscount(50);
            Cart cart = new Cart("configurable");
            cart.AddProduct(product, 2);
            Assert.Equal(35000, cart.GetDiscountedTotal());
        }
    }
}
