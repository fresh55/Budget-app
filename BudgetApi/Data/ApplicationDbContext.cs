using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BudgetApi.Data
{
    public class ApplicationDbContext :  IdentityDbContext<User>
    {
        //konstruktor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Budget> Budgets { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Budget>()
       .Property(b => b.Amount)
       .HasPrecision(18, 4); // Adjust the precision and scale as needed

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 4); // Adjust the precision and scale as needed

              modelBuilder.Entity<User>().HasData(
           new User { UserId = 1, Username = "HardcodedUser1", Email = "user1@example.com" },
        new User { UserId = 2, Username = "HardcodedUser2", Email = "user2@example.com" }
    );

        }
    }
}