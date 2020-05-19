using System;
using ClassProduct;
using static System.Console;

namespace TestProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDetect.message += Show;
            var product = ProductDetect.Create("ukulele", "guns");
            if(product.getContent() != "ok")
            {
                ProductDetect.toWarehouse(product);
            }
        }
        static void Show(string msg)
        {
            WriteLine(msg);
        }
    }
}
