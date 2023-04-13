using MediatR;
using ShipsApi.Application.Interfaces;
using ShipsApi.Application.Products.Commands.Create;
using ShipsApi.Entities;
using System.Threading.Tasks;
using System.Threading;
using ShipsApi.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ShipsApi.Application.Products.Commands.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IShipsDbContext _dbContext;

        public DeleteProductCommandHandler(IShipsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(product => product.Id == request.Id, cancellationToken);

            if (product == null || product.Id != request.Id)
            {
                throw new NotFoundEntityException(nameof(Product), request.Id);
            }

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return 0;
        }
    }
}
