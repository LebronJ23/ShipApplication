using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace ShipDrawer.Models
{
    public class ShipDbContext : DbContext
    {
        public DbSet<Voyage> Voyages { get; set; }
        
        public ShipDbContext(DbContextOptions<ShipDbContext> options) : base(options)
        {
            
        }
    }
}
