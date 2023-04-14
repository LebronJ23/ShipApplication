using AutoMapper;
using ShipsApi.Application.Common.Mappings;
using ShipsApi.Application.Products.Commands.Create;

namespace ShipsApi.Models.Products
{
    public class CreateProductDto : IMapWith<CreateProductCommand>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductDto, CreateProductCommand>();
        }
    }
}
