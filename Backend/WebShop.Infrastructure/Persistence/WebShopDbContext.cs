using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Domain.Entities;

namespace WebShop.Infrastructure.Persistence;

internal class WebShopDbContext : DbContext
{
    public WebShopDbContext(DbContextOptions<WebShopDbContext> options) : base(options)
    {
    }
    internal DbSet<User> Users { get; set; }

    internal DbSet<Admin> Admins { get; set; }

    internal DbSet<Order> Orders { get; set; }

    internal DbSet<Product> Products { get; set; }

    internal DbSet<ProductOrder> ProductOrders { get; set; }

    internal DbSet<DiscountCoupon> DiscountCoupons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .OwnsOne(u => u.Address);

        modelBuilder.Entity<Order>()
            .OwnsOne(o => o.Address);

        modelBuilder.Entity<Order>()
        .HasOne(o => o.User)                    
        .WithMany(u => u.Orders)                 
        .HasForeignKey(o => o.UserId)          
        .IsRequired();

        modelBuilder.Entity<Order>()
            .HasOne(o => o.DiscountCoupon)
            .WithMany(d => d.Orders)
            .HasForeignKey(o => o.DiscountCouponId);

        modelBuilder.Entity<Product>()
          .HasMany(p => p.Orders)
          .WithMany(o => o.Products)
          .UsingEntity<ProductOrder>();
    }
}
