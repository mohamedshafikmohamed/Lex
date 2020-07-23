using System;
using System.Collections.Generic;
using System.Text;
using Lex.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lex.Data
{
    public class ApplicationDbContext : IdentityDbContext<Application_user>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
   
}
