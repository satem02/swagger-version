using FluentValidation;

namespace Application.V1.CreditReconcilation.Fibabank.Queries.ReconcilationQuery
{
    public class FibabankReconcilationQueryHandlerValidator : AbstractValidator<FibabankReconcilationQuery>
    {

        public FibabankReconcilationQueryHandlerValidator()
        {
            RuleFor(v => v.Tckn)
                .NotEmpty().WithMessage("TCKN is required.")
                .Length(11).WithMessage("TCKN must not exceed 11 characters.");
        }

    }
}