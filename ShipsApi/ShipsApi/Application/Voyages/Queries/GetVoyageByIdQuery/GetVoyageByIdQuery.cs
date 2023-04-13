using MediatR;

namespace ShipsApi.Application.Voyages.Queries.GetVoyageByIdQuery
{
    public class GetVoyageByIdQuery : IRequest<VoyageVm>
    {
        public int Id { get; set; }
    }
}
