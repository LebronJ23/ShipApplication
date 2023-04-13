using FluentValidation;

namespace ShipsApi.Application.Ships.Commands.Delete
{
    public class DeleteShipCommandValidator : AbstractValidator<DeleteShipCommand>
    {
        public DeleteShipCommandValidator()
        {
            RuleFor(deleteShipCommand => deleteShipCommand.Id).GreaterThan(0);
        }
    }
}
