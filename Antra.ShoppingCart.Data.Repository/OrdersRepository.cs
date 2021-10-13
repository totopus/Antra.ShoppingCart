using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Antra.ShoppingCart.Data.Model;
using System.Data;
using Dapper;

namespace Antra.ShoppingCart.Data.Repository
{
    public class OrdersRepository : IRepository<Orders>
    {
        FruitDbContext db;
        public OrdersRepository()
        {
            db = new FruitDbContext();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Orders> GetAll()
        {
            string query = @"select OrderId from Orders";
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.Query<Orders>(query);
            }
        }

        public Orders GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Orders item)
        {
            
            using (IDbConnection conn = db.GetConnection())
            {
                
                conn.Execute("Insert into Orders default values");
                int orderId = conn.QueryFirstOrDefault<int>("Select max(OrderId) from Orders");
                return orderId;
            }
        }

        public int Update(Orders item)
        {
            throw new NotImplementedException();
        }
    }
}
