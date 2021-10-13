using System;
using System.Collections.Generic;
using System.Text;
using Antra.ShoppingCart.Data.Model;
using Antra.ShoppingCart.Data.Repository;

namespace Antra.ShoppingCart.ConsoleApp
{
    class ManageProduct
    {
        IRepository<Product> productRepository;
        public ManageProduct()
        {
            productRepository = new ProductRepository();
        }

        void PrintAll()
        {
            var collection = productRepository.GetAll();
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Id}\t {item.ProductName}\t {item.Price}\t");
            }
        }
        public void Run()
        {
            PrintAll();
        }

    }
}
