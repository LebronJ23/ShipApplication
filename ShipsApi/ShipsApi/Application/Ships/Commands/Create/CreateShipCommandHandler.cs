using MediatR;
using System.Threading.Tasks;
using System.Threading;
using ShipsApi.Application.Interfaces;
using ShipsApi.Entities;

namespace ShipsApi.Application.Ships.Commands.Create
{
    public class CreateShipCommandHandler : IRequestHandler<CreateShipCommand, int>
    {
        private readonly IShipsDbContext _dbContext;

        public CreateShipCommandHandler(IShipsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateShipCommand request, CancellationToken cancellationToken)
        {
            var ship = new Ship
            {
                Name = request.Name,
            };

            await _dbContext.Ships.AddAsync(ship, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return ship.Id;
        }
    }
}
