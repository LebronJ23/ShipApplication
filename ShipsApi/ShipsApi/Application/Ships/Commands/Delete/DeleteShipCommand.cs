using MediatR;

namespace ShipsApi.Application.Ships.Commands.Delete
{
    public class DeleteShipCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
