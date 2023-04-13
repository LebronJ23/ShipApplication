using AutoMapper;
using MediatR;
using ShipsApi.Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using ShipsApi.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using ShipsApi.Entities;

namespace ShipsApi.Application.Products.Queries.GetProductByIdQuery
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductVm>
    {
        private readonly IShipsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IShipsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductVm> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _dbContext
                .Products
                .FirstOrDefaultAsync(product => product.Id == request.Id, cancellationToken);

            if (product == null || product.Id != request.Id)
            {
                throw new NotFoundEntityException(nameof(Product), request.Id);
            }

            return _mapper.Map<ProductVm>(product);
        }
    }
}
