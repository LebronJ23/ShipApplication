using MediatR;
using ShipsApi.Application.Interfaces;
using ShipsApi.Application.Products.Commands.Create;
using ShipsApi.Entities;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using ShipsApi.Application.Common.Exceptions;

namespace ShipsApi.Application.Products.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IShipsDbContext _dbContext;

        public UpdateProductCommandHandler(IShipsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(product => product.Id == request.Id, cancellationToken);

            if (product == null || product.Id != request.Id)
            {
                throw new NotFoundEntityException(nameof(Product), request.Id);
            }

            product.Name = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
