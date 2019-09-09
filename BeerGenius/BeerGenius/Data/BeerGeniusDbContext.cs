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
                 new FlavorProfile() { Id = 1, BreweryDbId = 1, Color = 2, Crisp = 2, Hop = 3, Malt = 2, Fruity = 2, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 2, BreweryDbId = 2, Color = 2, Crisp = 2, Hop = 3, Malt = 2, Fruity = 3, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 3, BreweryDbId = 3, Color = 2, Crisp = 2, Hop = 3, Malt = 2, Fruity = 1, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 4, BreweryDbId = 4, Color = 2, Crisp = 2, Hop = 3, Malt = 2, Fruity = 1, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 1 },
                 new FlavorProfile() { Id = 5, BreweryDbId = 5, Color = 2, Crisp = 2, Hop = 3, Malt = 2, Fruity = 1, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 6, BreweryDbId = 6, Color = 1, Crisp = 2, Hop = 3, Malt = 1, Fruity = 1, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 1 },
                 new FlavorProfile() { Id = 7, BreweryDbId = 7, Color = 1, Crisp = 2, Hop = 1, Malt = 2, Fruity = 1, Sour = 1, ABV = 1, Roasty = 2, Sweetness = 1 },
                 new FlavorProfile() { Id = 8, BreweryDbId = 8, Color = 2, Crisp = 2, Hop = 1, Malt = 2, Fruity = 1, Sour = 1, ABV = 1, Roasty = 2, Sweetness = 1 },
                 new FlavorProfile() { Id = 9, BreweryDbId = 9, Color = 2, Crisp = 2, Hop = 1, Malt = 2, Fruity = 2, Sour = 1, ABV = 1, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 10, BreweryDbId = 10, Color = 2, Crisp = 2, Hop = 1, Malt = 3, Fruity = 1, Sour = 1, ABV = 1, Roasty = 2, Sweetness = 1 },
                 new FlavorProfile() { Id = 11, BreweryDbId = 11, Color = 3, Crisp = 1, Hop = 1, Malt = 3, Fruity = 1, Sour = 1, ABV = 1, Roasty = 2, Sweetness = 1 },
                 new FlavorProfile() { Id = 12, BreweryDbId = 12, Color = 2, Crisp = 1, Hop = 1, Malt = 3, Fruity = 1, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 13, BreweryDbId = 13, Color = 2, Crisp = 1, Hop = 1, Malt = 3, Fruity = 2, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 14, BreweryDbId = 14, Color = 2, Crisp = 1, Hop = 1, Malt = 3, Fruity = 2, Sour = 1, ABV = 3, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 15, BreweryDbId = 15, Color = 2, Crisp = 1, Hop = 1, Malt = 3, Fruity = 1, Sour = 1, ABV = 3, Roasty = 3, Sweetness = 3 },
                 new FlavorProfile() { Id = 16, BreweryDbId = 16, Color = 3, Crisp = 1, Hop = 2, Malt = 3, Fruity = 2, Sour = 1, ABV = 3, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 17, BreweryDbId = 17, Color = 2, Crisp = 1, Hop = 1, Malt = 3, Fruity = 3, Sour = 1, ABV = 3, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 18, BreweryDbId = 18, Color = 2, Crisp = 1, Hop = 2, Malt = 3, Fruity = 2, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 19, BreweryDbId = 19, Color = 3, Crisp = 1, Hop = 2, Malt = 3, Fruity = 2, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 20, BreweryDbId = 20, Color = 2, Crisp = 1, Hop = 2, Malt = 3, Fruity = 2, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 3 },
                 new FlavorProfile() { Id = 21, BreweryDbId = 21, Color = 3, Crisp = 1, Hop = 1, Malt = 3, Fruity = 1, Sour = 1, ABV = 2, Roasty = 3, Sweetness = 2 },
                 new FlavorProfile() { Id = 22, BreweryDbId = 22, Color = 2, Crisp = 2, Hop = 2, Malt = 2, Fruity = 1, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 23, BreweryDbId = 23, Color = 3, Crisp = 1, Hop = 3, Malt = 3, Fruity = 1, Sour = 1, ABV = 2, Roasty = 3, Sweetness = 2 },
                 new FlavorProfile() { Id = 24, BreweryDbId = 24, Color = 3, Crisp = 1, Hop = 3, Malt = 2, Fruity = 1, Sour = 1, ABV = 3, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 25, BreweryDbId = 25, Color = 2, Crisp = 2, Hop = 3, Malt = 2, Fruity = 3, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 26, BreweryDbId = 29, Color = 2, Crisp = 2, Hop = 3, Malt = 1, Fruity = 2, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 27, BreweryDbId = 30, Color = 2, Crisp = 3, Hop = 3, Malt = 1, Fruity = 2, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 28, BreweryDbId = 31, Color = 2, Crisp = 2, Hop = 3, Malt = 1, Fruity = 3, Sour = 1, ABV = 3, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 29, BreweryDbId = 32, Color = 2, Crisp = 1, Hop = 2, Malt = 3, Fruity = 1, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 1 },
                 new FlavorProfile() { Id = 30, BreweryDbId = 33, Color = 2, Crisp = 1, Hop = 3, Malt = 3, Fruity = 1, Sour = 1, ABV = 3, Roasty = 2, Sweetness = 1 },
                 new FlavorProfile() { Id = 31, BreweryDbId = 34, Color = 2, Crisp = 1, Hop = 3, Malt = 3, Fruity = 3, Sour = 1, ABV = 3, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 32, BreweryDbId = 35, Color = 2, Crisp = 1, Hop = 2, Malt = 3, Fruity = 3, Sour = 1, ABV = 3, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 33, BreweryDbId = 36, Color = 1, Crisp = 3, Hop = 1, Malt = 2, Fruity = 1, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 34, BreweryDbId = 37, Color = 2, Crisp = 2, Hop = 1, Malt = 2, Fruity = 1, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 1 },
                 new FlavorProfile() { Id = 35, BreweryDbId = 38, Color = 3, Crisp = 1, Hop = 2, Malt = 3, Fruity = 1, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 36, BreweryDbId = 41, Color = 3, Crisp = 1, Hop = 3, Malt = 2, Fruity = 2, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 1 },
                 new FlavorProfile() { Id = 37, BreweryDbId = 42, Color = 3, Crisp = 1, Hop = 3, Malt = 2, Fruity = 1, Sour = 1, ABV = 2, Roasty = 3, Sweetness = 1 },
                 new FlavorProfile() { Id = 38, BreweryDbId = 43, Color = 3, Crisp = 1, Hop = 3, Malt = 3, Fruity = 2, Sour = 1, ABV = 3, Roasty = 3, Sweetness = 2 },
                 new FlavorProfile() { Id = 39, BreweryDbId = 44, Color = 3, Crisp = 1, Hop = 2, Malt = 2, Fruity = 2, Sour = 1, ABV = 3, Roasty = 2, Sweetness = 1 },
                 new FlavorProfile() { Id = 40, BreweryDbId = 45, Color = 1, Crisp = 3, Hop = 2, Malt = 1, Fruity = 1, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 41, BreweryDbId = 46, Color = 1, Crisp = 3, Hop = 1, Malt = 1, Fruity = 2, Sour = 2, ABV = 1, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 42, BreweryDbId = 47, Color = 1, Crisp = 3, Hop = 1, Malt = 1, Fruity = 3, Sour = 3, ABV = 2, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 43, BreweryDbId = 48, Color = 1, Crisp = 2, Hop = 1, Malt = 1, Fruity = 3, Sour = 2, ABV = 2, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 44, BreweryDbId = 49, Color = 1, Crisp = 2, Hop = 1, Malt = 1, Fruity = 2, Sour = 2, ABV = 2, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 45, BreweryDbId = 50, Color = 1, Crisp = 2, Hop = 1, Malt = 1, Fruity = 2, Sour = 1, ABV = 1, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 46, BreweryDbId = 51, Color = 2, Crisp = 2, Hop = 1, Malt = 2, Fruity = 2, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 47, BreweryDbId = 52, Color = 2, Crisp = 2, Hop = 1, Malt = 2, Fruity = 2, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 48, BreweryDbId = 53, Color = 2, Crisp = 2, Hop = 1, Malt = 2, Fruity = 2, Sour = 1, ABV = 3, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 49, BreweryDbId = 54, Color = 2, Crisp = 2, Hop = 1, Malt = 2, Fruity = 3, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 50, BreweryDbId = 55, Color = 2, Crisp = 3, Hop = 1, Malt = 1, Fruity = 1, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 51, BreweryDbId = 57, Color = 2, Crisp = 2, Hop = 1, Malt = 1, Fruity = 2, Sour = 3, ABV = 2, Roasty = 2, Sweetness = 1 },
                 new FlavorProfile() { Id = 52, BreweryDbId = 58, Color = 2, Crisp = 2, Hop = 2, Malt = 2, Fruity = 2, Sour = 2, ABV = 2, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 53, BreweryDbId = 59, Color = 2, Crisp = 2, Hop = 2, Malt = 2, Fruity = 2, Sour = 2, ABV = 3, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 54, BreweryDbId = 60, Color = 2, Crisp = 2, Hop = 2, Malt = 2, Fruity = 3, Sour = 2, ABV = 3, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 55, BreweryDbId = 61, Color = 2, Crisp = 2, Hop = 1, Malt = 1, Fruity = 2, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 56, BreweryDbId = 62, Color = 2, Crisp = 2, Hop = 2, Malt = 1, Fruity = 2, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 57, BreweryDbId = 63, Color = 2, Crisp = 1, Hop = 2, Malt = 1, Fruity = 3, Sour = 1, ABV = 3, Roasty = 1, Sweetness = 3 },
                 new FlavorProfile() { Id = 58, BreweryDbId = 64, Color = 2, Crisp = 1, Hop = 2, Malt = 3, Fruity = 3, Sour = 1, ABV = 3, Roasty = 1, Sweetness = 3 },
                 new FlavorProfile() { Id = 59, BreweryDbId = 65, Color = 1, Crisp = 2, Hop = 1, Malt = 1, Fruity = 2, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 60, BreweryDbId = 66, Color = 1, Crisp = 3, Hop = 1, Malt = 1, Fruity = 3, Sour = 2, ABV = 2, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 61, BreweryDbId = 67, Color = 1, Crisp = 3, Hop = 1, Malt = 1, Fruity = 3, Sour = 3, ABV = 2, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 62, BreweryDbId = 68, Color = 1, Crisp = 3, Hop = 1, Malt = 1, Fruity = 3, Sour = 3, ABV = 2, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 63, BreweryDbId = 69, Color = 2, Crisp = 3, Hop = 1, Malt = 1, Fruity = 2, Sour = 2, ABV = 1, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 64, BreweryDbId = 71, Color = 2, Crisp = 2, Hop = 2, Malt = 3, Fruity = 2, Sour = 2, ABV = 2, Roasty = 3, Sweetness = 2 },
                 new FlavorProfile() { Id = 65, BreweryDbId = 72, Color = 2, Crisp = 2, Hop = 2, Malt = 1, Fruity = 2, Sour = 2, ABV = 2, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 66, BreweryDbId = 73, Color = 2, Crisp = 2, Hop = 3, Malt = 1, Fruity = 3, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 67, BreweryDbId = 74, Color = 2, Crisp = 2, Hop = 2, Malt = 1, Fruity = 3, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 68, BreweryDbId = 75, Color = 1, Crisp = 3, Hop = 2, Malt = 1, Fruity = 1, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 69, BreweryDbId = 76, Color = 1, Crisp = 3, Hop = 2, Malt = 2, Fruity = 1, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 1 },
                 new FlavorProfile() { Id = 70, BreweryDbId = 77, Color = 1, Crisp = 3, Hop = 2, Malt = 1, Fruity = 1, Sour = 1, ABV = 1, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 71, BreweryDbId = 78, Color = 1, Crisp = 3, Hop = 1, Malt = 2, Fruity = 1, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 72, BreweryDbId = 79, Color = 1, Crisp = 3, Hop = 1, Malt = 1, Fruity = 1, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 73, BreweryDbId = 80, Color = 2, Crisp = 3, Hop = 1, Malt = 2, Fruity = 1, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 74, BreweryDbId = 81, Color = 2, Crisp = 2, Hop = 1, Malt = 3, Fruity = 1, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 75, BreweryDbId = 82, Color = 2, Crisp = 2, Hop = 1, Malt = 3, Fruity = 1, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 76, BreweryDbId = 83, Color = 2, Crisp = 2, Hop = 1, Malt = 2, Fruity = 1, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 77, BreweryDbId = 84, Color = 2, Crisp = 2, Hop = 2, Malt = 3, Fruity = 1, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 78, BreweryDbId = 85, Color = 2, Crisp = 1, Hop = 1, Malt = 3, Fruity = 1, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 79, BreweryDbId = 86, Color = 1, Crisp = 1, Hop = 1, Malt = 2, Fruity = 1, Sour = 1, ABV = 2, Roasty = 3, Sweetness = 2 },
                 new FlavorProfile() { Id = 80, BreweryDbId = 88, Color = 3, Crisp = 1, Hop = 1, Malt = 3, Fruity = 1, Sour = 1, ABV = 2, Roasty = 3, Sweetness = 2 },
                 new FlavorProfile() { Id = 81, BreweryDbId = 89, Color = 1, Crisp = 1, Hop = 2, Malt = 3, Fruity = 1, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 82, BreweryDbId = 90, Color = 3, Crisp = 1, Hop = 2, Malt = 3, Fruity = 2, Sour = 1, ABV = 3, Roasty = 3, Sweetness = 2 },
                 new FlavorProfile() { Id = 83, BreweryDbId = 93, Color = 1, Crisp = 3, Hop = 1, Malt = 1, Fruity = 1, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 84, BreweryDbId = 94, Color = 1, Crisp = 3, Hop = 1, Malt = 1, Fruity = 1, Sour = 1, ABV = 1, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 85, BreweryDbId = 95, Color = 1, Crisp = 3, Hop = 1, Malt = 1, Fruity = 1, Sour = 1, ABV = 1, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 86, BreweryDbId = 98, Color = 1, Crisp = 3, Hop = 2, Malt = 1, Fruity = 1, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 87, BreweryDbId = 101, Color = 2, Crisp = 2, Hop = 2, Malt = 3, Fruity = 1, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 1 },
                 new FlavorProfile() { Id = 88, BreweryDbId = 102, Color = 2, Crisp = 2, Hop = 2, Malt = 3, Fruity = 1, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 89, BreweryDbId = 103, Color = 3, Crisp = 2, Hop = 1, Malt = 3, Fruity = 1, Sour = 1, ABV = 2, Roasty = 2, Sweetness = 1 },
                 new FlavorProfile() { Id = 90, BreweryDbId = 104, Color = 3, Crisp = 1, Hop = 1, Malt = 3, Fruity = 2, Sour = 1, ABV = 3, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 91, BreweryDbId = 105, Color = 1, Crisp = 3, Hop = 1, Malt = 1, Fruity = 1, Sour = 1, ABV = 1, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 92, BreweryDbId = 109, Color = 1, Crisp = 3, Hop = 1, Malt = 1, Fruity = 1, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 93, BreweryDbId = 114, Color = 2, Crisp = 2, Hop = 1, Malt = 2, Fruity = 3, Sour = 1, ABV = 2, Roasty = 1, Sweetness = 2 },
                 new FlavorProfile() { Id = 94, BreweryDbId = 115, Color = 2, Crisp = 2, Hop = 1, Malt = 2, Fruity = 2, Sour = 1, ABV = 3, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 95, BreweryDbId = 116, Color = 3, Crisp = 2, Hop = 1, Malt = 2, Fruity = 2, Sour = 1, ABV = 3, Roasty = 2, Sweetness = 2 },
                 new FlavorProfile() { Id = 96, BreweryDbId = 117, Color = 3, Crisp = 2, Hop = 1, Malt = 2, Fruity = 2, Sour = 1, ABV = 3, Roasty = 2, Sweetness = 2 }
                 );
            });
        }
    }
}
