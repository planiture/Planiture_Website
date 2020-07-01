using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Planiture_Website.Areas.Identity.Pages.Account;
using static Planiture_Website.Areas.Identity.Pages.Account.RegisterModel.InputModel;

namespace Planiture_Website.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RegisterModel.InputModel> Customer_Info { get; set; }


    }
}
