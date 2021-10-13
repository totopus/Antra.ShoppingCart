using System;
using System.Collections.Generic;
using System.Text;
using Antra.ShoppingCart.Data.Model;
using Antra.ShoppingCart.Data.Repository;
using Antra.ShoppingCart.Services;

namespace Antra.ShoppingCart.ConsoleApp
{
    class ManageCart
    {
        CartService cartService;
        
        public ManageCart()
        {
            cartService = new CartService();

        }

        public void AddToCart()
        {
            
            Console.WriteLine();
            Console.WriteLine("Please Enter Product Id and Quantity!");
            Orders orders = new Orders();
            orders.OrderDetails = new List<OrderDetails>();
            do
            {
                OrderDetails orderDetails = new OrderDetails();
                Console.Write("Enter Product Id: ");
                orderDetails.ProductId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Product Quantity: ");
                orderDetails.Quantity = (Convert.ToInt32(Console.ReadLine()));
                orders.OrderDetails.Add(orderDetails);
                Console.WriteLine("Do You Want To Checkout?(Y/N)");
                string s = Console.ReadLine();
                
                if (s == "Y")
                {
                    cartService.StoreToOrders(orders);
                    break;
                }

            } while (true);


        }

        public void PrintTotal()
        {
            decimal total = cartService.GetTotal();
            Console.WriteLine();
            Console.WriteLine($"Your Total is {total} !",total);
         }
        public void Run()
        {
            AddToCart();
            PrintTotal();
        }
    }
}
