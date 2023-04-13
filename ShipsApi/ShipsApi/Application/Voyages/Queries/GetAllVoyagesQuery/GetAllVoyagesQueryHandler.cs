using AutoMapper;
using MediatR;
using ShipsApi.Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace ShipsApi.Application.Voyages.Queries.GetAllVoyagesQuery
{
    public class GetAllVoyagesQueryHandler : IRequestHandler<GetAllVoyagesQuery, VoyageListVm>
    {
        private readonly IShipsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllVoyagesQueryHandler(IShipsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<VoyageListVm> Handle(GetAllVoyagesQuery request, CancellationToken cancellationToken)
        {
            var voyagesList = await _dbContext
                .Voyages
                .ProjectTo<VoyageVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new VoyageListVm { Voyages = voyagesList };
        }
    }
}
