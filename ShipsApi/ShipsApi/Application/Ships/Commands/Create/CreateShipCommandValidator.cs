using FluentValidation;

namespace ShipsApi.Application.Ships.Commands.Create
{
    public class CreateShipCommandValidator : AbstractValidator<CreateShipCommand>
    {
        public CreateShipCommandValidator()
        {
            RuleFor(createShipCommand => createShipCommand.Name).NotEmpty().MinimumLength(2).MaximumLength(250);
        }
    }
}
