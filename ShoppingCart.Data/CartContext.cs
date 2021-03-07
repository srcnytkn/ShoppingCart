using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Models;
using ShoppingCart.Data.Repository.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Data
{
    public class CartContext : DbContext
    {
        public CartContext(DbContextOptions<CartContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cart>()
                .HasOne(x => x.Product);

        }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
