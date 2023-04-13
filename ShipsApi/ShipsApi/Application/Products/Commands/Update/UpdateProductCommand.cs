using MediatR;

namespace ShipsApi.Application.Products.Commands.Update
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
