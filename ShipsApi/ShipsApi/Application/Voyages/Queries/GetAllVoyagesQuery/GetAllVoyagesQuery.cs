using MediatR;

namespace ShipsApi.Application.Voyages.Queries.GetAllVoyagesQuery
{
    public class GetAllVoyagesQuery : IRequest<VoyageListVm>
    {
    }
}
