using Billing.API.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Billing.API.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "Tony", LastName = "Stark", Email = "t.start@bloxxon.co" },
                new Customer { Id = 2, FirstName = "Peter", LastName = "Parker", Email = "p.parker@bloxxon.co" },
                new Customer { Id = 3, FirstName = "Bruce", LastName = "Banner", Email = "b.banner@bloxxon.co" }
            );

            modelBuilder.Entity<Invoice>().HasData(
                new Invoice
                {
                    Id = 1,
                    Amount = 50_000,
                    CustomerId = 2,
                    DeadLine = DateTime.UtcNow.AddDays(15),
                    Date = DateTime.Now.AddDays(-15)
                }
                );
        }
    }
}
