using MediatR;

namespace ShipsApi.Application.Products.Commands.Create
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
