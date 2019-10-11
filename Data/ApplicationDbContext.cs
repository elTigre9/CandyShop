using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CandyShop.Data;

namespace CandyShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CandyShop.Data.Manufacturer> Manufacturer { get; set; }
        public DbSet<CandyShop.Data.Store> Store { get; set; }
        public DbSet<CandyShop.Data.Candy> Candy { get; set; }
    }
}
