using System;
using Antra.ShoppingCart.Services;

namespace Antra.ShoppingCart.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ManageProduct manageProduct = new ManageProduct();
            manageProduct.Run();

            ManageCart managecart = new ManageCart();
            managecart.Run();


        }

    }
}
