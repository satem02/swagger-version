using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Application.Common.Interfaces;
using MediatR;

namespace Application.V1.CreditPayment.Fibabank.Queries.PaymentQuery
{
    public class FibabankPaymentQuery : IRequest<FibabankPaymentVm>
    {
        public string Tckn { get; set; }
        public string AccountNo { get; set; }
    }

    public class FibabankPaymentQueryHandler : IRequestHandler<FibabankPaymentQuery, FibabankPaymentVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FibabankPaymentQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FibabankPaymentVm> Handle(FibabankPaymentQuery request, CancellationToken cancellationToken)
        {
            return new FibabankPaymentVm
            {
            };
        }
    }
}