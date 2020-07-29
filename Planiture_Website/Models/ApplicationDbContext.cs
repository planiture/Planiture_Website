﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Planiture_Website.Controllers;

namespace Planiture_Website.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Investment_Info> UserInvestment { get; set; }
        public DbSet<Account_Info> UserAccount { get; set; }
        public DbSet<CusTransaction> UserTransaction { get; set; }
        public DbSet<Feedback> UserFeedback { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<ApplicationUser>().Ignore(x => x.NormalizedUserName)
            //                                 .Ignore(x => x.NormalizedEmail);

            builder.Entity<ApplicationUser>()
                .Property(p => p.MemberSince)
                .HasDefaultValueSql("getdate()");
            //builder.Entity<Investment_Info>()
            //    .HasOne(p => p.User)
             //   .WithMany(b => b.UserInvestments)
              //  .HasForeignKey(f => f.UserID);

           // builder.Entity<UserInvestment_Info>()
             //   .HasKey(p => new { p.InvestID, p.UserID });// sets both columns has composite primary key




            //builder.Entity<ApplicationUser>().ToTable("Users");

        }
    }
}
