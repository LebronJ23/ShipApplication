using MediatR;

namespace ShipsApi.Application.Products.Queries.GetAllProductsQuery
{
    public class GetAllProductsQuery : IRequest<ProductListVm>
    {
    }
}
