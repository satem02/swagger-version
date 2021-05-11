using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProductServiceLocator.Commands.CreateProductServiceLocator
{
    public class CreateProductServiceLocatorCommand : IRequest<Guid>
    {
        public Guid? TenantId { get; set; }
    }

    public class CreateProductServiceLocatorCommandHandler : IRequestHandler<CreateProductServiceLocatorCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateProductServiceLocatorCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateProductServiceLocatorCommand request, CancellationToken cancellationToken)
        {
            var entity = new ProductServiceLocatorItem();

            entity.TenantId = request.TenantId;

            _context.ProductServiceLocatorItems.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
