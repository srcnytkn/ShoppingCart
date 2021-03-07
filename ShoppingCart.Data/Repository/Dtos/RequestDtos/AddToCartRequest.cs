using ShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Data.Repository.Dtos.RequestDtos
{
    public class AddToCartRequest
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public int Count { get; set; }
        public Products Product { get; set; }
    }
}
