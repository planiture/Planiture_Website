using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Planiture_Website.Models;
using static Planiture_Website.Areas.Identity.Pages.Account.RegisterModel;

namespace Planiture_Website.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<InputModel> Customer_Info { get; set; }
        public DbSet<Account_Info> Account_Info { get; set; }
        //public DbSet<Beneficiary_Info> Beneficiary_Info { get; set; }
        public DbSet<CusTransaction> CusTransaction { get; set; }
        public DbSet<Employee_Info> Employee_Info { get; set; }
        public DbSet<Investment_Info> Investment_Info { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InputModel>()
                .Property(p => p.MemberSince)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<InputModel>()
                .Property(p => p.CustomerID)
                .UseIdentityColumn();

            modelBuilder.Entity<Account_Info>()
                .Property(p => p.AccountNumber)
                .UseIdentityColumn();

            /*modelBuilder.Entity<Beneficiary_Info>()
                .Property(p => p.BeneficiaryID)
                .UseIdentityColumn();*/

            modelBuilder.Entity<CusTransaction>()
                .Property(p => p.TransactionID)
                .UseIdentityColumn();

            modelBuilder.Entity<Employee_Info>()
                .Property(p => p.EmployeeID)
                .UseIdentityColumn();

            modelBuilder.Entity<Investment_Info>()
                .Property(p => p.InvestID)
                .UseIdentityColumn();

            //Configuring database relationships and references
            modelBuilder.Entity<InputModel>() //Customer_Info Foreign Key
                .HasMany(p => p.Bene_Investments)
                .WithOne();
            //modelBuilder.Entity<InputModel>()
               // .Navigation(b => b.Bene_Invesments)
                  //  .UsePropertyAccessMode(PropertyAccessMode.Property);
            modelBuilder.Entity<InputModel>()
                .HasMany(p => p.Accounts)
                .WithOne();
            modelBuilder.Entity<InputModel>()
                .HasMany(p => p.cusTransactionsCustomer)
                .WithOne();
            modelBuilder.Entity<Employee_Info>()
                .HasMany(p => p.cusTransactionsEmployee)
                .WithOne();
            modelBuilder.Entity<Account_Info>()
                .HasMany(p => p.cusTransactionsAccount)
                .WithOne();
            
        }
    }
}
