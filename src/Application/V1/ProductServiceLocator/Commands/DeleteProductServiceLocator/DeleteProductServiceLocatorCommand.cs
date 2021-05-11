using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProductServiceLocator.Commands.DeleteProductServiceLocator
{
    public class DeleteProductServiceLocatorCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteProductServiceLocatorCommandHandler : IRequestHandler<DeleteProductServiceLocatorCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProductServiceLocatorCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProductServiceLocatorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductServiceLocatorItems
                .Where(l => l.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductServiceLocator), request.Id);
            }

            _context.ProductServiceLocatorItems.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
