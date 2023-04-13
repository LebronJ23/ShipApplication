using MediatR;

namespace ShipsApi.Application.Ships.Queries.GetShipByIdQuery
{
    public class GetShipByIdQuery : IRequest<ShipVm>
    {
        public int Id { get; set; }
    }
}
