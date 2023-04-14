using AutoMapper;
using ShipsApi.Application.Common.Mappings;
using ShipsApi.Application.Ships.Commands.Create;

namespace ShipsApi.Models.Ships
{
    public class CreateShipDto : IMapWith<CreateShipCommand>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateShipDto, CreateShipCommand>();
        }
    }
}
