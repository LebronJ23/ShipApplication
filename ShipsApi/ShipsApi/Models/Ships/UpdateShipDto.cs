using AutoMapper;
using ShipsApi.Application.Common.Mappings;
using ShipsApi.Application.Ships.Commands.Update;

namespace ShipsApi.Models.Ships
{
    public class UpdateShipDto : IMapWith<UpdateShipCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateShipDto, UpdateShipCommand>();
        }
    }
}
