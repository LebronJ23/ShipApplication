using FluentValidation;

namespace ShipsApi.Application.Voyages.Commands.Create
{
    public class CreateVoyageCommandValidator : AbstractValidator<CreateVoyageCommand>
    {
        public CreateVoyageCommandValidator()
        {
            RuleFor(createVoyageCommand => createVoyageCommand.Weight).GreaterThan(0);
            RuleFor(createVoyageCommand => createVoyageCommand.Arrival).NotEmpty();
            RuleFor(createVoyageCommand => createVoyageCommand.Sailed).NotEmpty();
            RuleFor(createVoyageCommand => createVoyageCommand.Arrival)
                .LessThan(createVoyageCommand => createVoyageCommand.Sailed);
            RuleFor(createVoyageCommand => createVoyageCommand.Sailed)
                .GreaterThan(createVoyageCommand => createVoyageCommand.Arrival);
            RuleFor(createVoyageCommand => createVoyageCommand.ShipId).NotEmpty().GreaterThan(0);
            RuleFor(createVoyageCommand => createVoyageCommand.ProductId).NotEmpty().GreaterThan(0);

        }
    }
}
