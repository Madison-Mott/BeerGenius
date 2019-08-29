using System;
using Microsoft.EntityFrameworkCore;

namespace BeerGenius.Data
{
    public class BeerGeniusDbContext : DbContext
    {
        public BeerGeniusDbContext(DbContextOptions<BeerGeniusDbContext> options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
