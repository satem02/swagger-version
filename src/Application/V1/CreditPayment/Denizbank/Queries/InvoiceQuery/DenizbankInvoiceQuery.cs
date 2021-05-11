using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Application.Common.Interfaces;
using MediatR;

namespace Application.V1.CreditPayment.Denizbank.Queries.InvoiceQuery
{
    public class DenizbankInvoiceQuery : IRequest<DenizbankInvoiceVm>
    {
    }

    public class DenizbankInvoiceQueryHandler : IRequestHandler<DenizbankInvoiceQuery, DenizbankInvoiceVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DenizbankInvoiceQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DenizbankInvoiceVm> Handle(DenizbankInvoiceQuery request, CancellationToken cancellationToken)
        {
            return new DenizbankInvoiceVm
            {
            };
        }
    }
}