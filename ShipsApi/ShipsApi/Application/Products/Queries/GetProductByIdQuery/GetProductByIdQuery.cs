using MediatR;

namespace ShipsApi.Application.Products.Queries.GetProductByIdQuery
{
    public class GetProductByIdQuery : IRequest<ProductVm>
    {
        public int Id { get; set; }
    }
}
