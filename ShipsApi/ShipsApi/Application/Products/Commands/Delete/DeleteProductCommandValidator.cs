using FluentValidation;

namespace ShipsApi.Application.Products.Commands.Delete
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(deleteProductCommand => deleteProductCommand.Id).GreaterThan(0);
        }
    }
}
