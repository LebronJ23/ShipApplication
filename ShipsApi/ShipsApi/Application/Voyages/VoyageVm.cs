using AutoMapper;
using ShipsApi.Application.Common.Mappings;
using ShipsApi.Application.Products;
using ShipsApi.Application.Ships;
using ShipsApi.Application.Voyages.Commands.Create;
using ShipsApi.Application.Voyages.Commands.Delete;
using ShipsApi.Application.Voyages.Commands.Update;
using ShipsApi.Entities;
using System;

namespace ShipsApi.Application.Voyages
{
    public class VoyageVm : IMapWith<Voyage>, IMapWith<CreateVoyageCommand>, IMapWith<UpdateVoyageCommand>, IMapWith<DeleteVoyageCommand>
    {
        public int Id { get; set; }
        public float Weight { get; set; }
        public DateTime Arrival { get; set; } = DateTime.UtcNow.Date;
        public DateTime Sailed { get; set; } = DateTime.UtcNow.Date.AddDays(1);

        public int ShipId { get; set; }
        public ShipVm Ship { get; set; }
        public int ProductId { get; set; }
        public ProductVm Product { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Voyage, VoyageVm>();
            profile.CreateMap<VoyageVm, CreateVoyageCommand>();
            profile.CreateMap<VoyageVm, UpdateVoyageCommand>();
            profile.CreateMap<VoyageVm, DeleteVoyageCommand>();
        }
    }
}
