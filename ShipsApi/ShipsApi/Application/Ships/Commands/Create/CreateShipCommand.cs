using MediatR;

namespace ShipsApi.Application.Ships.Commands.Create
{
    public class CreateShipCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
