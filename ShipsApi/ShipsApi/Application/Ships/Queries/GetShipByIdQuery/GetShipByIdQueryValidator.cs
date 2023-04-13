using FluentValidation;

namespace ShipsApi.Application.Ships.Queries.GetShipByIdQuery
{
    public class GetShipByIdQueryValidator : AbstractValidator<GetShipByIdQuery>
    {
        public GetShipByIdQueryValidator()
        {
            RuleFor(getShipQuery => getShipQuery.Id).GreaterThan(0);
        }
    }
}
