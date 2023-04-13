using AutoMapper;
using MediatR;
using ShipsApi.Application.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using ShipsApi.Application.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using ShipsApi.Entities;

namespace ShipsApi.Application.Ships.Queries.GetShipByIdQuery
{
    public class GetShipByIdQueryHandler : IRequestHandler<GetShipByIdQuery, ShipVm>
    {
        private readonly IShipsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetShipByIdQueryHandler(IShipsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ShipVm> Handle(GetShipByIdQuery request, CancellationToken cancellationToken)
        {
            var ship = await _dbContext
                .Ships
                .FirstOrDefaultAsync(ship => ship.Id == request.Id, cancellationToken);

            if (ship == null || ship.Id != request.Id)
            {
                throw new NotFoundEntityException(nameof(Ship), request.Id);
            }

            return _mapper.Map<ShipVm>(ship);
        }
    }
}
