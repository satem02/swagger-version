using FluentValidation;

namespace Application.V1.CreditPayment.Fibabank.Queries.InvoiceQuery
{
    public class FibabankInvoiceQueryHandlerValidator : AbstractValidator<FibabankInvoiceQuery>
    {

        public FibabankInvoiceQueryHandlerValidator()
        {
            RuleFor(v => v.Tckn)
                .NotEmpty().WithMessage("TCKN is required.")
                .Length(11).WithMessage("TCKN must not exceed 11 characters.");
        }

    }
}