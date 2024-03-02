using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudWebApi.Application.Common.Interfaces;
using CrudWebApi.Domain.Events;

namespace CrudWebApi.Application.CustomerItems.Commands.DeleteCustomerItem;
public record DeleteCustomerItemCommand : IRequest
{
    public int CustomerId { get; init; }

    public DeleteCustomerItemCommand(int customerId)
    {
        CustomerId = customerId;
    }


}

public class DeleteCustomerItemCommandHandler : IRequestHandler<DeleteCustomerItemCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteCustomerItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task DeleteCustomerItemComand(DeleteCustomerItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Customers.Where(c => c.CustomerId == request.CustomerId).FirstOrDefaultAsync(cancellationToken);
        //.FindAsync(new object[] { request.CustomerId }, cancellationToken);

        Guard.Against.NotFound(request.CustomerId, entity);

        _context.Customers.Remove(entity);

        entity.AddDomainEvent(new CustomerItemDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Handle(DeleteCustomerItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Customers.Where(c => c.CustomerId == request.CustomerId).FirstOrDefaultAsync(cancellationToken);


        Guard.Against.NotFound(request.CustomerId, entity);

        _context.Customers.Remove(entity);

        entity.AddDomainEvent(new CustomerItemDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}
