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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlavorProfile>(p =>
            {
                p.HasKey(_ => _.Id);
                p.HasData(
                 new FlavorProfile() { Id = 66, Color = 0, Aroma = 0, Crisp = 0, Hop = 0, Malt = 0, Fruity = 0, Sour = 0, ABV = 0, Roasty = 0, Sweetness = 0 },
                 new FlavorProfile() { Id = 2, Color = 0, Aroma = 0, Crisp = 0, Hop = 0, Malt = 0, Fruity = 0, Sour = 0, ABV = 0, Roasty = 0, Sweetness = 0 },
                 new FlavorProfile() { Id = 3, Color = 0, Aroma = 0, Crisp = 0, Hop = 0, Malt = 0, Fruity = 0, Sour = 0, ABV = 0, Roasty = 0, Sweetness = 0 },
                 new FlavorProfile() { Id = 4, Color = 0, Aroma = 0, Crisp = 0, Hop = 0, Malt = 0, Fruity = 0, Sour = 0, ABV = 0, Roasty = 0, Sweetness = 0 }
                 ) ;
            });
        }
    }
}
