using MediatR;
using ShipsApi.Application.Common.Exceptions;
using ShipsApi.Application.Interfaces;
using ShipsApi.Application.Products.Commands.Update;
using ShipsApi.Entities;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace ShipsApi.Application.Voyages.Commands.Update
{
    public class UpdateVoyageCommandHandler : IRequestHandler<UpdateVoyageCommand, int>
    {
        private readonly IShipsDbContext _dbContext;

        public UpdateVoyageCommandHandler(IShipsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(UpdateVoyageCommand request, CancellationToken cancellationToken)
        {
            var voyage = await _dbContext.Voyages.FirstOrDefaultAsync(v => v.Id == request.Id, cancellationToken);

            if (voyage == null || voyage.Id != request.Id)
            {
                throw new NotFoundEntityException(nameof(Voyage), request.Id);
            }

            voyage.Weight = request.Weight;
            voyage.Arrival = request.Arrival;
            voyage.Sailed = request.Sailed;
            voyage.ShipId = request.ShipId;
            voyage.ProductId = request.ProductId;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return voyage.Id;
        }
    }
}
