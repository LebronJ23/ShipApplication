using MediatR;
using System;

namespace ShipsApi.Application.Voyages.Commands.Update
{
    public class UpdateVoyageCommand : IRequest<int>
    {
        public int Id { get; set; }
        public float Weight { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Sailed { get; set; }

        public int ShipId { get; set; }
        public int ProductId { get; set; }
    }
}
