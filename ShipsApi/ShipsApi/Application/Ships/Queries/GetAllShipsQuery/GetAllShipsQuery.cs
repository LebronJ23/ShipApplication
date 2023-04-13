using MediatR;

namespace ShipsApi.Application.Ships.Queries.GetAllShipsQuery
{
    public class GetAllShipsQuery : IRequest<ShipListVm>
    {
    }
}
