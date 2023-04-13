using MediatR;
using Microsoft.EntityFrameworkCore;
using ShipsApi.Application.Interfaces;
using ShipsApi.Application.Products.Commands.Create;
using ShipsApi.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace ShipsApi.Application.Voyages.Commands.Create
{
    public class CreateVoyageCommandHandler : IRequestHandler<CreateVoyageCommand, int>
    {
        private readonly IShipsDbContext _dbContext;

        public CreateVoyageCommandHandler(IShipsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateVoyageCommand request, CancellationToken cancellationToken)
        {
            var voyage = new Voyage
            {
                Weight = request.Weight,
                Arrival = request.Arrival,
                Sailed = request.Sailed,
                ShipId = request.ShipId,
                ProductId = request.ProductId,
            };

            await _dbContext.Voyages.AddAsync(voyage, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return voyage.Id;
        }
    }
}
