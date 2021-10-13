using System;
using System.Collections.Generic;
using System.Text;
using Antra.ShoppingCart.Data.Model;
using System.Data;
using Dapper;

namespace Antra.ShoppingCart.Data.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        FruitDbContext db;
        public ProductRepository()
        {
            db = new FruitDbContext();
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.Query<Product>("Select Id,ProductName,Price from Product");
            }
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Product item)
        {
            throw new NotImplementedException();
        }

        public int Update(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
