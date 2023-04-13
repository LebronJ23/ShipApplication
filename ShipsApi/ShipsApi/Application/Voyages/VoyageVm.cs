using AutoMapper;
using ShipsApi.Application.Common.Mappings;
using ShipsApi.Entities;
using System;

namespace ShipsApi.Application.Voyages
{
    public class VoyageVm : IMapWith<Voyage>
    {
        public int Id { get; set; }
        public float Weight { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Sailed { get; set; }

        public int ShipId { get; set; }
        public Ship Ship { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Voyage, VoyageVm>();
        }
    }
}
