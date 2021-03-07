using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Data.Enumerations;
using ShoppingCart.Data.Models;
using ShoppingCart.Data.Repository.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Repository
{
    public class CartRepository
    {
        private readonly CartContext _cartContext;

        public CartRepository(CartContext context)
        {
            _cartContext = context;
        }
        public async Task<CartControl> AddToCartAsync(Cart cart)
        {
            CartControl cartControl = new CartControl();

            var cartProduct = _cartContext.Cart.FirstOrDefault(
               x => x.Product.Id == cart.Product.Id && x.CustomerId == cart.CustomerId);

            if (cartProduct == null)
            {
                if (cart.Count > 3)
                    cartControl = CartControl.StockOut;
                else
                {
                    cartProduct = new Cart
                    {
                        CustomerId = cart.CustomerId,
                        Count = cart.Count,
                        Product = cart.Product
                    };
                    _cartContext.Cart.Add(cartProduct);
                    cartControl = CartControl.Success;
                }
                    
            }
            else
            {
                if (cartProduct.Count + cart.Count > 3)
                    cartControl = CartControl.StockOut;
                else
                {
                    cartProduct.Count += cart.Count;
                    cartControl = CartControl.Success;
                }
            }
            
            await _cartContext.SaveChangesAsync();
            return cartControl;
        }
    }
}
