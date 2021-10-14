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
        OfferService offerService;
        CartService cartService;
        
        public ManageCart()
        {
            cartService = new CartService();
            offerService = new OfferService();
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
            decimal discountTotal, normalTotal, totalDifference;
            Console.WriteLine("Are You A Member With Us? (Y/N) Enter Y For Exclusive Discount!");
            string s = Console.ReadLine();
            discountTotal = offerService.GetDiscount();
            normalTotal = offerService.GetTotal();
            if (s == "Y")
            {
               totalDifference = normalTotal - discountTotal;
               Console.WriteLine();
               Console.WriteLine($"Your Total is {discountTotal} !", discountTotal);
               Console.WriteLine($"You Saved {totalDifference} !", totalDifference);
            }
            else
            {

                Console.WriteLine();
                Console.WriteLine($"Your Total is {normalTotal} !", normalTotal);
                
            }
            
           
         }
        public void Run()
        {
            AddToCart();
            PrintTotal();
        }
    }
}
