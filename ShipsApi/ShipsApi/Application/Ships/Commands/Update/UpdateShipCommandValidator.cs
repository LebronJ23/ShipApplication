using FluentValidation;

namespace ShipsApi.Application.Ships.Commands.Update
{
    public class UpdateShipCommandValidator : AbstractValidator<UpdateShipCommand>
    {
        public UpdateShipCommandValidator()
        {
            RuleFor(updateShipCommand => updateShipCommand.Id).GreaterThan(0);
            RuleFor(updateShipCommand => updateShipCommand.Name).NotEmpty().MinimumLength(2).MaximumLength(250);
        }
    }
}
