using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Data.Models
{
    public class Cart
    {

        public int Id { get; set; }

        public int CustomerId { get; set; }
        public int Count { get; set; }

        public Products Product { get; set; }
    }
}
