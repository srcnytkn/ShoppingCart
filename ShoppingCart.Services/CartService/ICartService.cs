using ShoppingCart.Services.CartService.Dtos.RequestDtos;
using ShoppingCart.Services.CartService.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services.CartService
{
    public interface ICartService
    {
        Task<AddToCartResponseDto> AddToCart(AddToCartRequestDto request);
    }
}
