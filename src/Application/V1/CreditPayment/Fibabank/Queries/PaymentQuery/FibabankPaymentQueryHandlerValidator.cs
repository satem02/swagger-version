using FluentValidation;

namespace Application.V1.CreditPayment.Fibabank.Queries.PaymentQuery
{
    public class FibabankPaymentQueryHandlerValidator : AbstractValidator<FibabankPaymentQuery>
    {

        public FibabankPaymentQueryHandlerValidator()
        {
            RuleFor(v => v.Tckn)
                .NotEmpty().WithMessage("TCKN is required.")
                .Length(11).WithMessage("TCKN must not exceed 11 characters.");
        }

    }
}