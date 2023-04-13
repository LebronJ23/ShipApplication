using AutoMapper;
using ShipsApi.Application.Common.Mappings;
using ShipsApi.Application.Products.Commands.Create;
using ShipsApi.Application.Products.Commands.Delete;
using ShipsApi.Application.Products.Commands.Update;
using ShipsApi.Entities;

namespace ShipsApi.Application.Products
{
    public class ProductVm : IMapWith<Product>, IMapWith<CreateProductCommand>, IMapWith<UpdateProductCommand>, IMapWith<DeleteProductCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductVm>();
            profile.CreateMap<ProductVm, CreateProductCommand>();
            profile.CreateMap<ProductVm, UpdateProductCommand>();
            profile.CreateMap<ProductVm, DeleteProductCommand>();
        }
    }
}
