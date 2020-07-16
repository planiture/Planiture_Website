using System;
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

        public DbSet<Investment_Info> Investment_Info { get; set; }
        public DbSet<UserInvestment_Info> UserInvestment_Infos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<ApplicationUser>().Ignore(x => x.NormalizedUserName)
            //                                 .Ignore(x => x.NormalizedEmail);

            builder.Entity<ApplicationUser>()
                .Property(p => p.MemberSince)
                .HasDefaultValueSql("getdate()");

            builder.Entity<UserInvestment_Info>()
                .HasKey(p => new { p.InvestID, p.UserID });// sets both columns has composite primary key


            //builder.Entity<ApplicationUser>().ToTable("Users");

        }
    }
}
