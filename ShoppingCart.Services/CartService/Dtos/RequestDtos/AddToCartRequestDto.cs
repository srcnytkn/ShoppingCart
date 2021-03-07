using ShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Services.CartService.Dtos.RequestDtos
{
    public class AddToCartRequestDto
    {
        public int CustomerId { get; set; }
        public int Count { get; set; }

        public Products Product { get; set; }
    }
}
