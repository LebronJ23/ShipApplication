using MediatR;

namespace ShipsApi.Application.Products.Commands.Delete
{
    public class DeleteProductCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
