using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProductServiceLocator.Commands.UpdateProductServiceLocator
{
    public class UpdateProductServiceLocatorCommand : IRequest
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
    }

    public class UpdateProductServiceLocatorCommandHandler : IRequestHandler<UpdateProductServiceLocatorCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProductServiceLocatorCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProductServiceLocatorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProductServiceLocatorItems.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProductServiceLocator), request.Id);
            }


            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
