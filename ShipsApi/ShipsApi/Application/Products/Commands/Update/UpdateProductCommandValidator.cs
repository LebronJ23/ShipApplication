using FluentValidation;
using ShipsApi.Application.Products.Commands.Create;

namespace ShipsApi.Application.Products.Commands.Update
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(updateProductCommand => updateProductCommand.Id).GreaterThan(0);
            RuleFor(updateProductCommand => updateProductCommand.Name).NotEmpty().MinimumLength(2).MaximumLength(250);
        }
    }
}
