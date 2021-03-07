using ShoppingCart.Data.Enumerations;
using ShoppingCart.Data.Models;
using ShoppingCart.Data.Repository;
using ShoppingCart.Data.Repository.Dtos.RequestDtos;
using ShoppingCart.Services.CartService.Dtos.RequestDtos;
using ShoppingCart.Services.CartService.Dtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly CartRepository _cartRepository;
        public CartService(CartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<AddToCartResponseDto> AddToCart(AddToCartRequestDto request)
        {
            try
            {
                if(request.Count == 0)
                    return new AddToCartResponseDto
                    {
                        Code = 101,
                        Message = "Sepete ürün eklemelisiniz."
                    };

                CartControl cartControl =  await _cartRepository.AddToCartAsync(new Cart
                {
                    CustomerId = request.CustomerId,
                    Count = request.Count,
                    Product = request.Product
                });
                
                if(cartControl == CartControl.StockOut)
                    return new AddToCartResponseDto
                    {
                        Code = 102,
                        Message = "Ürün, stoklarımızda tükenmiştir."
                    };


                return new AddToCartResponseDto
                {
                    Code = 0,
                    Message = "İşlem başarılı."

                };
            }
            catch (Exception ex)
            {
                return new AddToCartResponseDto
                {
                    Code = 999,
                    Message = "Şu anda işleminizi gerçekleştiremiyoruz. Lütfen daha sonra tekrar deneyin."
                };
            }

        }
    }
}
