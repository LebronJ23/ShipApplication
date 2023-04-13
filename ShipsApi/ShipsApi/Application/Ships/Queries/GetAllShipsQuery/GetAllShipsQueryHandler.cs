using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using ShipsApi.Application.Interfaces;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace ShipsApi.Application.Ships.Queries.GetAllShipsQuery
{
    public class GetAllShipsQueryHandler : IRequestHandler<GetAllShipsQuery, ShipListVm>
    {
        private readonly IShipsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllShipsQueryHandler(IShipsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ShipListVm> Handle(GetAllShipsQuery request, CancellationToken cancellationToken)
        {
            var shipsList = await _dbContext
                .Ships
                .ProjectTo<ShipVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ShipListVm { Ships = shipsList };
        }
    }
}
