using System;
using BeerGenius.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerGenius.Data
{
    public class BeerGeniusDbContext : DbContext
    {
        public BeerGeniusDbContext(DbContextOptions<BeerGeniusDbContext> options)
            : base(options)
        { }
        
        public DbSet<FlavorProfile> FlavorProfiles { get; set; }
        public DbSet<BeerGeniusUser> BeerGeniusUsers { get; set; }
        public DbSet<UserFlavorProfile> UserFlavorProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlavorProfile>(p =>
            {
                p.HasKey(_ => _.Id);
                p.HasData(
                 new FlavorProfile() { Id = 66, Color = 1, Crisp = 3, Hop = 1, Malt = 1, Fruity = 3, Sour = 2, ABV = 2, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 43, Color = 3, Crisp = 1, Hop = 2, Malt = 3, Fruity = 1, Sour = 1, ABV = 3, Roasty = 3, Sweetness = 2 },
                 new FlavorProfile() { Id = 75, Color = 1, Crisp = 3, Hop = 2, Malt = 1, Fruity = 1, Sour = 1, ABV = 1, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 60, Color = 1, Crisp = 1, Hop = 1, Malt = 3, Fruity = 3, Sour = 1, ABV = 3, Roasty = 2, Sweetness = 3 }
                 ) ;
            });
        }
    }
}
