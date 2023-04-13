using AutoMapper;
using MediatR;
using ShipsApi.Application.Common.Exceptions;
using ShipsApi.Application.Interfaces;
using ShipsApi.Entities;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace ShipsApi.Application.Voyages.Queries.GetVoyageByIdQuery
{
    public class GetVoyageByIdQueryHandler : IRequestHandler<GetVoyageByIdQuery, VoyageVm>
    {
        private readonly IShipsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetVoyageByIdQueryHandler(IShipsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<VoyageVm> Handle(GetVoyageByIdQuery request, CancellationToken cancellationToken)
        {
            var voyage = await _dbContext
                .Voyages
                .FirstOrDefaultAsync(voyage => voyage.Id == request.Id, cancellationToken);

            if (voyage == null || voyage.Id != request.Id)
            {
                throw new NotFoundEntityException(nameof(Voyage), request.Id);
            }

            return _mapper.Map<VoyageVm>(voyage);
        }
    }
}
