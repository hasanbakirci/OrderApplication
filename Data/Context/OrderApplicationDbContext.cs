using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class OrderApplicationDbContext : DbContext
    {
        public OrderApplicationDbContext(DbContextOptions<OrderApplicationDbContext> options) : base(options){}
        public DbSet<Order> orders { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Address> addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Product>().Property(p => p.ImageUrl).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(150);

            modelBuilder.Entity<Address>().Property(a => a.AddressLine).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Address>().Property(a => a.City).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Address>().Property(a => a.CityCode).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Address>().Property(a => a.Country).IsRequired().HasMaxLength(150);

            modelBuilder.Entity<Order>().Property(o => o.AddressId).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.CreatedAt).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Order>().Property(o => o.UpdatedAt).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Order>().Property(o => o.CustomerId).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.Price).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Order>().Property(o => o.ProductId).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.Quantity).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Order>().Property(o => o.Status).IsRequired().HasMaxLength(150);

            modelBuilder.Entity<Customer>().Property(c => c.AddressId).IsRequired();
            modelBuilder.Entity<Customer>().Property(c => c.CreatedAt).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Customer>().Property(c => c.UpdatedAt).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Customer>().Property(c => c.Name).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<Customer>().Property(c => c.Email).IsRequired().HasMaxLength(150);


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            base.OnConfiguring(optionsBuilder);
        }
    }
}