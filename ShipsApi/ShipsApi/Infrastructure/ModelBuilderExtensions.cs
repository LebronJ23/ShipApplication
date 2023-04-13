using Microsoft.EntityFrameworkCore;
using ShipsApi.Entities;
using System;

namespace ShipsApi.Infrastructure
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Petrol" },
                new Product { Id = 2, Name = "Oil" },
                new Product { Id = 3, Name = "Grain" },
                new Product { Id = 4, Name = "Containers" },
                new Product { Id = 5, Name = "Meet" },
                new Product { Id = 6, Name = "bulk cargo" }
            );

            modelBuilder.Entity<Ship>().HasData(
                new Ship { Id = 1, Name = "Dry Cargo Ship" },
                new Ship { Id = 2, Name = "Bulk Carrier" },
                new Ship { Id = 3, Name = "Container Vessel" },
                new Ship { Id = 4, Name = "Liquid Cargo Ship" },
                new Ship { Id = 5, Name = "Crude Carrier" },
                new Ship { Id = 6, Name = "Chemical Carrier" },
                new Ship { Id = 7, Name = "Reefer Vessel" }
            );

            modelBuilder.Entity<Voyage>().HasData(
                new Voyage { Id = 1, Weight = 1000, Arrival = DateTime.Now, Sailed = DateTime.Now.AddDays(1), ShipId = 7, ProductId = 1 },
                new Voyage { Id = 2, Weight = 1000, Arrival = DateTime.Now, Sailed = DateTime.Now.AddDays(1), ShipId = 6, ProductId = 2 },
                new Voyage { Id = 3, Weight = 1000, Arrival = DateTime.Now, Sailed = DateTime.Now.AddDays(1), ShipId = 5, ProductId = 3 },
                new Voyage { Id = 4, Weight = 1000, Arrival = DateTime.Now.AddDays(1), Sailed = DateTime.Now.AddDays(2), ShipId = 4, ProductId = 4 },
                new Voyage { Id = 5, Weight = 1000, Arrival = DateTime.Now.AddDays(1), Sailed = DateTime.Now.AddDays(2), ShipId = 3, ProductId = 5 },
                new Voyage { Id = 6, Weight = 1000, Arrival = DateTime.Now.AddDays(1), Sailed = DateTime.Now.AddDays(2), ShipId = 2, ProductId = 6 },
                new Voyage { Id = 7, Weight = 1000, Arrival = DateTime.Now.AddDays(1), Sailed = DateTime.Now.AddDays(2), ShipId = 1, ProductId = 1 },
                new Voyage { Id = 8, Weight = 1000, Arrival = DateTime.Now.AddDays(2), Sailed = DateTime.Now.AddDays(3), ShipId = 7, ProductId = 2 }
            );
        }
    }
}
