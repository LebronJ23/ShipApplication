using MediatR;
using ShipsApi.Application.Interfaces;
using ShipsApi.Application.Products.Commands.Create;
using ShipsApi.Entities;
using System.Threading.Tasks;
using System.Threading;
using ShipsApi.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ShipsApi.Application.Ships.Commands.Delete
{
    public class DeleteShipCommandHandler : IRequestHandler<DeleteShipCommand, int>
    {
        private readonly IShipsDbContext _dbContext;

        public DeleteShipCommandHandler(IShipsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(DeleteShipCommand request, CancellationToken cancellationToken)
        {
            var ship = await _dbContext.Ships.FirstOrDefaultAsync(ship => ship.Id == request.Id, cancellationToken);

            if (ship == null || ship.Id != request.Id)
            {
                throw new NotFoundEntityException(nameof(Ship), request.Id);
            }

            _dbContext.Ships.Remove(ship);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return 0;
        }
    }
}
