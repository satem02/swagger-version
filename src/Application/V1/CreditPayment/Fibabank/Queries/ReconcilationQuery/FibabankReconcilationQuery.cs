using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Application.Common.Interfaces;
using MediatR;

namespace Application.V1.CreditReconcilation.Fibabank.Queries.ReconcilationQuery
{
    public class FibabankReconcilationQuery : IRequest<FibabankReconcilationVm>
    {
        public string Tckn { get; set; }
        public string AccountNo { get; set; }
    }

    public class FibabankReconcilationQueryHandler : IRequestHandler<FibabankReconcilationQuery, FibabankReconcilationVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FibabankReconcilationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FibabankReconcilationVm> Handle(FibabankReconcilationQuery request, CancellationToken cancellationToken)
        {
            return new FibabankReconcilationVm
            {
            };
        }
    }
}