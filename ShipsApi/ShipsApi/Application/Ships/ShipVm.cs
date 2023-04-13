using AutoMapper;
using ShipsApi.Application.Common.Mappings;
using ShipsApi.Application.Ships.Commands.Create;
using ShipsApi.Application.Ships.Commands.Delete;
using ShipsApi.Application.Ships.Commands.Update;
using ShipsApi.Entities;

namespace ShipsApi.Application.Ships
{
    public class ShipVm : IMapWith<Ship>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Ship, ShipVm>();
            profile.CreateMap<ShipVm, CreateShipCommand>();
            profile.CreateMap<ShipVm, UpdateShipCommand>();
            profile.CreateMap<ShipVm, DeleteShipCommand>();
        }
    }
}
