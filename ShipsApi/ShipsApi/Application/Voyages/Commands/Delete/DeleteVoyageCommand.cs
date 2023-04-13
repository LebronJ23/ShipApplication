using MediatR;

namespace ShipsApi.Application.Voyages.Commands.Delete
{
    public class DeleteVoyageCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
