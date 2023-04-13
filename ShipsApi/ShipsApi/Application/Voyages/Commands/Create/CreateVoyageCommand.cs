using MediatR;
using ShipsApi.Entities;
using System;

namespace ShipsApi.Application.Voyages.Commands.Create
{
    public class CreateVoyageCommand : IRequest<int>
    {
        public float Weight { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Sailed { get; set; }

        public int ShipId { get; set; }
        public int ProductId { get; set; }
    }
}
