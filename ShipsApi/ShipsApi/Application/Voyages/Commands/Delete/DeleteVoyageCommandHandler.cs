using MediatR;
using ShipsApi.Application.Common.Exceptions;
using ShipsApi.Application.Interfaces;
using ShipsApi.Application.Products.Commands.Delete;
using ShipsApi.Entities;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace ShipsApi.Application.Voyages.Commands.Delete
{
    public class DeleteVoyageCommandHandler : IRequestHandler<DeleteVoyageCommand, int>
    {
        private readonly IShipsDbContext _dbContext;

        public DeleteVoyageCommandHandler(IShipsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(DeleteVoyageCommand request, CancellationToken cancellationToken)
        {
            var voyage = await _dbContext.Voyages.FirstOrDefaultAsync(v => v.Id == request.Id, cancellationToken);

            if (voyage == null || voyage.Id != request.Id)
            {
                throw new NotFoundEntityException(nameof(Voyage), request.Id);
            }

            _dbContext.Voyages.Remove(voyage);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return 0;
        }
    }
}
