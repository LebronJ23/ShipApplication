using MediatR;
using ShipsApi.Application.Interfaces;
using ShipsApi.Entities;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using ShipsApi.Application.Common.Exceptions;

namespace ShipsApi.Application.Ships.Commands.Update
{
    public class UpdateShipCommandHandler : IRequestHandler<UpdateShipCommand, int>
    {
        private readonly IShipsDbContext _dbContext;

        public UpdateShipCommandHandler(IShipsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(UpdateShipCommand request, CancellationToken cancellationToken)
        {
            var ship = await _dbContext.Ships.FirstOrDefaultAsync(ship => ship.Id == request.Id, cancellationToken);

            if (ship == null || ship.Id != request.Id)
            {
                throw new NotFoundEntityException(nameof(Ship), request.Id);
            }

            ship.Name = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return ship.Id;
        }
    }
}
