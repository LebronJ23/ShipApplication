using Microsoft.EntityFrameworkCore;
using ShipsApi.Application.Interfaces;
using ShipsApi.Entities;
using ShipsApi.Infrastructure.EntityTypeConfiguration;
using System.Threading;
using System.Threading.Tasks;

namespace ShipsApi.Infrastructure
{
    public class ShipsDbContext : DbContext, IShipsDbContext
    {
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Voyage> Voyages { get; set; }

        public ShipsDbContext(DbContextOptions<ShipsDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ShipTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VoyageTypeConfiguration());

            base.OnModelCreating(modelBuilder);

            modelBuilder.SeedData();
        }


    }
}
