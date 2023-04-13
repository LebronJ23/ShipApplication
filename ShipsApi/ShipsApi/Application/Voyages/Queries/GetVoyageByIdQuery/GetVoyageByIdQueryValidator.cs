using FluentValidation;

namespace ShipsApi.Application.Voyages.Queries.GetVoyageByIdQuery
{
    public class GetVoyageByIdQueryValidator : AbstractValidator<GetVoyageByIdQuery>
    {
        public GetVoyageByIdQueryValidator()
        {
            RuleFor(getVoyageQuery => getVoyageQuery.Id).GreaterThan(0);
        }
    }
}
