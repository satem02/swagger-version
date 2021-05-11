using FluentValidation;

namespace Application.V1.CreditCancel.Fibabank.Queries.CancelQuery
{
    public class FibabankCancelQueryHandlerValidator : AbstractValidator<FibabankCancelQuery>
    {

        public FibabankCancelQueryHandlerValidator()
        {
            RuleFor(v => v.Tckn)
                .NotEmpty().WithMessage("TCKN is required.")
                .Length(11).WithMessage("TCKN must not exceed 11 characters.");
        }

    }
}