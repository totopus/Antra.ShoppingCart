using System;
using System.Collections.Generic;
using System.Text;


namespace Antra.ShoppingCart.Data.Model
{
    public class Orders
    {
        public int Id { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }
    }
}
