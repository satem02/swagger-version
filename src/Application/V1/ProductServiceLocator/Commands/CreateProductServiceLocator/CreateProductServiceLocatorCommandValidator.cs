using FluentValidation;

namespace Application.ProductServiceLocator.Commands.CreateProductServiceLocator
{
    public class CreateProductServiceLocatorCommandValidator : AbstractValidator<CreateProductServiceLocatorCommand>
    {

        public CreateProductServiceLocatorCommandValidator()
        {

            RuleFor(v => v.TenantId)
                .NotEmpty().WithMessage("TenantId is required.");
        }

    }
}
