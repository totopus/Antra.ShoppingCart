using System;
using System.Collections.Generic;
using System.Text;
using Antra.ShoppingCart.Data.Model;
using Antra.ShoppingCart.Data.Repository;
using System.Linq;

namespace Antra.ShoppingCart.Services
{
    public class OfferService
    {
        IRepository<OrderDetails> orderDetailsRepository;
        IRepository<Orders> ordersRepository;
        
        public OfferService()
        {
            orderDetailsRepository = new OrderDetailsRepository();
            ordersRepository = new OrdersRepository();
          
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


        public decimal GetDiscount()
        {
            
            var orderDetails = orderDetailsRepository.GetAll().ToList();
            var max = orderDetails.Max(x=>x.OrderId);

            int appleNormal = (from n in orderDetails
                             where n.OrderId == max
                             group n by n.ProductId into g
                             where g.Key == 1
                             select g.Sum(f => f.Quantity) ).FirstOrDefault();

            int orangeNormal = (from n in orderDetails
                               where n.OrderId == max
                               group n by n.ProductId into g
                               where g.Key == 2
                               select g.Sum(f => f.Quantity)).FirstOrDefault();

            decimal applePrice = (from n in orderDetails 
                         where n.OrderId == max
                         group n by new { n.ProductId, n.Product.Price } into g
                         where g.Key.ProductId == 1
                         select g.Key.Price ).First();
            
           

            decimal orangePrice = (from n in orderDetails
                          where n.OrderId == max
                          group n by new { n.ProductId, n.Product.Price } into g
                          where g.Key.ProductId == 2
                          select g.Key.Price).First();

           
            int appleDiscount, orangeDiscount;

            if (appleNormal % 2 == 0)

            { appleDiscount = appleNormal / 2; }
            else
            {
                appleDiscount = (appleNormal / 2) + 1;
            }

            if (orangeNormal % 3 == 0)

            { orangeDiscount = (orangeNormal / 3) * 2; }
            else if (orangeNormal % 3 == 1)
            {
                orangeDiscount = (orangeNormal / 3) * 2 + 1;
            }
            else
            {
                orangeDiscount = (orangeNormal / 3) * 2 + 2;
            }


            decimal total = (applePrice * appleDiscount) + (orangePrice * orangeDiscount);

            return total;

        }
    }
}
