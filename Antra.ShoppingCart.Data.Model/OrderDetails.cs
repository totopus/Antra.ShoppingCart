using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.ShoppingCart.Data.Model
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Orders Orders { get; set; }
        public Product Product { get; set; }
        
    }
}
