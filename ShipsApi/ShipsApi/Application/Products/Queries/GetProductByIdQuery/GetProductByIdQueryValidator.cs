using FluentValidation;

namespace ShipsApi.Application.Products.Queries.GetProductByIdQuery
{
    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(getProductQuery => getProductQuery.Id).GreaterThan(0);
        }
    }
}
