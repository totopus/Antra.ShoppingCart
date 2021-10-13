using System;
using System.Collections.Generic;
using System.Text;
using Antra.ShoppingCart.Data.Model;
using Antra.ShoppingCart.Data.Repository;

namespace Antra.ShoppingCart.ConsoleApp
{
    class ManageOrderDetails
    {
        

        IRepository<OrderDetails> orderDetailsRepository;

        public ManageOrderDetails()
        {
            orderDetailsRepository = new OrderDetailsRepository();

        }
        void AddOrderDetails()
        {
            
            OrderDetails r = new OrderDetails();
            Console.Write("Enter Order Id: ");
            r.OrderId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Product Id: ");
            r.ProductId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Quantity: ");
            r.Quantity = Convert.ToInt32(Console.ReadLine());

            if (orderDetailsRepository.Insert(r) > 0)

                Console.WriteLine("Order Successfully Added!");

            else

                Console.WriteLine("Some Error has Occured");

        }
        public void Run()
        {
            AddOrderDetails();
        }
    }
}
