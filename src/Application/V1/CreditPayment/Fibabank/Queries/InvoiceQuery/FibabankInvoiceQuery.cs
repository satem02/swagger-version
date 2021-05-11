using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Application.Common.Interfaces;
using MediatR;

namespace Application.V1.CreditPayment.Fibabank.Queries.InvoiceQuery
{
    public class FibabankInvoiceQuery : IRequest<FibabankInvoiceVm>
    {
        public string Tckn { get; set; }
        public string AccountNo { get; set; }
    }

    public class FibabankInvoiceQueryHandler : IRequestHandler<FibabankInvoiceQuery, FibabankInvoiceVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FibabankInvoiceQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FibabankInvoiceVm> Handle(FibabankInvoiceQuery request, CancellationToken cancellationToken)
        {
            return new FibabankInvoiceVm
            {
            };
        }
    }
}