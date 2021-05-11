using FluentValidation;

namespace Application.ProductServiceLocator.Commands.UpdateProductServiceLocator
{
    public class UpdateProductServiceLocatorCommandValidator : AbstractValidator<UpdateProductServiceLocatorCommand>
    {
        public UpdateProductServiceLocatorCommandValidator()
        {
            RuleFor(v => v.Title);
        }
    }
}
