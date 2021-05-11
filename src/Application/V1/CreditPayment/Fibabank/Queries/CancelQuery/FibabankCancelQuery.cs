using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Application.Common.Interfaces;
using MediatR;

namespace Application.V1.CreditCancel.Fibabank.Queries.CancelQuery
{
    public class FibabankCancelQuery : IRequest<FibabankCancelVm>
    {
        public string Tckn { get; set; }
        public string AccountNo { get; set; }
    }

    public class FibabankCancelQueryHandler : IRequestHandler<FibabankCancelQuery, FibabankCancelVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FibabankCancelQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FibabankCancelVm> Handle(FibabankCancelQuery request, CancellationToken cancellationToken)
        {
            return new FibabankCancelVm
            {
            };
        }
    }
}