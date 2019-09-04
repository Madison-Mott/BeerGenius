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
                 new FlavorProfile() { Id = 66, Color = 2, Aroma = 1, Crisp = 7, Hop = 1, Malt = 1, Fruity = 10, Sour = 6, ABV = 6, Roasty = 0, Sweetness = 6 },
                 new FlavorProfile() { Id = 43, Color = 10, Aroma = 10, Crisp = 0, Hop = 5, Malt = 10, Fruity = 1, Sour = 0, ABV = 8, Roasty = 8, Sweetness = 4 },
                 new FlavorProfile() { Id = 75, Color = 1, Aroma = 3, Crisp = 8, Hop = 4, Malt = 2, Fruity = 1, Sour = 0, ABV = 3, Roasty = 0, Sweetness = 1 },
                 new FlavorProfile() { Id = 60, Color = 3, Aroma = 7, Crisp = 0, Hop = 3, Malt = 8, Fruity = 8, Sour = 0, ABV = 10, Roasty = 4, Sweetness = 7 }
                 ) ;
            });
        }
    }
}
