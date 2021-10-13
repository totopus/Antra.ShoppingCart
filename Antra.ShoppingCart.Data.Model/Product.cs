﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.ShoppingCart.Data.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public Orders Orders { get; set; }
    }
}
