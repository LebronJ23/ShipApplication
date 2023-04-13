using MediatR;
using System.Threading.Tasks;
using System.Threading;
using ShipsApi.Application.Interfaces;
using ShipsApi.Entities;

namespace ShipsApi.Application.Products.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IShipsDbContext _dbContext;

        public CreateProductCommandHandler(IShipsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
            };

            await _dbContext.Products.AddAsync(product, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
