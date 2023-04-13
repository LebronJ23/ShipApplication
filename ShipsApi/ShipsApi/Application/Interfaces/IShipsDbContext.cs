using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using ShipsApi.Entities;

namespace ShipsApi.Application.Interfaces
{
    public interface IShipsDbContext
    {
        DbSet<Ship> Ships { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Voyage> Voyages { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
