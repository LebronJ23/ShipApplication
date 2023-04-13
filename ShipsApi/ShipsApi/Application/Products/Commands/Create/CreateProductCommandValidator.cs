using FluentValidation;

namespace ShipsApi.Application.Products.Commands.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(createProductCommand => createProductCommand.Name).NotEmpty().MinimumLength(2).MaximumLength(250);
        }
    }
}
