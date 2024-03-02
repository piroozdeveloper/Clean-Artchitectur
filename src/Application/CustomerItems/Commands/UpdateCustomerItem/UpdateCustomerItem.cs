using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudWebApi.Application.Common.Interfaces;

namespace CrudWebApi.Application.CustomerItems.Commands.UpdateCustomerItem;
public record UpdateCustomerItemCommand : IRequest
{
    public int CustomerId { get; init; }
    public string? FirstName { get; init; }

    public string? LastName { get; init; }
    public DateTime DateOfBirth { get; init; }
    public string? PhoneNumber { get; init; }
    public string? Email { get; init; }
    public int? BankAccountNumber { get; init; }
}

public class CustomerItemCommandHandler : IRequestHandler<UpdateCustomerItemCommand>
{
    private readonly IApplicationDbContext _context;

    public CustomerItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCustomerItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Customers.Where(c => c.CustomerId == request.CustomerId).FirstOrDefaultAsync(cancellationToken);
        // .FindAsync(new object[] { request.CustomerId }, cancellationToken);

        Guard.Against.NotFound(request.CustomerId, entity);

        entity.CustomerId = request.CustomerId;
        entity.FirstName = request.FirstName;
        entity.LastName = request.LastName;
        entity.Email = request.Email;
        entity.PhoneNumber = request.PhoneNumber;
        entity.DateOfBirth = request.DateOfBirth;
        entity.BankAccountNumber = request.BankAccountNumber;


        await _context.SaveChangesAsync(cancellationToken);
    }
}

