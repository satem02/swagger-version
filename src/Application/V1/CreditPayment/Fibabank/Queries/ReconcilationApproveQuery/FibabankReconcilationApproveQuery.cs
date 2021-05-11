using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Application.Common.Interfaces;
using MediatR;

namespace Application.V1.CreditReconcilationApprove.Fibabank.Queries.ReconcilationApproveQuery
{
    public class FibabankReconcilationApproveQuery : IRequest<FibabankReconcilationApproveVm>
    {
        public string Tckn { get; set; }
        public string AccountNo { get; set; }
    }

    public class FibabankReconcilationApproveQueryHandler : IRequestHandler<FibabankReconcilationApproveQuery, FibabankReconcilationApproveVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FibabankReconcilationApproveQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FibabankReconcilationApproveVm> Handle(FibabankReconcilationApproveQuery request, CancellationToken cancellationToken)
        {
            return new FibabankReconcilationApproveVm
            {
            };
        }
    }
}