using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudWebApi.Application.Common.Interfaces;

namespace CrudWebApi.Application.CustomerItems.Commands.UpdateCustomerItemDetail;
public record UpdateCustomerItemDetailCommand : IRequest
{
    public int CustomerId { get; init; }
    public string? FirstName { get; init; }

    public string? LastName { get; init; }
    public DateTime DateOfBirth { get; init; }
    public string? PhoneNumber { get; init; }
    public string? Email { get; init; }
    public int? BankAccountNumber { get; init; }
}

public class UpdateCustomerItemDetailCommandHandler : IRequestHandler<UpdateCustomerItemDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCustomerItemDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCustomerItemDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Customers
            .FindAsync(new object[] { request.CustomerId }, cancellationToken);

        Guard.Against.NotFound(request.CustomerId, entity);

        entity.CustomerId = request.CustomerId;
        entity.FirstName = request.FirstName;
        entity.LastName = request.LastName;
        entity.Email = request.Email;
        entity.BankAccountNumber = request.BankAccountNumber;
        entity.PhoneNumber = request.PhoneNumber;

        await _context.SaveChangesAsync(cancellationToken);
    }
}

