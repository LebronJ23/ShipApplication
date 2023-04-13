using FluentValidation;

namespace ShipsApi.Application.Voyages.Commands.Delete
{
    public class DeleteVoyageCommandValidator : AbstractValidator<DeleteVoyageCommand>
    {
        public DeleteVoyageCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().GreaterThan(0);
        }
    }
}
