using MediatR;

namespace ShipsApi.Application.Ships.Commands.Update
{
    public class UpdateShipCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
