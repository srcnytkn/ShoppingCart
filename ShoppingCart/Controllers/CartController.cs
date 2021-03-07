using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Data.Models;
using ShoppingCart.Services.CartService;
using ShoppingCart.Services.CartService.Dtos.RequestDtos;
using ShoppingCart.Services.CartService.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] Cart cart)
        {
            AddToCartResponseDto result = await _cartService.AddToCart(new AddToCartRequestDto
            {
                CustomerId = cart.CustomerId,
                Count = cart.Count,
                Product = cart.Product
            });
            if (result.Code == 0)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
