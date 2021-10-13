using System;
using System.Collections.Generic;
using System.Text;
using Antra.ShoppingCart.Data.Model;
using Antra.ShoppingCart.Data.Repository;
using System.Linq;


namespace Antra.ShoppingCart.Services
{
    public class CartService
    {
        

        IRepository<Orders> ordersRepository;
        IRepository<OrderDetails> orderDetailsRepository;
        

        public CartService()
        {
            ordersRepository = new OrdersRepository();
            orderDetailsRepository = new OrderDetailsRepository();    
        }

        public void StoreToOrders(Orders Order)
        {
            
            int orderId = ordersRepository.Insert(Order);
            foreach (var item in Order.OrderDetails)
            {
                item.OrderId = orderId;
                orderDetailsRepository.Insert(item);
            }

        }
        public decimal GetTotal()
        {
       
            var orderDetails = orderDetailsRepository.GetAll().ToList();
            var query = (from n in orderDetails
                         
                             group n by n.OrderId into g
                            orderby g.Key descending
                             select new { Total = g.Sum(f => f.Product.Price * f.Quantity) }).First();
            var max = query.Total;
            return Convert.ToDecimal(max);
        }

        


    }
}
