using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingApp
{
    public interface IProduct
    {
        string Name { get;  }
        double Price { get;}
    }
    public class MackBook : IProduct
    {
        public string Name => "Mackbook ";

        public double Price => 60000;
    }
    public class Surface : IProduct
    {
        public string Name => "Surface";

        public double Price => 35000;
    }
}
