using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using ShipsApi.Application.Interfaces;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace ShipsApi.Application.Products.Queries.GetAllProductsQuery
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ProductListVm>
    {
        private readonly IShipsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IShipsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductListVm> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var productsList = await _dbContext
                .Products
                .ProjectTo<ProductVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProductListVm { Products = productsList };
        }
    }
}
