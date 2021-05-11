using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Common.Interfaces;
using Application.Common.Security;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProductServiceLocator.Queries.GetProductServiceLocator
{
    public class GetProductServiceLocatorItemsQuery : IRequest<ProductServiceLocatorItemVm>
    {
    }

    public class GetProductServiceLocatorItemsQueryHandler : IRequestHandler<GetProductServiceLocatorItemsQuery, ProductServiceLocatorItemVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductServiceLocatorItemsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductServiceLocatorItemVm> Handle(GetProductServiceLocatorItemsQuery request, CancellationToken cancellationToken)
        {
            return new ProductServiceLocatorItemVm
            {
                Lists = await _context.ProductServiceLocatorItems
                    .AsNoTracking()
                    .ProjectTo<ProductServiceLocatorItemDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.ProcessType)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
