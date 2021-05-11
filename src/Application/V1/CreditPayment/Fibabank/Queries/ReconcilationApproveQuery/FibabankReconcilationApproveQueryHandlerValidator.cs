using FluentValidation;

namespace Application.V1.CreditReconcilationApprove.Fibabank.Queries.ReconcilationApproveQuery
{
    public class FibabankReconcilationApproveQueryHandlerValidator : AbstractValidator<FibabankReconcilationApproveQuery>
    {

        public FibabankReconcilationApproveQueryHandlerValidator()
        {
            RuleFor(v => v.Tckn)
                .NotEmpty().WithMessage("TCKN is required.")
                .Length(11).WithMessage("TCKN must not exceed 11 characters.");
        }

    }
}