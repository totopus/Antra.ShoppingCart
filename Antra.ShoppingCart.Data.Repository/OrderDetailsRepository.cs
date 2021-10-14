using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Antra.ShoppingCart.Data.Model;
using System.Data;
using Dapper;

namespace Antra.ShoppingCart.Data.Repository
{
    public class OrderDetailsRepository : IRepository<OrderDetails>
    {
        FruitDbContext db;
        public OrderDetailsRepository()
        {
            db = new FruitDbContext();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            string query = @"select od.orderid,od.quantity,od.productId,p.Id,p.productname,p.price from orderdetails od
                        left join product p on p.Id=od.ProductId";
            using (IDbConnection conn = db.GetConnection())
            {
                return conn.Query<OrderDetails, Product, OrderDetails>(query, (od, p) => { od.Product = p; return od; });
            }
        }

        public OrderDetails GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(OrderDetails item)
        {
            
            using (IDbConnection conn = db.GetConnection() )
            {
                
                return conn.Execute("Insert into OrderDetails values (@OrderId,@ProductId,@Quantity)", item);
            }
        }

        public int Update(OrderDetails item)
        {
            throw new NotImplementedException();
        }
    }



       
    }
