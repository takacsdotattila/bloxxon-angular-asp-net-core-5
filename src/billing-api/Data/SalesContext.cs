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
                new Customer { Id = 1, FirstName = "Tony", LastName = "Stark", Email = "t.start@bloxxon.co", ImgUrl = "https://i.imgflip.com/1bepoi.jpg" },                
                new Customer { Id = 2, FirstName = "Peter", LastName = "Parker", Email = "p.parker@bloxxon.co" , ImgUrl= "https://media.tenor.com/images/980f9c417ca728c305659728764998c1/tenor.gif" },
                new Customer { Id = 3, FirstName = "Bruce", LastName = "Banner", Email = "b.banner@bloxxon.co" , ImgUrl = "https://img1.looper.com/img/gallery/will-bruce-banner-be-in-the-disney-she-hulk-series/intro-1569264697.jpg" },
                new Customer { Id = 4, FirstName = "Robert", LastName= "Freeman", Email = "robert.jabadiah.ph.freeman@boondocxxx.com", 
                    ImgUrl = "https://thesource.com/wp-content/uploads/2019/06/Check-Out-Robert-Freemans-Design-From-The-Boondocks-Reboot.jpg" } 
            );

            modelBuilder.Entity<Invoice>().HasData(
                new Invoice
                {
                    Id = 1,
                    Amount = 50_000,
                    CustomerId = 2,
                    DeadLine = DateTime.UtcNow.AddDays(15)
                }
                );

            modelBuilder.Entity<Customer>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
