using FluentValidation;
using ShipsApi.Application.Voyages.Commands.Create;

namespace ShipsApi.Application.Voyages.Commands.Update
{
    public class UpdateVoyageCommandValidator : AbstractValidator<UpdateVoyageCommand>
    {
        public UpdateVoyageCommandValidator()
        {
            RuleFor(createVoyageCommand => createVoyageCommand.Id).NotEmpty().GreaterThan(0);
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
